using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses AS records into GridMoraCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.19.1
    /// Grid MORA (Grid MORA-AS) and were verified against every AS record in FAACIFP18.
    /// </remarks>
    public static class GridMoraCifpParser
    {
        /// <summary>
        /// Parses one AS record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new GridMoraCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                StartingLatitude = CifpFieldConverter.Field5141(line.Slice(13, 3)),
                StartingLongitude = CifpFieldConverter.Field5142(line.Slice(16, 4)),
                Mora1 = CifpFieldConverter.Field5143(line.Slice(30, 3)),
                Mora2 = CifpFieldConverter.Field5143(line.Slice(33, 3)),
                Mora3 = CifpFieldConverter.Field5143(line.Slice(36, 3)),
                Mora4 = CifpFieldConverter.Field5143(line.Slice(39, 3)),
                Mora5 = CifpFieldConverter.Field5143(line.Slice(42, 3)),
                Mora6 = CifpFieldConverter.Field5143(line.Slice(45, 3)),
                Mora7 = CifpFieldConverter.Field5143(line.Slice(48, 3)),
                Mora8 = CifpFieldConverter.Field5143(line.Slice(51, 3)),
                Mora9 = CifpFieldConverter.Field5143(line.Slice(54, 3)),
                Mora10 = CifpFieldConverter.Field5143(line.Slice(57, 3)),
                Mora11 = CifpFieldConverter.Field5143(line.Slice(60, 3)),
                Mora12 = CifpFieldConverter.Field5143(line.Slice(63, 3)),
                Mora13 = CifpFieldConverter.Field5143(line.Slice(66, 3)),
                Mora14 = CifpFieldConverter.Field5143(line.Slice(69, 3)),
                Mora15 = CifpFieldConverter.Field5143(line.Slice(72, 3)),
                Mora16 = CifpFieldConverter.Field5143(line.Slice(75, 3)),
                Mora17 = CifpFieldConverter.Field5143(line.Slice(78, 3)),
                Mora18 = CifpFieldConverter.Field5143(line.Slice(81, 3)),
                Mora19 = CifpFieldConverter.Field5143(line.Slice(84, 3)),
                Mora20 = CifpFieldConverter.Field5143(line.Slice(87, 3)),
                Mora21 = CifpFieldConverter.Field5143(line.Slice(90, 3)),
                Mora22 = CifpFieldConverter.Field5143(line.Slice(93, 3)),
                Mora23 = CifpFieldConverter.Field5143(line.Slice(96, 3)),
                Mora24 = CifpFieldConverter.Field5143(line.Slice(99, 3)),
                Mora25 = CifpFieldConverter.Field5143(line.Slice(102, 3)),
                Mora26 = CifpFieldConverter.Field5143(line.Slice(105, 3)),
                Mora27 = CifpFieldConverter.Field5143(line.Slice(108, 3)),
                Mora28 = CifpFieldConverter.Field5143(line.Slice(111, 3)),
                Mora29 = CifpFieldConverter.Field5143(line.Slice(114, 3)),
                Mora30 = CifpFieldConverter.Field5143(line.Slice(117, 3)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.GridMora.Add(model);
        }
    }
}