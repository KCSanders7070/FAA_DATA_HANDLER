using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - LocalizerAndGlideSlope (PI) section data
    /// </summary>
    /// <remarks>
    /// Contains data for Localizer, MLS, and GLS facilities associated
    /// with runways at airports, including identifiers, frequencies, locations,
    /// bearings, positions, widths, angles, elevations, and supporting facility
    /// information. Each record corresponds to a specific localizer or approach
    /// system linked to a runway, providing essential details for navigation
    /// and approach procedures.
    /// </remarks>
    public class LocalizerAndGlideSlopeCifpDataModel
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
        /// Localizer Identifier
        /// _Ref: 5.44
        /// _Idx: 13:16
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the Localizer, MLS facility, or GLS Reference Path associated with a runway, using the facility or path code (e.g., IDEN, ISTX, IDU, PP, MDEN, MSTX, MLAX, LFBL, EGLC, KSAN).
        /// </remarks>
        public string? LocId { get; set; }

        /// <summary>
        /// ILS Category
        /// _Ref: 5.80
        /// _Idx: 17
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the performance category or classification of a Localizer, MLS, or GLS system: 0=ILS Localizer only (no glideslope) __ 1=ILS/MLS/GLS Category I __ 2=ILS/MLS/GLS Category II __ 3=ILS/MLS/GLS Category III __ I=IGS Facility __ L=LDA Facility with glideslope __ A=LDA Facility without glideslope __ S=SDF Facility with glideslope __ F=SDF Facility without glideslope.
        /// </remarks>
        public string? IlsCat { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 18:20
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// 
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
        /// Localizer Frequency
        /// _Ref: 5.45
        /// _Idx: 22:26
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the VHF frequency of the localizer in 50 kHz resolution, with the decimal suppressed (e.g., 11030, 11195).
        /// </remarks>
        public string? LocFreq { get; set; }

        /// <summary>
        /// Runway Identifier
        /// _Ref: 5.46
        /// _Idx: 27:31
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the runway ID associated with runway data or ILS/MLS records, formatted as “RW” plus a two-digit number (01–36) and optional suffix: C (Center), L (Left), R (Right), T (True degrees), or special types W (Water), S (Soft-surface), G (Glider), U (Ultralight), numeric (Assault Strip); e.g., RW26L, RW08R, RW26C, RW05, RW17T. Note: Non-numeric runway identifiers (5.46) are included and will not carry the prefixed ‘RW’ characters.
        /// </remarks>
        public string? RwyId { get; set; }

        /// <summary>
        /// Localizer Latitude
        /// _Ref: 5.36
        /// _Idx: 32:40
        /// _MaxLength: 9
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigational feature using one alpha character ('N' or 'S') followed by eight digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., N39513881).
        /// </remarks>
        public string? LocLat { get; set; }

        /// <summary>
        /// Localizer Longitude
        /// _Ref: 5.37
        /// _Idx: 41:50
        /// _MaxLength: 10
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigational feature using one alpha character ('E' or 'W') followed by nine digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., W104450794).
        /// </remarks>
        public string? LocLon { get; set; }

        /// <summary>
        /// Localizer Bearing
        /// _Ref: 5.47
        /// _Idx: 51:54
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the magnetic bearing of the localizer course in degrees and tenths (decimal suppressed), with a trailing “T” for true courses (e.g., 2570, 0147, 2910, 347T).
        /// </remarks>
        public string? LocBearing { get; set; }

        /// <summary>
        /// Glide Slope Latitude
        /// _Ref: 5.36
        /// _Idx: 55:63
        /// _MaxLength: 9
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigational feature using one alpha character ('N' or 'S') followed by eight digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., N39513881).
        /// </remarks>
        public string? GlideSlopeLat { get; set; }

        /// <summary>
        /// Glide Slope Longitude
        /// _Ref: 5.37
        /// _Idx: 64:73
        /// _MaxLength: 10
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigational feature using one alpha character ('E' or 'W') followed by nine digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., W104450794).
        /// </remarks>
        public string? GlideSlopeLon { get; set; }

        /// <summary>
        /// Localizer Position
        /// _Ref: 5.48
        /// _Idx: 74:77
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the antenna’s position relative to the runway end, given as a distance in feet with 1-ft resolution (e.g., 0950, 1000).
        /// </remarks>
        public string? LocPosition { get; set; }

        /// <summary>
        /// Localizer Position Reference
        /// _Ref: 5.49
        /// _Idx: 78
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the antenna’s position relative to the runway: Localizer/Azimuth — @=beyond stop end, +=ahead of approach end, -=off to one side; Back Azimuth — @=ahead of approach end, +=beyond stop end, -=off to one side.
        /// </remarks>
        public string? LocPositionReference { get; set; }

        /// <summary>
        /// Glide Slope Position
        /// _Ref: 5.50
        /// _Idx: 79:82
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the glide slope antenna’s distance in feet from the runway threshold, measured perpendicular to the runway, with 1-ft resolution (e.g., 0980, 1417).
        /// </remarks>
        public string? GlideSlopePosition { get; set; }

        /// <summary>
        /// Localizer Width
        /// _Ref: 5.51
        /// _Idx: 83:86
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the localizer course width in degrees, tenths, and hundredths (decimal suppressed) for the ILS facility (e.g., 0500, 0400, 0350).
        /// </remarks>
        public string? LocWidth { get; set; }

        /// <summary>
        /// Glide Slope Angle
        /// _Ref: 5.52
        /// _Idx: 87:89
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the glide slope angle for an ILS facility or GLS approach in degrees, tenths, and hundredths (decimal suppressed) (e.g., 275, 300).
        /// </remarks>
        public string? GlideSlopeAngle { get; set; }

        /// <summary>
        /// Station Declination
        /// _Ref: 5.66
        /// _Idx: 90:94
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the angular difference between true north and the NAVAID’s zero-degree radial (or magnetic north for ILS localizers), expressed as a character indicating orientation (E=East of True North, W=West of True North, T=oriented True North, G=oriented Grid North) followed by declination in degrees/tenths with decimal suppressed; T and G entries are followed by zeros (e.g., E0072, E0000, T0000, G0000). Last digit is decimal (E0150 = E15.0)
        /// </remarks>
        public string? StationDeclination { get; set; }

        /// <summary>
        /// Glide Slope Height at Landing Threshold
        /// _Ref: 5.67
        /// _Idx: 95:96
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the height above the runway threshold on a normal glide path, taken from ILS/MLS glide slope, RNAV procedure, published VGSI, or set to 50 ft if none are available; also used in approach continuation and ILS/MLS records.
        /// </remarks>
        public string? GlideSlopeHeightAtLandingThreshold { get; set; }

        /// <summary>
        /// Glide Slope Elevation
        /// _Ref: 5.74
        /// _Idx: 97:101
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the elevation of system components relative to MSL: GS ELEV = Glide Slope __ EL ELEV = MLS Elevation __ AZ ELEV = MLS Azimuth __ BAZ ELEV = MLS Back Azimuth __ GLS ELEV = GLS ground station; negative sign indicates below MSL (e.g., 00235, 01265, -0011).
        /// </remarks>
        public string? GlideSlopeElevation { get; set; }

        /// <summary>
        /// Supporting Facility ID
        /// _Ref: 5.33
        /// _Idx: 102:105
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS. Identifies the VHF, MF, or LF facility by its official government-assigned 1-4 character code (e.g., DEN, 6YA, PPI, TIKX).
        /// </remarks>
        public string? SupportingFacId { get; set; }

        /// <summary>
        /// Supporting Facility ICAO Code
        /// _Ref: 5.14
        /// _Idx: 106:107
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS. Two-character ICAO code used for geographic categorization, typically based on ICAO Doc 7910. U.S. codes begin with 'K' followed by a digit for regional subdivision (e.g., K1, K7). Used for airports with at least one hard-surfaced runway or supporting enroute airway structure. If no ICAO identifier is published, the FAA identifier is used instead.
        /// </remarks>
        public string? SupportingFacIcaoLocationCode { get; set; }

        /// <summary>
        /// Supporting Facility Section Code
        /// _Ref: 5.4
        /// _Idx: 108
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS. Single character identifying the data section or domain, such as NAVAIDS (D), AIRPORT (P), ENROUTE (E), etc.
        /// </remarks>
        public string? SupportingFacSectionCode { get; set; }

        /// <summary>
        /// Supporting Facility Subsection Code
        /// _Ref: 5.5
        /// _Idx: 109
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Terminal Navaids used as Supporting Facilities must be located at the same airport as the ILS. Defines the specific subsection within a major database section where the record resides; used with Section Code and record identifier to reference related data such as fixes, procedures, communications, and routes.
        /// </remarks>
        public string? SupportingFacSubsectionCode { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 110:122
        /// _MaxLength: 13
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        // public string ReservedExpansion { get; set; }

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
        public string? FileRecordNoFileRecordNum { get; set; }

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