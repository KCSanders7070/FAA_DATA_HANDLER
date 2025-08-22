using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Heliports (HA) section data
    /// </summary>
    /// <remarks>
    /// Contains information for heliports.
    /// </remarks>
    public class HeliportsCifpDataModel
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
        /// 
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Heliport Identifier
        /// _Ref: 5.6
        /// _Idx: 6:9
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Contains the ICAO heliport identifier to which the record's data applies. If there is no published ICAO Heliport Identifier, then the published FAA Heliport Identifier will be used.
        /// </remarks>
        public string? HeliportIdentifier { get; set; }

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
        public string? HeliportIcaoCode { get; set; }

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
        /// ATA/IATA Designator
        /// _Ref: 5.107
        /// _Idx: 13:15
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Contains the ATA/IATA designator code for the airport or heliport related to the record's data (e.g., DEN, LHR, JFK).
        /// </remarks>
        public string? AtaIataDesignator { get; set; }

        /// <summary>
        /// PAD Identifier
        /// _Ref: 5.18
        /// _Idx: 16:20
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the helipad with a unique heliport record for each helipad at a location (e.g., PADA1, NWPAD, ALPHA, A1, HELO1, HELO2, HELO3)
        /// </remarks>
        public string? PadIdentifier { get; set; }

        /// <summary>
        /// Continuation Record No.
        /// _Ref: 5.16
        /// _Idx: 21
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the position of a continuation record in a sequence; primary records use '0' if no continuation follows, '1' if they do, with continuations numbered '2'–'9' and then 'A'–'Z' as needed.
        /// </remarks>
        public string? ContinuationRecordNumber { get; set; }

        /// <summary>
        /// Speed Limit Altitude
        /// _Ref: 5.73
        /// _Idx: 22:26
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Altitude below which speed limits may be imposed (e.g., 10000, F125).
        /// </remarks>
        public string? SpeedLimitAltitude { get; set; }

        /// <summary>
        /// Datum Code
        /// _Ref: 5.197
        /// _Idx: 27:29
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the local horizontal reference datum used for the geographic position (latitude and longitude); represented by a three-letter code from official government publications (e.g., AGD, NAS, WGA).
        /// </remarks>
        public string? DatumCode { get; set; }

        /// <summary>
        /// IFR Indicator
        /// _Ref: 5.108
        /// _Idx: 30
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates whether the airport or heliport has any published instrument approach procedures; 'Y' if published, 'N' if not.
        /// </remarks>
        public string? IfrCapability { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 31
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Latitude
        /// _Ref: 5.36
        /// _Idx: 32:40
        /// _MaxLength: 9
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigational feature using one alpha character ('N' or 'S') followed by eight digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., N39513881).
        /// </remarks>
        public string? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// _Ref: 5.37
        /// _Idx: 41:50
        /// _MaxLength: 10
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigational feature using one alpha character ('E' or 'W') followed by nine digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., W104450794).
        /// </remarks>
        public string? Longitude { get; set; }

        /// <summary>
        /// Magnetic Variation
        /// _Ref: 5.39
        /// _Idx: 51:55
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the angular difference between True North and Magnetic North; format is one character (E, W, or T) followed by four digits for degrees and tenths (e.g., E0140, W0075, T0000). Note: Differences between MagVar and Dynamic-MagVar.
        /// </remarks>
        public string? MagVar { get; set; }

        /// <summary>
        /// Heliport Elevation
        /// _Ref: 5.55
        /// _Idx: 56:60
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the elevation of the airport or heliport in feet to a resolution of one foot; positive values are above MSL, negative values (with a leading minus sign) are below MSL (e.g., 02171, -0142).
        /// </remarks>
        public string? HeliportElevation { get; set; }

        /// <summary>
        /// Speed Limit
        /// _Ref: 5.72
        /// _Idx: 61:63
        /// _MaxLength: 3
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Defines a speed limit in knots indicated airspeed (KIAS) for a fix in a terminal procedure or for an airport/heliport terminal environment. When used in airport or heliport records, it indicates the maximum speed allowed for all flight segments at or below the specified Speed Limit Altitude (5.73). In SID records, the limit applies from the procedure start or previous speed limit through the end of the leg on which it's coded, unless superseded. In STAR and Approach records, the speed limit applies from the point it is coded forward through the procedure unless replaced by another limit.


        /// </remarks>
        public string? SpeedLimit { get; set; }

        /// <summary>
        /// Recommended VHF Navaid
        /// _Ref: 5.23
        /// _Idx: 64:67
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the recommended navigational aid (Navaid) to reference a waypoint or an airport/heliport, using a 1–4 character identifier. May include VHF, NDB, Localizer, TACAN, GLS, or MLS facilities. (e.g., P, PP, DEN, LAX, ILAX, MJFK).
        /// </remarks>
        public string? RecommendedVhfNavaid { get; set; }

        /// <summary>
        /// ICAO Code
        /// _Ref: 5.14
        /// _Idx: 68:69
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the specific subsection within a major database section where the record resides; used with Section Code and record identifier to reference related data such as fixes, procedures, communications, and routes.
        /// </remarks>
        public string? NavaidIcaoCode { get; set; }

        /// <summary>
        /// Transition Altitude
        /// _Ref: 5.53
        /// _Idx: 70:74
        /// _MaxLength: 5
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Defines the altitude (in feet MSL) at or below which aircraft reference local altimeter settings and above which standard settings are used (QNE). Applied in STAR and Approach records as the level where barometric settings change to local, and in SID records as the transition altitude. Must be present in the first leg of each SID/STAR/Approach procedure if known. If unknown or varies by procedure, the field is left blank. Recorded to a one-foot resolution (e.g., 05000, 23000, 18000).
        /// </remarks>
        public string? TransitionAlt { get; set; }

        /// <summary>
        /// Transition Level
        /// _Ref: 5.53
        /// _Idx: 75:79
        /// _MaxLength: 5
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Defines the altitude (in feet MSL) at or below which aircraft reference local altimeter settings and above which standard settings are used (QNE). Applied in STAR and Approach records as the level where barometric settings change to local, and in SID records as the transition altitude. Must be present in the first leg of each SID/STAR/Approach procedure if known. If unknown or varies by procedure, the field is left blank. Recorded to a one-foot resolution (e.g., 05000, 23000, 18000).
        /// </remarks>
        public string? TransitionLvl { get; set; }

        /// <summary>
        /// Public Military Indicator
        /// _Ref: 5.177
        /// _Idx: 80
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Categorizes the airport or heliport by usage: C = civil (open to the public), M = military, P = private (not open to the public). Joint-use facilities are classified as civil.
        /// </remarks>
        public string? PublicMilitaryIndicator { get; set; }

        /// <summary>
        /// Time Zone
        /// _Ref: 5.178
        /// _Idx: 81:83
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the heliports standard time zone using a single-letter code based on 15° longitude intervals relative to Greenwich Mean Time (GMT): Z (0), A (-1), B (-2), C (-3), D (-4), E (-5), F (-6), G (-7), H (-8), I (-9), K (-10), L (-11), M (-12), N (+1), O (+2), P (+3), Q (+4), R (+5), S (+6), T (+7), U (+8), V (+9), W (+10), X (+11), Y (+12).
        /// </remarks>
        public string? TimeZone { get; set; }

        /// <summary>
        /// Daylight Indicator
        /// _Ref: 5.179
        /// _Idx: 84
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates whether the heliport observes Daylight or Summer Time: 'Y' if observed, 'N' if not observed or unknown.
        /// </remarks>
        public string? DaylightIndicator { get; set; }

        /// <summary>
        /// Pad Dimensions
        /// _Ref: 5.176
        /// _Idx: 85:90
        /// _MaxLength: 6
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Defines the landing surface dimensions of the helicopter pad, described as a rectangle or circle (e.g., 060060, 100050, 040040).
        /// </remarks>
        public string? PadDeimensions { get; set; }

        /// <summary>
        /// Magnetic/True Indicator
        /// _Ref: 5.165
        /// _Idx: 91
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates whether bearings and courses are referenced to Magnetic or True North: 'M' for magnetic, 'T' for true. In airport records, 'M' or 'T' signifies all procedures use that reference and is blank if a mix of magnetic and true data.


        /// </remarks>
        public string? MagTrueIndicator { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 92
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        // public string ReservedExpansion { get; set; }

        /// <summary>
        /// Heliport Name
        /// _Ref: 5.71
        /// _Idx: 93:122
        /// _MaxLength: 30
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Provides the facility name and may include a parenthetical location for clarity.
        /// </remarks>
        public string? HeliportName { get; set; }

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
        /// Identifies the 28-day data update cycle in which the record was added or last revised; format is YYCC, where YY is the last two digits of the year and CC is the cycle number (01–13, occasionally 14). Example (pad zeros left): Cycle 11 in the year 2032 would be "3211". A cycle date change will happen for any change to fields except Dynamic Magnetic Variation, Frequency Protection, Continuation Record Number, and File Record Number.
        /// </remarks>
        public string? CycleDate { get; set; }
    }
}