using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - PathPoint (PP) section data
    /// </summary>
    /// <remarks>
    /// ???
    /// </remarks>
    public class PathPointCifpDataModel
    {
        #region PrimaryRecord

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
        /// Airport Identifier
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
        /// Approach Procedure Ident
        /// _Ref: 5.10
        /// _Idx: 13:18
        /// _MaxLength: 6
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the identifier of an approach route, including provisions for multiple procedures, circle-to-land operations, and helicopter approaches. Runway-dependent procedures use alphanumeric codes with optional multiple indicators (e.g., I26L, R29, V08-A). Circle-to-land procedures use four-character alpha identifiers with an optional fifth character for multiples (e.g., VORA, VOR-B, NDB-1). Helicopter-to-runway identifiers start with the approach type followed by a three-digit runway/course number and optional multiple indicator (e.g., I13L, V175, N175B). Helicopter-to-helipad identifiers use the approach type plus the pad designation, with no multiple indicator in this field (e.g., IA127, VBRAVO, N23, RWESTA). Col:1=Approach type (alpha, same as RouteType field) __ Col:2–3=RwyId in tens of degrees (01–36) __ Col:4=Rwy designation (L=Left, R=Right, C=Center, T=True North, dash=placeholder, blank=unused) __ Col:5=Multiple indicator (alphanumeric or blank) __ 6=Blank.
        /// </remarks>
        public string? ApproachProcedrueIdent { get; set; }

        /// <summary>
        /// Runway or Helipad Identifier
        /// _Ref: 5.46 or 5.180
        /// _Idx: 19:23
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the runway or helipad ID associated with runway/heliport data or ILS/MLS records. RUNWAYS: formatted as “RW” plus a two-digit number (01–36) and optional suffix: C (Center), L (Left), R (Right), T (True degrees), or special types W (Water), S (Soft-surface), G (Glider), U (Ultralight), numeric (Assault Strip); e.g., RW26L, RW08R, RW26C, RW05, RW17T. Note: Non-numeric runway identifiers (5.46) are included and will not carry the prefixed ‘RW’ characters. HELIPADS: unique record for each pad at a location. If not supplied from source data, identifiers are assigned by the supplier using the prefix “HELO” plus a number. Examples include source-supplied IDs like PADA1, NWPAD, ALPHA, A1 and supplier-assigned IDs like HELO1, HELO2, HELO3.
        /// </remarks>
        public string? RwyHelipadIdentifier { get; set; }

        /// <summary>
        /// Operation Type
        /// _Ref: 5.223
        /// _Idx: 24:25
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the type of final approach segment; 00 = straight-in procedure, 01–15 reserved for future use.
        /// </remarks>
        public string? OperationType { get; set; }

        /// <summary>
        /// Continuation Record Number
        /// _Ref: 5.16
        /// _Idx: 26
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the position of a continuation record in a sequence; primary records use '0' if no continuation follows, "1" if they do, with continuations numbered "2-"9" and then "A"="Z" as needed.
        /// </remarks>
        public string? ContinuationRecordNumber { get; set; }

        /// <summary>
        /// Route Indicator
        /// _Ref: 5.224
        /// _Idx: 27
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies a single alpha character (A–Z, excluding I and O) used to distinguish multiple final approach segments to the same runway or helipad, matching the Multiple Approach Indicator in procedure identifiers.
        /// </remarks>
        public string? RouteIndicator { get; set; }

        /// <summary>
        /// SBAS Service Provider Identifier
        /// _Ref: 5.255
        /// _Idx: 28:29
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Associates the approach procedure with a specific SBAS service provider, coded as a number from 00 to 15 (definitions set by ICAO SBAS SARPS working groups).
        /// </remarks>
        public string? SbasServeiceProviderId { get; set; }

        /// <summary>
        /// Reference Path Data Selector
        /// _Ref: 5.256
        /// _Idx: 30:31
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Enables automatic tuning of a procedure by GBAS avionics, represented by a number from 00 to 48 (definitions under development by ICAO GBAS SARPS working groups).
        /// </remarks>
        public string? RefPathDataSelector { get; set; }

        /// <summary>
        /// Reference Path Identifier
        /// _Ref: 5.257
        /// _Idx: 32:35
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Provides an identifier to verify selection of the correct approach procedure, functioning like a Morse code ID in ILS approaches (e.g., GDCA, SJK2). Related to the GLS Station Identifier, which is the ICAO location code of the airport or heliport where the GLS transmitter is installed.
        /// </remarks>
        public string? RefPathId { get; set; }

        /// <summary>
        /// Approach Performance Designator
        /// _Ref: 5.258
        /// _Idx: 36
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the type or category of approach, represented by a number from 0 to 7, with assignments defined by ICAO GBAS SARPS and official government sources (e.g., 1 = Category I Approach).
        /// </remarks>
        public string? ApproachPerformanceDesignator { get; set; }

        /// <summary>
        /// Landing Threshold Point Latitude
        /// _Ref: 5.267
        /// _Idx: 37:47
        /// _MaxLength: 11
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigation feature. Expands on Field Ref 5.36 by improving precision resolution to 0.0005 arc-seconds (e.g., N3028422400).
        /// </remarks>
        public string? LandingThresholPointLat { get; set; }

        /// <summary>
        /// Landing Threshold Point Longitude
        /// _Ref: 5.268
        /// _Idx: 48:59
        /// _MaxLength: 12
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigation feature. Expands on Field Ref 5.37 by improving precision resolution to 0.0005 arc-seconds (e.g., W081420301000). 
        /// </remarks>
        public string? LandingThresholPointLon { get; set; }

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
        public string? LtpEllipsoidHeight { get; set; }

        /// <summary>
        /// Glide Path Angle
        /// _Ref: 5.226
        /// _Idx: 66:69
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the intended descent gradient for the final approach, given as the glide path angle in degrees, tenths, and hundredths at the Flight Path Control Point (e.g., 0275 = 2.75°, 1015 = 10.15°, 0300 = 3.00°).
        /// </remarks>
        public string? GlidePathAngle { get; set; }

        /// <summary>
        /// Flight Path Alignment Point Latitude
        /// _Ref: 5.267
        /// _Idx: 70:80
        /// _MaxLength: 11
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigation feature. Expands on Field Ref 5.36 by improving precision resolution to 0.0005 arc-seconds (e.g., N3028422400).
        /// </remarks>
        public string? FlightPathAlignmentPointLat { get; set; }

        /// <summary>
        /// Flight Path Alignment Point Longitude
        /// _Ref: 5.268
        /// _Idx: 81:92
        /// _MaxLength: 12
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigation feature. Expands on Field Ref 5.37 by improving precision resolution to 0.0005 arc-seconds (e.g., W081420301000). 
        /// </remarks>
        public string? FlightPathAlignmentPointLon { get; set; }

        /// <summary>
        /// Course Width at Threshold
        /// _Ref: 5.228
        /// _Idx: 93:97
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the lateral course width at the Landing Threshold Point (LTP), defining approach sensitivity with the FPAP location; values in meters with 0.25 m resolution, ending in 00, 25, 50, or 75, and set to 38 m for helicopter alighting points (e.g., 08025, 14375, 03800)
        /// </remarks>
        public string? CourseWidthAtThreshold { get; set; }

        /// <summary>
        /// Length Offset
        /// _Ref: 5.259
        /// _Idx: 98:101
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the distance in meters from the runway stop end (SER) to the Flight Path Alignment Point (FPAP), marking where lateral sensitivity shifts to missed approach sensitivity; resolution is 8 m, with zero used when FPAP is at the opposite runway end center (e.g., 0000, 0432).
        /// </remarks>
        public string? LengthOffset { get; set; }

        /// <summary>
        /// Path Point TCH
        /// _Ref: 5.265
        /// _Idx: 102:107
        /// _MaxLength: 6
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the Threshold Crossing Height (TCH) above the runway threshold (LTP) or helipad, matching Field Ref 5.67 but with higher precision; recorded in feet to 0.1 ft or meters to 0.01 m, decimal suppressed, with units defined by the TCH Units Indicator (e.g., 566777, 356799).
        /// </remarks>
        public string? PathPointTch { get; set; }

        /// <summary>
        /// TCH Units Indicator
        /// _Ref: 5.266
        /// _Idx: 108
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the unit of measure for the Path Point TCH: F = feet, M = meters.
        /// </remarks>
        public string? TchUnitsIndicator { get; set; }

        /// <summary>
        /// HAL
        /// _Ref: 5.263
        /// _Idx: 109:111
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the Horizontal Alert Limit (HAL), the radius in meters of a circle centered on the true position within which the indicated horizontal position must fall with required probability for a given navigation mode; recorded to 0.1 m resolution, decimal suppressed (e.g., 400, 200).
        /// </remarks>
        public string? Hal { get; set; }

        /// <summary>
        /// VAL
        /// _Ref: 5.264
        /// _Idx: 112:114
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the Vertical Alert Limit (VAL), half the vertical segment length centered on the true position within which the indicated vertical position must fall with required probability; expressed in meters to 0.1 m resolution, decimal suppressed (e.g., 120, 500).
        /// </remarks>
        public string? Val { get; set; }

        /// <summary>
        /// SBAS FAS Data CRC Remainder
        /// _Ref: 5.229
        /// _Idx: 115:122
        /// _MaxLength: 8
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Represents the 8-character hexadecimal CRC remainder for the final approach segment data, a 32-bit value ensuring data integrity calculated per the specification’s algorithm (e.g., 243BC649, A6934B72).
        /// </remarks>
        public string? SbasFasDataCrcRemainder { get; set; }

        /// <summary>
        /// File Record Number
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

        #endregion

        #region ContinuationRecord

        /// <summary>
        /// Application Type
        /// _Ref: 5.91
        /// _Idx: 27
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the application type of a continuation record: A=Standard ARINC continuation (notes/formatted data) __ B=Combined Controlling Agency/Call Sign with Time of Operation __ C=Call Sign/Controlling Agency continuation __ E=Primary Record Extension __ L=VHF Navaid Limitation continuation __ N=Sector Narrative continuation __ T=Time of Operations continuation (formatted time) __ U=Time of Operations continuation (narrative time) __ V=Time of Operations continuation (Start/End Date) __ P=Flight Planning Application continuation __ Q=Flight Planning Application Primary Data continuation __ S=Simulation Application continuation __ W=Airport/Heliport Procedure Data continuation with SBAS authorization.
        /// </remarks>
        public string? ApplicationType { get; set; }

        /// <summary>
        /// (FPAP) Ellipsoid Height
        /// _Ref: 5.225
        /// _Idx: 28:33
        /// _MaxLength: 6
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the surveyed height relative to the WGS-84 ellipsoid in meters (0.1 m resolution, decimal suppressed), with a leading “+” or “–” indicating above or below the ellipsoid; applies to LTP positions in Path Point Records or landing thresholds in Runway Records (e.g., +00356, +00051, +015, -00022, -01566). Note: Runway gradient (5.212) and ellipsoid height (5.225) are included in the runway record when available.
        /// </remarks>
        public string? FpapEllipsoidHeight { get; set; }

        /// <summary>
        /// (FPAP) Orthometric Height
        /// _Ref: 5.227
        /// _Idx: 34:39
        /// _MaxLength: 6
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the surveyed height relative to Mean Sea Level (MSL) in 0.1 m resolution, decimal suppressed, with a leading “+” for above MSL or “–” for below (e.g., +00356, +00051, +01566, -00022, -01566).
        /// </remarks>
        public string? FpapOrthometricHeight { get; set; }

        /// <summary>
        /// (LTP) Orthometric Height
        /// _Ref: 5.227
        /// _Idx: 40:45
        /// _MaxLength: 6
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the surveyed height relative to Mean Sea Level (MSL) in 0.1 m resolution, decimal suppressed, with a leading “+” for above MSL or “–” for below (e.g., +00356, +00051, +01566, -00022, -01566).
        /// </remarks>
        public string? LtpOrthometricHeight { get; set; }

        /// <summary>
        /// Approach Type Identifier
        /// _Ref: 5.262
        /// _Idx: 46:55
        /// _MaxLength: 10
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies published approach types requiring path points, HAL, and VAL, using up to 10 characters to represent the approach name (e.g., GLS, LPV, APV-II).
        /// </remarks>
        public string? ApproachTypeId { get; set; }

        /// <summary>
        /// GNSS Channel Number
        /// _Ref: 5.244
        /// _Idx: 56:60
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the GNSS channel used to decode the augmentation system, with values 20001–39999 reserved for GBAS (and SBAS if applicable) and 40000–99999 reserved for SBAS; values below 20000 are reserved for ILS/MLS (e.g., 20010, 56234).
        /// </remarks>
        public string? GnssChannelNum { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 61:70
        /// _MaxLength: 10
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Helicopter Procedure Course
        /// _Ref: 5.269
        /// _Idx: 71:73
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the final approach course in full degrees for helicopter procedures to helipads or points in space, used with the Approach Procedure Identifier and Runway/Helipad Identifier to uniquely define the procedure (e.g., 003, 013, 103, 310, 333).
        /// </remarks>
        public string? HeliProcedureCourse { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 74:122
        /// _MaxLength: 49
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        // public string BlankSpacing { get; set; }

        #endregion
    }
}