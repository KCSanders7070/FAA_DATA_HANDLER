using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses HA records into HeliportsCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.2.1.1
    /// Heliport (Heliports-HA) and were verified against every HA record in FAACIFP18.
    /// </remarks>
    public static class HeliportsCifpParser
    {
        /// <summary>
        /// Parses one HA record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new HeliportsCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                HeliportIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                HeliportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                AtaIataDesignator = CifpFieldConverter.Field5107(line.Slice(13, 3)),
                PadIdentifier = CifpSpan.Text(line.Slice(16, 5)),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[21]),
                SpeedLimitAltitude = CifpFieldConverter.Field573(line.Slice(22, 5)),
                DatumCode = CifpSpan.Text(line.Slice(27, 3)),
                IfrIndicator = CifpFieldConverter.Field5108(line[30]),
                Latitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                Longitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                MagneticVariation = CifpFieldConverter.Field539(line.Slice(51, 5)),
                HeliportElevation = CifpFieldConverter.Field555(line.Slice(56, 5)),
                SpeedLimit = CifpFieldConverter.Field572(line.Slice(61, 3)),
                RecommendedVhfNavaid = CifpSpan.Text(line.Slice(64, 4)),
                RecommendedVhfNavaidIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(68, 2)),
                TransitionAltitude = CifpFieldConverter.Field553(line.Slice(70, 5)),
                TransitionLevel = CifpFieldConverter.Field553(line.Slice(75, 5)),
                PublicMilitaryIndicator = CifpFieldConverter.Field5177(line[80]),
                TimeZoneLetter = CifpFieldConverter.Field5178TimeZoneLetter(line[81]),
                TimeZoneMinutes = CifpFieldConverter.Field5178TimeZoneMinutes(line.Slice(82, 2)),
                DaylightIndicator = CifpFieldConverter.Field5179(line[84]),
                PadDimensionA = CifpFieldConverter.Field5176PadDimensionA(line.Slice(85, 3)),
                PadDimensionB = CifpFieldConverter.Field5176PadDimensionB(line.Slice(88, 3)),
                MagneticTrueIndicator = CifpFieldConverter.Field5165(line[91]),
                HeliportName = CifpSpan.Text(line.Slice(93, 30)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.Heliports.Add(model);
        }
    }
}