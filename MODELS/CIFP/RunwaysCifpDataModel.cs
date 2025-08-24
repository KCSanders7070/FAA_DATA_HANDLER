using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Runways (PG) section data
    /// </summary>
    /// <remarks>
    /// Provides supplemental details about a runway, such as surface characteristics or operational limitations (e.g., GROOVED, SINGLE ENG. ONLY).
    /// </remarks>
    public class RunwaysCifpDataModel
    {

        /// <summary>
        /// Record Type
        /// _Ref: 5.2
        /// _Idx: 0
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Record types are divided into "standard" (S) and "tailored" (T) groups based on the first column; standard records precede tailored records in the file.
        /// </remarks>
        public string? RecordType { get; set; }

        /// <summary>
        /// Customer/Area Code
        /// _Ref: 5.3
        /// _Idx: 1:3
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the customer or area the data is intended for, such as nations (e.g., USA, CAN, EUR) or operators (e.g., UAL, DAL).
        /// </remarks>
        public string? CustomerAreaCode { get; set; }

        /// <summary>
        /// Section Code
        /// _Ref: 5.4
        /// _Idx: 4
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Single character identifying the data section or domain, such as NAVAIDS (D), AIRPORT (P), ENROUTE (E), etc.
        /// </remarks>
        public string? SectionCode { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 5
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Airport ICAO Identifier
        /// _Ref: 5.6
        /// _Idx: 6:9
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Contains the ICAO airport identifier to which the record's data applies. If there is no published ICAO Airport Identifier, then the published FAA Airport Identifier will be used.
        /// </remarks>
        public string? AirportIdentifier { get; set; }

        /// <summary>
        /// ICAO Code
        /// _Ref: 5.14
        /// _Idx: 10:11
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Two-character ICAO code used for geographic categorization, typically based on ICAO Doc 7910. U.S. codes begin with 'K' followed by a digit for regional subdivision (e.g., K1, K7). Used for airports with at least one hard-surfaced runway or supporting enroute airway structure. If no ICAO identifier is published, the FAA identifier is used instead.
        /// </remarks>
        public string? AirportIcaoLocationCode { get; set; }

        /// <summary>
        /// Subsection Code
        /// _Ref: 5.5
        /// _Idx: 12
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the specific subsection within a major database section where the record resides; used with Section Code and record identifier to reference related data such as fixes, procedures, communications, and routes.
        /// </remarks>
        public string? SubsectionCode { get; set; }

        /// <summary>
        /// Runway Identifier
        /// _Ref: 5.46
        /// _Idx: 13:17
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the runway ID associated with runway data or ILS/MLS records, formatted as “RW” plus a two-digit number (01–36) and optional suffix: C (Center), L (Left), R (Right), T (True degrees), or special types W (Water), S (Soft-surface), G (Glider), U (Ultralight), numeric (Assault Strip); e.g., RW26L, RW08R, RW26C, RW05, RW17T. Note: Non-numeric runway identifiers (5.46) are included and will not carry the prefixed ‘RW’ characters.
        /// </remarks>
        public string? RwyId { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 18:20
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Continuation Record No.
        /// _Ref: 5.16
        /// _Idx: 21
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the position of a continuation record in a sequence; primary records use '0' if no continuation follows, '1' if they do, with continuations numbered '2'â€“'9' and then 'A'â€“'Z' as needed.
        /// </remarks>
        public string? ContinuationRecordNumber { get; set; }

        /// <summary>
        /// Runway Length
        /// _Ref: 5.57
        /// _Idx: 22:26
        /// _MaxLength: 5
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Indicates the total declared runway surface length in feet (to 1-ft resolution) for the identified runway, excluding displaced thresholds, stopways, overruns, and clearways; operational lengths may differ and require review of displaced threshold and stopway data (e.g., 05000, 07000, 11480).
        /// </remarks>
        public string? RwyLength { get; set; }

        /// <summary>
        /// Runway Magnetic Bearing
        /// _Ref: 5.58
        /// _Idx: 27:30
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Represents the magnetic bearing of the specified runway in degrees and tenths (decimal suppressed), with a trailing “T” used for true bearings (e.g., 1800, 2302, 0605, 347T). Note: If a magnetic variation is not available to help determine Runway Magnetic Bearings, one will be calculated using the WMM calculator.
        /// </remarks>
        public string? RwyMagBearing { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 31
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Runway Latitude
        /// _Ref: 5.36
        /// _Idx: 32:40
        /// _MaxLength: 9
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigational feature using one alpha character ('N' or 'S') followed by eight digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., N39513881).
        /// </remarks>
        public string? RwyLat { get; set; }

        /// <summary>
        /// Runway Longitude
        /// _Ref: 5.37
        /// _Idx: 41:50
        /// _MaxLength: 10
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigational feature using one alpha character ('E' or 'W') followed by nine digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., W104450794).
        /// </remarks>
        public string? RwyLong { get; set; }

        /// <summary>
        /// Runway Gradient
        /// _Ref: 5.212
        /// _Idx: 51:55
        /// _MaxLength: 5
        /// _DataType: Double
        /// </summary>
        /// <remarks>
        /// Indicates the overall runway gradient in percent from the takeoff roll start to runway end, expressed with a leading “+” (upward) or “–” (downward) and four digits with the decimal suppressed; max range ±9.000% (e.g., +0450, -0300). Note: Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available.
        /// </remarks>
        public string? RwyGradient { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 56:59
        /// _MaxLength: 4
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// (LTP) Ellipsoid Height
        /// _Ref: 5.225
        /// _Idx: 60:65
        /// _MaxLength: 6
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the surveyed height relative to the WGS-84 ellipsoid in meters (0.1 m resolution, decimal suppressed), with a leading “+” or “–” indicating above or below the ellipsoid; applies to LTP positions in Path Point Records or landing thresholds in Runway Records (e.g., +00356, +00051, +015, -00022, -01566). Note: Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available.
        /// </remarks>
        public string? EllipsoidHeight { get; set; }

        /// <summary>
        /// Landing Threshold Elevation
        /// _Ref: 5.68
        /// _Idx: 66:70
        /// _MaxLength: 5
        /// _DataType: Double
        /// </summary>
        /// <remarks>
        /// Represents the elevation of a runway’s landing threshold in feet (1-ft resolution), expressed as numeric values above MSL or with a leading “–” for below MSL (e.g., 01250, -0150).
        /// </remarks>
        public string? LandingThresholdElev { get; set; }

        /// <summary>
        /// Displaced Threshold Distance
        /// _Ref: 5.69
        /// _Idx: 71:74
        /// _MaxLength: 4
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Specifies the distance in feet from the runway end to a displaced threshold when the threshold is not located at the extremity (e.g., 0485, 1260).
        /// </remarks>
        public string? DisplayedThresholdDistance { get; set; }

        /// <summary>
        /// Threshold Crossing Height
        /// _Ref: 5.67
        /// _Idx: 75:76
        /// _MaxLength: 2
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Defines the height above the landing threshold on a standard glide path, sourced from ILS/MLS glide slope, RNAV procedure, published VGSI, or defaulted to 50 ft when unavailable; also used in approach continuation and ILS/MLS records (e.g., 37, 50, 99, 044, 055, 102).
        /// </remarks>
        public string? ThresholdCrossingHeight { get; set; }

        /// <summary>
        /// Runway Width
        /// _Ref: 5.109
        /// _Idx: 77:79
        /// _MaxLength: 3
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Specifies the runway width in feet (1-ft resolution), recorded as the minimum width when the runway varies along its length (e.g., 150, 300, 075).
        /// </remarks>
        public string? RwyWidth { get; set; }

        /// <summary>
        /// TCH Value Indicator
        /// _Ref: 5.27
        /// _Idx: 80
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the source of the Threshold Crossing Height (TCH) in runway records: I = ILS/MLS glide slope, R = RNAV procedure, V = VGSI for the runway, D = default value of 50 ft.
        /// </remarks>
        public string? TchValueIndicator { get; set; }

        /// <summary>
        /// Localizer/MLS/ GLS Ref Path Identifier
        /// _Ref: 5.44
        /// _Idx: 81:84
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the Localizer, MLS facility, or GLS Reference Path linked to a runway, with fields available for multiple systems (e.g., ILS and LDA); values contain the facility or reference path code (e.g., IDEN, ISTX, IDU, MDEN, MSTX, MLAX, LFBL, EGLC, KSAN).
        /// </remarks>
        public string? LocMlsGlsRefPathIdentifier { get; set; }

        /// <summary>
        /// Localizer/ MLS/ GLS Category/ Class
        /// _Ref: 5.8
        /// _Idx: 85
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the performance category or classification of a Localizer/MLS/GLS system, including ILS Categories I–III, or classifications for non-ILS systems such as IGS, LDA, or SDF, with codes assigned per table (e.g., 0 = ILS Localizer only, 1 = Category I, 2 = Category II, 3 = Category III, I = IGS, L = LDA w/Glideslope, A = LDA no Glideslope, S = SDF w/Glideslope, F = SDF no Glideslope).
        /// </remarks>
        public string? LocMlsGlsCategoryClass { get; set; }

        /// <summary>
        /// Stopway
        /// _Ref: 5.79
        /// _Idx: 86:89
        /// _MaxLength: 4
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Represents the length in feet of a designated area beyond the runway, aligned with its centerline, intended for aircraft deceleration during an aborted takeoff (e.g., 0900, 1000).
        /// </remarks>
        public string? Stopway { get; set; }

        /// <summary>
        /// Second Localizer/ MLS/ GLS Ref Path Ident
        /// _Ref: 5.44
        /// _Idx: 90:93
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Second ID for the Localizer, MLS facility, or GLS Reference Path linked to a runway, with fields available for multiple systems (e.g., ILS and LDA); values contain the facility or reference path code (e.g., IDEN, ISTX, IDU, MDEN, MSTX, MLAX, LFBL, EGLC, KSAN).
        /// </remarks>
        public string? SecondLocMlsGlsRefPathIdentifier { get; set; }

        /// <summary>
        /// Second Localizer/ MLS/ GLS Category/ Class
        /// _Ref: 5.8
        /// _Idx: 94
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Second ID for the performance category or classification of a Localizer/MLS/GLS system, including ILS Categories I–III, or classifications for non-ILS systems such as IGS, LDA, or SDF, with codes assigned per table (e.g., 0 = ILS Localizer only, 1 = Category I, 2 = Category II, 3 = Category III, I = IGS, L = LDA w/Glideslope, A = LDA no Glideslope, S = SDF w/Glideslope, F = SDF no Glideslope).
        /// </remarks>
        public string? SecondLocMlsGlsCategoryClass { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 95:100
        /// _MaxLength: 6
        /// </summary>
        /// <remarks>
        /// Not used yet but may be in the future.
        /// </remarks>
        // public string ReservedExpansion { get; set; }

        /// <summary>
        /// Runway Description
        /// _Ref: 5.59
        /// _Idx: 101:122
        /// _MaxLength: 22
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Provides supplemental details about a runway, such as surface characteristics or operational limitations (e.g., GROOVED, SINGLE ENG. ONLY).
        /// </remarks>
        public string? RwyDescription { get; set; }

        /// <summary>
        /// File Record No.
        /// _Ref: 5.31
        /// _Idx: 123:127
        /// _MaxLength: 5
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Sequential reference number assigned to each record for housekeeping purposes, starting at 00001 and resetting to 00000 after 99999; subject to change with each file update. Examples (pad zeros left): 10640, 00420, 31462
        /// </remarks>
        public string? FileRecordNum { get; set; }

        /// <summary>
        /// Cycle Date
        /// _Ref: 5.32
        /// _Idx: 128:131
        /// _MaxLength: 4
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Identifies the 28-day data update cycle in which the record was added or last revised; format is YYCC, where YY is the last two digits of the year and CC is the cycle number (01â€“13, occasionally 14). Example (pad zeros left): Cycle 11 in the year 2032 would be "3211". A cycle date change will happen for any change to fields except Dynamic Magnetic Variation, Frequency Protection, Continuation Record Number, and File Record Number.
        /// </remarks>
        public string? CycleDate { get; set; }
    }
}