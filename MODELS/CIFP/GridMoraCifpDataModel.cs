using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// FAACIFP18 File - GridMora (AS) record.
    /// </summary>
    /// <remarks>
    /// ARINC 424 layout 4.1.19.1 Grid MORA (Grid MORA-AS). Identified by Section Code 'A' and Subsection
    /// Code 'S'. This record type has no Continuation Record Number field.
    /// </remarks>
    public class GridMoraCifpDataModel
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
        /// Blank (Spacing)
        /// _Idx: 1:3
        /// _MaxLength: 3
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

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
        /// Subsection Code
        /// _Ref: 5.5
        /// _Idx: 5
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
        /// Blank (Spacing)
        /// _Idx: 6:12
        /// _MaxLength: 7
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// Starting Latitude
        /// _Ref: 5.141
        /// _Idx: 13:15
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The latitude of the south-west corner of the first one-degree block in a Grid MORA record.
        /// </remarks>
        public int? StartingLatitude { get; set; }

        /// <summary>
        /// Starting Longitude
        /// _Ref: 5.142
        /// _Idx: 16:19
        /// _MaxLength: 4
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The longitude of the south-west corner of the first one-degree block in a Grid MORA record.
        /// </remarks>
        public int? StartingLongitude { get; set; }

        /// <summary>
        /// Blank (Spacing)
        /// _Idx: 20:29
        /// _MaxLength: 10
        /// </summary>
        /// <remarks>
        /// Carries no data. Present so the column map stays continuous across all 132 columns.
        /// </remarks>
        // public string? BlankSpacing { get; set; }

        /// <summary>
        /// MORA 1
        /// _Ref: 5.143
        /// _Idx: 30:32
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora1 { get; set; }

        /// <summary>
        /// MORA 2
        /// _Ref: 5.143
        /// _Idx: 33:35
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora2 { get; set; }

        /// <summary>
        /// MORA 3
        /// _Ref: 5.143
        /// _Idx: 36:38
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora3 { get; set; }

        /// <summary>
        /// MORA 4
        /// _Ref: 5.143
        /// _Idx: 39:41
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora4 { get; set; }

        /// <summary>
        /// MORA 5
        /// _Ref: 5.143
        /// _Idx: 42:44
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora5 { get; set; }

        /// <summary>
        /// MORA 6
        /// _Ref: 5.143
        /// _Idx: 45:47
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora6 { get; set; }

        /// <summary>
        /// MORA 7
        /// _Ref: 5.143
        /// _Idx: 48:50
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora7 { get; set; }

        /// <summary>
        /// MORA 8
        /// _Ref: 5.143
        /// _Idx: 51:53
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora8 { get; set; }

        /// <summary>
        /// MORA 9
        /// _Ref: 5.143
        /// _Idx: 54:56
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora9 { get; set; }

        /// <summary>
        /// MORA 10
        /// _Ref: 5.143
        /// _Idx: 57:59
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora10 { get; set; }

        /// <summary>
        /// MORA 11
        /// _Ref: 5.143
        /// _Idx: 60:62
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora11 { get; set; }

        /// <summary>
        /// MORA 12
        /// _Ref: 5.143
        /// _Idx: 63:65
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora12 { get; set; }

        /// <summary>
        /// MORA 13
        /// _Ref: 5.143
        /// _Idx: 66:68
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora13 { get; set; }

        /// <summary>
        /// MORA 14
        /// _Ref: 5.143
        /// _Idx: 69:71
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora14 { get; set; }

        /// <summary>
        /// MORA 15
        /// _Ref: 5.143
        /// _Idx: 72:74
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora15 { get; set; }

        /// <summary>
        /// MORA 16
        /// _Ref: 5.143
        /// _Idx: 75:77
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora16 { get; set; }

        /// <summary>
        /// MORA 17
        /// _Ref: 5.143
        /// _Idx: 78:80
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora17 { get; set; }

        /// <summary>
        /// MORA 18
        /// _Ref: 5.143
        /// _Idx: 81:83
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora18 { get; set; }

        /// <summary>
        /// MORA 19
        /// _Ref: 5.143
        /// _Idx: 84:86
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora19 { get; set; }

        /// <summary>
        /// MORA 20
        /// _Ref: 5.143
        /// _Idx: 87:89
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora20 { get; set; }

        /// <summary>
        /// MORA 21
        /// _Ref: 5.143
        /// _Idx: 90:92
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora21 { get; set; }

        /// <summary>
        /// MORA 22
        /// _Ref: 5.143
        /// _Idx: 93:95
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora22 { get; set; }

        /// <summary>
        /// MORA 23
        /// _Ref: 5.143
        /// _Idx: 96:98
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora23 { get; set; }

        /// <summary>
        /// MORA 24
        /// _Ref: 5.143
        /// _Idx: 99:101
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora24 { get; set; }

        /// <summary>
        /// MORA 25
        /// _Ref: 5.143
        /// _Idx: 102:104
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora25 { get; set; }

        /// <summary>
        /// MORA 26
        /// _Ref: 5.143
        /// _Idx: 105:107
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora26 { get; set; }

        /// <summary>
        /// MORA 27
        /// _Ref: 5.143
        /// _Idx: 108:110
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora27 { get; set; }

        /// <summary>
        /// MORA 28
        /// _Ref: 5.143
        /// _Idx: 111:113
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora28 { get; set; }

        /// <summary>
        /// MORA 29
        /// _Ref: 5.143
        /// _Idx: 114:116
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora29 { get; set; }

        /// <summary>
        /// MORA 30
        /// _Ref: 5.143
        /// _Idx: 117:119
        /// _MaxLength: 3
        /// _DataType: Int
        /// _Converted: Y
        /// </summary>
        /// <remarks>
        /// The minimum off-route altitude for one one-degree latitude/longitude block, in hundreds of feet, or
        /// UNK where no value has been established.
        /// </remarks>
        public int? Mora30 { get; set; }

        /// <summary>
        /// Reserved (Expansion)
        /// _Idx: 120:122
        /// _MaxLength: 3
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