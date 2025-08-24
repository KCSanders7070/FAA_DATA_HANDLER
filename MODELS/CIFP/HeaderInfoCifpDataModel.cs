using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - HeaderInfo (HDR) section data
    /// </summary>
    /// <remarks>
    /// ???
    /// </remarks>
    public class HeaderInfoCifpDataModel
    {
        #region HDR 01
        /// <summary>
        /// Header Ident
        /// _Ref: N/A
        /// _Idx: 0:2
        /// _MaxLength: 3
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Just "HDR", indicating this line is a HEADER line.
        /// </remarks>
        public string? HeaderIdent { get; set; }

        /// <summary>
        /// Header Number
        /// _Ref: N/A
        /// _Idx: 3:4
        /// _MaxLength: 2
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the record is the first Header Record, marked by a decimal value of 01.
        /// </remarks>
        public string? HeaderNumber { get; set; }

        /// <summary>
        /// File Name
        /// _Ref: N/A
        /// _Idx: 5:19
        /// _MaxLength: 15
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// File name, eg. "FAACIFP18"
        /// </remarks>
        public string? FileName { get; set; }

        /// <summary>
        /// Version Number
        /// _Ref: N/A
        /// _Idx: 20:22
        /// _MaxLength: 3
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Specifies a three-digit revision number for the file, starting at 001 and incremented if multiple versions are produced within the same cycle.
        /// </remarks>
        public string? VersionNumber { get; set; }

        /// <summary>
        /// Production/Test Flag
        /// _Ref: N/A
        /// _Idx: 23
        /// _MaxLength: 1
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates file type: “P” for production data or “T” for test data.
        /// </remarks>
        public string? ProductionTestFlag { get; set; }

        /// <summary>
        /// Record Length
        /// _Ref: N/A
        /// _Idx: 24:27
        /// _MaxLength: 4
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Specifies the fixed record length of characters per data record eg. "0132"
        /// </remarks>
        public string? RecordLength { get; set; }

        /// <summary>
        /// Record Count
        /// _Ref: N/A
        /// _Idx: 28:34
        /// _MaxLength: 7
        /// _DataType: Int
        /// </summary>
        /// <remarks>
        /// Provides the total number of data records in the file, expressed as a decimal count.
        /// </remarks>
        public string? RecordCount { get; set; }

        /// <summary>
        /// Cycle Date
        /// _Ref: N/A
        /// _Idx: 35:38
        /// _MaxLength: 4
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Identifies the 28-day data update cycle in which the record was added or last revised; format is YYCC, where YY is the last two digits of the year and CC is the cycle number (01â€“13, occasionally 14). Example (pad zeros left): Cycle 11 in the year 2032 would be "3211". A cycle date change will happen for any change to fields except Dynamic Magnetic Variation, Frequency Protection, Continuation Record Number, and File Record Number.
        /// </remarks>
        public string? CycleDate { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 39:40
        /// _MaxLength: 2
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Creation Date
        /// _Ref: N/A
        /// _Idx: 41:51
        /// _MaxLength: 11
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the file creation date in DD-MMM-YYYY format, using a two-digit day, three-letter month abbreviation, and four-digit year (e.g., 12-APR-2002).
        /// </remarks>
        public string? CreationDate { get; set; }

        /// <summary>
        /// Creation Time
        /// _Ref: N/A
        /// _Idx: 52:59
        /// _MaxLength: 8
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies the UTC creation time of the file in HH:MM:SS format with two-digit hours, minutes, and seconds (e.g., 13:12:02).
        /// </remarks>
        public string? CreationTime { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 60
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Data Supplier Ident
        /// _Ref: N/A
        /// _Idx: 61:76
        /// _MaxLength: 16
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Holds identifying information about the data supplier, with content defined by the supplier.
        /// </remarks>
        public string? DataSupplierIdent { get; set; }

        /// <summary>
        /// Target Customer Ident
        /// _Ref: N/A
        /// _Idx: 77:92
        /// _MaxLength: 16
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Provides identifying details for the data user or customer (e.g., names, file codes), with content defined by the supplier and/or customer; optional field.
        /// </remarks>
        public string? TargetCustomerIdent { get; set; }

        /// <summary>
        /// Database Part Number
        /// _Ref: N/A
        /// _Idx: 93:112
        /// _MaxLength: 20
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Specifies a unique part number for the database; optional with content to be determined.
        /// </remarks>
        public string? DataPartNumber { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 113:123
        /// _MaxLength: 11
        /// </summary>
        /// <remarks>
        /// Not used yet but may be in the future.
        /// </remarks>
        // public string ReservedExpansion { get; set; }

        /// <summary>
        /// File CRC
        /// _Ref: N/A
        /// _Idx: 124:131
        /// _MaxLength: 8
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Represents the Cyclic Redundancy Check (CRC) value for the ARINC data file (data and header records), using a polynomial and block size TBD; if multiple CRCs are required, this field may be split and relocated. For calculation, Header Record 1 columns 125–132 are treated as zeros.
        /// </remarks>
        public string? FileCrc { get; set; }
        #endregion

        #region HDR 02
        /// <summary>
        /// Expiration Date
        /// _Ref: 
        /// _Idx: 16:26
        /// _MaxLength: 11
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Indicates the file expiration date in DD-MMM-YYYY format if created outside standard cycles; left blank when aligned with the Cycle Date. (Optional)
        /// </remarks>
        public string? ExpDate { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 27
        /// _MaxLength: 1
        /// </summary>
        /// <remarks>
        /// Keeps similar types of information lined up in the same column positions across different records.
        /// </remarks>
        // public string BlankSpacing { get; set; }

        /// <summary>
        /// Supplier Text Field
        /// _Ref: 
        /// _Idx: 28:57
        /// _MaxLength: 30
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Holds supplier-specific information, such as extract program version; content defined by the supplier. (Optional)
        /// </remarks>
        public string? SupplierTextField { get; set; }

        /// <summary>
        /// Descriptive Text
        /// _Ref: 
        /// _Idx: 58:87
        /// _MaxLength: 30
        /// _DataType: String
        /// </summary>
        /// <remarks>
        /// Provides a description of the file contents or other agreed-upon details between supplier and customer (e.g., content summary, test file notes). (Optional)
        /// </remarks>
        public string? DescriptiveText { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 88:131
        /// _MaxLength: 43
        /// </summary>
        /// <remarks>
        /// Not used yet but may be in the future.
        /// </remarks>
        // public string ReservedExpansion { get; set; }
        #endregion
    }
}