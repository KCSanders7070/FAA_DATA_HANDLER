using System;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Header (HDR) record.
    /// </summary>
    /// <remarks>
    /// The five header lines at the top of the file are not ARINC 424 data records and follow no
    /// Chapter 4 layout. HDR01 carries the file identity, size and cycle; HDR02 carries free text.
    /// HDR03 through HDR05 are unstructured supplier text and are not parsed.
    /// <para>One model instance is produced per header line, so <see cref="HeaderNumber"/> tells you
    /// which set of properties is populated.</para>
    /// </remarks>
    public class HeaderInfoCifpDataModel
    {
        /// <summary>The complete, unmodified source record.</summary>
        public string? RawRecord { get; set; }

        /// <summary>Always "HDR".</summary>
        public string? HeaderIdent { get; set; }

        /// <summary>Which header line this is: "01" or "02".</summary>
        public string? HeaderNumber { get; set; }

        // ----- HDR01 -----------------------------------------------------------------

        /// <summary>File name as written by the supplier, e.g. "FAACIFP18".</summary>
        public string? FileName { get; set; }

        /// <summary>ARINC 424 version number the file claims to follow.</summary>
        public string? VersionNumber { get; set; }

        /// <summary>'P' for production data, 'T' for test data.</summary>
        public string? ProductionTestFlag { get; set; }

        /// <summary>Length of every data record in characters. Always 132 for the FAA CIFP.</summary>
        public int? RecordLength { get; set; }

        /// <summary>
        /// Number of data records the supplier says the file contains.
        /// </summary>
        /// <remarks>
        /// Excludes the header lines themselves. Worth asserting against the parse count as a cheap
        /// integrity check on the download.
        /// </remarks>
        public int? RecordCount { get; set; }

        /// <summary>The 28-day AIRAC cycle, formatted YYCC.</summary>
        public string? CycleDate { get; set; }

        /// <summary>Date the file was produced, e.g. "17-JUN-2026".</summary>
        public string? CreationDate { get; set; }

        /// <summary>Time the file was produced, e.g. "14:54:13".</summary>
        public string? CreationTime { get; set; }

        /// <summary>Organization that supplied the data.</summary>
        public string? DataSupplierIdent { get; set; }

        /// <summary>Customer the file was cut for.</summary>
        public string? TargetCustomerIdent { get; set; }

        /// <summary>Supplier's part number for this data set.</summary>
        public string? DataPartNumber { get; set; }

        /// <summary>
        /// 32-bit CRC over the file, as eight hexadecimal characters.
        /// </summary>
        /// <remarks>
        /// Calculated as described in ARINC Report 665. Kept as text because it is a checksum to
        /// compare, not a number to do arithmetic on.
        /// </remarks>
        public string? FileCrc { get; set; }

        // ----- HDR02 -----------------------------------------------------------------

        /// <summary>Date the data expires.</summary>
        public string? ExpDate { get; set; }

        /// <summary>Free text from the supplier.</summary>
        public string? SupplierTextField { get; set; }

        /// <summary>Further free text describing the data set.</summary>
        public string? DescriptiveText { get; set; }
    }
}
