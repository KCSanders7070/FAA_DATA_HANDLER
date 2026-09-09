using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - SpecialUseRestrictive (UR) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.18.1 Restrictive Airspace (Special Use Airspace-UR). Identified by Section Code
    /// 'U' and Subsection Code 'R'. Continuation Record Number is at zero-based index 24; '0' or '1' marks
    /// a primary record and anything else a continuation.
    /// </remarks>
    public class SpecialUseRestrictiveCifpDataModel
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
        /// Airspace ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 6:7
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string AirspaceIcaoLocationCode { get; set; }

        /// <summary>
        /// Restrictive Type
        /// _Ref: 5.128
        /// _Idx: 8
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says what kind of special use airspace the record describes - MOA, restricted, prohibited, warning,
        /// alert and so on.
        /// <para>FAA: The FAA uses U for two things the generic table does not cover: Special Air Traffic Rules Areas described under 14 CFR Part 93, whenever their spatial dimensions can be coded, are published as UR records typed U. National Security Areas are also published as UR records typed U. That second one matters: ARINC 424-19A defines a dedicated code N for National Security Area, and the FAA explicitly does</para>
        /// </remarks>
        public string RestrictiveType { get; set; }

        /// <summary>
        /// Restrictive Airspace Designation
        /// _Ref: 5.129
        /// _Idx: 9:18
        /// _MaxLength: 10
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The short designation that identifies a special use airspace area - the number of a restricted or
        /// warning area, or the name of a MOA or special flight rules area.
        /// <para>FAA: The readme lists the FAA's named special air traffic rule / special flight rules designations together with the published names they stand for: ANC SATR Anchorage, Alaska Terminal Area KTN SATR Ketchikan International Airport Traffic Rule GCNPSFRA E and GCNPSFRA W Grand Canyon Special Flight Rules, east and west sections LUKE SATR Special Air Traffic Rules near Luke AFB, AZ DC SFRA Washington DC M</para>
        /// </remarks>
        public string RestrictiveAirspaceDesignation { get; set; }

        /// <summary>
        /// Multiple Code
        /// _Ref: 5.130
        /// _Idx: 19
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Distinguishes several areas that share the same designation but differ in lateral or vertical detail
        /// - the A, B, C of a subdivided MOA, or of an MSA published around the same centre fix.
        /// <para>FAA: The readme adds no rule. In practice the FAA subdivides special use airspace heavily: A through K all occur on UR records, with A on 23,311 of them.</para>
        /// </remarks>
        public string MultipleCode { get; set; }

        /// <summary>
        /// Sequence Number
        /// _Ref: 5.12
        /// _Idx: 20:23
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
        /// Continuation Record No.
        /// _Ref: 5.16
        /// _Idx: 24
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
        /// Level
        /// _Ref: 5.19
        /// _Idx: 25
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
        /// Time Code
        /// _Ref: 5.131
        /// _Idx: 26
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the thing described by the record is active continuously or only at certain times, and
        /// on continuation records says how to read the time-of-operation columns.
        /// <para>FAA: "Special Use Airspace: Time Code (5.131) uses a C to indicate continuous and is blank to indicate part-time." That redefines blank. Under generic ARINC a blank means "active times announced by NOTAM"; in the FAA CIFP it means "part-time" with no further detail carried. There are no time-of-operation continuation records in the file (UR continuations exist only to carry the controlling agency), so </para>
        /// </remarks>
        public string TimeCode { get; set; }

        /// <summary>
        /// NOTAM
        /// _Ref: 5.132
        /// _Idx: 27
        /// _MaxLength: 1
        /// _DataType: Bool
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Flags special use airspace whose activation comes by NOTAM rather than from a published schedule.
        /// <para>FAA: The FAA never populates this column - all 43,129 UR and UC records leave it blank. Note that the FAA instead signals part-time airspace by leaving Time Code (5.131) blank, and it publishes no time-of-operation continuation records at all, so NOTAM-activated airspace is effectively indistinguishable from any other part-time airspace in this file.</para>
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public bool? Notam { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 28:29
        /// _MaxLength: 2
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Boundary Via - PathType
        /// _Ref: 5.118
        /// _Idx: 30
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.118 (Boundary Via). Describes the shape of the airspace boundary
        /// leaving this vertex - straight line, arc, circle - and flags the vertex that closes the boundary.
        /// </remarks>
        public string BoundaryViaPathType { get; set; }

        /// <summary>
        /// Boundary Via - IsEndOfDescription
        /// _Ref: 5.118
        /// _Idx: 31
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.118 (Boundary Via). Describes the shape of the airspace boundary
        /// leaving this vertex - straight line, arc, circle - and flags the vertex that closes the boundary.
        /// </remarks>
        public string BoundaryViaIsEndOfDescription { get; set; }

        /// <summary>
        /// Latitude
        /// _Ref: 5.36
        /// _Idx: 32:40
        /// _MaxLength: 9
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Signed latitude packed as a hemisphere letter followed by eight digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// </remarks>
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// _Ref: 5.37
        /// _Idx: 41:50
        /// _MaxLength: 10
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Signed longitude packed as a hemisphere letter followed by nine digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// </remarks>
        public double? Longitude { get; set; }

        /// <summary>
        /// Arc Origin Latitude
        /// _Ref: 5.36
        /// _Idx: 51:59
        /// _MaxLength: 9
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Signed latitude packed as a hemisphere letter followed by eight digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// </remarks>
        public double? ArcOriginLatitude { get; set; }

        /// <summary>
        /// Arc Origin Longitude
        /// _Ref: 5.37
        /// _Idx: 60:69
        /// _MaxLength: 10
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Signed longitude packed as a hemisphere letter followed by nine digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// </remarks>
        public double? ArcOriginLongitude { get; set; }

        /// <summary>
        /// Arc Distance
        /// _Ref: 5.119
        /// _Idx: 70:73
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The radius, in nautical miles, from the arc origin out to the arc or circle that forms this piece of
        /// the airspace boundary.
        /// </remarks>
        public double? ArcDistance { get; set; }

        /// <summary>
        /// Arc Bearing
        /// _Ref: 5.120
        /// _Idx: 74:77
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The true bearing from the arc origin to the point where the arc begins.
        /// </remarks>
        public double? ArcBearing { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 78:80
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Lower Limit
        /// _Ref: 5.121
        /// _Idx: 81:85
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The floor or ceiling of a piece of special use or controlled airspace, expressed as an altitude in
        /// feet, a flight level, or a reserved word such as GND or UNLTD.
        /// <para>FAA: "Special Use Airspace Altitudes (5.121) are only coded on the first record of each area. Upper altitudes are described as 'to and including'." So the ceiling is inclusive - an upper limit of 17999 means the airspace includes 17,999 ft. Every altitude the FAA describes as GND carries A (AGL) in its Unit Indicator. A volume that is completely excluded from within an airspace is coded with the six ch</para>
        /// </remarks>
        public string LowerLimit { get; set; }

        /// <summary>
        /// Unit Indicator
        /// _Ref: 5.133
        /// _Idx: 86
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the airspace limit sitting immediately before it is measured above mean sea level or
        /// above ground level.
        /// <para>FAA: "Unit Indicator (5.133) for all altitudes described as GND contains an A for AGL." That holds without exception in the data: all 1,308 GND lower limits carry A. The distribution shows the pairing rules clearly. On restrictive airspace: GND with A (589), digits with M (506), digits with A (452), FLnnn with M (36) for lower limits; digits with M (1,232), FLnnn with M (166), UNLTD with M (151), digit</para>
        /// </remarks>
        public string LowerLimitUnitIndicator { get; set; }

        /// <summary>
        /// Upper Limit
        /// _Ref: 5.121
        /// _Idx: 87:91
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The floor or ceiling of a piece of special use or controlled airspace, expressed as an altitude in
        /// feet, a flight level, or a reserved word such as GND or UNLTD.
        /// <para>FAA: "Special Use Airspace Altitudes (5.121) are only coded on the first record of each area. Upper altitudes are described as 'to and including'." So the ceiling is inclusive - an upper limit of 17999 means the airspace includes 17,999 ft. Every altitude the FAA describes as GND carries A (AGL) in its Unit Indicator. A volume that is completely excluded from within an airspace is coded with the six ch</para>
        /// </remarks>
        public string UpperLimit { get; set; }

        /// <summary>
        /// Unit Indicator
        /// _Ref: 5.133
        /// _Idx: 92
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the airspace limit sitting immediately before it is measured above mean sea level or
        /// above ground level.
        /// <para>FAA: "Unit Indicator (5.133) for all altitudes described as GND contains an A for AGL." That holds without exception in the data: all 1,308 GND lower limits carry A. The distribution shows the pairing rules clearly. On restrictive airspace: GND with A (589), digits with M (506), digits with A (452), FLnnn with M (36) for lower limits; digits with M (1,232), FLnnn with M (166), UNLTD with M (151), digit</para>
        /// </remarks>
        public string UpperLimitUnitIndicator { get; set; }

        /// <summary>
        /// Restrictive Airspace Name
        /// _Ref: 5.126
        /// _Idx: 93:122
        /// _MaxLength: 30
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The plain-language name of a piece of special use airspace, written once per area.
        /// <para>FAA: For the Grand Canyon Special Flight Rules Area the FAA puts all the internal boundary names - sectors and flight free zones - and their altitudes into this field. (The readme calls the field 5.216 there, which is the controlled-airspace name; on a UR record the column at index 93 is 5.126.)</para>
        /// </remarks>
        public string RestrictiveAirspaceName { get; set; }

        /// <summary>
        /// File Record No.
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