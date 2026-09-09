using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Airways (ER) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.6.1 Enroute Airways (Airways-ER). Identified by Section Code 'E' and Subsection
    /// Code 'R'. Continuation Record Number is at zero-based index 38; '0' or '1' marks a primary record
    /// and anything else a continuation.
    /// </remarks>
    public class AirwaysCifpDataModel
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
        /// Subsection Code
        /// _Ref: 5.5
        /// _Idx: 5
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
        /// Blank (Spacing)
        /// _Idx: 6:12
        /// _MaxLength: 7
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Route Identifier
        /// _Ref: 5.8
        /// _Idx: 13:17
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// The published designator of the airway or preferred route the record belongs to, exactly as it
        /// appears on charts.
        /// <para>FAA: The FAA readme does not call out 5.8 by number, but the Airways paragraph is directly relevant: US airways in the CIFP comprise enroute airways, area navigation routes, area navigation IFR terminal transition routes and ATS routes. Non-US airways, including Canadian airways, are no longer included. Related: Level (5.19) at offset 45 is coded "L" when the identifier begins with V or T, "H" when it </para>
        /// <para>Layout note: The standard Route Identifier length is five characters; however, this reserved column permits six-character identifiers and may also be used by some data suppliers for the ATS Service suffix associated with certain Route Identifiers. The following 18th index is this reserved character.</para>
        /// </remarks>
        public string? RouteIdentifier { get; set; }

        /// <summary>
        /// Reserved
        /// _Idx: 18
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? Reserved { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 19:24
        /// _MaxLength: 6
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Sequence Number
        /// _Ref: 5.12
        /// _Idx: 25:28
        /// _MaxLength: 4
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
        /// Section Code
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
        /// Subsection
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
        /// Continuation Record No.
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
        public string ContinuationRecordNo { get; set; }

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
        /// Boundary Code
        /// _Ref: 5.18
        /// _Idx: 43
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// On an enroute airway leg, marks that the route crosses into a different world area at this point and
        /// names the area being entered or left.
        /// <para>FAA: The readme says nothing about this field directly, but it does say non-U.S. airways - including Canadian ones - are no longer carried. The 'C' entries that survive are boundary markers on legs that leave U.S. airspace, not Canadian route data.</para>
        /// </remarks>
        public string BoundaryCode { get; set; }

        /// <summary>
        /// Route Type
        /// _Ref: 5.7
        /// _Idx: 44
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
        /// Level
        /// _Ref: 5.19
        /// _Idx: 45
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the airway or airspace record belongs to the low-altitude structure, the high-altitude
        /// structure, or applies at all altitudes.
        /// <para>FAA: The readme gives an explicit rule for airways and ATS routes: Level is 'L' when the route identifier starts with V or T, 'H' when it starts with J or Q, and blank otherwise. That rule is borne out by the data - 13,219 'L', 3,761 'H' and 2,119 blank on ER primaries.</para>
        /// </remarks>
        public string Level { get; set; }

        /// <summary>
        /// Direction Restriction
        /// _Ref: 5.115
        /// _Idx: 46
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// On an airway, says whether the route may be flown only in the direction it is coded, only against
        /// it, or both ways.
        /// <para>FAA: "ATS Routes will not contain directional restrictions (5.115)." In practice the FAA leaves the column blank on all 19,099 airway records, not just on ATS routes - no F or B appears anywhere in the file.</para>
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public string? DirectionRestriction { get; set; }

        /// <summary>
        /// Cruise Table Indicator
        /// _Ref: 5.134
        /// _Idx: 47:48
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Points an airway record at the table of cruising levels that applies to it.
        /// <para>FAA: The FAA publishes no cruise table records and leaves this column blank on all 19,099 airway records. There is nothing to dereference.</para>
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public string? CruiseTableIndicator { get; set; }

        /// <summary>
        /// EU Indicator
        /// _Ref: 5.164
        /// _Idx: 49
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Flags an enroute airway segment that has an associated Airway Restriction record, without saying
        /// what the restriction is.
        /// <para>FAA: The FAA CIFP does not include Airway Restriction (EU) records at all, and this indicator is blank on every airway record. Treat it as permanently false for this dataset.</para>
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public string EuIndicator { get; set; }

        /// <summary>
        /// Recommended NAVAID
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
        /// Recommended NAVAIDICAO Location Code
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
        /// RNP
        /// _Ref: 5.211
        /// _Idx: 56:58
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The navigation accuracy required on this segment, encoded as two significant digits plus a negative
        /// decimal exponent.
        /// <para>FAA: The readme devotes a whole section to this field. The FAA populates RNP from the NAVSPEC values in FAA Order 8260.58C Table 1-2-1, using five rules: 1. On day-forward procedures, HF and HM (holding) legs are NOT coded with RNP values at all. 2. On amendments and abbreviated amendments, values match FAA Form 8260-3 Terminal Routes. 3. For P-NOTAMs requiring coding changes, values match Form 8260-3 </para>
        /// </remarks>
        public double? Rnp { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 59:61
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

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
        /// Outbound Magnetic Course
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
        public double? OutboundMagneticCourse { get; set; }

        /// <summary>
        /// Route Distance From
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
        public double? RouteDistanceFrom { get; set; }

        /// <summary>
        /// Inbound Magnetic Course
        /// _Ref: 5.28
        /// _Idx: 78:81
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Published magnetic course inbound to the fix named in the record, expressed in tenths of a degree
        /// with the decimal point removed.
        /// </remarks>
        public double? InboundMagneticCourse { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 82
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Minimum Altitude 1
        /// _Ref: 5.30
        /// _Idx: 83:87
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Five-column altitude that may be feet MSL, a negative elevation, a flight level, or one of two
        /// alphabetic sentinels meaning the minimum altitude is unknown or unestablished.
        /// <para>FAA: For airways the FAA codes the point-to-point MEA here. A conventional route gets the conventional MEA; an RNAV route gets the GNSS MEA, falling back to the conventional MEA when no GNSS value is published.</para>
        /// <para>Layout note: If the minimum altitude is the same in both directions, the MinimumAltitude1 field contains the MEA or MFA and MinimumAltitude2 is blank; if the altitudes differ by direction, MinimumAltitude1 applies to the coded direction and MinimumAltitude2 applies to the opposite direction; UNKNN means the altitude is unknown, and NESTB means it has not been established.</para>
        /// </remarks>
        public int? MinimumAltitude1 { get; set; }

        /// <summary>
        /// Minimum Altitude 2
        /// _Ref: 5.30
        /// _Idx: 88:92
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Five-column altitude that may be feet MSL, a negative elevation, a flight level, or one of two
        /// alphabetic sentinels meaning the minimum altitude is unknown or unestablished.
        /// <para>FAA: For airways the FAA codes the point-to-point MEA here. A conventional route gets the conventional MEA; an RNAV route gets the GNSS MEA, falling back to the conventional MEA when no GNSS value is published.</para>
        /// <para>Layout note: If the minimum altitude is the same in both directions, the MinimumAltitude1 field contains the MEA or MFA and MinimumAltitude2 is blank; if the altitudes differ by direction, MinimumAltitude1 applies to the coded direction and MinimumAltitude2 applies to the opposite direction; UNKNN means the altitude is unknown, and NESTB means it has not been established.</para>
        /// </remarks>
        public int? MinimumAltitude2 { get; set; }

        /// <summary>
        /// Maximum Altitude
        /// _Ref: 5.127
        /// _Idx: 93:97
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The ceiling of an airway segment - the highest altitude at which the segment may be flown.
        /// <para>FAA: The readme says nothing specific about this field. It does specify that Route Type (5.7) is O for conventional and R for RNAV routes and that the Minimum Altitude field carries the point-to-point MEA, which is the companion to this ceiling.</para>
        /// </remarks>
        public int? MaximumAltitude { get; set; }

        /// <summary>
        /// Fix Radius Transition Indicator
        /// _Ref: 5.254
        /// _Idx: 98:100
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The required turn radius, in tenths of a nautical mile, when the controlling authority mandates a
        /// fixed radius transition between airway legs.
        /// <para>FAA: The readme does not mention the field, and the FAA does not use it: all 19,099 enroute airway primary records carry three spaces at offset 98.</para>
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public double? FixRadiusTransitionIndicator { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 101:122
        /// _MaxLength: 22
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

        /// <summary>
        /// File Record No
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
        public string? FileRecordNo { get; set; }

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