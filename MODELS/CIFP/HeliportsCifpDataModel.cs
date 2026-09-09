using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Heliports (HA) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.2.1.1 Heliport (Heliports-HA). Identified by Section Code 'H' and Subsection Code
    /// 'A'. Continuation Record Number is at zero-based index 21; '0' or '1' marks a primary record and
    /// anything else a continuation.
    /// </remarks>
    public class HeliportsCifpDataModel
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
        /// Heliport Identifier
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
        public string? HeliportIdentifier { get; set; }

        /// <summary>
        /// Heliport ICAO Location Code
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
        public string HeliportIcaoLocationCode { get; set; }

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
        /// ATA/IATA Designator
        /// _Ref: 5.107
        /// _Idx: 13:15
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A three-character short code for the airport or heliport - internationally the IATA/ATA code, but in
        /// the FAA CIFP the three-character FAA location identifier.
        /// <para>FAA: "The IATA code field in the Airport Record will contain the FAA Airport Identifier. If the Airport Identifier is four characters in length, the field will be left blank." In the 2507 file 8,150 of 13,321 airport records and 5,941 of 6,134 heliport records have this field blank.</para>
        /// </remarks>
        public string AtaIataDesignator { get; set; }

        /// <summary>
        /// PAD Identifier
        /// _Ref: 5.180
        /// _Idx: 16:20
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// The name of an individual helipad, unique within its heliport, used as part of the record key.
        /// <para>FAA: The readme does not mention the field. In practice the FAA uses a simple 'H' plus sequence number scheme - 'H1' covers 5,638 of the 6,134 heliport records, running up to 'H27', with a small tail of lettered pads 'HA' through 'HI'.</para>
        /// </remarks>
        public string? PadIdentifier { get; set; }

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
        /// Speed Limit Altitude
        /// _Ref: 5.73
        /// _Idx: 22:26
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Altitude at and below which the terminal-area speed limit in 5.72 applies.
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public int? SpeedLimitAltitude { get; set; }

        /// <summary>
        /// Datum Code
        /// _Ref: 5.197
        /// _Idx: 27:29
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
        /// IFR Indicator
        /// _Ref: 5.108
        /// _Idx: 30
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the airport or heliport has at least one official published instrument approach
        /// procedure.
        /// </remarks>
        public string IfrIndicator { get; set; }

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
        /// Magnetic Variation
        /// _Ref: 5.39
        /// _Idx: 51:55
        /// _MaxLength: 5
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Angular difference between true and magnetic north at the record's location, given as a direction
        /// letter plus four digits of degrees and tenths.
        /// <para>FAA: The FAA computes variation from the World Magnetic Model, 2020 epoch. Where no government-assigned variation exists, the CIFP dynamic magnetic variation is calculated at the magnetic epoch of a specified cycle so that it stays aligned with the NASR AWY.txt and ATS.txt files; for 2025 that reference was cycle 2504. Waypoint records and DME-only facilities use the cycle 2504 epoch. DME-only faciliti</para>
        /// </remarks>
        public double? MagneticVariation { get; set; }

        /// <summary>
        /// Heliport Elevation
        /// _Ref: 5.55
        /// _Idx: 56:60
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Elevation of the airport or heliport in feet relative to mean sea level, signed.
        /// </remarks>
        public int? HeliportElevation { get; set; }

        /// <summary>
        /// Speed Limit
        /// _Ref: 5.72
        /// _Idx: 61:63
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
        /// Recommended VHF Navaid
        /// _Ref: 5.23
        /// _Idx: 64:67
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Identifier of the ground navaid that the leg, waypoint or airport is referenced to - the facility
        /// that Theta (5.24) and Rho (5.25) are measured from.
        /// <para>FAA: The readme does not mention the field. In the shipped file it is populated only on procedure leg records (22,958 of 201,114 primaries, 1,968 distinct identifiers) and is blank on all 13,321 airport records, all 6,134 heliport records and all 19,099 enroute airway primary records - even though ARINC allows it on all three.</para>
        /// </remarks>
        public string? RecommendedVhfNavaid { get; set; }

        /// <summary>
        /// Recommended VHF Navaid ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 68:69
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// </remarks>
        public string RecommendedVhfNavaidIcaoLocationCode { get; set; }

        /// <summary>
        /// Transition Altitude
        /// _Ref: 5.53
        /// _Idx: 70:74
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
        /// Transition Level
        /// _Ref: 5.53
        /// _Idx: 75:79
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Altitude in feet at which altimeter setting changes between local (QNH) and standard (QNE), carried
        /// on airport, heliport and procedure records.
        /// <para>FAA: The FAA codes a constant 18000 everywhere it codes this field at all - that is the United States transition altitude. Measured: PA 13,263 of 13,321 records = "18000", 58 blank; HA 6,104 of 6,134 = "18000", 30 blank; PD 10,373 of 34,605 populated, all "18000"; PE 9,644 of 44,148, all "18000"; PF primary 32,375 of 122,323, all "18000".</para>
        /// </remarks>
        public int? TransitionLevel { get; set; }

        /// <summary>
        /// Public Military Indicator
        /// _Ref: 5.177
        /// _Idx: 80
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Classifies a landing facility as civil/public, military, or private/not open to the public.
        /// <para>FAA: Not discussed in the readme. Distribution in the shipped file: airports 8,143 private, 4,983 civil, 195 military; heliports 5,857 private, 216 military, 61 civil. Private facilities dominate the CIFP because of the very large number of private helipads.</para>
        /// </remarks>
        public string PublicMilitaryIndicator { get; set; }

        /// <summary>
        /// Time Zone - TimeZoneLetter
        /// _Ref: 5.178
        /// _Idx: 81
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.178 (Time Zone). The airport's or heliport's standard-time offset
        /// from UTC, as a zone letter plus an extra minutes correction.
        /// </remarks>
        public string TimeZoneLetter { get; set; }

        /// <summary>
        /// Time Zone - TimeZoneMinutes
        /// _Ref: 5.178
        /// _Idx: 82:83
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.178 (Time Zone). The airport's or heliport's standard-time offset
        /// from UTC, as a zone letter plus an extra minutes correction.
        /// </remarks>
        public string TimeZoneMinutes { get; set; }

        /// <summary>
        /// Daylight Indicator
        /// _Ref: 5.179
        /// _Idx: 84
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the facility observes daylight saving / summer time.
        /// <para>FAA: Not mentioned in the readme, and never populated: all 13,321 airport and all 6,134 heliport records carry a space. Since Time Zone is blank too, the CIFP gives no local-time information at all for U.S. facilities.</para>
        /// <para>Never populated in the FAA CIFP.</para>
        /// </remarks>
        public string DaylightIndicator { get; set; }

        /// <summary>
        /// Pad Dimensions - PadDimensionA
        /// _Ref: 5.176
        /// _Idx: 85:87
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.176 (Pad Dimensions). The size of a helicopter landing pad in
        /// feet, packed as two three-digit numbers.
        /// </remarks>
        public string PadDimensionA { get; set; }

        /// <summary>
        /// Pad Dimensions - PadDimensionB
        /// _Ref: 5.176
        /// _Idx: 88:90
        /// _MaxLength: 3
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 4 of the composite field 5.176 (Pad Dimensions). The size of a helicopter landing pad in
        /// feet, packed as two three-digit numbers.
        /// </remarks>
        public string PadDimensionB { get; set; }

        /// <summary>
        /// Magnetic/True Indicator
        /// _Ref: 5.165
        /// _Idx: 91
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
        /// _Idx: 92
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? ReservedExpansion { get; set; }

        /// <summary>
        /// Heliport Name
        /// _Ref: 5.71
        /// _Idx: 93:122
        /// _MaxLength: 30
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Plain-language facility name for a navaid, airport or heliport, taken from official government
        /// publications.
        /// </remarks>
        public string? HeliportName { get; set; }

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