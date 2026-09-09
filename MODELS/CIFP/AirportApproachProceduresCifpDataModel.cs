using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - AirportApproachProcedures (PF) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.9.1 Approach (Approaches-PF). Identified by Section Code 'P' and Subsection
    /// Code 'F'. Continuation Record Number is at zero-based index 38; '0' or '1' marks a primary record
    /// and anything else a continuation.
    /// </remarks>
    public class AirportApproachProceduresCifpDataModel
    {
        /// <summary>
        /// The complete, unmodified 132-character source record.
        /// </summary>
        /// <remarks>
        /// Kept so that any field can be re-sliced and so an unexpected value can always be traced
        /// back to its source line. Populated only when CifpParseOptions.KeepRawRecord is true.
        /// </remarks>
        public string? RawRecord { get; set; }

        /// <summary>
        /// Record Type
        /// _Ref: 5.2
        /// _Idx: 0
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 flag saying whether the record belongs to the universally applicable dataset or to a
        /// customer-specific tailored set.
        /// <para>FAA: The FAA readme does not discuss this field. Across all 396,430 records the value is always 'S'.</para>
        /// </remarks>
        public string RecordType { get; set; }

        /// <summary>
        /// Customer/Area Code
        /// _Ref: 5.3
        /// _Idx: 1:3
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Three-letter code grouping each record into a broad geographic region (or, in airline-tailored
        /// files, naming the airline the record was built for).
        /// <para>FAA: Fixes that NASR classifies as 'Offshore' may be given a Customer/Area Code of USA paired with an ICAO Code (5.14) of 'K ' or 'P ' (single letter plus a blank). Terminal waypoint (PC) records inherit the Customer/Area Code of their parent airport regardless of where the waypoint itself sits, even though those same PC records keep their own distinct ICAO Code (5.14). Do not infer geography for a PC </para>
        /// </remarks>
        public string? CustomerAreaCode { get; set; }

        /// <summary>
        /// Section Code
        /// _Ref: 5.4
        /// _Idx: 4
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter naming the major database section a record belongs to - or, on pointer fields, the
        /// section of the record being referenced.
        /// <para>FAA: The FAA readme does not call this field out directly, but it fixes the set of sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute waypoints and airways), H (heliports and heli terminal data), P (airport and terminal data) and U (controlled and special use airspace). No other section is produced.</para>
        /// </remarks>
        public string? SectionCode { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 5
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Airport Identifier
        /// _Ref: 5.6
        /// _Idx: 6:9
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Four-character identifier of the airport or heliport that owns, or is referenced by, the data in the
        /// record.
        /// <para>FAA: The FAA uses the published ICAO airport identifier when one exists; when there is none it falls back to the published FAA identifier. On the Airport (PA) record the IATA field (5.107) is used to carry the FAA identifier instead, and that IATA field is left blank whenever the airport identifier here is already four characters long.</para>
        /// </remarks>
        public string? AirportIdentifier { get; set; }

        /// <summary>
        /// Airport ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 10:11
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string AirportIcaoLocationCode { get; set; }

        /// <summary>
        /// Subsection Code
        /// _Ref: 5.5
        /// _Idx: 12
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter that, combined with the Section Code, names the exact file a record belongs to - the
        /// primary key for record dispatch.
        /// <para>FAA: The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB, PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF (primary and Level of Service continuation), HF (primary and Level of Service continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC matrix below is absent. The FAA chooses between PC and EA for a named ter</para>
        /// </remarks>
        public string? SubsectionCode { get; set; }

        /// <summary>
        /// SID/STAR/Approach Identifier
        /// _Ref: 5.10
        /// _Idx: 13:18
        /// _MaxLength: 6
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Names the specific published approach procedure, encoding the approach type, the runway it serves,
        /// and a suffix that separates several approaches of the same type to the same runway.
        /// <para>FAA: The FAA applies ARINC 424-19 (not -18) to this field, so the circle-to-land three-letter mnemonic table of -19 is the one in force. For RNAV (RNP) procedures the FAA puts H in column 1 of the identifier for the final and missed approach segments (and H in Route Type column 20 with F in Route Qualifier 1). All of the observed H## values are RNP procedures, not helicopter procedures. Alternate misse</para>
        /// <para>Layout note: SID/STAR IDs, see Section 5.9. IAP IDs, see Section 5.10.</para>
        /// </remarks>
        public string SidStarApproachIdentifier { get; set; }

        /// <summary>
        /// Route Type
        /// _Ref: 5.7
        /// _Idx: 19
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Classifies the airway, SID, STAR, approach or preferred route that the record belongs to; on
        /// approach records it is a three-part code made of a primary route type plus two qualifiers.
        /// <para>FAA: Enroute airways: the FAA uses only "O" for conventional routes and "R" for RNAV routes. Measured on 19,099 ER records: O = 13,304, R = 5,795, nothing else. Approaches: ARINC 424-19 is applied for the route type at column 20 (offset 19) and for Route Qualifier 1 at column 119 (offset 118). Concretely, RNAV (RNP) approaches get route type "H" and Qualifier 1 "F". Measured: 3,157 PF records with H, e</para>
        /// </remarks>
        public string RouteType { get; set; }

        /// <summary>
        /// Transition Identifier
        /// _Ref: 5.11
        /// _Idx: 20:24
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Names the transition a procedure leg belongs to - the enroute transition, the runway transition, or
        /// the approach/missed-approach transition - so that legs can be grouped into the correct branch of a
        /// SID, STAR or approach.
        /// <para>FAA: The FAA CIFP readme does not add any rule of its own for this field beyond the general statement that the file follows ARINC 424-18.</para>
        /// </remarks>
        public string TransitionIdentifier { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 25
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Sequence Number
        /// _Ref: 5.12
        /// _Idx: 26:28
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Orders the records that together define one thing - the legs of a route, the vertices of an airspace
        /// boundary, or the several primary records needed to describe one item.
        /// <para>FAA: The FAA readme adds no rule for this field. Note that the FAA MSA (PS, HS) record layout has no sequence number column at all, so the 1-character MSA/TAA/cruise-table variant described in ARINC never occurs in this file.</para>
        /// </remarks>
        public int? SequenceNumber { get; set; }

        /// <summary>
        /// Fix Identifier
        /// _Ref: 5.13
        /// _Idx: 29:33
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Holds the identifier of the fix this record is about - an enroute or terminal waypoint, a VHF or NDB
        /// navaid, an airport, or a runway threshold expressed as a fix.
        /// <para>FAA: The FAA excludes waypoints whose identifiers are entirely numeric. Fixes classified as offshore may carry an area code of USA with an ICAO code of "K " or "P " (letter followed by a blank). Terminal waypoints are published as PC records when used at a single airport and not on an airway, otherwise as EA records; NDBs get a PN record under the same conditions.</para>
        /// </remarks>
        public string FixIdentifier { get; set; }

        /// <summary>
        /// Fix ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 34:35
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string FixIcaoLocationCode { get; set; }

        /// <summary>
        /// Fix Section Code
        /// _Ref: 5.4
        /// _Idx: 36
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter naming the major database section a record belongs to - or, on pointer fields, the
        /// section of the record being referenced.
        /// <para>FAA: The FAA readme does not call this field out directly, but it fixes the set of sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute waypoints and airways), H (heliports and heli terminal data), P (airport and terminal data) and U (controlled and special use airspace). No other section is produced.</para>
        /// </remarks>
        public string? FixSectionCode { get; set; }

        /// <summary>
        /// Fix Subsection Code
        /// _Ref: 5.5
        /// _Idx: 37
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter that, combined with the Section Code, names the exact file a record belongs to - the
        /// primary key for record dispatch.
        /// <para>FAA: The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB, PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF (primary and Level of Service continuation), HF (primary and Level of Service continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC matrix below is absent. The FAA chooses between PC and EA for a named ter</para>
        /// </remarks>
        public string? FixSubsectionCode { get; set; }

        /// <summary>
        /// Continuation Record Number
        /// _Ref: 5.16
        /// _Idx: 38
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Marks whether a record is a primary record and whether continuation records follow it, and numbers
        /// the continuations in order.
        /// <para>FAA: The FAA emits only 0, 1 and 2. Continuations exist for exactly two things: approach level-of- service continuation records on PF/HF (6,742 pairs), and controlling agency continuation records on UR (1,175 pairs). Every other record type in the file is 0 throughout.</para>
        /// </remarks>
        public string ContinuationRecordNumber { get; set; }

        /// <summary>
        /// Waypoint Description Code - FixType
        /// _Ref: 5.17
        /// _Idx: 39
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.17 (Waypoint Description Code). Four independent single-character
        /// flags describing the fix on this leg: what kind of thing the fix is, whether it must be flown over
        /// or ends the segment, and two columns of approach/enroute function such as step-down fix, IAF, FAF or
        /// missed approach point.
        /// </remarks>
        public string WaypointDescriptionCodeFixType { get; set; }

        /// <summary>
        /// Waypoint Description Code - FlyOverOrEndOfSegment
        /// _Ref: 5.17
        /// _Idx: 40
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.17 (Waypoint Description Code). Four independent single-character
        /// flags describing the fix on this leg: what kind of thing the fix is, whether it must be flown over
        /// or ends the segment, and two columns of approach/enroute function such as step-down fix, IAF, FAF or
        /// missed approach point.
        /// </remarks>
        public string WaypointDescriptionCodeFlyOverOrEndOfSegment { get; set; }

        /// <summary>
        /// Waypoint Description Code - FixFunction1
        /// _Ref: 5.17
        /// _Idx: 41
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 3 of the composite field 5.17 (Waypoint Description Code). Four independent single-character
        /// flags describing the fix on this leg: what kind of thing the fix is, whether it must be flown over
        /// or ends the segment, and two columns of approach/enroute function such as step-down fix, IAF, FAF or
        /// missed approach point.
        /// </remarks>
        public string WaypointDescriptionCodeFixFunction1 { get; set; }

        /// <summary>
        /// Waypoint Description Code - FixFunction2
        /// _Ref: 5.17
        /// _Idx: 42
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.17 (Waypoint Description Code). Four independent single-character
        /// flags describing the fix on this leg: what kind of thing the fix is, whether it must be flown over
        /// or ends the segment, and two columns of approach/enroute function such as step-down fix, IAF, FAF or
        /// missed approach point.
        /// </remarks>
        public string WaypointDescriptionCodeFixFunction2 { get; set; }

        /// <summary>
        /// Turn Direction
        /// _Ref: 5.20
        /// _Idx: 43
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Forces the direction of turn on a terminal procedure leg or course reversal.
        /// <para>FAA: Not mentioned in the FAA readme. In practice only 25,904 of 201,114 procedure leg records carry a direction, and 'E' (either) is essentially unused - it appears on just 2 records.</para>
        /// </remarks>
        public string TurnDirection { get; set; }

        /// <summary>
        /// RNP
        /// _Ref: 5.211
        /// _Idx: 44:46
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The navigation accuracy required on this segment, encoded as two significant digits plus a negative
        /// decimal exponent.
        /// <para>FAA: The readme devotes a whole section to this field. The FAA populates RNP from the NAVSPEC values in FAA Order 8260.58C Table 1-2-1, using five rules: 1. On day-forward procedures, HF and HM (holding) legs are NOT coded with RNP values at all. 2. On amendments and abbreviated amendments, values match FAA Form 8260-3 Terminal Routes. 3. For P-NOTAMs requiring coding changes, values match Form 8260-3 </para>
        /// <para>Layout note: If the RNAV procedure has only one set of RNP criteria, it is in the Primary Record’s RNP value field; otherwise, one consistent set of RNP values represent the least restrictive operating criteria, without mixing values from different criteria.</para>
        /// </remarks>
        public double? Rnp { get; set; }

        /// <summary>
        /// Path and Termination
        /// _Ref: 5.21
        /// _Idx: 47:48
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Two-letter code defining both the geometry of the path flown on this procedure leg and the condition
        /// that ends it.
        /// <para>FAA: The FAA readme does not enumerate leg types, but two of its rules bear directly on this field. RF legs are coded as fly-by except when followed by an Hx (holding) leg. And a CA leg may be used as the first leg of a missed approach - when the source gives no mandatory altitude, the FAA codes the lowest of the DA, the MDA, or 400 feet above airport elevation.</para>
        /// </remarks>
        public string PathAndTermination { get; set; }

        /// <summary>
        /// Turn Direction Valid
        /// _Ref: 5.22
        /// _Idx: 49
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Flags that the direction in Turn Direction (5.20) is a hard requirement that must be flown before
        /// joining this leg's path.
        /// <para>FAA: Not addressed in the FAA readme.</para>
        /// </remarks>
        public string TurnDirectionValid { get; set; }

        /// <summary>
        /// Recommended Navaid
        /// _Ref: 5.23
        /// _Idx: 50:53
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Identifier of the ground navaid that the leg, waypoint or airport is referenced to - the facility
        /// that Theta (5.24) and Rho (5.25) are measured from.
        /// <para>FAA: The readme does not mention the field. In the shipped file it is populated only on procedure leg records (22,958 of 201,114 primaries, 1,968 distinct identifiers) and is blank on all 13,321 airport records, all 6,134 heliport records and all 19,099 enroute airway primary records - even though ARINC allows it on all three.</para>
        /// </remarks>
        public string? RecommendedNavaid { get; set; }

        /// <summary>
        /// Recommended Navaid ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 54:55
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string RecommendedNavaidIcaoLocationCode { get; set; }

        /// <summary>
        /// ARC Radius
        /// _Ref: 5.204
        /// _Idx: 56:61
        /// _MaxLength: 6
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The turn radius of a constant-radius arc leg or an RNP holding pattern, in thousandths of a nautical
        /// mile.
        /// <para>FAA: Not mentioned in the readme. In the shipped file 1,439 records carry a radius, 278 distinct values, ranging from 001060 (1.060 NM) to 024700 (24.700 NM). The count matches the number of RF legs exactly, so the FAA does not currently code RNP holding radii.</para>
        /// </remarks>
        public double? ArcRadius { get; set; }

        /// <summary>
        /// Theta
        /// _Ref: 5.24
        /// _Idx: 62:65
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Magnetic bearing from the Recommended Navaid to this record's fix, in tenths of a degree with the
        /// decimal point removed.
        /// <para>FAA: Not mentioned in the FAA readme.</para>
        /// </remarks>
        public double? Theta { get; set; }

        /// <summary>
        /// Rho
        /// _Ref: 5.25
        /// _Idx: 66:69
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Geodesic distance from the Recommended Navaid to this record's fix, in tenths of a nautical mile
        /// with the decimal point removed.
        /// <para>FAA: Not mentioned in the FAA readme.</para>
        /// </remarks>
        public double? Rho { get; set; }

        /// <summary>
        /// Magnetic Course
        /// _Ref: 5.26
        /// _Idx: 70:73
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The course, heading or radial for the leg, in tenths of a degree with the decimal point removed -
        /// magnetic unless the last character is 'T'.
        /// <para>FAA: Not mentioned in the readme, but the FAA never uses the true-degrees form: zero of the 3,544 distinct procedure values and zero airway values end in 'T'. Handle it anyway - non-FAA procedure coding is admitted into the file.</para>
        /// </remarks>
        public double? MagneticCourse { get; set; }

        /// <summary>
        /// Route Distance/Holding Distance or Time
        /// _Ref: 5.27
        /// _Idx: 74:77
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Either a distance in tenths of a nautical mile or, when prefixed with 'T', a holding leg time in
        /// tenths of a minute.
        /// <para>FAA: Not mentioned in the readme. In practice the FAA uses only two time values - 'T010' (4,320 records) and 'T015' (5 records) - so essentially every FAA holding leg is a standard one-minute pattern.</para>
        /// </remarks>
        public double? RouteDistanceHoldingDistanceOrTime { get; set; }

        /// <summary>
        /// RECD NAV Section
        /// _Ref: 5.4
        /// _Idx: 78
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter naming the major database section a record belongs to - or, on pointer fields, the
        /// section of the record being referenced.
        /// <para>FAA: The FAA readme does not call this field out directly, but it fixes the set of sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute waypoints and airways), H (heliports and heli terminal data), P (airport and terminal data) and U (controlled and special use airspace). No other section is produced.</para>
        /// </remarks>
        public string? RecdNavSection { get; set; }

        /// <summary>
        /// RECD NAV Subsection
        /// _Ref: 5.5
        /// _Idx: 79
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter that, combined with the Section Code, names the exact file a record belongs to - the
        /// primary key for record dispatch.
        /// <para>FAA: The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB, PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF (primary and Level of Service continuation), HF (primary and Level of Service continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC matrix below is absent. The FAA chooses between PC and EA for a named ter</para>
        /// </remarks>
        public string? RecdNavSubsection { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 80:81
        /// _MaxLength: 2
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

        /// <summary>
        /// Altitude Description
        /// _Ref: 5.29
        /// _Idx: 82
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Single character saying how the altitudes in the record are to be flown - at, at-or-above, at-or-
        /// below, between, or as a glide-slope / vertical-path pairing.
        /// <para>FAA: The FAA applies 424-19A Attachment 5 paragraph 6.10.3.2 to the Altitude 1 field of circling procedures that are not straight-in aligned with a runway, so Altitude 1 semantics on those legs follow the v19 rule rather than the v18 rule.</para>
        /// </remarks>
        public string? AltitudeDescription { get; set; }

        /// <summary>
        /// ATC Indicator
        /// _Ref: 5.81
        /// _Idx: 83
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Flags that the altitudes coded on this procedure leg may be changed by ATC, or will be assigned by
        /// ATC.
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public string AtcIndicator { get; set; }

        /// <summary>
        /// Altitude1
        /// _Ref: 5.30
        /// _Idx: 84:88
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Five-column altitude that may be feet MSL, a negative elevation, a flight level, or one of two
        /// alphabetic sentinels meaning the minimum altitude is unknown or unestablished.
        /// <para>FAA: For airways the FAA codes the point-to-point MEA here. A conventional route gets the conventional MEA; an RNAV route gets the GNSS MEA, falling back to the conventional MEA when no GNSS value is published.</para>
        /// <para>Layout note: If the Altitude Description (Field 5.29) contains +, -, B, G, H, or V require value in Altitude1; I, J, or blank may include value in Altitude1; and B, C, G, H, I, J, or V require a value in Altitude2.</para>
        /// </remarks>
        public int? Altitude1 { get; set; }

        /// <summary>
        /// Altitude2
        /// _Ref: 5.30
        /// _Idx: 89:93
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Five-column altitude that may be feet MSL, a negative elevation, a flight level, or one of two
        /// alphabetic sentinels meaning the minimum altitude is unknown or unestablished.
        /// <para>FAA: For airways the FAA codes the point-to-point MEA here. A conventional route gets the conventional MEA; an RNAV route gets the GNSS MEA, falling back to the conventional MEA when no GNSS value is published.</para>
        /// <para>Layout note: If the Altitude Description (Field 5.29) contains +, -, B, G, H, or V require value in Altitude1; I, J, or blank may include value in Altitude1; and B, C, G, H, I, J, or V require a value in Altitude2.</para>
        /// </remarks>
        public int? Altitude2 { get; set; }

        /// <summary>
        /// Transition Altitude
        /// _Ref: 5.53
        /// _Idx: 94:98
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Altitude in feet at which altimeter setting changes between local (QNH) and standard (QNE), carried
        /// on airport, heliport and procedure records.
        /// <para>FAA: The FAA codes a constant 18000 everywhere it codes this field at all - that is the United States transition altitude. Measured: PA 13,263 of 13,321 records = "18000", 58 blank; HA 6,104 of 6,134 = "18000", 30 blank; PD 10,373 of 34,605 populated, all "18000"; PE 9,644 of 44,148, all "18000"; PF primary 32,375 of 122,323, all "18000".</para>
        /// </remarks>
        public int? TransitionAltitude { get; set; }

        /// <summary>
        /// Speed Limit
        /// _Ref: 5.72
        /// _Idx: 99:101
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Speed restriction in knots indicated airspeed, applied either at a procedure fix or across an
        /// airport's terminal area.
        /// <para>FAA: The FAA leaves the airport and heliport terminal-area speed limit blank throughout, which is consistent with it also leaving Speed Limit Altitude (5.73) blank. Only procedure legs carry speed limits.</para>
        /// </remarks>
        public int? SpeedLimit { get; set; }

        /// <summary>
        /// Vertical Angle
        /// _Ref: 5.70
        /// _Idx: 102:105
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Descent angle in degrees for the vertical path flown from the coded fix, with the decimal point
        /// suppressed and a leading minus marking descent.
        /// <para>FAA: The FAA codes "000" - which appears in the slice as a blank sign column followed by three zeros, i.e. " 000" - for circling procedures and for dive-and-drive procedures. It also codes "000" for straight-in aligned procedures when Flight Inspection has identified obstacles in the visual areas. So a zero here does NOT mean a level path; it is a positive statement that no continuous descent angle is </para>
        /// </remarks>
        public double? VerticalAngle { get; set; }

        /// <summary>
        /// Center Fix or TAA Procedure Turn Indicator
        /// _Ref: 5.144 or 5.271
        /// _Idx: 106:110
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Names the fix a minimum safe altitude is drawn around, or - on an RF leg - the fix at the centre of
        /// the constant-radius turn.
        /// <para>This column carries one of two different fields depending on context: 5.144 or 5.271. It is left as raw text so neither reading is lost.</para>
        /// <para>FAA: "The MSA Center Fix (5.144) is normally coded on the FAF record. If the FAF record is an RF leg, then the MSA Center Fix is coded on the FACF record. If there is no FACF record, a center fix will not be coded." That rule is visible in the data: of the procedure records carrying a value, 4,458 are TF legs whose waypoint description code has F (final approach fix) in column 43, 2,783 are CF legs wit</para>
        /// </remarks>
        public string CenterFixOrTaaProcedureTurnIndicator { get; set; }

        /// <summary>
        /// Multiple Code or TAA Sector Identifier
        /// _Ref: 5.130 or 5.272
        /// _Idx: 111
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Distinguishes several areas that share the same designation but differ in lateral or vertical detail
        /// - the A, B, C of a subdivided MOA, or of an MSA published around the same centre fix.
        /// <para>This column carries one of two different fields depending on context: 5.130 or 5.272. It is left as raw text so neither reading is lost.</para>
        /// <para>FAA: The readme adds no rule. In practice the FAA subdivides special use airspace heavily: A through K all occur on UR records, with A on 23,311 of them.</para>
        /// </remarks>
        public string MultipleCodeOrTaaSectorIdentifier { get; set; }

        /// <summary>
        /// Point Reference ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 112:113
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// <para>Layout note: When index 106 thru 115 are providing a reference to a MSA or the center fix for an RF leg, all of the columns are used. When they are providing a reference to a TAA, only index 106 thru 111 are used and 112 thru 115 are blank.</para>
        /// </remarks>
        public string PointReferenceIcaoLocationCode { get; set; }

        /// <summary>
        /// Point Section Code
        /// _Ref: 5.4
        /// _Idx: 114
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter naming the major database section a record belongs to - or, on pointer fields, the
        /// section of the record being referenced.
        /// <para>FAA: The FAA readme does not call this field out directly, but it fixes the set of sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute waypoints and airways), H (heliports and heli terminal data), P (airport and terminal data) and U (controlled and special use airspace). No other section is produced.</para>
        /// <para>Layout note: When index 106 thru 115 are providing a reference to a MSA or the center fix for an RF leg, all of the columns are used. When they are providing a reference to a TAA, only index 106 thru 111 are used and 112 thru 115 are blank.</para>
        /// </remarks>
        public string? PointSectionCode { get; set; }

        /// <summary>
        /// Point Subsection Code
        /// _Ref: 5.5
        /// _Idx: 115
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter that, combined with the Section Code, names the exact file a record belongs to - the
        /// primary key for record dispatch.
        /// <para>FAA: The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB, PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF (primary and Level of Service continuation), HF (primary and Level of Service continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC matrix below is absent. The FAA chooses between PC and EA for a named ter</para>
        /// <para>Layout note: When index 106 thru 115 are providing a reference to a MSA or the center fix for an RF leg, all of the columns are used. When they are providing a reference to a TAA, only index 106 thru 111 are used and 112 thru 115 are blank.</para>
        /// </remarks>
        public string? PointSubsectionCode { get; set; }

        /// <summary>
        /// GNSS/FMS Indication
        /// _Ref: 5.222
        /// _Idx: 116
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether a conventional approach is authorised to be flown as a GNSS or FMS overlay, and for
        /// RNAV procedures whether SBAS vertical guidance is authorised.
        /// <para>FAA: The readme does not name the field, but its content is consistent with the FAA's approach inventory: GPS overlays, RNAV (GPS), RNAV (RNP) and stand-alone GPS procedures. Observed on procedure leg primaries: blank 78,769, 'A' 66,097, '0' 37,280, 'B' 18,658, '3' 174, 'P' 136. Codes 1, 2, 4, 5, C and U never appear.</para>
        /// </remarks>
        public string GnssFmsIndication { get; set; }

        /// <summary>
        /// Speed Limit Description
        /// _Ref: 5.261
        /// _Idx: 117
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Qualifies the speed restriction at a fix as at, at-or-above, or at-or-below the value in the Speed
        /// Limit field.
        /// <para>FAA: Not mentioned in the readme. Observed on procedure leg primaries: blank 197,008, '-' 4,102, '+' 4. The FAA overwhelmingly publishes maximum speeds; minimum speeds are essentially unused.</para>
        /// </remarks>
        public string SpeedLimitDescription { get; set; }

        /// <summary>
        /// Apch Route Qualifier 1
        /// _Ref: 5.7
        /// _Idx: 118
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Classifies the airway, SID, STAR, approach or preferred route that the record belongs to; on
        /// approach records it is a three-part code made of a primary route type plus two qualifiers.
        /// <para>FAA: Enroute airways: the FAA uses only "O" for conventional routes and "R" for RNAV routes. Measured on 19,099 ER records: O = 13,304, R = 5,795, nothing else. Approaches: ARINC 424-19 is applied for the route type at column 20 (offset 19) and for Route Qualifier 1 at column 119 (offset 118). Concretely, RNAV (RNP) approaches get route type "H" and Qualifier 1 "F". Measured: 3,157 PF records with H, e</para>
        /// <para>Layout note: Indexes 118 and 119 are required to match the Primary Record with the Continuation Record; this non-standard column order preserves the Primary Record format for SID, STAR, and Approach Records as much as possible following the introduction of these fields in Supplement 14.</para>
        /// </remarks>
        public string ApchRouteQualifier1 { get; set; }

        /// <summary>
        /// Apch Route Qualifier 2
        /// _Ref: 5.7
        /// _Idx: 119
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Classifies the airway, SID, STAR, approach or preferred route that the record belongs to; on
        /// approach records it is a three-part code made of a primary route type plus two qualifiers.
        /// <para>FAA: Enroute airways: the FAA uses only "O" for conventional routes and "R" for RNAV routes. Measured on 19,099 ER records: O = 13,304, R = 5,795, nothing else. Approaches: ARINC 424-19 is applied for the route type at column 20 (offset 19) and for Route Qualifier 1 at column 119 (offset 118). Concretely, RNAV (RNP) approaches get route type "H" and Qualifier 1 "F". Measured: 3,157 PF records with H, e</para>
        /// <para>Layout note: Indexes 118 and 119 are required to match the Primary Record with the Continuation Record; this non-standard column order preserves the Primary Record format for SID, STAR, and Approach Records as much as possible following the introduction of these fields in Supplement 14.</para>
        /// </remarks>
        public string ApchRouteQualifier2 { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 120:122
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// File Record Number
        /// _Ref: 5.31
        /// _Idx: 123:127
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Housekeeping reference number stamped on every record - in the FAA CIFP a per-record unique tag, not
        /// a sequential file position.
        /// <para>FAA: From the FAA CIFP readme, verbatim in substance: 'A unique number is assigned for each record rather than consecutively for the entire dataset. Some file record numbers will have alphabetic characters or blank fields.' Two consequences the implementer must not miss: - The value is NOT ordered and must never be used to sort records, to detect gaps, or to reason about file position. - The value is N</para>
        /// </remarks>
        public string? FileRecordNumber { get; set; }

        /// <summary>
        /// Cycle Date
        /// _Ref: 5.32
        /// _Idx: 128:131
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Two-digit year plus two-digit 28-day update cycle recording when the record was added or last
        /// changed.
        /// <para>FAA: The FAA states that cycle dates are set to the most recent cycle on every new record and on every record it modifies. Consequently the newest cycle value in the file identifies the CIFP volume itself.</para>
        /// </remarks>
        public string CycleDate { get; set; }

    }
}