using System;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Converts raw CIFP fixed-width field values into usable .NET values. Navaids, geodesy, runways and
    /// landing systems.
    /// <para>Methods are named for the field number with the decimal removed, so field 5.2 is
    /// <see cref="Field52"/>. Composite fields get one method per column, suffixed with the
    /// column name.</para>
    /// <para>Where a value is not recognized it is returned as-is rather than discarded, so an
    /// unexpected CIFP value surfaces in the output instead of silently becoming null.</para>
    /// </summary>
    internal static partial class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.34 "VOR/NDB Frequency"
        /// </summary>
        /// <remarks>
        /// Five digits giving the NAVAID frequency with the decimal point removed - hundredths of a megahertz
        /// for VHF, tenths of a kilohertz for NDB.
        /// <para>FAA: When a VOR frequency is unavailable the FAA writes '00000' into columns 23-27 (offsets 22-26) rather than leaving the field blank. For every other NAVAID an unavailable frequency is coded as blanks. A converter must therefore treat '00000' on a VHF NAVAID record as 'not published' rather than as 0.00 MHz.</para>
        /// <para>Blank: No frequency is published for this facility. Per the FAA readme this is how an unavailable frequency is coded for every NAVAID except a VOR.</para>
        /// </remarks>
        /// <returns>
        /// A double? of megahertz for VHF records and kilohertz for NDB records - or, better, a typed Frequency
        /// value carrying both the number and its unit. Return null for blanks and for the '00000' VOR
        /// sentinel.
        /// </returns>
        public static double? Field534(ReadOnlySpan<char> fieldValue, char sectionCode, char subsectionCode)
        {
            // The unit depends on the record: VHF navaids carry megahertz scaled by 100,
            // NDB navaids carry kilohertz scaled by 10. Pass the section/subsection so the
            // caller never has to guess which scale applied.
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return null;

            int? raw = CifpSpan.ToInt(value);
            if (raw is null)
                return null;

            // The FAA writes '00000' into a VOR frequency it cannot publish.
            if (raw.Value == 0)
                return null;

            bool isNdb = sectionCode == 'D' ? subsectionCode == 'B' : subsectionCode == 'N';
            return isNdb ? raw.Value / 10.0 : raw.Value / 100.0;
        }

        /// <summary>
        /// CIFP field 5.35 "NAVAID Class" — AdditionalInformation column
        /// </summary>
        /// <remarks>
        /// Five packed single-character codes describing facility type, secondary facility type, usable range
        /// or power, what extra information rides on the signal, and collocation.
        /// </remarks>
        public static string Field535AdditionalInformation(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Automatic transcribed weather broadcast. The FAA uses this single code for both HIWAS and TWEB.",
                'B' => "(B) Scheduled (non-continuous) weather broadcast.",   // not present in the current FAA cycle
                'W' => "(W) No voice on the frequency.",
                'D' => "(D) Biased ILS/DME or ILS/TACAN - the zero-range reading is not at the transmitting antenna. VHF NAVAID records only.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.35 "NAVAID Class" — Collocation column
        /// </summary>
        /// <remarks>
        /// Five packed single-character codes describing facility type, secondary facility type, usable range
        /// or power, what extra information rides on the signal, and collocation.
        /// </remarks>
        public static string Field535Collocation(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'N' => "(N) VHF: the VOR and its paired DME/TACAN are not collocated. The FAA applies this to a VORTAC when the two positions are 0.1 NM or more apart; ARINC states the rule as a latitude or longitude difference of 1/10 arc minute or more. For frequency-paired ILS/DME and ILS/TACAN the character rides on the ILS/DME or ILS/TACAN record.",
                'B' => "(B) NDB and marker/locator records: a beat frequency oscillator is required to hear the morse identifier. Not a collocation indication, but it shares the column; if both a collocation condition and a BFO condition exist, the collocation character wins.",   // not present in the current FAA cycle
                'A' => "(A) Marker/locator records (PM) only: marker and its associated locator differ by less than 1/10 arc minute. Not applicable to the FAA CIFP, which contains no PM records.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.35 "NAVAID Class" — NavaidType1 column
        /// </summary>
        /// <remarks>
        /// Five packed single-character codes describing facility type, secondary facility type, usable range
        /// or power, what extra information rides on the signal, and collocation.
        /// </remarks>
        public static string Field535NavaidType1(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'V' => "(V) VOR component present (VHF NAVAID records).",
                'H' => "(H) NDB (NDB and Terminal NDB records).",
                'S' => "(S) SABH - commercial broadcast station usable for navigation (NDB records).",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.35 "NAVAID Class" — NavaidType2 column
        /// </summary>
        /// <remarks>
        /// Five packed single-character codes describing facility type, secondary facility type, usable range
        /// or power, what extra information rides on the signal, and collocation.
        /// </remarks>
        public static string Field535NavaidType2(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'D' => "(D) DME (VHF NAVAID).",
                'T' => "(T) TACAN, channels 17-59 and 70-126 (VHF NAVAID).",
                'M' => "(M) Military TACAN, channels 1-16 and 60-69 (VHF NAVAID).",
                'I' => "(I) ILS/DME or ILS/TACAN (VHF NAVAID).",
                'N' => "(N) MLS/DME/N (VHF NAVAID).",   // not present in the current FAA cycle
                'P' => "(P) MLS/DME/P (VHF NAVAID).",   // not present in the current FAA cycle
                'O' => "(O) Outer marker (NDB/marker records).",
                'C' => "(C) Back marker (NDB/marker records).",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.35 "NAVAID Class" — RangePower column
        /// </summary>
        /// <remarks>
        /// Five packed single-character codes describing facility type, secondary facility type, usable range
        /// or power, what extra information rides on the signal, and collocation.
        /// </remarks>
        public static string Field535RangePower(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'T' => "(T) VHF: terminal service volume (roughly 25 NM below 12,000 ft per 424-19A).",
                'L' => "(L) VHF: low altitude service volume (roughly 40 NM up to 18,000 ft per 424-19A).",
                'H' => "(H) VHF: high altitude service volume (roughly 130 NM up to 60,000 ft per 424-19A). For NDB records, 200 watts or more.",
                'U' => "(U) VHF: undefined - the source does not define or restrict use by range or altitude. The FAA codes this when the altitude structure is undetermined and then sets Figure of Merit (5.149) to '3'.",
                'C' => "(C) VHF: a TACAN frequency-paired with an ILS localizer of the same identifier at the same site; range is understood to be terminal. Only valid together with 'I' in the NAVAID Type 2 column.",   // not present in the current FAA cycle
                'M' => "(M) NDB: 25 to less than 50 watts.",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.36 "Latitude"
        /// </summary>
        /// <remarks>
        /// Signed latitude packed as a hemisphere letter followed by eight digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// <para>Blank: No position is coded for this component of the record - for example the VOR latitude on a DME-only NAVAID, the glide slope latitude when no glide slope exists, or the arc origin latitude on an airspace boundary leg that is not an arc.</para>
        /// </remarks>
        /// <returns>
        /// A double? of signed decimal degrees in the range -90.0 to +90.0, or null when the nine characters
        /// are all blank. Prefer returning latitude and longitude together as one coordinate value.
        /// </returns>
        public static double? Field536(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char hemisphere = fieldValue[0];
            if (hemisphere != 'N' && hemisphere != 'S')
                return null;

            int? degrees = CifpSpan.ToInt(fieldValue.Slice(1, 2));
            int? minutes = CifpSpan.ToInt(fieldValue.Slice(3, 2));
            int? seconds = CifpSpan.ToInt(fieldValue.Slice(5, 4));
            if (degrees is null || minutes is null || seconds is null)
                return null;

            // The last 2 digits of the seconds group are fractional.
            double wholeSeconds = seconds.Value / 100.0;
            double value = degrees.Value + (minutes.Value / 60.0) + (wholeSeconds / 3600.0);
            return hemisphere == 'S' ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.37 "Longitude"
        /// </summary>
        /// <remarks>
        /// Signed longitude packed as a hemisphere letter followed by nine digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// <para>Blank: No position is coded for this component of the record. Always blank in lockstep with the paired latitude (5.36).</para>
        /// </remarks>
        /// <returns>
        /// A double? of signed decimal degrees in the range -180.0 to +180.0, or null when the ten characters
        /// are all blank. Prefer returning it with the paired latitude as one coordinate value.
        /// </returns>
        public static double? Field537(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char hemisphere = fieldValue[0];
            if (hemisphere != 'E' && hemisphere != 'W')
                return null;

            int? degrees = CifpSpan.ToInt(fieldValue.Slice(1, 3));
            int? minutes = CifpSpan.ToInt(fieldValue.Slice(4, 2));
            int? seconds = CifpSpan.ToInt(fieldValue.Slice(6, 4));
            if (degrees is null || minutes is null || seconds is null)
                return null;

            // The last 2 digits of the seconds group are fractional.
            double wholeSeconds = seconds.Value / 100.0;
            double value = degrees.Value + (minutes.Value / 60.0) + (wholeSeconds / 3600.0);
            return hemisphere == 'W' ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.39 "Magnetic Variation"
        /// </summary>
        /// <remarks>
        /// Angular difference between true and magnetic north at the record's location, given as a direction
        /// letter plus four digits of degrees and tenths.
        /// <para>FAA: The FAA computes variation from the World Magnetic Model, 2020 epoch. Where no government-assigned variation exists, the CIFP dynamic magnetic variation is calculated at the magnetic epoch of a specified cycle so that it stays aligned with the NASR AWY.txt and ATS.txt files; for 2025 that reference was cycle 2504. Waypoint records and DME-only facilities use the cycle 2504 epoch. DME-only faciliti</para>
        /// <para>Blank: No magnetic variation coded. Does not occur in the FAA CIFP for the record types that carry this field.</para>
        /// </remarks>
        /// <returns>
        /// A double? of degrees carrying the chosen sign convention, plus a bool IsTrueOriented set when the
        /// leading character is 'T'. Return null only for an all-blank slice.
        /// </returns>
        public static double? Field539(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char reference = fieldValue[0];

            // 'T' means the record is oriented to True North; the digits are always zero.
            if (reference == 'T')
                return 0.0;

            int? raw = CifpSpan.ToInt(fieldValue[1..]);
            if (raw is null)
                return null;

            // East variation is conventionally positive, west negative.
            double degrees = raw.Value / 10.0;
            return reference == 'W' ? -degrees : degrees;
        }

        /// <summary>
        /// CIFP field 5.40 "DME Elevation"
        /// </summary>
        /// <remarks>
        /// Elevation of the DME antenna in feet relative to mean sea level, with a leading minus sign when
        /// below sea level.
        /// <para>FAA: The FAA readme warns that the NASR NAV.txt subscriber file does not carry a DME elevation when it differs from the associated VOR or TACAN facility. In those cases the FAA populates this field with the VOR elevation instead. The value is therefore not guaranteed to be the DME antenna's own elevation - treat it as 'elevation of the facility', not as a survey-grade DME antenna height.</para>
        /// <para>Blank: No DME elevation published, or the record has no DME component.</para>
        /// </remarks>
        /// <returns>
        /// An int? of feet MSL, negative when below sea level, or null when the slice is blank.
        /// </returns>
        public static int? Field540(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.41 "Region Code"
        /// </summary>
        /// <remarks>
        /// Four columns that either hold the literal 'ENRT', marking the waypoint as enroute, or hold the
        /// identifier of the airport that owns the terminal waypoint.
        /// <para>FAA: The FAA readme does not name 5.41 directly, but its PC/EA selection rule determines what lands here: a named terminal waypoint gets a PC record (and therefore an airport identifier in this field) only when it is used at exactly one airport and is not on an enroute airway; otherwise it becomes an EA record with 'ENRT'.</para>
        /// <para>Blank: Never blank in the FAA CIFP.</para>
        /// </remarks>
        /// <returns>
        /// A trimmed string plus a bool IsEnroute (true when the trimmed value equals 'ENRT'). When IsEnroute
        /// is false the string is the owning airport or heliport identifier and can be used directly as a
        /// foreign key to the PA/HA record.
        /// </returns>
        public static string Field541(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return string.Empty;

            // 'ENRT' marks an enroute waypoint that belongs to no airport. Anything else is
            // the owning airport or heliport identifier and is usable as a foreign key.
            return value.SequenceEqual("ENRT") ? "ENRT (Enroute)" : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.42 "Waypoint Type" — ProcedurePublication column
        /// </summary>
        /// <remarks>
        /// Three packed single-character codes classifying a waypoint - how it is formed, what role it plays in
        /// terminal procedures, and which procedure types publish it.
        /// </remarks>
        public static string Field542ProcedurePublication(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'D' => "(D) Published for use in a SID.",   // not present in the current FAA cycle
                'E' => "(E) Published for use in a STAR.",   // not present in the current FAA cycle
                'F' => "(F) Published for use in an approach procedure.",   // not present in the current FAA cycle
                'Z' => "(Z) Published for use in multiple terminal procedure types.",   // not present in the current FAA cycle
                'G' => "(G) Source-provided enroute waypoint. Added by 424-19A.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.42 "Waypoint Type" — WaypointFormation column
        /// </summary>
        /// <remarks>
        /// Three packed single-character codes classifying a waypoint - how it is formed, what role it plays in
        /// terminal procedures, and which procedure types publish it.
        /// </remarks>
        public static string Field542WaypointFormation(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'R' => "(R) FAA meaning - fix defined by ground-based components, including any fix definable only by radar. ARINC meaning - named intersection.",
                'W' => "(W) FAA meaning - fix defined by satellite-based components. ARINC meaning - RNAV waypoint.",
                'C' => "(C) FAA meaning - fix defined by both ground-based and satellite-based components. ARINC meaning - combined named intersection and RNAV waypoint.",
                'V' => "(V) VFR waypoint. Columns 2 and 3 are unused when this is set.",
                'I' => "(I) Unnamed, charted intersection.",
                'A' => "(A) Arc centre fix waypoint. Columns 2 and 3 are always blank when this is set. Terminal waypoints only.",
                'N' => "(N) NDB or terminal NDB reproduced as a waypoint. Columns 2 and 3 are always blank when this is set.",   // not present in the current FAA cycle
                'M' => "(M) Middle marker used as a waypoint (424-19A widens this to middle or inner marker). Terminal waypoints only.",   // not present in the current FAA cycle
                'O' => "(O) Outer marker used as a waypoint (424-19A widens this to outer or back marker). Terminal waypoints only.",   // not present in the current FAA cycle
                'U' => "(U) Uncharted airway intersection. Enroute waypoints only.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.42 "Waypoint Type" — WaypointFunction column
        /// </summary>
        /// <remarks>
        /// Three packed single-character codes classifying a waypoint - how it is formed, what role it plays in
        /// terminal procedures, and which procedure types publish it.
        /// </remarks>
        public static string Field542WaypointFunction(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Final approach fix.",   // not present in the current FAA cycle
                'B' => "(B) Initial approach fix and final approach fix.",   // not present in the current FAA cycle
                'C' => "(C) Final approach course fix.",   // not present in the current FAA cycle
                'D' => "(D) Intermediate approach fix.",   // not present in the current FAA cycle
                'E' => "(E) Off-route intersection in the FAA National Reference System. Enroute waypoints only.",   // not present in the current FAA cycle
                'F' => "(F) Off-route intersection. Enroute waypoints only.",   // not present in the current FAA cycle
                'I' => "(I) Initial approach fix.",   // not present in the current FAA cycle
                'K' => "(K) Final approach course fix that is also an initial approach fix.",   // not present in the current FAA cycle
                'L' => "(L) Final approach course fix that is also an intermediate approach fix.",   // not present in the current FAA cycle
                'M' => "(M) Missed approach fix.",   // not present in the current FAA cycle
                'N' => "(N) Initial approach fix and missed approach fix.",   // not present in the current FAA cycle
                'O' => "(O) Oceanic entry/exit waypoint (424-19A calls it an oceanic gateway fix). Enroute waypoints only.",   // not present in the current FAA cycle
                'P' => "(P) Enroute - pitch and catch point in the FAA High Altitude Redesign. Terminal - unnamed step-down fix.",   // not present in the current FAA cycle
                'R' => "(R) RF leg fix not at a procedure fix location. Added by 424-19A; used only with column 1 set to C, R or W.",   // not present in the current FAA cycle
                'S' => "(S) Enroute - AACAA and SUA waypoints in the FAA High Altitude Redesign. Terminal - named step-down fix.",   // not present in the current FAA cycle
                'U' => "(U) FIR/UIR or controlled airspace intersection.",   // not present in the current FAA cycle
                'V' => "(V) Latitude/longitude intersection on a full degree of latitude (424-18). Enroute waypoints only.",
                'W' => "(W) Latitude/longitude intersection on a half degree of latitude (424-18). Enroute waypoints only.",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.45 "Localizer Frequency"
        /// </summary>
        /// <remarks>
        /// Localizer VHF frequency as five digits with the decimal point removed - megahertz times one hundred.
        /// <para>Blank: No localizer frequency published. Does not occur in the FAA CIFP.</para>
        /// </remarks>
        /// <returns>
        /// A double? of megahertz (raw / 100.0), or null when blank.
        /// </returns>
        public static double? Field545(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 100.0;
        }

        /// <summary>
        /// CIFP field 5.46 "Runway Identifier"
        /// </summary>
        /// <remarks>
        /// Five columns naming a runway, normally 'RW' plus a two-digit magnetic-heading designator plus an
        /// optional suffix letter, but in the FAA CIFP also a bare non-numeric designator such as N, SE or ALL.
        /// <para>FAA: Two FAA deviations, both stated in the CIFP readme, and both of which break a naive regular expression of ^RW\d{2}[CLRT ]?$: 1. Extra suffixes. The FAA includes runway-surface and use suffixes that ARINC does not define: W water runway S soft-surface runway G glider runway U ultralight runway a digit assault strip So 'RW17W', 'RW13S', 'RW09G', 'RW26U' and 'RW05' followed by a digit are all legitim</para>
        /// <para>Blank: No runway is identified. Does not occur on Runway, Localizer or Path Point records in the FAA CIFP.</para>
        /// </remarks>
        /// <returns>
        /// The trimmed raw identifier as the join key, plus decoded parts - int? DesignatorNumber (null for the
        /// bare non-numeric forms), char? Suffix, and an enum or bool distinguishing the 'RW' form from the
        /// bare water/seaplane form.
        /// </returns>
        public static string Field546(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return string.Empty;

            // The FAA includes bare non-numeric designators (N, SE, ALL, WAY and similar)
            // WITHOUT the 'RW' prefix, so the prefix cannot be assumed present.
            return value.ToString();
        }

        /// <summary>
        /// CIFP field 5.47 "Localizer Bearing"
        /// </summary>
        /// <remarks>
        /// Magnetic bearing of the localizer front course (or GLS approach course) in tenths of a degree with
        /// the decimal point removed.
        /// <para>Blank: No localizer course published. Does not occur in the FAA CIFP.</para>
        /// </remarks>
        /// <returns>
        /// A double? of degrees (raw / 10.0) plus a bool IsTrueCourse. Null only for a blank slice.
        /// </returns>
        public static double? Field547(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            if (fieldValue[3] == 'T')
                return CifpSpan.ToInt(fieldValue[..3]);

            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.48 "Localizer Position"
        /// </summary>
        /// <remarks>
        /// Distance in feet from the localizer (or MLS azimuth) antenna to the runway end, at one-foot
        /// resolution.
        /// <para>Blank: No antenna offset published.</para>
        /// </remarks>
        /// <returns>
        /// An int? of feet, returned together with the decoded 5.49 reference so that callers never see a bare
        /// magnitude. Null when blank.
        /// </returns>
        public static int? Field548(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.50 "Glide Slope Position / Elevation Position"
        /// </summary>
        /// <remarks>
        /// Distance in feet from the runway threshold to the glide slope antenna, measured along the runway.
        /// <para>Blank: No glide slope component exists for this localizer (localizer-only / LDA-without-glideslope installations).</para>
        /// </remarks>
        /// <returns>
        /// Distance in feet as int?, or null when the slice is blank.
        /// </returns>
        public static int? Field550(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.51 "Localizer Width"
        /// </summary>
        /// <remarks>
        /// Full course width of the localizer, in degrees, with the decimal point removed.
        /// <para>Blank: Never blank in the CIFP; every localizer record carries a course width.</para>
        /// </remarks>
        /// <returns>
        /// Course width in degrees as decimal? (raw integer / 100).
        /// </returns>
        public static decimal? Field551(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 100m;
        }

        /// <summary>
        /// CIFP field 5.52 "Glide Slope Angle / Minimum Elevation Angle"
        /// </summary>
        /// <remarks>
        /// Glide slope angle in degrees with the decimal point removed (three digits, hundredths resolution).
        /// <para>Blank: No glide slope is installed for this localizer, so no angle is defined.</para>
        /// </remarks>
        /// <returns>
        /// Glide slope angle in degrees as decimal? (raw integer / 100), or null when blank.
        /// </returns>
        public static decimal? Field552(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 100m;
        }

        /// <summary>
        /// CIFP field 5.53 "Transition Altitude / Transition Level"
        /// </summary>
        /// <remarks>
        /// Altitude in feet at which altimeter setting changes between local (QNH) and standard (QNE), carried
        /// on airport, heliport and procedure records.
        /// <para>FAA: The FAA codes a constant 18000 everywhere it codes this field at all - that is the United States transition altitude. Measured: PA 13,263 of 13,321 records = "18000", 58 blank; HA 6,104 of 6,134 = "18000", 30 blank; PD 10,373 of 34,605 populated, all "18000"; PE 9,644 of 44,148, all "18000"; PF primary 32,375 of 122,323, all "18000".</para>
        /// <para>Blank: The altitude is not published, is unknown to ATC, or varies between procedures at that airport/heliport. On procedure records it also means simply that this leg is not the first leg of the transition.</para>
        /// </remarks>
        /// <returns>
        /// Altitude in feet as int?, or null when blank. Two separate model properties on PA/HA
        /// (TransitionAltitude and TransitionLevel).
        /// </returns>
        public static int? Field553(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.54 "Longest Runway"
        /// </summary>
        /// <remarks>
        /// Length of the airport's longest runway, expressed in hundreds of feet.
        /// <para>FAA: The FAA readme states plainly that this field may not always represent the longest HARD-SURFACE runway at the airport, which directly contradicts the ARINC definition. The real file bears this out: the three longest values in the whole dataset - 260 (LIBBY CAMPS), 250 (LONG LAKE) and 211 (CONCHAS LAKE) - are all water landing areas, not pavement. Never present this value to a user as a hard-surfac</para>
        /// <para>Blank: Never blank in the CIFP; every Airport record carries a value.</para>
        /// </remarks>
        /// <returns>
        /// Length in FEET as int? (raw three-digit value multiplied by 100).
        /// </returns>
        public static int? Field554(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value * 100;
        }

        /// <summary>
        /// CIFP field 5.55 "Airport/Heliport Elevation"
        /// </summary>
        /// <remarks>
        /// Elevation of the airport or heliport in feet relative to mean sea level, signed.
        /// <para>Blank: Never blank in the CIFP.</para>
        /// </remarks>
        /// <returns>
        /// Signed elevation in feet as int?.
        /// </returns>
        public static int? Field555(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.57 "Runway Length"
        /// </summary>
        /// <remarks>
        /// Overall physical length of the runway surface in feet.
        /// <para>Blank: Never blank in the CIFP.</para>
        /// </remarks>
        /// <returns>
        /// Runway length in feet as int?.
        /// </returns>
        public static int? Field557(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.58 "Runway Magnetic Bearing"
        /// </summary>
        /// <remarks>
        /// Bearing of the runway centreline in degrees and tenths, decimal point suppressed, with an optional
        /// trailing T marking a true rather than magnetic bearing.
        /// <para>FAA: When the source data has no magnetic variation available to convert a true bearing to a magnetic one, the FAA computes the variation with the World Magnetic Model (WMM) calculator and publishes a magnetic bearing anyway. That is why the "T" form never appears in the CIFP: the FAA always resolves to magnetic rather than falling back to the true-bearing encoding.</para>
        /// <para>Blank: No bearing is defined for this runway - in the CIFP this happens only on non-numeric runway designators such as NW, SE, ALL and WAY.</para>
        /// </remarks>
        /// <returns>
        /// Bearing in degrees as decimal? (raw digits / 10), plus a bool IsTrueBearing set when column 4 is
        /// 'T'. Null bearing when the slice is blank.
        /// </returns>
        public static decimal? Field558(ReadOnlySpan<char> fieldValue)
        {
            // Four PG records in the current FAA cycle carry a BLANK bearing (the non-numeric
            // runway identifiers at 13FD and 16WI), so this must stay nullable.
            if (fieldValue.IsWhiteSpace())
                return null;

            if (fieldValue[3] == 'T')
                return CifpSpan.ToInt(fieldValue[..3]);

            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10m;
        }

        /// <summary>
        /// CIFP field 5.66 "Station Declination" — DeclinationDirection column
        /// </summary>
        /// <remarks>
        /// Angular offset between true north and the reference the facility is aligned to, given as a direction
        /// letter followed by degrees and tenths.
        /// </remarks>
        public static string Field566DeclinationDirection(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'E' => "(E) Declination is east of true north (positive)",
                'W' => "(W) Declination is west of true north (negative)",
                'T' => "(T) Station is aligned to true north even though local variation is non-zero; magnitude columns are zero",   // not present in the current FAA cycle
                'G' => "(G) Station is aligned to grid north; the true declination cannot be expressed, magnitude columns are zero",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.66 "Station Declination" — DeclinationMagnitude column
        /// </summary>
        /// <remarks>
        /// Angular offset between true north and the reference the facility is aligned to, given as a direction
        /// letter followed by degrees and tenths.
        /// </remarks>
        public static string Field566DeclinationMagnitude(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.67 "Threshold Crossing Height"
        /// </summary>
        /// <remarks>
        /// Height in feet above the landing threshold at which a nominal glide path crosses it.
        /// <para>Blank: No glide path exists for this facility (localizer-only or LDA-without-glideslope installations on the PI record).</para>
        /// </remarks>
        /// <returns>
        /// Threshold crossing height in feet as int?, or null when blank. Field width must be supplied by the
        /// caller (2 on PG/PI, 3 on approach continuations).
        /// </returns>
        public static int? Field567(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.68 "Landing Threshold Elevation"
        /// </summary>
        /// <remarks>
        /// Elevation in feet MSL of the landing threshold of the runway described by the record.
        /// <para>Blank: Never blank in the CIFP.</para>
        /// </remarks>
        /// <returns>
        /// Signed threshold elevation in feet as int?.
        /// </returns>
        public static int? Field568(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.69 "Threshold Displacement Distance"
        /// </summary>
        /// <remarks>
        /// Distance in feet from the physical end of the runway to a threshold that is not located at that end.
        /// <para>Blank: Never blank in the CIFP; an undisplaced threshold is coded 0000, not blank.</para>
        /// </remarks>
        /// <returns>
        /// Displacement in feet as int?; 0 means the threshold is not displaced.
        /// </returns>
        public static int? Field569(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.70 "Vertical Angle"
        /// </summary>
        /// <remarks>
        /// Descent angle in degrees for the vertical path flown from the coded fix, with the decimal point
        /// suppressed and a leading minus marking descent.
        /// <para>FAA: The FAA codes "000" - which appears in the slice as a blank sign column followed by three zeros, i.e. " 000" - for circling procedures and for dive-and-drive procedures. It also codes "000" for straight-in aligned procedures when Flight Inspection has identified obstacles in the visual areas. So a zero here does NOT mean a level path; it is a positive statement that no continuous descent angle is </para>
        /// <para>Blank: No vertical path is defined for this leg.</para>
        /// </remarks>
        /// <returns>
        /// Descent angle in degrees as a NEGATIVE decimal? (raw digits / 100, negated when column 1 is '-'),
        /// null when blank. Expose the FAA ' 000' case distinctly - suggest a companion bool such as
        /// NoPublishedDescentAngle - so callers do not mistake it for a 0.00 degree glide path.
        /// </returns>
        public static double? Field570(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            bool isNegative = fieldValue[0] == '-';
            int? digits = CifpSpan.ToInt(fieldValue[1..]);
            if (digits is null)
                return null;

            double value = digits.Value / 100.0;
            return isNegative ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.72 "Speed Limit"
        /// </summary>
        /// <remarks>
        /// Speed restriction in knots indicated airspeed, applied either at a procedure fix or across an
        /// airport's terminal area.
        /// <para>FAA: The FAA leaves the airport and heliport terminal-area speed limit blank throughout, which is consistent with it also leaving Speed Limit Altitude (5.73) blank. Only procedure legs carry speed limits.</para>
        /// <para>Blank: No speed restriction applies at this fix, or none is published for this airport/heliport terminal area.</para>
        /// </remarks>
        /// <returns>
        /// Speed limit in knots IAS as int?, or null when blank. Always pair it with Speed Limit Description
        /// (5.261) before presenting it as a restriction.
        /// </returns>
        public static int? Field572(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.73 "Speed Limit Altitude"
        /// </summary>
        /// <remarks>
        /// Altitude at and below which the terminal-area speed limit in 5.72 applies.
        /// <para>Blank: No terminal-area speed limit altitude is published. In the CIFP this is always the case.</para>
        /// </remarks>
        /// <returns>
        /// Altitude in feet as int?, converting an 'F'-prefixed flight level by multiplying the level by 100.
        /// Null in every CIFP record.
        /// </returns>
        public static int? Field573(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return null;

            // An 'F' prefix marks a flight level; normalise it to feet.
            if (value[0] == 'F')
            {
                int? level = CifpSpan.ToInt(value[1..]);
                return level is null ? null : level.Value * 100;
            }

            return CifpSpan.ToInt(value);
        }

        /// <summary>
        /// CIFP field 5.74 "Component Elevation"
        /// </summary>
        /// <remarks>
        /// Elevation in feet MSL of a specific navigation component: the glide slope, MLS elevation, azimuth or
        /// back azimuth antenna, or the GLS ground station.
        /// <para>Blank: The component does not exist for this facility - on the CIFP's PI records, no glide slope is installed.</para>
        /// </remarks>
        /// <returns>
        /// Signed component elevation in feet as int?, or null when blank.
        /// </returns>
        public static int? Field574(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

    }
}