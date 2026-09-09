using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses PA records into AirportsCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.7.1
    /// Airport (Airports-PA) and were verified against every PA record in FAACIFP18.
    /// </remarks>
    public static class AirportsCifpParser
    {
        /// <summary>
        /// Parses one PA record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new AirportsCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIcaoIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                AtaIataDesignator = CifpFieldConverter.Field5107(line.Slice(13, 3)),
                ContinuationRecordNumber = CifpFieldConverter.Field516(line[21]),
                SpeedLimitAltitude = CifpFieldConverter.Field573(line.Slice(22, 5)),
                LongestRunway = CifpFieldConverter.Field554(line.Slice(27, 3)),
                IfrCapability = CifpFieldConverter.Field5108(line[30]),
                LongestRunwaySurfaceCode = CifpFieldConverter.Field5249(line[31]),
                AirportReferencePtLatitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                AirportReferencePtLongitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                MagneticVariation = CifpFieldConverter.Field539(line.Slice(51, 5)),
                AirportElevation = CifpFieldConverter.Field555(line.Slice(56, 5)),
                SpeedLimit = CifpFieldConverter.Field572(line.Slice(61, 3)),
                RecommendedNavaid = CifpSpan.Text(line.Slice(64, 4)),
                RecommendedNavaidIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(68, 2)),
                TransitionsAltitude = CifpFieldConverter.Field553(line.Slice(70, 5)),
                TransitionLevel = CifpFieldConverter.Field553(line.Slice(75, 5)),
                PublicMilitaryIndicator = CifpFieldConverter.Field5177(line[80]),
                TimeZoneLetter = CifpFieldConverter.Field5178TimeZoneLetter(line[81]),
                TimeZoneMinutes = CifpFieldConverter.Field5178TimeZoneMinutes(line.Slice(82, 2)),
                DaylightIndicator = CifpFieldConverter.Field5179(line[84]),
                MagneticTrueIndicator = CifpFieldConverter.Field5165(line[85]),
                DatumCode = CifpSpan.Text(line.Slice(86, 3)),
                AirportName = CifpSpan.Text(line.Slice(93, 30)),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.Airports.Add(model);
        }
    }
}