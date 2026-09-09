using System;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Converts raw CIFP fixed-width field values into usable .NET values. Airport, heliport, navaid detail
    /// and airspace altitudes.
    /// <para>Methods are named for the field number with the decimal removed, so field 5.2 is
    /// <see cref="Field52"/>. Composite fields get one method per column, suffixed with the
    /// column name.</para>
    /// <para>Where a value is not recognized it is returned as-is rather than discarded, so an
    /// unexpected CIFP value surfaces in the output instead of silently becoming null.</para>
    /// </summary>
    internal static partial class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.79 "Stopway"
        /// </summary>
        /// <remarks>
        /// Length in feet of the paved deceleration area beyond the departure end of the runway.
        /// <para>Blank: No stopway length is supplied. In the CIFP this is always the case.</para>
        /// </remarks>
        /// <returns>
        /// Stopway length in feet as int?, or null. In the CIFP always null.
        /// </returns>
        public static int? Field579(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.80 "ILS/MLS/GLS Category"
        /// </summary>
        /// <remarks>
        /// Performance category of an ILS/MLS/GLS facility, or the classification of a non-ILS localizer-type
        /// installation such as LDA, SDF or IGS.
        /// <para>FAA: The FAA includes ILS procedures for Category I only, and does not include CAT II, CAT III, PRM, converging ILS or GLS procedures. Category 2 and 3 values nonetheless appear here because this field describes the FACILITY classification, not the procedures published to it. For LDA approaches that have both LDA and glide slope minima, the FAA codes the procedure to LDA minimums only - which is consis</para>
        /// <para>Blank: No localizer, MLS or GLS facility is associated with this runway end.</para>
        /// </remarks>
        /// <returns>
        /// A resolved category/classification description (or enum member) for the character, or null when
        /// blank. Note the letter 'I' is a value in this table - do not confuse it with the digit 1.
        /// </returns>
        public static string Field580(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '0' => "(0) ILS localizer only, no glide slope",
                '1' => "(1) ILS localizer / MLS / GLS Category I",
                '2' => "(2) ILS localizer / MLS / GLS Category II",
                '3' => "(3) ILS localizer / MLS / GLS Category III",
                'I' => "(I) IGS (Instrument Guidance System) facility",   // not present in the current FAA cycle
                'L' => "(L) LDA facility with glide slope",
                'A' => "(A) LDA facility, no glide slope",
                'S' => "(S) SDF facility with glide slope",   // not present in the current FAA cycle
                'F' => "(F) SDF facility, no glide slope",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.81 "ATC Indicator"
        /// </summary>
        /// <remarks>
        /// Flags that the altitudes coded on this procedure leg may be changed by ATC, or will be assigned by
        /// ATC.
        /// <para>Blank: The altitudes in this leg are as published and are not flagged as ATC-modifiable or ATC-assigned.</para>
        /// </remarks>
        /// <returns>
        /// The resolved meaning of 'A' or 'S', or null when blank. In the CIFP always null.
        /// </returns>
        public static string Field581(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) The official source states the coded altitude can be modified or assigned by ATC",   // not present in the current FAA cycle
                'S' => "(S) The official source states the altitude will be assigned by ATC, or no altitude is supplied",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.82 "Waypoint Usage" — AltitudeStructure column
        /// </summary>
        /// <remarks>
        /// Two columns saying which airway structure a waypoint belongs to: column 1 flags RNAV use, column 2
        /// gives the altitude structure (high, low, or both).
        /// </remarks>
        public static string Field582AltitudeStructure(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'B' => "(B) Used in both the high and the low altitude structure",
                'H' => "(H) Used in the high altitude structure only",
                'L' => "(L) Used in the low altitude structure only",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.82 "Waypoint Usage" — RnavUsage column
        /// </summary>
        /// <remarks>
        /// Two columns saying which airway structure a waypoint belongs to: column 1 flags RNAV use, column 2
        /// gives the altitude structure (high, low, or both).
        /// </remarks>
        public static string Field582RnavUsage(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'R' => "(R) Waypoint is used in the RNAV route structure",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.90 "ILS/DME Bias"
        /// </summary>
        /// <remarks>
        /// Offset applied to a co-located ILS or MLS DME so that it reads zero at the runway threshold rather
        /// than at the antenna.
        /// <para>Blank: The DME is unbiased. In the CIFP this is always the case.</para>
        /// </remarks>
        /// <returns>
        /// Bias in nautical miles as decimal? (raw digits / 10), or null when blank. In the CIFP always null.
        /// </returns>
        public static decimal? Field590(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10m;
        }

        /// <summary>
        /// CIFP field 5.91 "Continuation Record Application Type"
        /// </summary>
        /// <remarks>
        /// Says what kind of continuation record this is, and therefore which field layout the rest of the
        /// record follows.
        /// <para>FAA: The FAA readme confirms two of the three: it applies ARINC 424 version 19 to the level of service continuation record, and it states that UR continuation records exist only to carry controlling agencies. It says nothing directly about the PP continuation.</para>
        /// <para>Blank: Not applicable - the record is a primary record, not a continuation. The field only exists on continuation records.</para>
        /// </remarks>
        /// <returns>
        /// A resolved continuation-application enum used to select the continuation layout. The parser should
        /// treat an unrecognised value as a hard stop rather than guessing a layout.
        /// </returns>
        public static string Field591(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Standard ARINC continuation carrying notes or other formatted data not covered by a defined continuation type",   // not present in the current FAA cycle
                'B' => "(B) Combined controlling agency / call sign plus formatted time of operation",   // not present in the current FAA cycle
                'C' => "(C) Call sign / controlling agency continuation",
                'E' => "(E) Primary record extension",
                'L' => "(L) VHF navaid limitation continuation",   // not present in the current FAA cycle
                'N' => "(N) Sector narrative continuation",   // not present in the current FAA cycle
                'P' => "(P) Flight planning application continuation",   // not present in the current FAA cycle
                'Q' => "(Q) Flight planning application primary data continuation",   // not present in the current FAA cycle
                'S' => "(S) Simulation application continuation",   // not present in the current FAA cycle
                'T' => "(T) Time of operations continuation, formatted time data",   // not present in the current FAA cycle
                'U' => "(U) Time of operations continuation, narrative time data",   // not present in the current FAA cycle
                'V' => "(V) Time of operations continuation, start and end dates",   // not present in the current FAA cycle
                'W' => "(W) Airport or heliport procedure data continuation carrying SBAS use authorization information (the Level of Service record)",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.107 "ATA/IATA Designator"
        /// </summary>
        /// <remarks>
        /// A three-character short code for the airport or heliport - internationally the IATA/ATA code, but in
        /// the FAA CIFP the three-character FAA location identifier.
        /// <para>FAA: "The IATA code field in the Airport Record will contain the FAA Airport Identifier. If the Airport Identifier is four characters in length, the field will be left blank." In the 2507 file 8,150 of 13,321 airport records and 5,941 of 6,134 heliport records have this field blank.</para>
        /// <para>Blank: In the FAA CIFP: the airport ICAO identifier is four characters long, so no separate three-character code is carried. In generic ARINC terms: no IATA code is assigned.</para>
        /// </remarks>
        /// <returns>
        /// The trimmed three-character code, or null when the slice is blank.
        /// </returns>
        public static string Field5107(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.108 "IFR Capability"
        /// </summary>
        /// <remarks>
        /// Says whether the airport or heliport has at least one official published instrument approach
        /// procedure.
        /// <para>Blank: Does not occur in the FAA CIFP - every airport and heliport record carries Y or N.</para>
        /// </remarks>
        /// <returns>
        /// true for Y, false for N, null for anything else.
        /// </returns>
        public static string Field5108(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'Y' => "(Y) An official government instrument approach procedure is published for this airport or heliport",
                'N' => "(N) No published instrument approach procedure",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.109 "Runway Width"
        /// </summary>
        /// <remarks>
        /// The width of the runway, in whole feet.
        /// <para>Blank: Width unknown or not applicable. Does not occur in the FAA CIFP - every runway record has a value.</para>
        /// </remarks>
        /// <returns>
        /// The width in whole feet as an int, or null if the slice is blank or non-numeric.
        /// </returns>
        public static int? Field5109(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.118 "Boundary Via" — IsEndOfDescription column
        /// </summary>
        /// <remarks>
        /// Describes the shape of the airspace boundary leaving this vertex - straight line, arc, circle - and
        /// flags the vertex that closes the boundary.
        /// </remarks>
        public static string Field5118IsEndOfDescription(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'E' => "(E) Last vertex - close the boundary back to the first point",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.118 "Boundary Via" — PathType column
        /// </summary>
        /// <remarks>
        /// Describes the shape of the airspace boundary leaving this vertex - straight line, arc, circle - and
        /// flags the vertex that closes the boundary.
        /// </remarks>
        public static string Field5118PathType(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'C' => "(C) Circle - the entire boundary is a circle about the arc origin given in this record",
                'G' => "(G) Great circle (straight line) to the next point",
                'H' => "(H) Rhumb line (constant bearing) to the next point",
                'L' => "(L) Counter-clockwise arc about the arc origin in this record",
                'R' => "(R) Clockwise arc about the arc origin in this record",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.119 "Arc Distance"
        /// </summary>
        /// <remarks>
        /// The radius, in nautical miles, from the arc origin out to the arc or circle that forms this piece of
        /// the airspace boundary.
        /// <para>Blank: This boundary segment is not an arc or a circle - Boundary Via is G or H - so there is no radius to give.</para>
        /// </remarks>
        /// <returns>
        /// The radius in nautical miles as a double (raw integer / 10.0), or null when the slice is blank.
        /// </returns>
        public static double? Field5119(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.120 "Arc Bearing"
        /// </summary>
        /// <remarks>
        /// The true bearing from the arc origin to the point where the arc begins.
        /// <para>Blank: This boundary segment is not an arc - Boundary Via is G or H, or the segment is a full circle - so there is no start bearing.</para>
        /// </remarks>
        /// <returns>
        /// The true bearing in degrees as a double (raw integer / 10.0), or null when the slice is blank.
        /// </returns>
        public static double? Field5120(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.121 "Lower/Upper Limit"
        /// </summary>
        /// <remarks>
        /// The floor or ceiling of a piece of special use or controlled airspace, expressed as an altitude in
        /// feet, a flight level, or a reserved word such as GND or UNLTD.
        /// <para>FAA: "Special Use Airspace Altitudes (5.121) are only coded on the first record of each area. Upper altitudes are described as 'to and including'." So the ceiling is inclusive - an upper limit of 17999 means the airspace includes 17,999 ft. Every altitude the FAA describes as GND carries A (AGL) in its Unit Indicator. A volume that is completely excluded from within an airspace is coded with the six ch</para>
        /// <para>Blank: Not the first record of this airspace. The limits are carried only on the first record of each area; every later vertex record leaves both limit columns blank.</para>
        /// </remarks>
        /// <returns>
        /// A small value type: the numeric altitude in feet where one exists (FL245 becoming 24500 if you
        /// choose to normalise, or 245 kept as a level - pick one and document it), a kind discriminator (Feet,
        /// FlightLevel, Ground, Unlimited, MeanSeaLevel, NotSpecified, ByNotam, NotCoded), and the datum taken
        /// from the adjacent Unit Indicator.
        /// </returns>
        public static string Field5121(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return string.Empty;

            // GND, MSL, UNLTD, NOTSP and NOTAM are sentinels rather than altitudes; they are
            // returned verbatim so no caller mistakes them for a number. Read the paired Unit
            // Indicator (5.133) alongside this: the FAA codes 'A' for AGL on every GND limit.
            if (value.SequenceEqual("GND"))   return "GND (Surface)";
            if (value.SequenceEqual("MSL"))   return "MSL";
            if (value.SequenceEqual("UNLTD")) return "UNLTD (Unlimited)";
            if (value.SequenceEqual("NOTSP")) return "NOTSP (Not Specified)";
            if (value.SequenceEqual("NOTAM")) return "NOTAM (By NOTAM)";

            if (value.StartsWith("FL"))
                return "FL" + value[2..].ToString().TrimStart('0');

            int? feet = CifpSpan.ToInt(value);
            return feet is null ? value.ToString() : feet.Value.ToString() + " ft";
        }

        /// <summary>
        /// CIFP field 5.126 "Restrictive Airspace Name"
        /// </summary>
        /// <remarks>
        /// The plain-language name of a piece of special use airspace, written once per area.
        /// <para>FAA: For the Grand Canyon Special Flight Rules Area the FAA puts all the internal boundary names - sectors and flight free zones - and their altitudes into this field. (The readme calls the field 5.216 there, which is the controlled-airspace name; on a UR record the column at index 93 is 5.126.)</para>
        /// <para>Blank: Either this is not the first record of the area, or the government source assigns no name to it.</para>
        /// </remarks>
        /// <returns>
        /// The trimmed name, or null when the slice is blank.
        /// </returns>
        public static string Field5126(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.127 "Maximum Altitude"
        /// </summary>
        /// <remarks>
        /// The ceiling of an airway segment - the highest altitude at which the segment may be flown.
        /// <para>FAA: The readme says nothing specific about this field. It does specify that Route Type (5.7) is O for conventional and R for RNAV routes and that the Minimum Altitude field carries the point-to-point MEA, which is the companion to this ceiling.</para>
        /// <para>Blank: No maximum altitude is published for this airway segment.</para>
        /// </remarks>
        /// <returns>
        /// The ceiling in feet as an int. If FLnnn is encountered, either normalise to feet (level x 100) or
        /// return a discriminated value - document which. UNLTD should map to null-with-a-flag or int.MaxValue,
        /// not to 0.
        /// </returns>
        public static int? Field5127(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return null;

            // UNLTD means no published ceiling. Returned as null rather than a magic number.
            if (value.SequenceEqual("UNLTD"))
                return null;

            if (value.StartsWith("FL"))
            {
                int? level = CifpSpan.ToInt(value[2..]);
                return level is null ? null : level.Value * 100;
            }

            return CifpSpan.ToInt(value);
        }

        /// <summary>
        /// CIFP field 5.128 "Restrictive Airspace Type"
        /// </summary>
        /// <remarks>
        /// Says what kind of special use airspace the record describes - MOA, restricted, prohibited, warning,
        /// alert and so on.
        /// <para>FAA: The FAA uses U for two things the generic table does not cover: Special Air Traffic Rules Areas described under 14 CFR Part 93, whenever their spatial dimensions can be coded, are published as UR records typed U. National Security Areas are also published as UR records typed U. That second one matters: ARINC 424-19A defines a dedicated code N for National Security Area, and the FAA explicitly does</para>
        /// <para>Blank: Does not occur - every UR record carries a type.</para>
        /// </remarks>
        /// <returns>
        /// A typed enum value. Counts in the 2507 file: M 13,804; R 9,461; W 3,128; U 2,445; A 801; P 355.
        /// </returns>
        public static string Field5128(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Alert area",
                'C' => "(C) Caution area",   // not present in the current FAA cycle
                'D' => "(D) Danger area",   // not present in the current FAA cycle
                'M' => "(M) Military operations area (MOA)",
                'N' => "(N) National security area - 424-19A only; the FAA codes these as U instead",   // not present in the current FAA cycle
                'P' => "(P) Prohibited area",
                'R' => "(R) Restricted area",
                'T' => "(T) Training area",   // not present in the current FAA cycle
                'W' => "(W) Warning area",
                'U' => "(U) Unspecified or unknown. In the FAA CIFP this also carries Part 93 Special Air Traffic Rules Areas and National Security Areas",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.129 "Restrictive Airspace Designation"
        /// </summary>
        /// <remarks>
        /// The short designation that identifies a special use airspace area - the number of a restricted or
        /// warning area, or the name of a MOA or special flight rules area.
        /// <para>FAA: The readme lists the FAA's named special air traffic rule / special flight rules designations together with the published names they stand for: ANC SATR Anchorage, Alaska Terminal Area KTN SATR Ketchikan International Airport Traffic Rule GCNPSFRA E and GCNPSFRA W Grand Canyon Special Flight Rules, east and west sections LUKE SATR Special Air Traffic Rules near Luke AFB, AZ DC SFRA Washington DC M</para>
        /// <para>Blank: Does not occur - every UR record carries a designation.</para>
        /// </remarks>
        /// <returns>
        /// The right-trimmed designation string, preserving embedded blanks.
        /// </returns>
        public static string Field5129(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.TrimEnd();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.130 "Multiple Code"
        /// </summary>
        /// <remarks>
        /// Distinguishes several areas that share the same designation but differ in lateral or vertical detail
        /// - the A, B, C of a subdivided MOA, or of an MSA published around the same centre fix.
        /// <para>FAA: The readme adds no rule. In practice the FAA subdivides special use airspace heavily: A through K all occur on UR records, with A on 23,311 of them.</para>
        /// <para>Blank: There is only one area or MSA under this designation - no subdivision exists, so no discriminator is needed.</para>
        /// </remarks>
        /// <returns>
        /// The raw character, or null when blank. Do not fold blank into A - they are different keys.
        /// </returns>
        public static string Field5130(char fieldValue)
        {
            // Blank and 'A' are distinct keys here, so blank is preserved as an empty string
            // rather than being folded into the first subdivision.
            return fieldValue == ' ' ? string.Empty : fieldValue.ToString();
        }

        /// <summary>
        /// CIFP field 5.131 "Time Code"
        /// </summary>
        /// <remarks>
        /// Says whether the thing described by the record is active continuously or only at certain times, and
        /// on continuation records says how to read the time-of-operation columns.
        /// <para>FAA: "Special Use Airspace: Time Code (5.131) uses a C to indicate continuous and is blank to indicate part-time." That redefines blank. Under generic ARINC a blank means "active times announced by NOTAM"; in the FAA CIFP it means "part-time" with no further detail carried. There are no time-of-operation continuation records in the file (UR continuations exist only to carry the controlling agency), so </para>
        /// <para>Blank: In the FAA CIFP: the airspace is part-time. In generic ARINC: active times are announced by NOTAM. These are different claims - see the FAA notes.</para>
        /// </remarks>
        /// <returns>
        /// A typed value distinguishing Continuous, PartTime (FAA blank) and the ARINC codes the FAA does not
        /// use. Do not return "unknown" for blank - blank is a positive statement in this file.
        /// </returns>
        public static string Field5131(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'C' => "(C) Active continuously, including holidays",
                'H' => "(H) Active continuously, excluding holidays",   // not present in the current FAA cycle
                'N' => "(N) Primary: active non-continuously, see continuation record. Continuation: times too complex for the standard format, given as a note",   // not present in the current FAA cycle
                'T' => "(T) Continuation records only: times in Time of Operation format, holidays included",   // not present in the current FAA cycle
                'S' => "(S) Airway restriction records only: times in Time of Operation format, holidays excluded",   // not present in the current FAA cycle
                'P' => "(P) 424-19A only: active times announced by NOTAM",   // not present in the current FAA cycle
                'U' => "(U) 424-19A only: active times not specified in source",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.133 "Unit Indicator"
        /// </summary>
        /// <remarks>
        /// Says whether the airspace limit sitting immediately before it is measured above mean sea level or
        /// above ground level.
        /// <para>FAA: "Unit Indicator (5.133) for all altitudes described as GND contains an A for AGL." That holds without exception in the data: all 1,308 GND lower limits carry A. The distribution shows the pairing rules clearly. On restrictive airspace: GND with A (589), digits with M (506), digits with A (452), FLnnn with M (36) for lower limits; digits with M (1,232), FLnnn with M (166), UNLTD with M (151), digit</para>
        /// <para>Blank: No altitude is coded in the paired limit column - this is not the first record of the area.</para>
        /// </remarks>
        /// <returns>
        /// A datum enum (Msl, Agl, None). Bind it to the limit it follows, not to the record as a whole.
        /// </returns>
        public static string Field5133(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'M' => "(M) The paired limit is above mean sea level",
                'A' => "(A) The paired limit is above ground level",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.140 "Controlling Agency"
        /// </summary>
        /// <remarks>
        /// Names the ATC facility that may authorise IFR operations inside a joint-use special use airspace
        /// when the using agency is not working it.
        /// <para>FAA: "Continuation Records for UR records are included only for Controlling Agencies (5.140)." That is the whole purpose of the 1,175 UR continuation records in the file: everything else on them (time code, NOTAM, time indicator, time of operations) is blank. Conversely, if you want the controlling agency you must read the continuation records - it is not on the primary record.</para>
        /// <para>Blank: No controlling agency is specified for this joint-use airspace.</para>
        /// </remarks>
        /// <returns>
        /// The trimmed facility name, or null when the slice is blank.
        /// </returns>
        public static string Field5140(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.141 "Starting Latitude"
        /// </summary>
        /// <remarks>
        /// The latitude of the south-west corner of the first one-degree block in a Grid MORA record.
        /// <para>Blank: Does not occur - every Grid MORA record carries a starting latitude.</para>
        /// </remarks>
        /// <returns>
        /// The signed latitude in whole degrees as an int (S becomes negative), representing the southern edge
        /// of the block row.
        /// </returns>
        public static int? Field5141(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char hemisphere = fieldValue[0];
            int? degrees = CifpSpan.ToInt(fieldValue.Slice(1, 2));
            if (degrees is null)
                return null;

            return hemisphere == 'S' ? -degrees.Value : degrees.Value;
        }

        /// <summary>
        /// CIFP field 5.142 "Starting Longitude"
        /// </summary>
        /// <remarks>
        /// The longitude of the south-west corner of the first one-degree block in a Grid MORA record.
        /// <para>Blank: Does not occur - every Grid MORA record carries a starting longitude.</para>
        /// </remarks>
        /// <returns>
        /// The signed longitude in whole degrees as an int (W becomes negative), representing the western edge
        /// of the first block.
        /// </returns>
        public static int? Field5142(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            char hemisphere = fieldValue[0];
            int? degrees = CifpSpan.ToInt(fieldValue.Slice(1, 3));
            if (degrees is null)
                return null;

            return hemisphere == 'W' ? -degrees.Value : degrees.Value;
        }

        /// <summary>
        /// CIFP field 5.143 "Grid MORA"
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// <para>Blank: Does not occur - unsurveyed blocks carry UNK, not blanks.</para>
        /// </remarks>
        /// <returns>
        /// The altitude in FEET as an int (raw digits x 100), or null when the slice is UNK.
        /// </returns>
        public static int? Field5143(ReadOnlySpan<char> fieldValue)
        {
            // UNK is a sentinel, not a value.
            if (fieldValue.Trim().SequenceEqual("UNK"))
                return null;

            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value * 100;
        }

        /// <summary>
        /// CIFP field 5.144 "Center Fix"
        /// </summary>
        /// <remarks>
        /// Names the fix a minimum safe altitude is drawn around, or - on an RF leg - the fix at the centre of
        /// the constant-radius turn.
        /// <para>FAA: "The MSA Center Fix (5.144) is normally coded on the FAF record. If the FAF record is an RF leg, then the MSA Center Fix is coded on the FACF record. If there is no FACF record, a center fix will not be coded." That rule is visible in the data: of the procedure records carrying a value, 4,458 are TF legs whose waypoint description code has F (final approach fix) in column 43, 2,783 are CF legs wit</para>
        /// <para>Blank: On an MSA record: never blank. On a procedure record: this leg neither points at an MSA/TAA nor is an RF leg. Blank is the normal case on procedure records (119,842 of them).</para>
        /// </remarks>
        /// <returns>
        /// The trimmed fix identifier or null, together with the qualifier tuple (ICAO code, section,
        /// subsection) read from the columns that follow, and a discriminator saying whether this occurrence is
        /// an MSA pointer, a TAA pointer or an RF arc centre.
        /// </returns>
        public static string Field5144(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.145 "Radius Limit"
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// <para>Blank: This sector slot is unused. An MSA record has seven bearing/altitude/radius slots and most airports use only one.</para>
        /// </remarks>
        /// <returns>
        /// The radius in whole nautical miles as an int, or null when the slot is unused.
        /// </returns>
        public static int? Field5145(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.146 "Sector Bearing" — EndBearing column
        /// </summary>
        /// <remarks>
        /// The pair of bearings, measured to the MSA centre fix, that bound one sector of a minimum safe
        /// altitude - start bearing first, end bearing second, going clockwise.
        /// </remarks>
        public static string Field5146EndBearing(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.146 "Sector Bearing" — StartBearing column
        /// </summary>
        /// <remarks>
        /// The pair of bearings, measured to the MSA centre fix, that bound one sector of a minimum safe
        /// altitude - start bearing first, end bearing second, going clockwise.
        /// </remarks>
        public static string Field5146StartBearing(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.147 "Sector Altitude"
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// <para>Blank: This sector slot is unused.</para>
        /// </remarks>
        /// <returns>
        /// The altitude in FEET as an int (raw digits x 100), or null when the slot is unused. If 999 is ever
        /// seen, return null and flag it rather than reporting 99,900 ft.
        /// </returns>
        public static int? Field5147(ReadOnlySpan<char> fieldValue)
        {
            // 999 is a sentinel, not a value.
            if (fieldValue.Trim().SequenceEqual("999"))
                return null;

            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value * 100;
        }

        /// <summary>
        /// CIFP field 5.149 "Figure of Merit"
        /// </summary>
        /// <remarks>
        /// Encodes the usable range of a VHF navaid beyond what the Class field gives, and doubles as a flag
        /// for navaids that are out of service or absent from civil NOTAM coverage.
        /// <para>FAA: The FAA derives the Figure of Merit from the NAVAID Class. Where the class cannot be determined, the FAA codes the Figure of Merit as '3'.</para>
        /// <para>Blank: Not applicable to this record.</para>
        /// </remarks>
        /// <returns>
        /// A description of the service volume, e.g. "(2) High Altitude Use (within 130NM)", or the status text
        /// for 7 and 9. Unrecognized characters pass through unchanged.
        /// </returns>
        public static string Field5149(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '0' => "(0) Terminal use, generally usable within 25 NM",
                '1' => "(1) Low altitude use, generally usable within 40 NM",
                '2' => "(2) High altitude use, generally usable within 130 NM",
                '3' => "(3) Extended high altitude use, generally usable beyond 130 NM",
                '7' => "(7) Navaid is not carried in a civil international NOTAM system",   // not present in the current FAA cycle
                '9' => "(9) Navaid is out of service",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

    }
}