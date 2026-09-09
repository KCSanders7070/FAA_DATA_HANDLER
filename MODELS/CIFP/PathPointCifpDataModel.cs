using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - PathPoint (PP) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.28.1 Path Point (Path Point-PP). Identified by Section Code 'P' and Subsection
    /// Code 'P'. Continuation Record Number is at zero-based index 26; '0' or '1' marks a primary record
    /// and anything else a continuation.
    /// </remarks>
    public class PathPointCifpDataModel
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
        /// Route Indicator
        /// _Ref: 5.224
        /// _Idx: 27
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// A single letter distinguishing between several different final approach segments serving the same
        /// runway or helipad.
        /// <para>FAA: Not mentioned in the readme. Observed on path point primaries: blank 4,432, 'Y' 330, 'Z' 129, 'X' 14. So the FAA uses only the tail end of the alphabet, matching its Y/Z/X approach naming convention.</para>
        /// </remarks>
        public string? RouteIndicator { get; set; }

        /// <summary>
        /// SBAS Service Provider Identifier
        /// _Ref: 5.255
        /// _Idx: 28:29
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Two-digit code tying the approach to a particular satellite based augmentation system service
        /// provider.
        /// <para>FAA: The readme does not mention the field. All 4,905 path point primary records carry '00', which is consistent with a single U.S. provider (WAAS) for the whole dataset.</para>
        /// </remarks>
        public int? SbasServiceProviderIdentifier { get; set; }

        /// <summary>
        /// Reference Path Data Selector
        /// _Ref: 5.256
        /// _Idx: 30:31
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Two-digit selector that lets GBAS avionics tune the correct approach data block automatically.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primary records carry '00'. That is expected - the FAA publishes no GBAS/GLS procedures in the CIFP, so there is no data block to select.</para>
        /// </remarks>
        public int? ReferencePathDataSelector { get; set; }

        /// <summary>
        /// Reference Path Identifier
        /// _Ref: 5.257
        /// _Idx: 32:35
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Four-character identifier a crew can use to confirm the avionics tuned the intended approach - the
        /// augmented-approach equivalent of an ILS Morse ident.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry a value, 95 distinct. The FAA uses a systematic scheme rather than free text: a leading 'W' (for WAAS), then the two-digit runway number, then a letter - 'W18A', 'W36A', 'W35A', 'W13A', 'W27A'. The trailing letter distinguishes multiple reference paths to the same runway number.</para>
        /// </remarks>
        public string? ReferencePathIdentifier { get; set; }

        /// <summary>
        /// Approach Performance Designator
        /// _Ref: 5.258
        /// _Idx: 36
        /// _MaxLength: 1
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Single digit stating the type or category of approach the path point record supports.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primary records carry '0'. Combined with the approach type identifiers on the continuation records (LPV and LP only), '0' evidently corresponds to the non-precision-approach-category SBAS approaches the FAA publishes.</para>
        /// </remarks>
        public int? ApproachPerformanceDesignator { get; set; }

        /// <summary>
        /// Landing Threshold Point Latitude
        /// _Ref: 5.267
        /// _Idx: 37:47
        /// _MaxLength: 11
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Latitude of a path point feature at 0.0001 arc-second resolution - the high precision extension of
        /// the ordinary latitude field.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry both latitudes; 4,881 distinct LTP values, so a handful of thresholds are shared between procedures.</para>
        /// </remarks>
        public double? LandingThresholdPointLatitude { get; set; }

        /// <summary>
        /// Landing Threshold Point Longitude
        /// _Ref: 5.268
        /// _Idx: 48:59
        /// _MaxLength: 12
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Longitude carried at the extra precision the FAS data block needs, used for the landing threshold
        /// and flight path alignment points on Path Point records.
        /// </remarks>
        public double? LandingThresholdPointLongitude { get; set; }

        /// <summary>
        /// (LTP) Ellipsoid Height
        /// _Ref: 5.225
        /// _Idx: 60:65
        /// _MaxLength: 6
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Height of a surveyed point above (or below) the WGS-84 ellipsoid, in tenths of a metre with an
        /// explicit sign.
        /// <para>FAA: The readme names this field explicitly: "Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available." That half of the statement holds - 6,282 of 16,805 runway records carry a value. Gradient never does. On path point records, all 4,905 primaries carry an LTP ellipsoidal height (3,441 distinct values), but the FPAP ellipsoidal height on the continuation r</para>
        /// </remarks>
        public double? LtpEllipsoidHeight { get; set; }

        /// <summary>
        /// Glide Path Angle
        /// _Ref: 5.226
        /// _Idx: 66:69
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The intended descent angle of the final approach path, in hundredths of a degree.
        /// <para>FAA: Not mentioned in the readme. Observed on all 4,905 path point primaries, 81 distinct values from '0000' to '0570' (0.00 to 5.70 degrees). '0300' - a standard 3.00 degree path - covers 4,229 of them. A value of '0000' appears on 180 records and correlates exactly with LP procedures: every 0000 record has approach type identifier 'LP' on its continuation record and vertical alert limit '000'. So 000</para>
        /// </remarks>
        public double? GlidePathAngle { get; set; }

        /// <summary>
        /// Flight Path Alignment Point Latitude
        /// _Ref: 5.267
        /// _Idx: 70:80
        /// _MaxLength: 11
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Latitude of a path point feature at 0.0001 arc-second resolution - the high precision extension of
        /// the ordinary latitude field.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry both latitudes; 4,881 distinct LTP values, so a handful of thresholds are shared between procedures.</para>
        /// </remarks>
        public double? FlightPathAlignmentPointLatitude { get; set; }

        /// <summary>
        /// Flight Path Alignment Point Longitude
        /// _Ref: 5.268
        /// _Idx: 81:92
        /// _MaxLength: 12
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Longitude carried at the extra precision the FAS data block needs, used for the landing threshold
        /// and flight path alignment points on Path Point records.
        /// </remarks>
        public double? FlightPathAlignmentPointLongitude { get; set; }

        /// <summary>
        /// Course Width at Threshold
        /// _Ref: 5.228
        /// _Idx: 93:97
        /// _MaxLength: 5
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The lateral width of the final approach course at the landing threshold, in hundredths of a metre,
        /// which sets lateral deviation sensitivity.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries are populated; 47 distinct values ranging from '08000' (80.00 m) to '14375' (143.75 m), with '10675' (106.75 m) on 4,804 of them. Every value ends in 00, 25, 50 or 75 as required. The 38.00 m helicopter value never appears, because there are no runway-00 path point records in the file.</para>
        /// <para>Layout note: If Runway Number = 00 (helipad), the Course Width field is ignored.</para>
        /// </remarks>
        public double? CourseWidthAtThreshold { get; set; }

        /// <summary>
        /// Length Offset
        /// _Ref: 5.259
        /// _Idx: 98:101
        /// _MaxLength: 4
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Distance in metres from the stop end of the runway to the Flight Path Alignment Point, marking where
        /// lateral sensitivity switches to missed approach sensitivity.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry a value, 239 distinct, ranging from 0000 to 2016 metres, and every single one is an exact multiple of 8 - a useful validation check. The most common are 1224 m (597 records) and 0000 (565 records).</para>
        /// </remarks>
        public int? LengthOffset { get; set; }

        /// <summary>
        /// Path Point TCH
        /// _Ref: 5.265
        /// _Idx: 102:107
        /// _MaxLength: 6
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The height of the approach path above the landing threshold or helicopter alighting point, at higher
        /// resolution than the ordinary TCH field.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry a value with units 'F', 287 distinct, from '000000' to '000680' - so 0.0 to 68.0 feet. The common ones are 000400 (40.0 ft, 1,221 records), 000450 (45.0 ft) and 000500 (50.0 ft), which are typical published TCH values. 177 records carry 000000; those pair with the LP procedures that have no vertical guidance.</para>
        /// </remarks>
        public double? PathPointTch { get; set; }

        /// <summary>
        /// TCH Units Indicator
        /// _Ref: 5.266
        /// _Idx: 108
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Says whether the Path Point TCH beside it is expressed in feet or in metres.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primary records carry 'F'; the FAA publishes threshold crossing heights in feet throughout.</para>
        /// </remarks>
        public string TchUnitsIndicator { get; set; }

        /// <summary>
        /// HAL
        /// _Ref: 5.263
        /// _Idx: 109:111
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The radius of the horizontal containment circle the navigation solution must stay inside, in tenths
        /// of a metre.
        /// <para>FAA: Not mentioned in the readme. All 4,905 path point primaries carry '400' - 40.0 metres, the standard LPV/LP horizontal alert limit. There is no variation in the dataset.</para>
        /// </remarks>
        public double? Hal { get; set; }

        /// <summary>
        /// VAL
        /// _Ref: 5.264
        /// _Idx: 112:114
        /// _MaxLength: 3
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Half the height of the vertical containment segment the navigation solution must stay inside, in
        /// tenths of a metre.
        /// <para>FAA: Not mentioned in the readme, but the observed values map exactly onto the FAA's SBAS service levels, cross-checked against the approach type identifier (5.262) on the matching continuation record: '500' (50.0 m) on 2,985 records - all LPV, the standard LPV vertical alert limit. '350' (35.0 m) on 1,202 records - all LPV, the tighter LPV-200 limit. '000' on 718 records - all LP, which is a lateral-o</para>
        /// </remarks>
        public double? Val { get; set; }

        /// <summary>
        /// SBAS FAS Data CRC Remainder
        /// _Ref: 5.229
        /// _Idx: 115:122
        /// _MaxLength: 8
        /// _DataType: UInt
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Eight-character hexadecimal representation of the 32-bit CRC that protects the final approach
        /// segment data block.
        /// <para>FAA: The readme does not discuss the FAS CRC specifically, but it does state the whole CIFP file is wrapped with a separate 32-bit CRC calculated per ARINC Report 665. Observed: all 4,905 path point primaries carry a CRC and all 4,905 values are distinct, as expected.</para>
        /// </remarks>
        public uint? SbasFasDataCrcRemainder { get; set; }

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