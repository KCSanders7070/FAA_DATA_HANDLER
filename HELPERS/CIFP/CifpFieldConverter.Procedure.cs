using System;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Converts raw CIFP fixed-width field values into usable .NET values. Path point, SBAS/RNP level of
    /// service and approach performance.
    /// <para>Methods are named for the field number with the decimal removed, so field 5.2 is
    /// <see cref="Field52"/>. Composite fields get one method per column, suffixed with the
    /// column name.</para>
    /// <para>Where a value is not recognized it is returned as-is rather than discarded, so an
    /// unexpected CIFP value surfaces in the output instead of silently becoming null.</para>
    /// </summary>
    internal static partial class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.222 "GNSS/FMS Indicator"
        /// </summary>
        /// <remarks>
        /// Says whether a conventional approach is authorised to be flown as a GNSS or FMS overlay, and for
        /// RNAV procedures whether SBAS vertical guidance is authorised.
        /// <para>FAA: The readme does not name the field, but its content is consistent with the FAA's approach inventory: GPS overlays, RNAV (GPS), RNAV (RNP) and stand-alone GPS procedures. Observed on procedure leg primaries: blank 78,769, 'A' 66,097, '0' 37,280, 'B' 18,658, '3' 174, 'P' 136. Codes 1, 2, 4, 5, C and U never appear.</para>
        /// <para>Blank: No overlay or SBAS statement for this procedure. 78,769 of 201,114 procedure leg primaries are blank - the field is only meaningful on approach records.</para>
        /// </remarks>
        /// <returns>
        /// A GnssFmsIndicator enum, or null when blank.
        /// </returns>
        public static string Field5222(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '0' => "(0) Procedure is not authorised for GNSS or FMS overlay.",
                '1' => "(1) Authorised for GNSS overlay; the underlying navaids are operating and monitored.",   // not present in the current FAA cycle
                '2' => "(2) Authorised for GNSS overlay; the underlying navaids are installed but not monitored.",   // not present in the current FAA cycle
                '3' => "(3) Authorised for GNSS overlay; the procedure title itself includes GPS or GNSS.",
                '4' => "(4) Authorised for FMS overlay.",   // not present in the current FAA cycle
                '5' => "(5) Authorised for FMS and/or GNSS overlay. Removed in 424-19A.",   // not present in the current FAA cycle
                'A' => "(A) RNAV (GPS) or RNAV (GNSS) procedure with SBAS use authorised - this is the code that indicates GNSS-based vertical guidance (LPV, LNAV/VNAV). Requires a procedure data continuation record.",
                'B' => "(B) RNAV (GPS) or RNAV (GNSS) procedure with SBAS use NOT authorised - lateral guidance only.",
                'C' => "(C) RNAV (GPS) or RNAV (GNSS) procedure with SBAS use not specified.",   // not present in the current FAA cycle
                'P' => "(P) Stand-alone GPS (GNSS) procedure.",
                'U' => "(U) Overlay authorisation not specified. Removed in 424-19A.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.223 "Operation Type"
        /// </summary>
        /// <remarks>
        /// Classifies the kind of final approach segment a path point record describes.
        /// <para>FAA: The readme does not mention it. All 4,905 path point primary records carry '00' - every FAA path point describes a straight-in final approach segment.</para>
        /// <para>Blank: Not applicable. Does not occur - every path point record carries '00'.</para>
        /// </remarks>
        /// <returns>
        /// The two digits as an int (0-15), or null when blank.
        /// </returns>
        public static string Field5223(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return string.Empty;

            return value switch
            {
                "00" => "(00) Straight-in approach procedure.",
                "01" => "(01) Reserved for future definition.",   // not present in the current FAA cycle
                "02" => "(02) Reserved for future definition.",   // not present in the current FAA cycle
                "03" => "(03) Reserved for future definition.",   // not present in the current FAA cycle
                "04" => "(04) Reserved for future definition.",   // not present in the current FAA cycle
                "05" => "(05) Reserved for future definition.",   // not present in the current FAA cycle
                "06" => "(06) Reserved for future definition.",   // not present in the current FAA cycle
                "07" => "(07) Reserved for future definition.",   // not present in the current FAA cycle
                "08" => "(08) Reserved for future definition.",   // not present in the current FAA cycle
                "09" => "(09) Reserved for future definition.",   // not present in the current FAA cycle
                "10" => "(10) Reserved for future definition.",   // not present in the current FAA cycle
                "11" => "(11) Reserved for future definition.",   // not present in the current FAA cycle
                "12" => "(12) Reserved for future definition.",   // not present in the current FAA cycle
                "13" => "(13) Reserved for future definition.",   // not present in the current FAA cycle
                "14" => "(14) Reserved for future definition.",   // not present in the current FAA cycle
                "15" => "(15) Reserved for future definition.",   // not present in the current FAA cycle

                // Return unrecognized values as-is.
                _ => value.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.225 "Ellipsoidal Height"
        /// </summary>
        /// <remarks>
        /// Height of a surveyed point above (or below) the WGS-84 ellipsoid, in tenths of a metre with an
        /// explicit sign.
        /// <para>FAA: The readme names this field explicitly: "Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available." That half of the statement holds - 6,282 of 16,805 runway records carry a value. Gradient never does. On path point records, all 4,905 primaries carry an LTP ellipsoidal height (3,441 distinct values), but the FPAP ellipsoidal height on the continuation r</para>
        /// <para>Blank: No ellipsoidal height published for this point. Blank on 10,523 of 16,805 runway records and on all 4,905 path point continuation records.</para>
        /// </remarks>
        /// <returns>
        /// Height in metres as a signed double (five digits divided by 10.0, sign applied), or null when blank.
        /// </returns>
        public static double? Field5225(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            bool isNegative = fieldValue[0] == '-';
            int? digits = CifpSpan.ToInt(fieldValue[1..]);
            if (digits is null)
                return null;

            double value = digits.Value / 10.0;
            return isNegative ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.226 "Glide Path Angle"
        /// </summary>
        /// <remarks>
        /// The intended descent angle of the final approach path, in hundredths of a degree.
        /// <para>FAA: Not mentioned in the readme. Observed on all 4,905 path point primaries, 81 distinct values from '0000' to '0570' (0.00 to 5.70 degrees). '0300' - a standard 3.00 degree path - covers 4,229 of them. A value of '0000' appears on 180 records and correlates exactly with LP procedures: every 0000 record has approach type identifier 'LP' on its continuation record and vertical alert limit '000'. So 000</para>
        /// <para>Blank: No glide path angle. Does not occur - all 4,905 path point primaries are populated, though 180 of them carry 0000.</para>
        /// </remarks>
        /// <returns>
        /// The angle in decimal degrees (raw integer divided by 100.0), or null when blank. Treat 0.00 as 'no
        /// vertical guidance' rather than a real angle.
        /// </returns>
        public static double? Field5226(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 100.0;
        }

        /// <summary>
        /// CIFP field 5.227 "Orthometric Height"
        /// </summary>
        /// <remarks>
        /// Height of a surveyed point above mean sea level, in tenths of a metre with an explicit sign.
        /// <para>FAA: Not mentioned in the readme. Both instances are fully populated on all 4,905 path point continuation records - 3,310 distinct FPAP values and 3,308 distinct LTP values, mostly small positive numbers in the tens of metres.</para>
        /// <para>Blank: No orthometric height published for this point.</para>
        /// </remarks>
        /// <returns>
        /// Height above MSL in metres as a signed double (five digits divided by 10.0, sign applied), or null
        /// when blank.
        /// </returns>
        public static double? Field5227(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            bool isNegative = fieldValue[0] == '-';
            int? digits = CifpSpan.ToInt(fieldValue[1..]);
            if (digits is null)
                return null;

            double value = digits.Value / 10.0;
            return isNegative ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.228 "Course Width At Threshold"
        /// </summary>
        /// <remarks>
        /// The lateral width of the final approach course at the landing threshold, in hundredths of a metre,
        /// which sets lateral deviation sensitivity.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries are populated; 47 distinct values ranging from '08000' (80.00 m) to '14375' (143.75 m), with '10675' (106.75 m) on 4,804 of them. Every value ends in 00, 25, 50 or 75 as required. The 38.00 m helicopter value never appears, because there are no runway-00 path point records in the file.</para>
        /// <para>Blank: No course width. Does not occur - all 4,905 path point primaries are populated.</para>
        /// </remarks>
        /// <returns>
        /// Course width in metres as a double (raw integer divided by 100.0), or null when blank.
        /// </returns>
        public static double? Field5228(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 100.0;
        }

        /// <summary>
        /// CIFP field 5.229 "Final Approach Segment Data CRC Remainder"
        /// </summary>
        /// <remarks>
        /// Eight-character hexadecimal representation of the 32-bit CRC that protects the final approach
        /// segment data block.
        /// <para>FAA: The readme does not discuss the FAS CRC specifically, but it does state the whole CIFP file is wrapped with a separate 32-bit CRC calculated per ARINC Report 665. Observed: all 4,905 path point primaries carry a CRC and all 4,905 values are distinct, as expected.</para>
        /// <para>Blank: No CRC supplied. Does not occur - all 4,905 path point primaries carry one.</para>
        /// </remarks>
        /// <returns>
        /// The 32-bit value as a uint (parsed base 16), plus the original eight characters retained verbatim.
        /// Null when blank.
        /// </returns>
        public static uint? Field5229(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.Length != 8)
                return null;

            return uint.TryParse(value, System.Globalization.NumberStyles.HexNumber,
                                 System.Globalization.CultureInfo.InvariantCulture, out uint crc)
                ? crc
                : null;
        }

        /// <summary>
        /// CIFP field 5.244 "GLS Channel / GNSS Channel Number"
        /// </summary>
        /// <remarks>
        /// Five-digit channel number that identifies which augmentation system and reference path the procedure
        /// uses.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point continuation records carry a channel, 4,904 of them distinct, ranging from 40000 to 99747. Every single one falls in the SBAS band - the FAA publishes no GBAS/GLS procedures in the CIFP, which matches the readme's statement that GLS procedures are not included.</para>
        /// <para>Blank: No channel assigned to this procedure.</para>
        /// </remarks>
        /// <returns>
        /// The channel number as an int, plus an augmentation-system classification derived from the band. Null
        /// when blank.
        /// </returns>
        public static int? Field5244(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.249 "Longest Runway Surface Code"
        /// </summary>
        /// <remarks>
        /// Says what the longest runway at the airport is surfaced with - hard, soft, water, or unknown.
        /// <para>FAA: The readme warns that "The Longest Runway (5.54) field may not always represent the longest hard-surface runway at the airport" - so the length and this surface code must be read together, and neither should be used alone to decide whether a paved runway of a given length exists. Observed: 'S' soft on 7,735 airports, 'H' hard on 5,000, 'W' water on 586. 'U' never appears - the FAA always states a </para>
        /// <para>Blank: Surface type not stated. Does not occur in the FAA file - all 13,321 airport records are populated.</para>
        /// </remarks>
        /// <returns>
        /// A RunwaySurfaceCode enum (Hard / Soft / Water / Undefined), or null when blank.
        /// </returns>
        public static string Field5249(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'H' => "(H) Hard surface - asphalt, concrete or similar.",
                'S' => "(S) Soft surface - gravel, grass, soil or similar.",
                'W' => "(W) Water runway.",
                'U' => "(U) Undefined - source did not state the surface material.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.254 "Fixed Radius Transition Indicator"
        /// </summary>
        /// <remarks>
        /// The required turn radius, in tenths of a nautical mile, when the controlling authority mandates a
        /// fixed radius transition between airway legs.
        /// <para>FAA: The readme does not mention the field, and the FAA does not use it: all 19,099 enroute airway primary records carry three spaces at offset 98.</para>
        /// <para>Blank: No fixed radius transition is required at this point. This is the value on every FAA airway record.</para>
        /// </remarks>
        /// <returns>
        /// Turn radius in decimal nautical miles (raw integer divided by 10.0), or null when blank - null
        /// meaning 'no fixed radius transition required'.
        /// </returns>
        public static double? Field5254(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.255 "SBAS Service Provider Identifier"
        /// </summary>
        /// <remarks>
        /// Two-digit code tying the approach to a particular satellite based augmentation system service
        /// provider.
        /// <para>FAA: The readme does not mention the field. All 4,905 path point primary records carry '00', which is consistent with a single U.S. provider (WAAS) for the whole dataset.</para>
        /// <para>Blank: No SBAS service provider identified for this procedure. Does not occur - all 4,905 path point primaries carry '00'.</para>
        /// </remarks>
        /// <returns>
        /// The two digits as an int in the range 0-15, or null when blank.
        /// </returns>
        public static int? Field5255(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.256 "Reference Path Data Selector"
        /// </summary>
        /// <remarks>
        /// Two-digit selector that lets GBAS avionics tune the correct approach data block automatically.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primary records carry '00'. That is expected - the FAA publishes no GBAS/GLS procedures in the CIFP, so there is no data block to select.</para>
        /// <para>Blank: No data selector. Does not occur - all 4,905 path point primaries carry '00'.</para>
        /// </remarks>
        /// <returns>
        /// The two digits as an int in the range 0-48, or null when blank.
        /// </returns>
        public static int? Field5256(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.258 "Approach Performance Designator"
        /// </summary>
        /// <remarks>
        /// Single digit stating the type or category of approach the path point record supports.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primary records carry '0'. Combined with the approach type identifiers on the continuation records (LPV and LP only), '0' evidently corresponds to the non-precision-approach-category SBAS approaches the FAA publishes.</para>
        /// <para>Blank: No performance designator. Does not occur - all 4,905 path point primaries carry '0'.</para>
        /// </remarks>
        /// <returns>
        /// The digit as an int in the range 0-7, or null when blank.
        /// </returns>
        public static int? Field5258(char fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.259 "Length Offset"
        /// </summary>
        /// <remarks>
        /// Distance in metres from the stop end of the runway to the Flight Path Alignment Point, marking where
        /// lateral sensitivity switches to missed approach sensitivity.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry a value, 239 distinct, ranging from 0000 to 2016 metres, and every single one is an exact multiple of 8 - a useful validation check. The most common are 1224 m (597 records) and 0000 (565 records).</para>
        /// <para>Blank: No offset stated. Does not occur - all 4,905 path point primaries carry a value, including 565 explicit zeros.</para>
        /// </remarks>
        /// <returns>
        /// The offset in whole metres as an int, or null when blank. Zero means the FPAP is at the opposite
        /// runway end, not that the value is missing.
        /// </returns>
        public static int? Field5259(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.261 "Speed Limit Description"
        /// </summary>
        /// <remarks>
        /// Qualifies the speed restriction at a fix as at, at-or-above, or at-or-below the value in the Speed
        /// Limit field.
        /// <para>FAA: Not mentioned in the readme. Observed on procedure leg primaries: blank 197,008, '-' 4,102, '+' 4. The FAA overwhelmingly publishes maximum speeds; minimum speeds are essentially unused.</para>
        /// <para>Blank: Mandatory speed - cross the fix AT the speed given in the Speed Limit field. Blank is NOT 'no value'; it is the 'at' qualifier. If the Speed Limit field itself is empty there is simply no speed restriction.</para>
        /// </remarks>
        /// <returns>
        /// A SpeedLimitDescription enum (At / AtOrAbove / AtOrBelow). Return At for a blank - never null - and
        /// let the caller decide there is no restriction by checking the Speed Limit field.
        /// </returns>
        public static string Field5261(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '+' => "(+) Minimum speed - cross the fix AT OR ABOVE the speed in the Speed Limit field.",
                '-' => "(-) Maximum speed - cross the fix AT OR BELOW the speed in the Speed Limit field.",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.263 "Horizontal Alert Limit"
        /// </summary>
        /// <remarks>
        /// The radius of the horizontal containment circle the navigation solution must stay inside, in tenths
        /// of a metre.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry '400' - 40.0 metres, the standard LPV/LP horizontal alert limit. There is no variation in the dataset.</para>
        /// <para>Blank: No horizontal alert limit stated. Does not occur - all 4,905 path point primaries carry a value.</para>
        /// </remarks>
        /// <returns>
        /// The limit in metres as a double (raw integer divided by 10.0), or null when blank.
        /// </returns>
        public static double? Field5263(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.264 "Vertical Alert Limit"
        /// </summary>
        /// <remarks>
        /// Half the height of the vertical containment segment the navigation solution must stay inside, in
        /// tenths of a metre.
        /// <para>FAA: Not mentioned in the readme, but the observed values map exactly onto the FAA's SBAS service levels, cross-checked against the approach type identifier (5.262) on the matching continuation record: '500' (50.0 m) on 2,985 records - all LPV, the standard LPV vertical alert limit. '350' (35.0 m) on 1,202 records - all LPV, the tighter LPV-200 limit. '000' on 718 records - all LP, which is a lateral-o</para>
        /// <para>Blank: No vertical alert limit stated. Does not occur - all 4,905 path point primaries carry a value, though 718 of them are '000'.</para>
        /// </remarks>
        /// <returns>
        /// The limit in metres as a double (raw integer divided by 10.0), or null when blank. Treat 0.0 as 'no
        /// vertical guidance' - it pairs with approach type LP and with glide path angle 0000.
        /// </returns>
        public static double? Field5264(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.265 "Path Point TCH"
        /// </summary>
        /// <remarks>
        /// The height of the approach path above the landing threshold or helicopter alighting point, at higher
        /// resolution than the ordinary TCH field.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry a value with units 'F', 287 distinct, from '000000' to '000680' - so 0.0 to 68.0 feet. The common ones are 000400 (40.0 ft, 1,221 records), 000450 (45.0 ft) and 000500 (50.0 ft), which are typical published TCH values. 177 records carry 000000; those pair with the LP procedures that have no vertical guidance.</para>
        /// <para>Blank: No threshold crossing height stated. Does not occur - all 4,905 path point primaries carry a value, including 177 explicit zeros.</para>
        /// </remarks>
        /// <returns>
        /// The crossing height as a double, together with its unit. Divide by 10.0 when 5.266 is 'F', by 100.0
        /// when it is 'M'. Null when blank.
        /// </returns>
        public static double? Field5265(ReadOnlySpan<char> fieldValue, char unitsIndicator)
        {
            // Six digits whose implied decimal position depends on the paired TCH Units
            // Indicator (5.266): one place for feet, two for metres.
            if (fieldValue.IsWhiteSpace())
                return null;

            int? raw = CifpSpan.ToInt(fieldValue);
            if (raw is null)
                return null;

            return unitsIndicator == 'M' ? raw.Value / 100.0 : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.266 "TCH Units Indicator"
        /// </summary>
        /// <remarks>
        /// Says whether the Path Point TCH beside it is expressed in feet or in metres.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primary records carry 'F'; the FAA publishes threshold crossing heights in feet throughout.</para>
        /// <para>Blank: Units not stated, which makes the Path Point TCH unusable. Does not occur - all 4,905 path point primaries carry 'F'.</para>
        /// </remarks>
        /// <returns>
        /// A TchUnits enum (Feet / Metres), or null when blank. The Path Point TCH converter must consume this
        /// value.
        /// </returns>
        public static string Field5266(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'F' => "(F) Path Point TCH is in feet, resolution one tenth of a foot.",
                'M' => "(M) Path Point TCH is in metres, resolution one hundredth of a metre.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.267 "High Precision Latitude"
        /// </summary>
        /// <remarks>
        /// Latitude of a path point feature at 0.0001 arc-second resolution - the high precision extension of
        /// the ordinary latitude field.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry both latitudes; 4,881 distinct LTP values, so a handful of thresholds are shared between procedures.</para>
        /// <para>Blank: No high precision latitude. Does not occur - both instances on every path point primary are populated.</para>
        /// </remarks>
        /// <returns>
        /// Signed decimal degrees as a double, positive north, negative south. Null when blank. Keep the raw 11
        /// characters too, because the value is inside the FAS CRC wrap.
        /// </returns>
        public static double? Field5267(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char hemisphere = fieldValue[0];
            if (hemisphere != 'N' && hemisphere != 'S')
                return null;

            int? degrees = CifpSpan.ToInt(fieldValue.Slice(1, 2));
            int? minutes = CifpSpan.ToInt(fieldValue.Slice(3, 2));
            int? seconds = CifpSpan.ToInt(fieldValue.Slice(5, 6));
            if (degrees is null || minutes is null || seconds is null)
                return null;

            // The last 4 digits of the seconds group are fractional.
            double wholeSeconds = seconds.Value / 10000.0;
            double value = degrees.Value + (minutes.Value / 60.0) + (wholeSeconds / 3600.0);
            return hemisphere == 'S' ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.268 "High Precision Longitude"
        /// </summary>
        /// <remarks>
        /// Longitude carried at the extra precision the FAS data block needs, used for the landing threshold
        /// and flight path alignment points on Path Point records.
        /// <para>Blank: Position not provided.</para>
        /// </remarks>
        /// <returns>
        /// Signed decimal degrees as a double, negative for western longitudes; null when blank.
        /// </returns>
        public static double? Field5268(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char hemisphere = fieldValue[0];
            if (hemisphere != 'E' && hemisphere != 'W')
                return null;

            int? degrees = CifpSpan.ToInt(fieldValue.Slice(1, 3));
            int? minutes = CifpSpan.ToInt(fieldValue.Slice(4, 2));
            int? seconds = CifpSpan.ToInt(fieldValue.Slice(6, 6));
            if (degrees is null || minutes is null || seconds is null)
                return null;

            // The last 4 digits of the seconds group are fractional.
            double wholeSeconds = seconds.Value / 10000.0;
            double value = degrees.Value + (minutes.Value / 60.0) + (wholeSeconds / 3600.0);
            return hemisphere == 'W' ? -value : value;
        }

        /// <summary>
        /// CIFP field 5.276 "Level of Service Authorized"
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// <para>Blank: The level of service is not addressed on this record. On the 430 RNAV (RNP) continuations the SBAS flags are blank because the record carries RNP data instead.</para>
        /// </remarks>
        /// <returns>
        /// true for 'A', false for 'N', null when blank.
        /// </returns>
        public static string Field5276(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) The designated level of service is authorized for the procedure",
                'N' => "(N) The designated level of service is not authorized for the procedure",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.297 "RNP Level of Service"
        /// </summary>
        /// <remarks>
        /// An RNP value published as an additional level of service for an RNAV (RNP) approach, encoded the
        /// same way as the RNP field 5.211.
        /// <para>FAA: The FAA states it applies ARINC 424 version 19 to the level of service continuation record. Verified in FAACIFP18: 430 of the 6,742 PF/HF continuation records carry this block, and every one of them is an RNAV (RNP) approach (route type H with Approach Route Qualifier 1 F).</para>
        /// <para>Blank: No further RNP level of service at this position.</para>
        /// </remarks>
        /// <returns>
        /// The decoded RNP value as a double, e.g. 0.30 for "031"; null when blank.
        /// </returns>
        public static double? Field5297(ReadOnlySpan<char> fieldValue)
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

    }
}