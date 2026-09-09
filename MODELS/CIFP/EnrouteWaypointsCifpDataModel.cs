using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - EnrouteWaypoints (EA) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.4.1 Waypoint (Enroute Waypoints-EA). Identified by Section Code 'E' and
    /// Subsection Code 'A'. Continuation Record Number is at zero-based index 21; '0' or '1' marks a
    /// primary record and anything else a continuation.
    /// </remarks>
    public class EnrouteWaypointsCifpDataModel
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
        /// <para>Layout note: Subsection codes: Enroute Waypoint Records=Index5 while index12 is blank. __ Airport or Heliport Terminal Waypoint Records=index12 while index5 is blank.</para>
        /// </remarks>
        public string? SubsectionCode { get; set; }

        /// <summary>
        /// Region Code
        /// _Ref: 5.41
        /// _Idx: 6:9
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Four columns that either hold the literal 'ENRT', marking the waypoint as enroute, or hold the
        /// identifier of the airport that owns the terminal waypoint.
        /// <para>FAA: The FAA readme does not name 5.41 directly, but its PC/EA selection rule determines what lands here: a named terminal waypoint gets a PC record (and therefore an airport identifier in this field) only when it is used at exactly one airport and is not on an enroute airway; otherwise it becomes an EA record with 'ENRT'.</para>
        /// <para>Layout note: For Enroute Waypoint Records, the region code is listed as “ENRT.” For Terminal Waypoint Records, that field is populated with the Airport ICAO Identification code.</para>
        /// </remarks>
        public string RegionCode { get; set; }

        /// <summary>
        /// Region ICAO Location Code
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
        public string RegionIcaoLocationCode { get; set; }

        /// <summary>
        /// Subsection
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
        /// <para>Layout note: Subsection codes: Enroute Waypoint Records=Index5 while index12 is blank. __ Airport or Heliport Terminal Waypoint Records=index12 while index5 is blank.</para>
        /// </remarks>
        public string? Subsection { get; set; }

        /// <summary>
        /// Waypoint Identifier
        /// _Ref: 5.13
        /// _Idx: 13:17
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Holds the identifier of the fix this record is about - an enroute or terminal waypoint, a VHF or NDB
        /// navaid, an airport, or a runway threshold expressed as a fix.
        /// <para>FAA: The FAA excludes waypoints whose identifiers are entirely numeric. Fixes classified as offshore may carry an area code of USA with an ICAO code of "K " or "P " (letter followed by a blank). Terminal waypoints are published as PC records when used at a single airport and not on an airway, otherwise as EA records; NDBs get a PN record under the same conditions.</para>
        /// </remarks>
        public string WaypointIdentifier { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 18
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Waypoint ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 19:20
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string WaypointIcaoLocationCode { get; set; }

        /// <summary>
        /// Continuation Record No.
        /// _Ref: 5.16
        /// _Idx: 21
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
        /// Blank (Spacing)
        /// _Idx: 22:25
        /// _MaxLength: 4
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Waypoint Type - WaypointFormation
        /// _Ref: 5.42
        /// _Idx: 26
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.42 (Waypoint Type). Three packed single-character codes
        /// classifying a waypoint - how it is formed, what role it plays in terminal procedures, and which
        /// procedure types publish it.
        /// </remarks>
        public string WaypointTypeFormation { get; set; }

        /// <summary>
        /// Waypoint Type - WaypointFunction
        /// _Ref: 5.42
        /// _Idx: 27
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.42 (Waypoint Type). Three packed single-character codes
        /// classifying a waypoint - how it is formed, what role it plays in terminal procedures, and which
        /// procedure types publish it.
        /// </remarks>
        public string WaypointTypeFunction { get; set; }

        /// <summary>
        /// Waypoint Type - ProcedurePublication
        /// _Ref: 5.42
        /// _Idx: 28
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 3 of the composite field 5.42 (Waypoint Type). Three packed single-character codes
        /// classifying a waypoint - how it is formed, what role it plays in terminal procedures, and which
        /// procedure types publish it.
        /// </remarks>
        public string WaypointTypeProcedurePublication { get; set; }

        /// <summary>
        /// Waypoint Usage - RnavUsage
        /// _Ref: 5.82
        /// _Idx: 29
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.82 (Waypoint Usage). Two columns saying which airway structure a
        /// waypoint belongs to: column 1 flags RNAV use, column 2 gives the altitude structure (high, low, or
        /// both).
        /// </remarks>
        public string WaypointUsageRnav { get; set; }

        /// <summary>
        /// Waypoint Usage - AltitudeStructure
        /// _Ref: 5.82
        /// _Idx: 30
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.82 (Waypoint Usage). Two columns saying which airway structure a
        /// waypoint belongs to: column 1 flags RNAV use, column 2 gives the altitude structure (high, low, or
        /// both).
        /// </remarks>
        public string WaypointUsageAltitudeStructure { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 31
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Waypoint Latitude
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
        public double? WaypointLatitude { get; set; }

        /// <summary>
        /// Waypoint Longitude
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
        public double? WaypointLongitude { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 51:73
        /// _MaxLength: 23
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Dynamic Mag. Variation
        /// _Ref: 5.39
        /// _Idx: 74:78
        /// _MaxLength: 5
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Angular difference between true and magnetic north at the record's location, given as a direction
        /// letter plus four digits of degrees and tenths.
        /// <para>FAA: The FAA computes variation from the World Magnetic Model, 2020 epoch. Where no government-assigned variation exists, the CIFP dynamic magnetic variation is calculated at the magnetic epoch of a specified cycle so that it stays aligned with the NASR AWY.txt and ATS.txt files; for 2025 that reference was cycle 2504. Waypoint records and DME-only facilities use the cycle 2504 epoch. DME-only faciliti</para>
        /// </remarks>
        public double? DynamicMagVariation { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 79:83
        /// _MaxLength: 5
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

        /// <summary>
        /// Datum Code
        /// _Ref: 5.197
        /// _Idx: 84:86
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Three-letter code naming the local horizontal reference datum that the record's latitude and
        /// longitude are expressed in.
        /// <para>FAA: The readme does not mention datums. The FAA uses only two codes. 'NAR' (North American 1983) appears on essentially everything - all 70,036 waypoints, all 2,475 navaids, all 6,134 heliports and 13,311 of 13,321 airports. 'WGE' (WGS-84) appears on exactly ten airports, all military: KADW, KDAA, KHST, KLFI, KNBG, KNFW, KNGU, KNIP, KNRB and KNYG. Anything consuming CIFP coordinates should be aware th</para>
        /// </remarks>
        public string? DatumCode { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 87:94
        /// _MaxLength: 8
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

        /// <summary>
        /// Name Format Indicator - NameFormat1
        /// _Ref: 5.196
        /// _Idx: 95
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.196 (Name Format Indicator). Describes how the Waypoint
        /// Name/Description field was constructed - whether the name is a published five-letter fix, a navaid
        /// identifier, a lat/long, an abeam point and so on.
        /// </remarks>
        public string NameFormatIndicatorFormat1 { get; set; }

        /// <summary>
        /// Name Format Indicator - NameFormat2
        /// _Ref: 5.196
        /// _Idx: 96
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.196 (Name Format Indicator). Describes how the Waypoint
        /// Name/Description field was constructed - whether the name is a published five-letter fix, a navaid
        /// identifier, a lat/long, an abeam point and so on.
        /// </remarks>
        public string NameFormatIndicatorFormat2 { get; set; }

        /// <summary>
        /// Name Format Indicator - NameFormat3
        /// _Ref: 5.196
        /// _Idx: 97
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 3 of the composite field 5.196 (Name Format Indicator). Describes how the Waypoint
        /// Name/Description field was constructed - whether the name is a published five-letter fix, a navaid
        /// identifier, a lat/long, an abeam point and so on.
        /// </remarks>
        public string NameFormatIndicatorFormat3 { get; set; }

        /// <summary>
        /// Waypoint Name/Description
        /// _Ref: 5.43
        /// _Idx: 98:122
        /// _MaxLength: 25
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Twenty-five columns of free text spelling out a named waypoint's full name, or describing an unnamed
        /// waypoint.
        /// <para>FAA: The FAA readme says nothing directly about 5.43, but the observed behaviour is a significant deviation from ARINC intent - see anomalies. Note also the related FAA statement that Waypoint Name Format Indicator (5.196) is never populated, so there is no companion field telling a consumer how to parse this text.</para>
        /// </remarks>
        public string? WaypointNameDescription { get; set; }

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