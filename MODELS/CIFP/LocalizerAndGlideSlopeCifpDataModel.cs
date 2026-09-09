using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - LocalizerAndGlideSlope (PI) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.11.1 Airport and Heliport Localizer and Glide Slope (Localizer and Glide Slope-
    /// PI). Identified by Section Code 'P' and Subsection Code 'I'. Continuation Record Number is at zero-
    /// based index 21; '0' or '1' marks a primary record and anything else a continuation.
    /// </remarks>
    public class LocalizerAndGlideSlopeCifpDataModel
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
        /// </remarks>
        public string? Subsection { get; set; }

        /// <summary>
        /// Localizer Identifier
        /// _Ref: 5.44
        /// _Idx: 13:16
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Identifier of the localizer, MLS facility or GLS reference path serving the record, up to four
        /// characters.
        /// <para>FAA: The FAA adds PI (localizer and glide slope) records only for procedures that are actually in the CIFP, so a runway can carry a blank identifier here even though the real runway has an ILS - the absence means 'no CIFP procedure', not 'no ILS'. ILS CAT II, ILS CAT III, PRM, converging ILS and GLS procedures are excluded from the CIFP, so no GLS reference path identifiers occur.</para>
        /// </remarks>
        public string? LocalizerIdentifier { get; set; }

        /// <summary>
        /// ILS Category
        /// _Ref: 5.80
        /// _Idx: 17
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Performance category of an ILS/MLS/GLS facility, or the classification of a non-ILS localizer-type
        /// installation such as LDA, SDF or IGS.
        /// <para>FAA: The FAA includes ILS procedures for Category I only, and does not include CAT II, CAT III, PRM, converging ILS or GLS procedures. Category 2 and 3 values nonetheless appear here because this field describes the FACILITY classification, not the procedures published to it. For LDA approaches that have both LDA and glide slope minima, the FAA codes the procedure to LDA minimums only - which is consis</para>
        /// </remarks>
        public string IlsCategory { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 18:20
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

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
        /// Localizer Frequency
        /// _Ref: 5.45
        /// _Idx: 22:26
        /// _MaxLength: 5
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Localizer VHF frequency as five digits with the decimal point removed - megahertz times one hundred.
        /// </remarks>
        public double? LocalizerFrequency { get; set; }

        /// <summary>
        /// Runway Identifier
        /// _Ref: 5.46
        /// _Idx: 27:31
        /// _MaxLength: 5
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Five columns naming a runway, normally 'RW' plus a two-digit magnetic-heading designator plus an
        /// optional suffix letter, but in the FAA CIFP also a bare non-numeric designator such as N, SE or ALL.
        /// <para>FAA: Two FAA deviations, both stated in the CIFP readme, and both of which break a naive regular expression of ^RW\d{2}[CLRT ]?$: 1. Extra suffixes. The FAA includes runway-surface and use suffixes that ARINC does not define: W water runway S soft-surface runway G glider runway U ultralight runway a digit assault strip So 'RW17W', 'RW13S', 'RW09G', 'RW26U' and 'RW05' followed by a digit are all legitim</para>
        /// </remarks>
        public string RunwayIdentifier { get; set; }

        /// <summary>
        /// Localizer Latitude
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
        public double? LocalizerLatitude { get; set; }

        /// <summary>
        /// Localizer Longitude
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
        public double? LocalizerLongitude { get; set; }

        /// <summary>
        /// Localizer Bearing
        /// _Ref: 5.47
        /// _Idx: 51:54
        /// _MaxLength: 4
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Magnetic bearing of the localizer front course (or GLS approach course) in tenths of a degree with
        /// the decimal point removed.
        /// </remarks>
        public double? LocalizerBearing { get; set; }

        /// <summary>
        /// Glide Slope Latitude
        /// _Ref: 5.36
        /// _Idx: 55:63
        /// _MaxLength: 9
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Signed latitude packed as a hemisphere letter followed by eight digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// </remarks>
        public double? GlideSlopeLatitude { get; set; }

        /// <summary>
        /// Glide Slope Longitude
        /// _Ref: 5.37
        /// _Idx: 64:73
        /// _MaxLength: 10
        /// _DataType: Double
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Signed longitude packed as a hemisphere letter followed by nine digits of degrees, minutes, seconds
        /// and hundredths of a second.
        /// </remarks>
        public double? GlideSlopeLongitude { get; set; }

        /// <summary>
        /// Localizer Position
        /// _Ref: 5.48
        /// _Idx: 74:77
        /// _MaxLength: 4
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Distance in feet from the localizer (or MLS azimuth) antenna to the runway end, at one-foot
        /// resolution.
        /// </remarks>
        public int? LocalizerPosition { get; set; }

        /// <summary>
        /// Localizer Position Reference
        /// _Ref: 5.49
        /// _Idx: 78
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Single character saying where the antenna sits relative to the runway, qualifying the distance in
        /// 5.48.
        /// </remarks>
        public string? LocalizerPositionReference { get; set; }

        /// <summary>
        /// Glide Slope Position
        /// _Ref: 5.50
        /// _Idx: 79:82
        /// _MaxLength: 4
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Distance in feet from the runway threshold to the glide slope antenna, measured along the runway.
        /// </remarks>
        public int? GlideSlopePosition { get; set; }

        /// <summary>
        /// Localizer Width
        /// _Ref: 5.51
        /// _Idx: 83:86
        /// _MaxLength: 4
        /// _DataType: Decimal
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Full course width of the localizer, in degrees, with the decimal point removed.
        /// </remarks>
        public decimal? LocalizerWidth { get; set; }

        /// <summary>
        /// Glide Slope Angle
        /// _Ref: 5.52
        /// _Idx: 87:89
        /// _MaxLength: 3
        /// _DataType: Decimal
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Glide slope angle in degrees with the decimal point removed (three digits, hundredths resolution).
        /// </remarks>
        public decimal? GlideSlopeAngle { get; set; }

        /// <summary>
        /// Station Declination - DeclinationDirection
        /// _Ref: 5.66
        /// _Idx: 90
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 1 of the composite field 5.66 (Station Declination). Angular offset between true north and
        /// the reference the facility is aligned to, given as a direction letter followed by degrees and
        /// tenths.
        /// </remarks>
        public string StationDeclinationDirection { get; set; }

        /// <summary>
        /// Station Declination - DeclinationMagnitude
        /// _Ref: 5.66
        /// _Idx: 91:94
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Column 2 of the composite field 5.66 (Station Declination). Angular offset between true north and
        /// the reference the facility is aligned to, given as a direction letter followed by degrees and
        /// tenths.
        /// </remarks>
        public string StationDeclinationMagnitude { get; set; }

        /// <summary>
        /// Glide Slope Height at Landing Threshold
        /// _Ref: 5.67
        /// _Idx: 95:96
        /// _MaxLength: 2
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Height in feet above the landing threshold at which a nominal glide path crosses it.
        /// </remarks>
        public int? GlideSlopeHeightAtLandingThreshold { get; set; }

        /// <summary>
        /// Glide Slope Elevation
        /// _Ref: 5.74
        /// _Idx: 97:101
        /// _MaxLength: 5
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// Elevation in feet MSL of a specific navigation component: the glide slope, MLS elevation, azimuth or
        /// back azimuth antenna, or the GLS ground station.
        /// </remarks>
        public int? GlideSlopeElevation { get; set; }

        /// <summary>
        /// Supporting Facility ID
        /// _Ref: 5.33
        /// _Idx: 102:105
        /// _MaxLength: 4
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// Official one- to four-character identification code of the VHF or MF/LF navigation facility
        /// described by the record.
        /// <para>Layout note: Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS.</para>
        /// </remarks>
        public string? SupportingFacilityId { get; set; }

        /// <summary>
        /// Supporting Facility ICAO Location Code
        /// _Ref: 5.14
        /// _Idx: 106:107
        /// _MaxLength: 2
        /// _DataType: String
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// A two-character geographic qualifier, based on the ICAO location indicator, that scopes an
        /// identifier so the same fix name in two parts of the world can be told apart.
        /// <para>FAA: Fixes that the NASR database classifies as offshore may be given a customer/area code of USA together with an ICAO code of "K " or "P " - that is, the letter followed by a blank or null rather than a region digit. PC (terminal waypoint) records keep their own ICAO code even when it differs from the parent airport whose area code they inherit.</para>
        /// <para>Layout note: Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS.</para>
        /// </remarks>
        public string SupportingFacilityIcaoLocationCode { get; set; }

        /// <summary>
        /// Supporting Facility Section Code
        /// _Ref: 5.4
        /// _Idx: 108
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter naming the major database section a record belongs to - or, on pointer fields, the
        /// section of the record being referenced.
        /// <para>FAA: The FAA readme does not call this field out directly, but it fixes the set of sections the CIFP can contain: A (Grid MORA), D (VHF and NDB NAVAIDs), E (enroute waypoints and airways), H (heliports and heli terminal data), P (airport and terminal data) and U (controlled and special use airspace). No other section is produced.</para>
        /// <para>Layout note: Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS.</para>
        /// </remarks>
        public string? SupportingFacilitySectionCode { get; set; }

        /// <summary>
        /// Supporting Facility Subsection Code
        /// _Ref: 5.5
        /// _Idx: 109
        /// _MaxLength: 1
        /// _DataType: String
        /// _Converted: N
        /// </summary>
        /// <remarks>
        /// One letter that, combined with the Section Code, names the exact file a record belongs to - the
        /// primary key for record dispatch.
        /// <para>FAA: The CIFP contains only these twenty-one record kinds: AS, D (blank subsection), DB, PN, PA, HA, PG, PI, PP (primary and continuation), PS, HS, EA, PC, HC, PD, PE, PF (primary and Level of Service continuation), HF (primary and Level of Service continuation), ER, UC, UR (primary and continuation). Everything else in the ARINC matrix below is absent. The FAA chooses between PC and EA for a named ter</para>
        /// <para>Layout note: Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS.</para>
        /// </remarks>
        public string? SupportingFacilitySubsectionCode { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 110:122
        /// _MaxLength: 13
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