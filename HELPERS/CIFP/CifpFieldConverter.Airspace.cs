using System;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Converts raw CIFP fixed-width field values into usable .NET values. Airspace, MSA, procedure detail
    /// and time of operation.
    /// <para>Methods are named for the field number with the decimal removed, so field 5.2 is
    /// <see cref="Field52"/>. Composite fields get one method per column, suffixed with the
    /// column name.</para>
    /// <para>Where a value is not recognized it is returned as-is rather than discarded, so an
    /// unexpected CIFP value surfaces in the output instead of silently becoming null.</para>
    /// </summary>
    internal static partial class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.164 "EU Indicator"
        /// </summary>
        /// <remarks>
        /// Flags an enroute airway segment that has an associated Airway Restriction record, without saying
        /// what the restriction is.
        /// <para>FAA: The FAA CIFP does not include Airway Restriction (EU) records at all, and this indicator is blank on every airway record. Treat it as permanently false for this dataset.</para>
        /// <para>Blank: No airway restriction record exists for this segment.</para>
        /// </remarks>
        /// <returns>
        /// true when 'Y', otherwise false.
        /// </returns>
        public static string Field5164(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'Y' => "(Y) An airway restriction record exists for this segment",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.165 "Magnetic/True Indicator"
        /// </summary>
        /// <remarks>
        /// States whether the courses and bearings in a record are referenced to Magnetic North or True North.
        /// <para>Blank: On Airport and Heliport records, a deliberate signal that the facility carries a MIX of magnetic and true data, so each detail record must be read individually. It is not 'unknown'.</para>
        /// </remarks>
        /// <returns>
        /// "(M) Magnetic" or "(T) True"; empty string when blank.
        /// </returns>
        public static string Field5165(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'M' => "(M) Courses and bearings are magnetic",
                'T' => "(T) Courses and bearings are true",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.176 "Pad Dimensions" — PadDimensionA column
        /// </summary>
        /// <remarks>
        /// The size of a helicopter landing pad in feet, packed as two three-digit numbers.
        /// </remarks>
        public static string Field5176PadDimensionA(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.176 "Pad Dimensions" — PadDimensionB column
        /// </summary>
        /// <remarks>
        /// The size of a helicopter landing pad in feet, packed as two three-digit numbers.
        /// </remarks>
        public static string Field5176PadDimensionB(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.177 "Public/Military Indicator"
        /// </summary>
        /// <remarks>
        /// Classifies a landing facility as civil/public, military, or private/not open to the public.
        /// <para>FAA: Not discussed in the readme. Distribution in the shipped file: airports 8,143 private, 4,983 civil, 195 military; heliports 5,857 private, 216 military, 61 civil. Private facilities dominate the CIFP because of the very large number of private helipads.</para>
        /// <para>Blank: Use category not stated. Does not occur in the FAA file - all airport and heliport records are populated.</para>
        /// </remarks>
        /// <returns>
        /// A PublicMilitaryIndicator enum (Civil / Military / Private / JointUse), or null when blank.
        /// </returns>
        public static string Field5177(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'C' => "(C) Civil - open to the general public. Joint civil/military fields are coded here in 424-18.",
                'M' => "(M) Military airport or heliport.",
                'P' => "(P) Private - not open to the public.",
                'J' => "(J) Joint civil and military use. Added in 424-19A only; not valid under 424-18 and never emitted by the FAA.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.178 "Time Zone" — TimeZoneLetter column
        /// </summary>
        /// <remarks>
        /// The airport's or heliport's standard-time offset from UTC, as a zone letter plus an extra minutes
        /// correction.
        /// </remarks>
        public static string Field5178TimeZoneLetter(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'Z' => "(Z) UTC+00:00 (Greenwich).",   // not present in the current FAA cycle
                'A' => "(A) UTC-01:00.",   // not present in the current FAA cycle
                'B' => "(B) UTC-02:00.",   // not present in the current FAA cycle
                'C' => "(C) UTC-03:00.",   // not present in the current FAA cycle
                'D' => "(D) UTC-04:00.",   // not present in the current FAA cycle
                'E' => "(E) UTC-05:00.",   // not present in the current FAA cycle
                'F' => "(F) UTC-06:00.",   // not present in the current FAA cycle
                'G' => "(G) UTC-07:00.",   // not present in the current FAA cycle
                'H' => "(H) UTC-08:00.",   // not present in the current FAA cycle
                'I' => "(I) UTC-09:00.",   // not present in the current FAA cycle
                'K' => "(K) UTC-10:00.",   // not present in the current FAA cycle
                'L' => "(L) UTC-11:00.",   // not present in the current FAA cycle
                'M' => "(M) UTC-12:00.",   // not present in the current FAA cycle
                'N' => "(N) UTC+01:00.",   // not present in the current FAA cycle
                'O' => "(O) UTC+02:00.",   // not present in the current FAA cycle
                'P' => "(P) UTC+03:00.",   // not present in the current FAA cycle
                'Q' => "(Q) UTC+04:00.",   // not present in the current FAA cycle
                'R' => "(R) UTC+05:00.",   // not present in the current FAA cycle
                'S' => "(S) UTC+06:00.",   // not present in the current FAA cycle
                'T' => "(T) UTC+07:00.",   // not present in the current FAA cycle
                'U' => "(U) UTC+08:00.",   // not present in the current FAA cycle
                'V' => "(V) UTC+09:00.",   // not present in the current FAA cycle
                'W' => "(W) UTC+10:00.",   // not present in the current FAA cycle
                'X' => "(X) UTC+11:00.",   // not present in the current FAA cycle
                'Y' => "(Y) UTC+12:00.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.178 "Time Zone" — TimeZoneMinutes column
        /// </summary>
        /// <remarks>
        /// The airport's or heliport's standard-time offset from UTC, as a zone letter plus an extra minutes
        /// correction.
        /// </remarks>
        public static string Field5178TimeZoneMinutes(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.179 "Daylight Time Indicator"
        /// </summary>
        /// <remarks>
        /// Says whether the facility observes daylight saving / summer time.
        /// <para>FAA: Not mentioned in the readme, and never populated: all 13,321 airport and all 6,134 heliport records carry a space. Since Time Zone is blank too, the CIFP gives no local-time information at all for U.S. facilities.</para>
        /// <para>Blank: Not stated. This is the value in every FAA record.</para>
        /// </remarks>
        /// <returns>
        /// true for 'Y', false for 'N', null for blank. Note that false and null are not the same claim - 'N'
        /// also covers 'unknown'.
        /// </returns>
        public static string Field5179(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'Y' => "(Y) The facility observes daylight or summer time.",   // not present in the current FAA cycle
                'N' => "(N) The facility does not observe daylight time, or it is unknown.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.195 "Time of Operation" — DayRange column
        /// </summary>
        /// <remarks>
        /// One daily operating window inside a calendar week - which days, what start time and what end time -
        /// for a facility or an airspace restriction.
        /// </remarks>
        public static string Field5195DayRange(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.195 "Time of Operation" — EndTime column
        /// </summary>
        /// <remarks>
        /// One daily operating window inside a calendar week - which days, what start time and what end time -
        /// for a facility or an airspace restriction.
        /// </remarks>
        public static string Field5195EndTime(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.195 "Time of Operation" — StartTime column
        /// </summary>
        /// <remarks>
        /// One daily operating window inside a calendar week - which days, what start time and what end time -
        /// for a facility or an airspace restriction.
        /// </remarks>
        public static string Field5195StartTime(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.196 "Name Format Indicator" — NameFormat1 column
        /// </summary>
        /// <remarks>
        /// Describes how the Waypoint Name/Description field was constructed - whether the name is a published
        /// five-letter fix, a navaid identifier, a lat/long, an abeam point and so on.
        /// </remarks>
        public static string Field5196NameFormat1(char fieldValue)
        {
            return fieldValue == ' ' ? string.Empty : fieldValue.ToString();
        }

        /// <summary>
        /// CIFP field 5.196 "Name Format Indicator" — NameFormat2 column
        /// </summary>
        /// <remarks>
        /// Describes how the Waypoint Name/Description field was constructed - whether the name is a published
        /// five-letter fix, a navaid identifier, a lat/long, an abeam point and so on.
        /// </remarks>
        public static string Field5196NameFormat2(char fieldValue)
        {
            return fieldValue == ' ' ? string.Empty : fieldValue.ToString();
        }

        /// <summary>
        /// CIFP field 5.196 "Name Format Indicator" — NameFormat3 column
        /// </summary>
        /// <remarks>
        /// Describes how the Waypoint Name/Description field was constructed - whether the name is a published
        /// five-letter fix, a navaid identifier, a lat/long, an abeam point and so on.
        /// </remarks>
        public static string Field5196NameFormat3(char fieldValue)
        {
            return fieldValue == ' ' ? string.Empty : fieldValue.ToString();
        }

        /// <summary>
        /// CIFP field 5.204 "ARC Radius"
        /// </summary>
        /// <remarks>
        /// The turn radius of a constant-radius arc leg or an RNP holding pattern, in thousandths of a nautical
        /// mile.
        /// <para>FAA: Not mentioned in the readme. In the shipped file 1,439 records carry a radius, 278 distinct values, ranging from 001060 (1.060 NM) to 024700 (24.700 NM). The count matches the number of RF legs exactly, so the FAA does not currently code RNP holding radii.</para>
        /// <para>Blank: The leg is not a constant-radius turn. 199,675 of 201,114 procedure leg primaries are blank - only RF legs and RNP holding legs use it.</para>
        /// </remarks>
        /// <returns>
        /// Radius in decimal nautical miles (raw integer divided by 1000.0), or null when blank.
        /// </returns>
        public static double? Field5204(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 1000.0;
        }

        /// <summary>
        /// CIFP field 5.211 "Required Navigation Performance"
        /// </summary>
        /// <remarks>
        /// The navigation accuracy required on this segment, encoded as two significant digits plus a negative
        /// decimal exponent.
        /// <para>FAA: The readme devotes a whole section to this field. The FAA populates RNP from the NAVSPEC values in FAA Order 8260.58C Table 1-2-1, using five rules: 1. On day-forward procedures, HF and HM (holding) legs are NOT coded with RNP values at all. 2. On amendments and abbreviated amendments, values match FAA Form 8260-3 Terminal Routes. 3. For P-NOTAMs requiring coding changes, values match Form 8260-3 </para>
        /// <para>Blank: No source-published RNP value exists for this segment. It does NOT mean RNP zero and it does not mean the segment has no navigation requirement - it means the database carries no specified value. 153,709 of 201,114 procedure leg primaries are blank.</para>
        /// </remarks>
        /// <returns>
        /// RNP in decimal nautical miles: int(chars 0-1) * Math.Pow(10, -int(char 2)). Null when blank.
        /// </returns>
        public static double? Field5211(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.Length != 3)
                return null;

            int? significand = CifpSpan.ToInt(value[..2]);
            int? exponent    = CifpSpan.ToInt(value.Slice(2, 1));
            if (significand is null || exponent is null)
                return null;

            // Two significant digits followed by a negative power of ten:
            // "031" is 3 x 10^-1 = RNP 0.30, "112" is 11 x 10^-2 = RNP 0.11.
            return significand.Value * Math.Pow(10, -exponent.Value);
        }

        /// <summary>
        /// CIFP field 5.212 "Runway Gradient"
        /// </summary>
        /// <remarks>
        /// The overall slope of the runway in percent, signed, measured from the start of the take-off roll.
        /// <para>FAA: This field, together with Ellipsoidal Height (5.225), is one of the two additions the FAA calls out on the runway record: the readme says "Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available." In the shipped file that promise is not kept for gradient. All 16,805 runway records carry five spaces at offset 51. Ellipsoid height IS populated on 6,282 o</para>
        /// <para>Blank: No gradient published for this runway. This is the value on every FAA runway record.</para>
        /// </remarks>
        /// <returns>
        /// Gradient in percent as a signed double (digits divided by 1000.0, sign applied), or null when blank.
        /// </returns>
        public static double? Field5212(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            bool isNegative = fieldValue[0] == '-';
            int? digits = CifpSpan.ToInt(fieldValue[1..]);
            if (digits is null)
                return null;

            double value = digits.Value / 1000.0;
            return isNegative ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.213 "Controlled Airspace Type"
        /// </summary>
        /// <remarks>
        /// Names the category of controlled airspace the record describes - Class B, Class C, Class D, a
        /// control area, a TMA or a radar area.
        /// <para>FAA: The readme confirms the CIFP carries Class B, C and D airspace only ("Class B, C, and D Airspace (UC)"). Observed distribution: 'T' Class B on 7,150 records, 'A' Class C on 3,620, 'Z' Class D on 2,365. The three ICAO-flavoured codes never appear.</para>
        /// <para>Blank: Should not occur. Every controlled airspace record in the FAA file carries a type.</para>
        /// </remarks>
        /// <returns>
        /// A ControlledAirspaceType enum, or null when blank.
        /// </returns>
        public static string Field5213(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Class C airspace (previously ARSA in the USA).",
                'C' => "(C) Control area - the ICAO CTA designation.",   // not present in the current FAA cycle
                'M' => "(M) Terminal control area - the ICAO TMA or TCA designation.",   // not present in the current FAA cycle
                'R' => "(R) Radar zone or radar area (previously TRSA in the USA).",   // not present in the current FAA cycle
                'T' => "(T) Class B airspace (previously TCA in the USA).",
                'Z' => "(Z) Class D airspace in the USA; control zone, the ICAO CTR designation.",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.215 "Controlled Airspace Classification"
        /// </summary>
        /// <remarks>
        /// The published ICAO airspace class letter, A through G.
        /// <para>FAA: The readme does not mention the field. Observed: 'B' on 7,150 records, 'C' on 3,620, 'D' on 2,365 - matching the readme's statement that only Class B, C and D airspace is carried.</para>
        /// <para>Blank: Source does not assign a classification to this airspace. Does not occur in the FAA file.</para>
        /// </remarks>
        /// <returns>
        /// An AirspaceClass enum (A through G), or null when blank.
        /// </returns>
        public static string Field5215(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Class A airspace.",   // not present in the current FAA cycle
                'B' => "(B) Class B airspace.",
                'C' => "(C) Class C airspace.",
                'D' => "(D) Class D airspace.",
                'E' => "(E) Class E airspace.",   // not present in the current FAA cycle
                'F' => "(F) Class F airspace.",   // not present in the current FAA cycle
                'G' => "(G) Class G airspace.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

    }
}