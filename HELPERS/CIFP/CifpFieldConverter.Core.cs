using System;

namespace FAA_DATA_HANDLER.HELPERS.CIFP
{
    /// <summary>
    /// Converts raw CIFP fixed-width field values into usable .NET values. Record identity, section coding,
    /// sequencing and dating.
    /// <para>Methods are named for the field number with the decimal removed, so field 5.2 is
    /// <see cref="Field52"/>. Composite fields get one method per column, suffixed with the
    /// column name.</para>
    /// <para>Where a value is not recognized it is returned as-is rather than discarded, so an
    /// unexpected CIFP value surfaces in the output instead of silently becoming null.</para>
    /// </summary>
    internal static partial class CifpFieldConverter
    {
        /// <summary>
        /// CIFP field 5.7 as used on Enroute Airway records (ER), zero-based column 44.
        /// </summary>
        private static string RouteTypeEnroute(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Airline-specific airway supplied as tailored data",   // not present in the current FAA cycle
                'C' => "(C) Control airway",   // not present in the current FAA cycle
                'D' => "(D) Direct route",   // not present in the current FAA cycle
                'H' => "(H) Helicopter airway",   // not present in the current FAA cycle
                'O' => "(O) Officially designated airway other than an RNAV or helicopter airway (the conventional VOR/Jet airway structure)",
                'R' => "(R) RNAV airway (in the United States, the Q and T route structure)",
                'S' => "(S) Undesignated ATS route",   // not present in the current FAA cycle
                'T' => "(T) TACAN airway (added in 424-19A)",   // not present in the current FAA cycle

                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.7 as used on Airport SID / Heliport SID records (PD, HD), zero-based column 19.
        /// </summary>
        private static string RouteTypeSid(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '0' => "(0) Engine-out SID",   // not present in the current FAA cycle
                '1' => "(1) SID runway transition (conventional)",
                '2' => "(2) SID common route, or the whole SID when it has no transitions (conventional)",
                '3' => "(3) SID enroute transition (conventional)",
                '4' => "(4) RNAV SID runway transition",
                '5' => "(5) RNAV SID common route, or the whole RNAV SID",
                '6' => "(6) RNAV SID enroute transition",
                'F' => "(F) FMS SID runway transition (424-18 only; removed in 424-19A)",   // not present in the current FAA cycle
                'M' => "(M) FMS SID common route (424-18 only; removed in 424-19A)",   // not present in the current FAA cycle
                'S' => "(S) FMS SID enroute transition (424-18 only; removed in 424-19A)",   // not present in the current FAA cycle
                'T' => "(T) Vector SID runway transition",
                'V' => "(V) Vector SID enroute transition",
                'R' => "(R) RNP SID runway transition (424-19A only; the FAA uses 4 instead)",   // not present in the current FAA cycle
                'N' => "(N) RNP SID common route (424-19A only; the FAA uses 5 instead)",   // not present in the current FAA cycle
                'P' => "(P) RNP SID enroute transition (424-19A only; the FAA uses 6 instead)",   // not present in the current FAA cycle

                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.7 as used on Airport STAR / Heliport STAR records (PE, HE), zero-based column 19.
        /// </summary>
        private static string RouteTypeStar(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '1' => "(1) STAR enroute transition (conventional)",
                '2' => "(2) STAR common route, or the whole STAR when it has no transitions (conventional)",
                '3' => "(3) STAR runway transition (conventional)",
                '4' => "(4) RNAV STAR enroute transition",
                '5' => "(5) RNAV STAR common route, or the whole RNAV STAR",
                '6' => "(6) RNAV STAR runway transition",
                '7' => "(7) Profile descent enroute transition (424-18 only)",   // not present in the current FAA cycle
                '8' => "(8) Profile descent common route (424-18 only)",   // not present in the current FAA cycle
                '9' => "(9) Profile descent runway transition (424-18 only)",   // not present in the current FAA cycle
                'F' => "(F) FMS STAR enroute transition (424-18 only)",   // not present in the current FAA cycle
                'M' => "(M) FMS STAR common route (424-18 only)",   // not present in the current FAA cycle
                'S' => "(S) FMS STAR runway transition (424-18 only)",   // not present in the current FAA cycle
                'R' => "(R) RNP STAR enroute transition (424-19A only; the FAA uses 4 instead)",   // not present in the current FAA cycle
                'N' => "(N) RNP STAR common route (424-19A only; the FAA uses 5 instead)",   // not present in the current FAA cycle
                'P' => "(P) RNP STAR runway transition (424-19A only; the FAA uses 6 instead)",   // not present in the current FAA cycle

                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.7 as used on Airport Approach / Heliport Approach - primary route type records (PF, HF
        /// (primary and continuation)), zero-based column 19.
        /// </summary>
        private static string RouteTypeApproach(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Approach transition (a feeder/initial segment leading into the final approach)",
                'B' => "(B) Localizer back course approach",
                'D' => "(D) VOR/DME approach",
                'F' => "(F) Flight Management System (FMS) approach",   // not present in the current FAA cycle
                'G' => "(G) Instrument Guidance System (IGS) approach",   // not present in the current FAA cycle
                'H' => "(H) RNAV approach with Required Navigation Performance, i.e. RNAV (RNP) (424-19A addition)",
                'I' => "(I) ILS approach",
                'J' => "(J) GLS (GNSS Landing System) approach",   // not present in the current FAA cycle
                'L' => "(L) Localizer-only approach (no glide slope)",
                'M' => "(M) MLS approach",   // not present in the current FAA cycle
                'N' => "(N) NDB approach",
                'P' => "(P) GPS approach (including GPS overlays of conventional procedures)",
                'Q' => "(Q) NDB plus DME approach",
                'R' => "(R) RNAV approach - in the CIFP this is RNAV (GPS); the sensor detail is in Qualifier 1",
                'S' => "(S) VOR approach flown using a VOR/DME or VORTAC",
                'T' => "(T) TACAN approach",   // not present in the current FAA cycle
                'U' => "(U) Simplified Directional Facility (SDF) approach",   // not present in the current FAA cycle
                'V' => "(V) VOR approach (VOR with no DME capability)",
                'W' => "(W) MLS Type A approach",   // not present in the current FAA cycle
                'X' => "(X) Localizer Directional Aid (LDA) approach",
                'Y' => "(Y) MLS Type B and C approach",   // not present in the current FAA cycle
                'Z' => "(Z) Missed approach coding",   // not present in the current FAA cycle

                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.7 as used on Airport Approach / Heliport Approach - Route Qualifier 1 records (PF, HF
        /// (primary and continuation)), zero-based column 118.
        /// </summary>
        public static string RouteQualifier1(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Advanced RNAV RNP, authorization (SAAAR/AR) NOT required; GNSS implied. 424-19A, valid only with route type H",
                'D' => "(D) DME is required for the procedure",
                'F' => "(F) RNAV RNP procedure requiring FAA SAAAR or ICAO AR authorization. 424-19A, valid only with route type H",
                'J' => "(J) GPS/GNSS required; DME/DME to the stated RNP is not authorized",
                'L' => "(L) GBAS procedure",   // not present in the current FAA cycle
                'N' => "(N) DME is not required for the procedure",
                'P' => "(P) GNSS required",
                'R' => "(R) GPS/GNSS or DME/DME to the stated RNP is required",   // not present in the current FAA cycle
                'T' => "(T) DME/DME required for the procedure",   // not present in the current FAA cycle
                'U' => "(U) RNAV with the sensor unspecified",   // not present in the current FAA cycle
                'V' => "(V) VOR/DME RNAV",   // not present in the current FAA cycle
                'W' => "(W) RNAV procedure authorized for SBAS only and requiring the ARINC 424 Path Point FAS Data Block",

                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.7 as used on Airport Approach / Heliport Approach - Route Qualifier 2 records (PF, HF
        /// (primary and continuation)), zero-based column 119.
        /// </summary>
        public static string RouteQualifier2(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Primary missed approach (only valid with route type Z, which the FAA does not emit)",   // not present in the current FAA cycle
                'B' => "(B) Secondary missed approach (only valid with route type Z)",   // not present in the current FAA cycle
                'C' => "(C) Procedure published with circle-to-land minimums only",
                'E' => "(E) Engine-out missed approach (only valid with route type Z)",   // not present in the current FAA cycle
                'H' => "(H) Helicopter procedure with straight-in minimums (424-19A). The FAA uses it for copter approaches to helipads",
                'I' => "(I) Helicopter procedure with circle-to-land minimums (424-19A)",   // not present in the current FAA cycle
                'L' => "(L) Helicopter minimums published without a straight-in / circle-to-land distinction (424-19A)",   // not present in the current FAA cycle
                'S' => "(S) Procedure published with straight-in minimums, or with straight-in and circle-to-land minimums",

                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.2 "Record Type"
        /// </summary>
        /// <remarks>
        /// Column 1 flag saying whether the record belongs to the universally applicable dataset or to a
        /// customer-specific tailored set.
        /// <para>FAA: The FAA readme does not discuss this field. Across all 396,430 records the value is always 'S'.</para>
        /// <para>Blank: Should not occur. Every 132-character CIFP row begins with this flag; a blank here means the line is not a data record (for example a file header) or the read is misaligned.</para>
        /// </remarks>
        /// <returns>
        /// A RecordType enum value (Standard / Tailored), or null when the character is neither S nor T.
        /// </returns>
        public static string Field52(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'S' => "(S) Standard - data suitable for any user of the dataset.",
                'T' => "(T) Tailored - data placed on the file for one specific customer's use only.",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.7 "Route Type"
        /// </summary>
        /// <remarks>
        /// Classifies the airway, SID, STAR, approach or preferred route that the record belongs to; on
        /// approach records it is a three-part code made of a primary route type plus two qualifiers.
        /// <para>FAA: Enroute airways: the FAA uses only "O" for conventional routes and "R" for RNAV routes. Measured on 19,099 ER records: O = 13,304, R = 5,795, nothing else. Approaches: ARINC 424-19 is applied for the route type at column 20 (offset 19) and for Route Qualifier 1 at column 119 (offset 118). Concretely, RNAV (RNP) approaches get route type "H" and Qualifier 1 "F". Measured: 3,157 PF records with H, e</para>
        /// <para>Blank: Route type not applicable. On approach qualifier columns, blank means the source documentation does not require a qualifier.</para>
        /// </remarks>
        /// <returns>
        /// A resolved description string (or an enum member) for the given code. The converter MUST take the
        /// record's section and subsection - and, for approaches, which of the three columns is being decoded -
        /// as parameters: Field57(char code, string sectionSubsection, RouteTypeSlot slot). Decoding a SID '4'
        /// against the approach table, or an approach 'R' against the enroute table, silently produces a wrong
        /// but plausible answer.
        /// </returns>
        public static string Field57(char fieldValue, char sectionCode, char subsectionCode)
        {
            if (fieldValue == ' ')
                return string.Empty;

            // Route Type has no single meaning: the same character means different things on an
            // airway, a SID, a STAR and an approach. The section and subsection therefore have
            // to come in with the value.
            return sectionCode switch
            {
                'E' => RouteTypeEnroute(fieldValue),
                'P' or 'H' => subsectionCode switch
                {
                    'D' => RouteTypeSid(fieldValue),
                    'E' => RouteTypeStar(fieldValue),
                    'F' => RouteTypeApproach(fieldValue),
                    _   => fieldValue.ToString()
                },
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.9 "SID/STAR Route Identifier" — BasicIndicator column
        /// </summary>
        /// <remarks>
        /// Six-column name of the SID or STAR, made up of a basic indicator followed by a single-digit validity
        /// (revision) number.
        /// </remarks>
        public static string Field59BasicIndicator(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.9 "SID/STAR Route Identifier" — ValidityIndicator column
        /// </summary>
        /// <remarks>
        /// Six-column name of the SID or STAR, made up of a basic indicator followed by a single-digit validity
        /// (revision) number.
        /// </remarks>
        public static string Field59ValidityIndicator(char fieldValue)
        {
            return fieldValue == ' ' ? string.Empty : fieldValue.ToString();
        }

        /// <summary>
        /// CIFP field 5.10 "Approach Route Identifier"
        /// </summary>
        /// <remarks>
        /// Names the specific published approach procedure, encoding the approach type, the runway it serves,
        /// and a suffix that separates several approaches of the same type to the same runway.
        /// <para>FAA: The FAA applies ARINC 424-19 (not -18) to this field, so the circle-to-land three-letter mnemonic table of -19 is the one in force. For RNAV (RNP) procedures the FAA puts H in column 1 of the identifier for the final and missed approach segments (and H in Route Type column 20 with F in Route Qualifier 1). All of the observed H## values are RNP procedures, not helicopter procedures. Alternate misse</para>
        /// <para>Blank: Not an approach record. On the approach (PF/HF) records the FAA always populates this field.</para>
        /// </remarks>
        /// <returns>
        /// The trimmed identifier string (null when the slice is all blanks), plus - if the converter is made
        /// structured - ApproachTypeLetter (char), RunwayNumber (int?), RunwayDesignator (char?),
        /// MultipleIndicator (char?) and a flag saying which of the three shapes was matched.
        /// </returns>
        public static string Field510(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.11 "Transition Identifier"
        /// </summary>
        /// <remarks>
        /// Names the transition a procedure leg belongs to - the enroute transition, the runway transition, or
        /// the approach/missed-approach transition - so that legs can be grouped into the correct branch of a
        /// SID, STAR or approach.
        /// <para>FAA: The FAA CIFP readme does not add any rule of its own for this field beyond the general statement that the file follows ARINC 424-18.</para>
        /// <para>Blank: This leg belongs to the common/core portion of the procedure, or to an approach final segment, which by rule carries no transition name.</para>
        /// </remarks>
        /// <returns>
        /// The trimmed transition name, or null when the slice is all blanks. Callers usually also want a
        /// derived flag for the two reserved forms - IsAllRunways (value == "ALL") and IsBothParallels (matches
        /// RW\d\dB).
        /// </returns>
        public static string Field511(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.12 "Sequence Number"
        /// </summary>
        /// <remarks>
        /// Orders the records that together define one thing - the legs of a route, the vertices of an airspace
        /// boundary, or the several primary records needed to describe one item.
        /// <para>FAA: The FAA readme adds no rule for this field. Note that the FAA MSA (PS, HS) record layout has no sequence number column at all, so the 1-character MSA/TAA/cruise-table variant described in ARINC never occurs in this file.</para>
        /// <para>Blank: Never blank on any record type that carries this field in the FAA CIFP.</para>
        /// </remarks>
        /// <returns>
        /// The integer value of the slice. Return null only if the slice is blank or non-numeric, which does
        /// not occur in a well-formed FAACIFP18.
        /// </returns>
        public static int? Field512(ReadOnlySpan<char> fieldValue)
        {
            return CifpSpan.ToInt(fieldValue);
        }

        /// <summary>
        /// CIFP field 5.13 "Fix Identifier"
        /// </summary>
        /// <remarks>
        /// Holds the identifier of the fix this record is about - an enroute or terminal waypoint, a VHF or NDB
        /// navaid, an airport, or a runway threshold expressed as a fix.
        /// <para>FAA: The FAA excludes waypoints whose identifiers are entirely numeric. Fixes classified as offshore may carry an area code of USA with an ICAO code of "K " or "P " (letter followed by a blank). Terminal waypoints are published as PC records when used at a single airport and not on an airway, otherwise as EA records; NDBs get a PN record under the same conditions.</para>
        /// <para>Blank: The leg has no terminating fix - typical of legs that end on an altitude, a heading intercept or a manual termination (VA, VI, VM, CA and similar path terminators).</para>
        /// </remarks>
        /// <returns>
        /// The trimmed identifier, or null when the slice is blank. Pair it with the adjoining ICAO code,
        /// section and subsection to form the reference key.
        /// </returns>
        public static string Field513(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.14 "ICAO Code"
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// <para>Blank: No geographic qualifier applies to this record, or the referenced object is not geographically categorised.</para>
        /// </remarks>
        /// <returns>
        /// The two raw characters with the trailing blank preserved, or null when both characters are blank. Do
        /// not Trim() this field.
        /// </returns>
        public static string Field514(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.TrimEnd();
            return value.IsEmpty ? string.Empty : value.ToString();
        }

        /// <summary>
        /// CIFP field 5.16 "Continuation Record Number"
        /// </summary>
        /// <remarks>
        /// Marks whether a record is a primary record and whether continuation records follow it, and numbers
        /// the continuations in order.
        /// <para>FAA: The FAA emits only 0, 1 and 2. Continuations exist for exactly two things: approach level-of- service continuation records on PF/HF (6,742 pairs), and controlling agency continuation records on UR (1,175 pairs). Every other record type in the file is 0 throughout.</para>
        /// <para>Blank: Does not occur in the FAA CIFP; every record that carries this column has a value.</para>
        /// </remarks>
        /// <returns>
        /// The raw character, with helper predicates IsPrimary (0 or 1) and IsContinuation (anything else).
        /// </returns>
        public static string Field516(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                '0' => "(0) Primary record with no continuations",
                '1' => "(1) Primary record; one or more continuations follow",
                '2' => "(2) First continuation record",
                '3' => "(3) Second continuation record",   // not present in the current FAA cycle
                '4' => "(4) Third continuation record",   // not present in the current FAA cycle
                '5' => "(5) Fourth continuation record",   // not present in the current FAA cycle
                '6' => "(6) Fifth continuation record",   // not present in the current FAA cycle
                '7' => "(7) Sixth continuation record",   // not present in the current FAA cycle
                '8' => "(8) Seventh continuation record",   // not present in the current FAA cycle
                '9' => "(9) Eighth continuation record",   // not present in the current FAA cycle
                'A' => "(A) Ninth continuation record; A-Z continue the count past 9",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.17 "Waypoint Description Code" — FixFunction1 column
        /// </summary>
        /// <remarks>
        /// Four independent single-character flags describing the fix on this leg: what kind of thing the fix
        /// is, whether it must be flown over or ends the segment, and two columns of approach/enroute function
        /// such as step-down fix, IAF, FAF or missed approach point.
        /// </remarks>
        public static string Field517FixFunction1(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Unnamed step-down fix inside the final approach segment (between the FAF and the MAP)",   // not present in the current FAA cycle
                'B' => "(B) Unnamed step-down fix in the intermediate segment (between the FACF and the FAF)",   // not present in the current FAA cycle
                'C' => "(C) ATC compulsory reporting point",   // not present in the current FAA cycle
                'G' => "(G) Oceanic gateway waypoint - start or end of an organised track system",   // not present in the current FAA cycle
                'M' => "(M) First leg of the missed approach procedure - coded on the leg that follows the leg carrying M in column 43",
                'P' => "(P) Path point fix, supporting an RNAV GPS/GLS final approach segment data block",   // not present in the current FAA cycle
                'R' => "(R) Fix at which the final approach course changes - the begin or end fix of an RF leg. 424-19A code; it outranks a step-down code at the same fix",
                'S' => "(S) Named step-down fix",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.17 "Waypoint Description Code" — FixFunction2 column
        /// </summary>
        /// <remarks>
        /// Four independent single-character flags describing the fix on this leg: what kind of thing the fix
        /// is, whether it must be flown over or ends the segment, and two columns of approach/enroute function
        /// such as step-down fix, IAF, FAF or missed approach point.
        /// </remarks>
        public static string Field517FixFunction2(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) Initial approach fix (IAF)",
                'B' => "(B) Intermediate approach fix (IF), not coded as a final approach course fix",
                'C' => "(C) Initial approach fix that also has a published hold",   // not present in the current FAA cycle
                'D' => "(D) Initial approach fix that is also the final approach course fix",
                'E' => "(E) Final end point (FEP), used in the vertical coding of non-precision approaches",   // not present in the current FAA cycle
                'F' => "(F) Final approach fix (FAF)",
                'G' => "(G) 424-19A only: source-provided enroute waypoint without a hold",   // not present in the current FAA cycle
                'H' => "(H) Holding fix. In 424-19A this is narrowed to a source-provided waypoint with a hold",   // not present in the current FAA cycle
                'I' => "(I) Final approach course fix (FACF)",
                'M' => "(M) Published missed approach point (MAP)",
                'N' => "(N) 424-19A only: engine-out SID / missed approach disarm point",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.17 "Waypoint Description Code" — FixType column
        /// </summary>
        /// <remarks>
        /// Four independent single-character flags describing the fix on this leg: what kind of thing the fix
        /// is, whether it must be flown over or ends the segment, and two columns of approach/enroute function
        /// such as step-down fix, IAF, FAF or missed approach point.
        /// </remarks>
        public static string Field517FixType(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'A' => "(A) The fix is an airport reference point",
                'E' => "(E) Essential waypoint - a named waypoint required to define the route (course change, airway crossing, segment start or end)",
                'F' => "(F) Off-airway floating waypoint - published by the government but not part of any route structure",   // not present in the current FAA cycle
                'G' => "(G) The fix is a runway threshold or a helipad",
                'H' => "(H) The fix is a heliport reference point",   // not present in the current FAA cycle
                'N' => "(N) The fix is an NDB navaid",
                'P' => "(P) Phantom waypoint - created during procedure coding to sit on the nominal track",   // not present in the current FAA cycle
                'R' => "(R) Non-essential waypoint on an airway",   // not present in the current FAA cycle
                'T' => "(T) Transition-essential waypoint - used to move between the enroute and terminal structures",   // not present in the current FAA cycle
                'V' => "(V) The fix is a VHF navaid",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.17 "Waypoint Description Code" — FlyOverOrEndOfSegment column
        /// </summary>
        /// <remarks>
        /// Four independent single-character flags describing the fix on this leg: what kind of thing the fix
        /// is, whether it must be flown over or ends the segment, and two columns of approach/enroute function
        /// such as step-down fix, IAF, FAF or missed approach point.
        /// </remarks>
        public static string Field517FlyOverOrEndOfSegment(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'B' => "(B) Both at once - the fix is a fly-over fix and it also ends the continuous segment",
                'E' => "(E) End of the continuous segment: last leg of an airway, of a procedure transition, at a gap in an airway definition, or where the next leg changes ARINC area code",
                'U' => "(U) Uncharted airway intersection - a waypoint on an airway that was not established by the government source (used only with E in column 40)",   // not present in the current FAA cycle
                'Y' => "(Y) Fly-over fix - the aircraft must pass over the fix before starting the manoeuvre defined by the next leg",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.18 "Boundary Code"
        /// </summary>
        /// <remarks>
        /// On an enroute airway leg, marks that the route crosses into a different world area at this point and
        /// names the area being entered or left.
        /// <para>FAA: The readme says nothing about this field directly, but it does say non-U.S. airways - including Canadian ones - are no longer carried. The 'C' entries that survive are boundary markers on legs that leave U.S. airspace, not Canadian route data.</para>
        /// <para>Blank: The airway leg does not cross a geographic area boundary at this fix. This is the normal case - 19,057 of 19,099 enroute airway primary records are blank.</para>
        /// </remarks>
        /// <returns>
        /// A BoundaryCode enum naming the world area, or null when the slice is blank.
        /// </returns>
        public static string Field518(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'U' => "(U) United States (area code USA).",
                'C' => "(C) Canada and Alaska (area code CAN).",
                'P' => "(P) Pacific (area code PAC).",
                'L' => "(L) Latin America (area code LAM).",
                'S' => "(S) South America (area code SAM).",   // not present in the current FAA cycle
                '1' => "(1) South Pacific (area code SPA).",   // not present in the current FAA cycle
                'E' => "(E) Europe (area code EUR).",   // not present in the current FAA cycle
                '2' => "(2) Eastern Europe (area code EEU).",   // not present in the current FAA cycle
                'M' => "(M) Middle East and South Asia (area code MES).",   // not present in the current FAA cycle
                'A' => "(A) Africa (area code AFR).",   // not present in the current FAA cycle

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.19 "Level"
        /// </summary>
        /// <remarks>
        /// Says whether the airway or airspace record belongs to the low-altitude structure, the high-altitude
        /// structure, or applies at all altitudes.
        /// <para>FAA: The readme gives an explicit rule for airways and ATS routes: Level is 'L' when the route identifier starts with V or T, 'H' when it starts with J or Q, and blank otherwise. That rule is borne out by the data - 13,219 'L', 3,761 'H' and 2,119 blank on ER primaries.</para>
        /// <para>Blank: No level assigned. On FAA airways this means the route identifier does not begin with V, T, J or Q. On Class B/C/D airspace records the field is always blank.</para>
        /// </remarks>
        /// <returns>
        /// An AirwayLevel enum (Both / High / Low), or null when blank.
        /// </returns>
        public static string Field519(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'B' => "(B) Both - the record applies to all altitudes, high and low.",
                'H' => "(H) High level structure (jet routes, Q routes, high-altitude airspace).",
                'L' => "(L) Low level structure (Victor airways, T routes, low-altitude airspace).",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.20 "Turn Direction"
        /// </summary>
        /// <remarks>
        /// Forces the direction of turn on a terminal procedure leg or course reversal.
        /// <para>FAA: Not mentioned in the FAA readme. In practice only 25,904 of 201,114 procedure leg records carry a direction, and 'E' (either) is essentially unused - it appears on just 2 records.</para>
        /// <para>Blank: No turn direction is specified for this leg - the aircraft turns the short way, or the leg geometry makes the direction unambiguous.</para>
        /// </remarks>
        /// <returns>
        /// A TurnDirection enum (Left / Right / Either), or null when blank.
        /// </returns>
        public static string Field520(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'L' => "(L) Turn left.",
                'R' => "(R) Turn right.",
                'E' => "(E) Either direction is acceptable.",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.21 "Path and Termination"
        /// </summary>
        /// <remarks>
        /// Two-letter code defining both the geometry of the path flown on this procedure leg and the condition
        /// that ends it.
        /// <para>FAA: The FAA readme does not enumerate leg types, but two of its rules bear directly on this field. RF legs are coded as fly-by except when followed by an Hx (holding) leg. And a CA leg may be used as the first leg of a missed approach - when the source gives no mandatory altitude, the FAA codes the lowest of the DA, the MDA, or 400 feet above airport elevation.</para>
        /// <para>Blank: Not a flyable leg record. Blank appears on procedure rows that are not leg definitions (6,742 rows in the shipped file once continuation records are included); a primary leg record always carries a code.</para>
        /// </remarks>
        /// <returns>
        /// A PathTermination enum value covering all 23 codes, or null when the two characters are blank. The
        /// converter should also expose the path half and the terminator half separately, since almost every
        /// downstream rule keys off one or the other.
        /// </returns>
        public static string Field521(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return string.Empty;

            return value switch
            {
                "IF" => "(IF) Initial Fix. Not a flown path at all - it plants the start of a procedure or transition on a named database fix so the next leg has somewhere to begin. Also used mid-sequence when a fix must be re-anchored (for example between an FX/HX/PI leg and the next leg when the altitude constraints at each end differ). 43,906 records - the second most common leg in the file.",
                "TF" => "(TF) Track to a Fix. A great-circle track from the previous leg's termination fix to this record's fix. The default RNAV leg: both ends are known database fixes, so the path is fully determined without a course value. Preferred over CF whenever the resulting path is the same. 95,119 records - by far the most common leg.",
                "CF" => "(CF) Course to a Fix. Fly the specified magnetic course (5.26) and terminate at this record's fix. Unlike TF the course is stated explicitly, which matters when the inbound course is published and must be flown even if it differs slightly from the direct track - classic final approach coding. The distance field must always be filled in on a CF; when the CF follows an intercept it holds the no-wind intercept distance. 12,878 records.",
                "DF" => "(DF) Direct to a Fix. From an unspecified present position, proceed direct to this record's fix. Used whenever the previous leg ended somewhere unknown - at an altitude, a DME distance or a manual termination - so no track can be pre-computed. The preceding fix or termination must be overflown. 9,981 records.",
                "FA" => "(FA) Fix to an Altitude. From the named fix, hold the specified track until reaching the altitude in Altitude 1. The end point is wherever the climb or descent reaches that altitude, so it is not a fixed geographic position. The altitude is always an at-or-above constraint. 64 records.",
                "FC" => "(FC) Track from a Fix for a Distance. From the named fix, fly the specified track for the ALONG-PATH distance in field 5.27. Use FC (not FD) when the distance is measured along the path from the fix itself. Not used when the distance exceeds 60 NM and a CF follows. 600 records.",
                "FD" => "(FD) Track from a Fix to a DME Distance. From the named fix, fly the specified track until reaching a stated DME distance from the Recommended Navaid - the distance is slant range from a facility, not distance travelled. The termination point is overflown. Not used when the distance exceeds 60 NM and a CF follows. NOT PRESENT in the FAA CIFP.",   // not present in the current FAA cycle
                "FM" => "(FM) Track from a Fix to a Manual termination. From the named fix, fly the specified track until ATC intervenes - radar vectors, or an instruction to proceed. Used where a SID or STAR ends 'expect vectors'. On a SID the heading must come from source documentation. 1,703 records.",
                "CA" => "(CA) Course to an Altitude. Fly the specified magnetic course until reaching an altitude; there is no fix and no defined end point on the ground. The workhorse first leg of a runway-transition departure ('climb runway heading to 1000') and a common first leg of a missed approach. Termination altitude is at-or-above. 9,664 records.",
                "CD" => "(CD) Course to a DME Distance. Fly the specified course until reaching a stated DME distance from the Recommended Navaid. Overflies its termination point, so no turn anticipation. When a CD is followed by an AF leg, both must reference the same navaid at the same DME distance. Only 5 records in the whole file.",
                "CI" => "(CI) Course to an Intercept. Fly the specified course until it intercepts the path of the NEXT leg; the leg has no end point of its own. If a Recommended Navaid is coded it must be the same navaid as the leg being intercepted. Only 16 records.",
                "CR" => "(CR) Course to a Radial termination. Fly the specified course until crossing a named radial from a specific VOR. Overflies its termination point. NOT PRESENT in the FAA CIFP.",   // not present in the current FAA cycle
                "RF" => "(RF) Constant Radius to a Fix. A circular arc of the radius in field 5.204, about a centre fix, tangent to the inbound and outbound tracks, ending at this record's fix. The RNP-AR curved-path leg. Limited to turns of at least 2 and at most 300 degrees; the neighbouring legs must be tangent to the arc except for IF/RF, RF/RF and RF/Hx combinations. Overflies its termination point. 1,439 records.",
                "AF" => "(AF) Arc to a Fix. A DME arc flown at a constant distance from the Recommended Navaid, ending at this record's fix. Rho (5.25) is the arc radius, Theta (5.24) is the radial to the terminating fix and Outbound Magnetic Course (5.26) is the boundary radial where the arc begins. When the source's arc centre is a VOR/DME or VORTAC and the path is charted as a DME arc, AF must be used instead of RF. 1,210 records.",
                "VA" => "(VA) Heading to an Altitude. Fly a HEADING - no wind correction - until reaching an altitude. Ground track is undefined, so the leg cannot end at a fix. Used off the runway when the published instruction is a heading rather than a course. Termination altitude is at-or-above. 2,074 records.",
                "VD" => "(VD) Heading to a DME Distance. Fly a heading until reaching a stated DME distance from the Recommended Navaid. Overflies its termination point. If a VD is followed by an AF leg both must use the same navaid and the same distance. 71 records.",
                "VI" => "(VI) Heading to an Intercept. Fly a heading until intercepting the next leg's path. If a Recommended Navaid is coded it must match the navaid of the leg being intercepted. Standard construction for 'fly heading 090, vectors to intercept the localizer'. 2,494 records.",
                "VM" => "(VM) Heading to a Manual termination. Fly a heading until ATC intervenes. The usual way to end a STAR in vectors or to code a departure that hands off to radar. 1,790 records.",
                "VR" => "(VR) Heading to a Radial termination. Fly a heading until crossing a named radial from a specific VOR. Overflies its termination point. 30 records.",
                "PI" => "(PI) Procedure turn (the 45/180 course reversal). Starts at a named database fix, flies an outbound leg, turns 45 degrees, then reverses 180 degrees to intercept the next leg. The outbound course is coded 45 degrees off the reciprocal of the inbound course unless source says otherwise, a one-minute outbound leg is implied, and field 5.27 carries the MAXIMUM EXCURSION distance from the fix (not a path length). The PI fix must be the same fix that terminated the previous leg. Turn Direction (5.20) gives the direction of the 180-degree reversal. 1,076 records.",
                "HA" => "(HA) Hold to an Altitude. Enter the holding pattern at the named fix and keep circling until reaching the altitude in Altitude 1, then leave. A climb-in-hold. Leg time or distance is in field 5.27; on RNP holds the turn radius is in 5.204. Termination altitude is at-or-above. Only 78 records.",
                "HF" => "(HF) Hold, terminating at the Fix after a single circuit. One trip round the pattern and then continue on course - this is the 'hold in lieu of procedure turn' used to lose altitude or reverse course on an approach. Leg time or distance is in field 5.27. 6,691 records.",
                "HM" => "(HM) Hold, Manual termination. Enter the pattern at the named fix and stay there until ATC clears you out. The standard end of a missed approach. Leg time or distance is in field 5.27. 10,225 records - the fourth most common leg in the file.",

                // Return unrecognized values as-is.
                _ => value.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.22 "Turn Direction Valid"
        /// </summary>
        /// <remarks>
        /// Flags that the direction in Turn Direction (5.20) is a hard requirement that must be flown before
        /// joining this leg's path.
        /// <para>FAA: Not addressed in the FAA readme.</para>
        /// <para>Blank: No turn is required before the leg's path is captured; Turn Direction (5.20), if present, only governs the turn onto the path itself.</para>
        /// </remarks>
        /// <returns>
        /// true when the slice is 'Y', otherwise false.
        /// </returns>
        public static string Field522(char fieldValue)
        {
            if (fieldValue == ' ')
                return string.Empty;

            return fieldValue switch
            {
                'Y' => "(Y) A turn in the direction given by field 5.20 is required before the leg path is captured.",

                // Return unrecognized characters as-is.
                _ => fieldValue.ToString()
            };
        }

        /// <summary>
        /// CIFP field 5.24 "Theta"
        /// </summary>
        /// <remarks>
        /// Magnetic bearing from the Recommended Navaid to this record's fix, in tenths of a degree with the
        /// decimal point removed.
        /// <para>FAA: Not mentioned in the FAA readme.</para>
        /// <para>Blank: No bearing is defined for this record - either the leg type does not use one or no Recommended Navaid is coded. 176,912 of 201,114 procedure leg primaries are blank.</para>
        /// </remarks>
        /// <returns>
        /// Bearing in decimal degrees (raw integer divided by 10.0), or null when blank.
        /// </returns>
        public static double? Field524(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.25 "Rho"
        /// </summary>
        /// <remarks>
        /// Geodesic distance from the Recommended Navaid to this record's fix, in tenths of a nautical mile
        /// with the decimal point removed.
        /// <para>FAA: Not mentioned in the FAA readme.</para>
        /// <para>Blank: No distance is defined for this record. 178,376 of 201,114 procedure leg primaries are blank.</para>
        /// </remarks>
        /// <returns>
        /// Distance in decimal nautical miles (raw integer divided by 10.0), or null when blank.
        /// </returns>
        public static double? Field525(ReadOnlySpan<char> fieldValue)
        {
            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.26 "Outbound Magnetic Course"
        /// </summary>
        /// <remarks>
        /// The course, heading or radial for the leg, in tenths of a degree with the decimal point removed -
        /// magnetic unless the last character is 'T'.
        /// <para>FAA: Not mentioned in the readme, but the FAA never uses the true-degrees form: zero of the 3,544 distinct procedure values and zero airway values end in 'T'. Handle it anyway - non-FAA procedure coding is admitted into the file.</para>
        /// <para>Blank: No course, heading or radial applies to this record. 145,046 of 201,114 procedure leg primaries and 1,720 of 19,099 airway primaries are blank.</para>
        /// </remarks>
        /// <returns>
        /// Course in decimal degrees, plus a flag or separate property saying whether it is magnetic or true.
        /// Null when blank.
        /// </returns>
        public static double? Field526(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            // A trailing 'T' marks a course referenced to True North; otherwise the last
            // digit is tenths of a degree magnetic.
            if (fieldValue[3] == 'T')
                return CifpSpan.ToInt(fieldValue[..3]);

            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.27 "Route Distance From / Holding Distance or Time"
        /// </summary>
        /// <remarks>
        /// Either a distance in tenths of a nautical mile or, when prefixed with 'T', a holding leg time in
        /// tenths of a minute.
        /// <para>FAA: Not mentioned in the readme. In practice the FAA uses only two time values - 'T010' (4,320 records) and 'T015' (5 records) - so essentially every FAA holding leg is a standard one-minute pattern.</para>
        /// <para>Blank: The leg type does not require a distance or time. 164,126 of 201,114 procedure leg primaries and 1,720 of 19,099 airway primaries are blank.</para>
        /// </remarks>
        /// <returns>
        /// A decoded value plus a unit discriminator - nautical miles when the slice is all digits, minutes
        /// when it starts with 'T'. Null when blank.
        /// </returns>
        public static double? Field527(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            // A leading 'T' means the value is a holding TIME in tenths of a minute.
            // Otherwise it is a DISTANCE in tenths of a nautical mile. Read this together
            // with Field527IsTime so the unit is never guessed.
            ReadOnlySpan<char> digits = fieldValue[0] == 'T' ? fieldValue[1..] : fieldValue;
            int? raw = CifpSpan.ToInt(digits);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.28 "Inbound Magnetic Course"
        /// </summary>
        /// <remarks>
        /// Published magnetic course inbound to the fix named in the record, expressed in tenths of a degree
        /// with the decimal point removed.
        /// <para>Blank: No published inbound course for this airway segment.</para>
        /// </remarks>
        /// <returns>
        /// A double? of degrees (raw / 10.0) plus a bool telling the caller whether the course is true rather
        /// than magnetic. Return null for the all-blank slice.
        /// </returns>
        public static double? Field528(ReadOnlySpan<char> fieldValue)
        {
            if (fieldValue.IsWhiteSpace())
                return null;

            if (fieldValue[3] == 'T')
                return CifpSpan.ToInt(fieldValue[..3]);

            int? raw = CifpSpan.ToInt(fieldValue);
            return raw is null ? null : raw.Value / 10.0;
        }

        /// <summary>
        /// CIFP field 5.30 "Altitude/Minimum Altitude"
        /// </summary>
        /// <remarks>
        /// Five-column altitude that may be feet MSL, a negative elevation, a flight level, or one of two
        /// alphabetic sentinels meaning the minimum altitude is unknown or unestablished.
        /// <para>FAA: For airways the FAA codes the point-to-point MEA here. A conventional route gets the conventional MEA; an RNAV route gets the GNSS MEA, falling back to the conventional MEA when no GNSS value is published.</para>
        /// <para>Blank: No altitude constraint applies at this fix or for this direction of flight.</para>
        /// </remarks>
        /// <returns>
        /// An int? of feet (negative allowed) together with a flag distinguishing an MSL altitude from a flight
        /// level, plus a small enum or nullable flag carrying UNKNN / NESTB. Return null for blank.
        /// </returns>
        public static int? Field530(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.IsEmpty)
                return null;

            // UNKNN = altitude unknown, NESTB = not established. Both are sentinels, not values.
            if (value.SequenceEqual("UNKNN") || value.SequenceEqual("NESTB"))
                return null;

            // A flight level is normalised to feet so callers never mix the two scales.
            if (value.StartsWith("FL"))
            {
                int? level = CifpSpan.ToInt(value[2..]);
                return level is null ? null : level.Value * 100;
            }

            return CifpSpan.ToInt(value);
        }

        /// <summary>
        /// CIFP field 5.32 "Cycle Date"
        /// </summary>
        /// <remarks>
        /// Two-digit year plus two-digit 28-day update cycle recording when the record was added or last
        /// changed.
        /// <para>FAA: The FAA states that cycle dates are set to the most recent cycle on every new record and on every record it modifies. Consequently the newest cycle value in the file identifies the CIFP volume itself.</para>
        /// <para>Blank: Never blank in the FAA CIFP.</para>
        /// </remarks>
        /// <returns>
        /// A small struct or record carrying int Year (four-digit, resolved by a century rule) and int Cycle,
        /// plus the original four characters for round-tripping. Do not attempt to convert to a DateTime
        /// without an AIRAC epoch table - the field names a 28-day window, not a day.
        /// </returns>
        public static string Field532(ReadOnlySpan<char> fieldValue)
        {
            ReadOnlySpan<char> value = fieldValue.Trim();
            if (value.Length != 4)
                return string.Empty;

            int? year  = CifpSpan.ToInt(value[..2]);
            int? cycle = CifpSpan.ToInt(value.Slice(2, 2));
            if (year is null || cycle is null)
                return value.ToString();

            // Two-digit year, so a century has to be assumed. ARINC 424 data does not predate
            // 1990, which makes a 90-99 / 00-89 split unambiguous for the life of the format.
            int fullYear = year.Value >= 90 ? 1900 + year.Value : 2000 + year.Value;
            return $"{fullYear} cycle {cycle.Value:00}";
        }

    }
}