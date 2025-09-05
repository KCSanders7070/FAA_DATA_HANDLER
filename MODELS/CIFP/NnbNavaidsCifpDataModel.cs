using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - NdbNavaids (DB) section data
    /// </summary>
    /// <remarks>
    /// Contains the models for NDB NAVAIDS records.
    /// A PN Record may be used for NDBs when only used at one airport
    /// in the CIFP, when not used on an Enroute Airway, and when
    /// assigned a five-letter name. Otherwise, DB records will be used.
    /// </remarks>
    public class NdbNavaidsCifpDataModel
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
        /// Subsection Code
        /// _Ref: 5.5
        /// _Idx: 5
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Defines the specific subsection within a major database section where the record resides; used with Section Code and record identifier to reference related data such as fixes, procedures, communications, and routes.
        /// </remarks>
        public string? SubsectionCode { get; set; }

        /// <summary>
        /// Airport ICAO Identifier
        /// _Ref: 5.6
        /// _Idx: 6:9
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Contains the ICAO airport identifier to which the record's data applies; differs from the more familiar ATA/IATA airport designators.
        /// </remarks>
        public string? AptIcaoIdentifier { get; set; }

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
        /// Blank (Spacing)
        /// _Idx: 12
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// NDB Identifier
        /// _Ref: 5.33
        /// _Idx: 13:16
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the VHF, MF, or LF facility by its official government-assigned 1-4 character code (e.g., DEN, 6YA, PPI, TIKX).
        /// </remarks>
        public string? NdbIdentifier { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 17:18
        /// _MaxLength: 2
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// ICAO Code
        /// _Ref: 5.14
        /// _Idx: 19:20
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Two-character ICAO code used for geographic categorization, typically based on ICAO Doc 7910. U.S. codes begin with 'K' followed by a digit for regional subdivision (e.g., K1, K7). Used for airports with at least one hard-surfaced runway or supporting enroute airway structure. If no ICAO identifier is published, the FAA identifier is used instead.
        /// </remarks>
        public string? NavaidIcaoLocationCode { get; set; }

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
        /// NDB Frequency
        /// _Ref: 5.34
        /// _Idx: 22:26
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the operating frequency of the VOR or NDB, expressed without a decimal: VHF in hundredths of MHz and NDB in tenths of kHz. Examples: (VHF) "11630" "11795" (NDB) "03620" "17040". FAA NOTE: If a VOR frequency is unavailable, the VOR Frequency field will contain 00000. For all other Navaids, an unavailable frequency will result in blank coding.
        /// </remarks>
        public string? NdbFreq { get; set; }

        /// <summary>
        /// NAVAID Class Navaid Type 1
        /// _Ref: 5.35
        /// _Idx: 27
        /// _MaxLength: 
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// V = VOR
        /// </remarks>
        public string? NavaidClassNavaidType1 { get; set; }

        /// <summary>
        /// NAVAID Class Navaid Type 2
        /// _Ref: 5.35
        /// _Idx: 28
        /// _MaxLength: 
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// D = DME, T = TACAN (ch.17-59 and 70-126), M = MIL TACAN (ch.1-16 and 60-69), I = ILS/DME or ILS/TACAN, N = MLS/DME/N, P = MLS/DME/P
        /// </remarks>
        public string? NavaidClassNavaidType2 { get; set; }

        /// <summary>
        /// NAVAID Class Range/Power
        /// _Ref: 5.35
        /// _Idx: 29
        /// _MaxLength: 
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// T = Terminal, L = Low Altitude, H = High Altitude, U = Undefined, C = ILS/TACAN (freq-paired with ILS Loc with same ID and location. This TACAN may be listed elsewhere as a ILSTACAN and a TACAN.). FAA NOTE: Navaid Class 3 will be coded as "H" for high, "L" for low, and "T" for terminal altitude description. Where undetermined, the field will be coded with "U". Navaid Class 5 will carry an "N" for VORTACs if the VOR coordinates and the TACAN coordinates are 0.1 NM or greater distance from each other.
        /// </remarks>
        public string? NavaidClassRangePower { get; set; }

        /// <summary>
        /// NAVAID Class Additional Info
        /// _Ref: 5.35
        /// _Idx: 30
        /// _MaxLength: 
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// D = Biased ILSDME or ILSTACAN, A = Auto Transcribed Weather Broadcast, B = Scheduled Weather Broadcast, W = No Voice on Frequency, blank/null = Voice on Frequency. FAA NOTE: Weather Capability codes for Hazardous Inflight Weather Advisory Service (HIWAS) and Automatic Transcribed Weather Broadcast (TWEB), will be coded with an "A".
        /// </remarks>
        public string? NavaidClassAddInfo { get; set; }

        /// <summary>
        /// NAVAID Class Col-location
        /// _Ref: 5.35
        /// _Idx: 31
        /// _MaxLength: 
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// N = Not Collocated, blank/null = Collocated Navaids. If "ILSDME" or "ILSTACAN", N = Not Freq-Paired, blank/null = Freq-Paired
        /// </remarks>
        public string? NavaidClassCollocation { get; set; }

        /// <summary>
        /// NDB Latitude
        /// _Ref: 5.36
        /// _Idx: 32:40
        /// _MaxLength: 9
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the latitude of the navigational feature using one alpha character ('N' or 'S') followed by eight digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., N39513881).
        /// </remarks>
        public string? NdbLat { get; set; }

        /// <summary>
        /// NDB Longitude
        /// _Ref: 5.37
        /// _Idx: 41:50
        /// _MaxLength: 10
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the longitude of the navigational feature using one alpha character ('E' or 'W') followed by nine digits representing degrees, minutes, seconds, tenths, and hundredths of seconds (e.g., W104450794).
        /// </remarks>
        public string? NdbLon { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 51:73
        /// _MaxLength: 23
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Magnetic Variation
        /// _Ref: 5.39
        /// _Idx: 74:78
        /// _MaxLength: 5
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the angular difference between True North and Magnetic North; format is one character (E, W, or T) followed by four digits for degrees and tenths (e.g., E0140, W0075, T0000). Note: Differences between MagVar and Dynamic-MagVar.
        /// </remarks>
        public string? MagVar { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 79:84
        /// _MaxLength: 6
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 85:89
        /// _MaxLength: 5
        /// </summary>
        /// <remarks>
        /// Not used yet but may be in the future.
        /// </remarks>
        // public string ReservedExpansion { get; set; }

        /// <summary>
        /// Datum Code
        /// _Ref: 5.197
        /// _Idx: 90:92
        /// _MaxLength: 3
        /// _DataType: 
        /// </summary>
        /// <remarks>
        /// Defines the local horizontal reference datum used for the geographic position (latitude and longitude); represented by a three-letter code from official government publications (e.g., AGD, NAS, WGA).
        /// </remarks>
        public string? DatumCode { get; set; }

        /// <summary>
        /// NDB Name
        /// _Ref: 5.71
        /// _Idx: 93:122
        /// _MaxLength: 30
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Provides the facility name and may include a parenthetical location for clarity.
        /// </remarks>
        public string? NdbName { get; set; }

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
        /// Cycle Data
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