using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - PathPointContinuation (PP) continuation record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.28.2 Path Point Continuation (Path Point Continuation-PP). Identified by
    /// Section Code 'P' and Subsection Code 'P'. Continuation Record Number is at zero-based index 26; '0'
    /// or '1' marks a primary record and anything else a continuation.
    /// </remarks>
    public class PathPointContinuationCifpDataModel
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
        /// Blank
        /// _Idx: 5
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? Blank { get; set; }

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
        /// Approach Procedure Ident
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
        /// </remarks>
        public string ApproachProcedureIdent { get; set; }

        /// <summary>
        /// Runway or Helipad Identifier
        /// _Ref: 5.46 or 5.180
        /// _Idx: 19:23
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Five columns naming a runway, normally 'RW' plus a two-digit magnetic-heading designator plus an
        /// optional suffix letter, but in the FAA CIFP also a bare non-numeric designator such as N, SE or ALL.
        /// <para>This column carries one of two different fields depending on context: 5.46 or 5.180. It is left as raw text so neither reading is lost.</para>
        /// <para>FAA: Two FAA deviations, both stated in the CIFP readme, and both of which break a naive regular expression of ^RW\d{2}[CLRT ]?$: 1. Extra suffixes. The FAA includes runway-surface and use suffixes that ARINC does not define: W water runway S soft-surface runway G glider runway U ultralight runway a digit assault strip So 'RW17W', 'RW13S', 'RW09G', 'RW26U' and 'RW05' followed by a digit are all legitim</para>
        /// <para>Layout note: For helicopter procedures to a pad or point in space, runway number=00, runway letter is blank, and the pad identifier and/or final approach course are in the Continuation Record.</para>
        /// </remarks>
        public string RunwayOrHelipadIdentifier { get; set; }

        /// <summary>
        /// Operation Type
        /// _Ref: 5.223
        /// _Idx: 24:25
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Classifies the kind of final approach segment a path point record describes.
        /// <para>FAA: The readme does not mention it. All 4,905 path point primary records carry '00' - every FAA path point describes a straight-in final approach segment.</para>
        /// </remarks>
        public string OperationType { get; set; }

        /// <summary>
        /// Continuation Record Number
        /// _Ref: 5.16
        /// _Idx: 26
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
        /// _Idx: 27
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
        /// (FPAP) Ellipsoid Height
        /// _Ref: 5.225
        /// _Idx: 28:33
        /// _MaxLength: 6
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Height of a surveyed point above (or below) the WGS-84 ellipsoid, in tenths of a metre with an
        /// explicit sign.
        /// <para>FAA: The readme names this field explicitly: "Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available." That half of the statement holds - 6,282 of 16,805 runway records carry a value. Gradient never does. On path point records, all 4,905 primaries carry an LTP ellipsoidal height (3,441 distinct values), but the FPAP ellipsoidal height on the continuation r</para>
        /// </remarks>
        public double? FpapEllipsoidHeight { get; set; }

        /// <summary>
        /// (FPAP) Orthometric Height
        /// _Ref: 5.227
        /// _Idx: 34:39
        /// _MaxLength: 6
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Height of a surveyed point above mean sea level, in tenths of a metre with an explicit sign.
        /// <para>FAA: Not mentioned in the readme. Both instances are fully populated on all 4,905 path point continuation records - 3,310 distinct FPAP values and 3,308 distinct LTP values, mostly small positive numbers in the tens of metres.</para>
        /// </remarks>
        public double? FpapOrthometricHeight { get; set; }

        /// <summary>
        /// (LTP) Orthometric Height
        /// _Ref: 5.227
        /// _Idx: 40:45
        /// _MaxLength: 6
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Height of a surveyed point above mean sea level, in tenths of a metre with an explicit sign.
        /// <para>FAA: Not mentioned in the readme. Both instances are fully populated on all 4,905 path point continuation records - 3,310 distinct FPAP values and 3,308 distinct LTP values, mostly small positive numbers in the tens of metres.</para>
        /// </remarks>
        public double? LtpOrthometricHeight { get; set; }

        /// <summary>
        /// Approach Type Identifier
        /// _Ref: 5.262
        /// _Idx: 46:55
        /// _MaxLength: 10
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// The literal name of a vertically guided approach type that requires path point data, such as LPV or
        /// LP.
        /// <para>FAA: Not mentioned in the readme by name, but the CIFP's approach inventory constrains it. Only two values appear across all 4,905 path point continuation records: 'LPV' (4,187) and 'LP' (718). The correlation with the alert limits is exact - every LPV record has vertical alert limit 500 (50.0 m) or 350 (35.0 m), and every LP record has 000, because LP is a lateral-only service. GLS never appears, cons</para>
        /// </remarks>
        public string? ApproachTypeIdentifier { get; set; }

        /// <summary>
        /// GNSS Channel Number
        /// _Ref: 5.244
        /// _Idx: 56:60
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Five-digit channel number that identifies which augmentation system and reference path the procedure
        /// uses.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point continuation records carry a channel, 4,904 of them distinct, ranging from 40000 to 99747. Every single one falls in the SBAS band - the FAA publishes no GBAS/GLS procedures in the CIFP, which matches the readme's statement that GLS procedures are not included.</para>
        /// </remarks>
        public int? GnssChannelNumber { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 61:70
        /// _MaxLength: 10
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Helicopter Procedure Course
        /// _Ref: 5.269
        /// _Idx: 71:73
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Final approach course, in whole degrees, for helicopter procedures flown to a helipad or to a point
        /// in space.
        /// </remarks>
        public int? HelicopterProcedureCourse { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 74:122
        /// _MaxLength: 49
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