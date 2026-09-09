using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses DB records into NdbNavaidsCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.3.1
    /// NDB NAVAID (NDB Navaids-DB) and were verified against every DB record in FAACIFP18.
    /// </remarks>
    public static class NdbNavaidsCifpParser
    {
        /// <summary>
        /// Parses one DB record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new NdbNavaidsCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                AirportIcaoIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                NdbIdentifier = CifpSpan.Text(line.Slice(13, 4)),
                NdbIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(19, 2)),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[21]),
                NdbFrequency = CifpFieldConverter.Field534(line.Slice(22, 5), line[4], line[5]),
                NdbClassNavaidType1 = CifpFieldConverter.Field535NavaidType1(line[27]),
                NdbClassNavaidType2 = CifpFieldConverter.Field535NavaidType2(line[28]),
                NdbClassRangePower = CifpFieldConverter.Field535RangePower(line[29]),
                NdbClassAdditionalInformation = CifpFieldConverter.Field535AdditionalInformation(line[30]),
                NdbClassCollocation = CifpFieldConverter.Field535Collocation(line[31]),
                NdbLatitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                NdbLongitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                MagneticVariation = CifpFieldConverter.Field539(line.Slice(74, 5)),
                DatumCode = CifpSpan.Text(line.Slice(90, 3)),
                NdbName = CifpSpan.Text(line.Slice(93, 30)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.NdbNavaids.Add(model);
        }
    }
}