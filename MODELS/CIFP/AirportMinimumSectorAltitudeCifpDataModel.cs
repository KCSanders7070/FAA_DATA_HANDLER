using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - AirportMinimumSectorAltitude (PS) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.20.1 Airport MSA (MSA-PS). Identified by Section Code 'P' and Subsection Code
    /// 'S'. Continuation Record Number is at zero-based index 38; '0' or '1' marks a primary record and
    /// anything else a continuation.
    /// </remarks>
    public class AirportMinimumSectorAltitudeCifpDataModel
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
        /// MSA Center
        /// _Ref: 5.144
        /// _Idx: 13:17
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Names the fix a minimum safe altitude is drawn around, or - on an RF leg - the fix at the centre of
        /// the constant-radius turn.
        /// <para>FAA: "The MSA Center Fix (5.144) is normally coded on the FAF record. If the FAF record is an RF leg, then the MSA Center Fix is coded on the FACF record. If there is no FACF record, a center fix will not be coded." That rule is visible in the data: of the procedure records carrying a value, 4,458 are TF legs whose waypoint description code has F (final approach fix) in column 43, 2,783 are CF legs wit</para>
        /// </remarks>
        public string MsaCenter { get; set; }

        /// <summary>
        /// MSA ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 18:19
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string MsaIcaoLocationCode { get; set; }

        /// <summary>
        /// MSA Section Code
        /// _Ref: 5.4
        /// _Idx: 20
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter naming the major database section a record belongs to - or, on pointer fields, the
        /// section of the record being referenced.
        /// <para>FAA: The FAA readme does not call this field out directly, but it fixes the set of sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute waypoints and airways), H (heliports and heli terminal data), P (airport and terminal data) and U (controlled and special use airspace). No other section is produced.</para>
        /// </remarks>
        public string? MsaSectionCode { get; set; }

        /// <summary>
        /// MSA Subsection Code
        /// _Ref: 5.5
        /// _Idx: 21
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter that, combined with the Section Code, names the exact file a record belongs to - the
        /// primary key for record dispatch.
        /// <para>FAA: The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB, PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF (primary and Level of Service continuation), HF (primary and Level of Service continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC matrix below is absent. The FAA chooses between PC and EA for a named ter</para>
        /// </remarks>
        public string? MsaSubsectionCode { get; set; }

        /// <summary>
        /// Multiple Code
        /// _Ref: 5.130
        /// _Idx: 22
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
        /// Reserved (Expansion)
        /// _Idx: 23:37
        /// _MaxLength: 15
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

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
        /// Reserved (Spacing)
        /// _Idx: 39:41
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedSpacing { get; set; }

        /// <summary>
        /// Sector Bearing 1 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 42:44
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing1StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 1 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 45:47
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing1EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 1
        /// _Ref: 5.147
        /// _Idx: 48:50
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude1 { get; set; }

        /// <summary>
        /// Sector Radius 1
        /// _Ref: 5.145
        /// _Idx: 51:52
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius1 { get; set; }

        /// <summary>
        /// Sector Bearing 2 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 53:55
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing2StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 2 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 56:58
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing2EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 2
        /// _Ref: 5.147
        /// _Idx: 59:61
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude2 { get; set; }

        /// <summary>
        /// Sector Radius 2
        /// _Ref: 5.145
        /// _Idx: 62:63
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius2 { get; set; }

        /// <summary>
        /// Sector Bearing 3 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 64:66
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing3StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 3 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 67:69
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing3EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 3
        /// _Ref: 5.147
        /// _Idx: 70:72
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude3 { get; set; }

        /// <summary>
        /// Sector Radius 3
        /// _Ref: 5.145
        /// _Idx: 73:74
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius3 { get; set; }

        /// <summary>
        /// Sector Bearing 4 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 75:77
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing4StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 4 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 78:80
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing4EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 4
        /// _Ref: 5.147
        /// _Idx: 81:83
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude4 { get; set; }

        /// <summary>
        /// Sector Radius 4
        /// _Ref: 5.145
        /// _Idx: 84:85
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius4 { get; set; }

        /// <summary>
        /// Sector Bearing 5 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 86:88
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing5StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 5 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 89:91
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing5EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 5
        /// _Ref: 5.147
        /// _Idx: 92:94
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude5 { get; set; }

        /// <summary>
        /// Sector Radius 5
        /// _Ref: 5.145
        /// _Idx: 95:96
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius5 { get; set; }

        /// <summary>
        /// Sector Bearing 6 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 97:99
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing6StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 6 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 100:102
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing6EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 6
        /// _Ref: 5.147
        /// _Idx: 103:105
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude6 { get; set; }

        /// <summary>
        /// Sector Radius 6
        /// _Ref: 5.145
        /// _Idx: 106:107
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius6 { get; set; }

        /// <summary>
        /// Sector Bearing 7 - StartBearing
        /// _Ref: 5.146
        /// _Idx: 108:110
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing7StartBearing { get; set; }

        /// <summary>
        /// Sector Bearing 7 - EndBearing
        /// _Ref: 5.146
        /// _Idx: 111:113
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.146 (Sector Bearing). The pair of bearings, measured to the MSA
        /// centre fix, that bound one sector of a minimum safe altitude - start bearing first, end bearing
        /// second, going clockwise.
        /// </remarks>
        public string SectorBearing7EndBearing { get; set; }

        /// <summary>
        /// Sector Altitude 7
        /// _Ref: 5.147
        /// _Idx: 114:116
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum safe altitude for one sector of an MSA, in hundreds of feet.
        /// <para>FAA: The FAA never uses the 424-19A "no sector altitude" value 999 - every populated slot in the file carries a real altitude. Most common values are 031 (3,100 ft), 026, 036, 030, 029.</para>
        /// </remarks>
        public int? SectorAltitude7 { get; set; }

        /// <summary>
        /// Sector Radius 7
        /// _Ref: 5.145
        /// _Idx: 117:118
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// How far out from the MSA centre fix the sector altitude in the same slot provides obstacle
        /// clearance, in whole nautical miles.
        /// <para>FAA: The FAA is nearly uniform here: 6,930 of the 6,974 populated slots are 25 NM. The rest are 26, 27, 28, 29, 30 and a single 37.</para>
        /// </remarks>
        public int? SectorRadius7 { get; set; }

        /// <summary>
        /// Magnetic/True Indicator
        /// _Ref: 5.165
        /// _Idx: 119
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// States whether the courses and bearings in a record are referenced to Magnetic North or True North.
        /// </remarks>
        public string MagneticTrueIndicator { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 120:122
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

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