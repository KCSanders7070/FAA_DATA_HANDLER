using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - HeliportApproachProceduresContinuation (HF) continuation record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.9.5 Approach Level of Service Continuation Records (Heli Approaches
    /// Continuation-HF). Identified by Section Code 'H' and Subsection Code 'F'. Continuation Record Number
    /// is at zero-based index 38; '0' or '1' marks a primary record and anything else a continuation.
    /// </remarks>
    public class HeliportApproachProceduresContinuationCifpDataModel
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
        /// Application Type
        /// _Ref: 5.91
        /// _Idx: 39
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says what kind of continuation record this is, and therefore which field layout the rest of the
        /// record follows.
        /// <para>FAA: The FAA readme confirms two of the three: it applies ARINC 424 version 19 to the level of service continuation record, and it states that UR continuation records exist only to carry controlling agencies. It says nothing directly about the PP continuation.</para>
        /// </remarks>
        public string ApplicationType { get; set; }

        /// <summary>
        /// FAS Block Provided
        /// _Ref: 5.276
        /// _Idx: 40
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string FasBlockProvided { get; set; }

        /// <summary>
        /// FAS Block Provided Level of Service Name
        /// _Ref: 5.275
        /// _Idx: 41:50
        /// _MaxLength: 10
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// The published operating-minima name for an approach level of service authorized for SBAS, such as
        /// LPV or LNAV/VNAV.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record. Version 19 renumbers the RNP variant of this concept as 5.297 and adds RNP Level of Service values in columns that version 18 shows as blank spacing (see anomalies).</para>
        /// </remarks>
        public string? FasBlockProvidedLevelOfServiceName { get; set; }

        /// <summary>
        /// LNAV/VNAV Authorized for SBAS
        /// _Ref: 5.276
        /// _Idx: 51
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string LnavVnavAuthorizedForSbas { get; set; }

        /// <summary>
        /// LNAV/VNAV Level of Service Name
        /// _Ref: 5.275
        /// _Idx: 52:61
        /// _MaxLength: 10
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// The published operating-minima name for an approach level of service authorized for SBAS, such as
        /// LPV or LNAV/VNAV.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record. Version 19 renumbers the RNP variant of this concept as 5.297 and adds RNP Level of Service values in columns that version 18 shows as blank spacing (see anomalies).</para>
        /// </remarks>
        public string? LnavVnavLevelOfServiceName { get; set; }

        /// <summary>
        /// LNAV Authorized for SBAS
        /// _Ref: 5.276
        /// _Idx: 62
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string LnavAuthorizedForSbas { get; set; }

        /// <summary>
        /// LNAV Level of Service Name
        /// _Ref: 5.275
        /// _Idx: 63:72
        /// _MaxLength: 10
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// The published operating-minima name for an approach level of service authorized for SBAS, such as
        /// LPV or LNAV/VNAV.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record. Version 19 renumbers the RNP variant of this concept as 5.297 and adds RNP Level of Service values in columns that version 18 shows as blank spacing (see anomalies).</para>
        /// </remarks>
        public string? LnavLevelOfServiceName { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 73:87
        /// _MaxLength: 15
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// RNP Authorized 1
        /// _Ref: 5.276
        /// _Idx: 88
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string RnpAuthorized1 { get; set; }

        /// <summary>
        /// RNP Level of Service Value 1
        /// _Ref: 5.297
        /// _Idx: 89:91
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// An RNP value published as an additional level of service for an RNAV (RNP) approach, encoded the
        /// same way as the RNP field 5.211.
        /// <para>FAA: The FAA states it applies ARINC 424 version 19 to the level of service continuation record. Verified in FAACIFP18: 430 of the 6,742 PF/HF continuation records carry this block, and every one of them is an RNAV (RNP) approach (route type H with Approach Route Qualifier 1 F).</para>
        /// </remarks>
        public double? RnpLevelOfServiceValue1 { get; set; }

        /// <summary>
        /// RNP Authorized 2
        /// _Ref: 5.276
        /// _Idx: 92
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string RnpAuthorized2 { get; set; }

        /// <summary>
        /// RNP Level of Service Value 2
        /// _Ref: 5.297
        /// _Idx: 93:95
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// An RNP value published as an additional level of service for an RNAV (RNP) approach, encoded the
        /// same way as the RNP field 5.211.
        /// <para>FAA: The FAA states it applies ARINC 424 version 19 to the level of service continuation record. Verified in FAACIFP18: 430 of the 6,742 PF/HF continuation records carry this block, and every one of them is an RNAV (RNP) approach (route type H with Approach Route Qualifier 1 F).</para>
        /// </remarks>
        public double? RnpLevelOfServiceValue2 { get; set; }

        /// <summary>
        /// RNP Authorized 3
        /// _Ref: 5.276
        /// _Idx: 96
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string RnpAuthorized3 { get; set; }

        /// <summary>
        /// RNP Level of Service Value 3
        /// _Ref: 5.297
        /// _Idx: 97:99
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// An RNP value published as an additional level of service for an RNAV (RNP) approach, encoded the
        /// same way as the RNP field 5.211.
        /// <para>FAA: The FAA states it applies ARINC 424 version 19 to the level of service continuation record. Verified in FAACIFP18: 430 of the 6,742 PF/HF continuation records carry this block, and every one of them is an RNAV (RNP) approach (route type H with Approach Route Qualifier 1 F).</para>
        /// </remarks>
        public double? RnpLevelOfServiceValue3 { get; set; }

        /// <summary>
        /// RNP Authorized 4
        /// _Ref: 5.276
        /// _Idx: 100
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the level of service named in the adjacent 5.275 field is authorized for the procedure.
        /// <para>FAA: The FAA applies ARINC 424 version 19 to the level of service continuation record.</para>
        /// </remarks>
        public string RnpAuthorized4 { get; set; }

        /// <summary>
        /// RNP Level of Service Value 4
        /// _Ref: 5.297
        /// _Idx: 101:103
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// An RNP value published as an additional level of service for an RNAV (RNP) approach, encoded the
        /// same way as the RNP field 5.211.
        /// <para>FAA: The FAA states it applies ARINC 424 version 19 to the level of service continuation record. Verified in FAACIFP18: 430 of the 6,742 PF/HF continuation records carry this block, and every one of them is an RNAV (RNP) approach (route type H with Approach Route Qualifier 1 F).</para>
        /// </remarks>
        public double? RnpLevelOfServiceValue4 { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 104:117
        /// _MaxLength: 14
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Approach Route Type Qualifier 1
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
        public string ApproachRouteTypeQualifier1 { get; set; }

        /// <summary>
        /// Approach Route Type Qualifier 2
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
        public string ApproachRouteTypeQualifier2 { get; set; }

        /// <summary>
        /// Blank
        /// _Idx: 120:122
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? Blank { get; set; }

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