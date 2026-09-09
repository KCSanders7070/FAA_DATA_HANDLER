using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses PG records into RunwaysCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.10.1
    /// Runway (Runways-PG) and were verified against every PG record in FAACIFP18.
    /// </remarks>
    public static class RunwaysCifpParser
    {
        /// <summary>
        /// Parses one PG record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new RunwaysCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIcaoIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                RunwayIdentifier = CifpFieldConverter.Field546(line.Slice(13, 5)),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[21]),
                RunwayLength = CifpFieldConverter.Field557(line.Slice(22, 5)),
                RunwayMagneticBearing = CifpFieldConverter.Field558(line.Slice(27, 4)),
                RunwayLatitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                RunwayLongitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                RunwayGradient = CifpFieldConverter.Field5212(line.Slice(51, 5)),
                LtpEllipsoidHeight = CifpFieldConverter.Field5225(line.Slice(60, 6)),
                LandingThresholdElevation = CifpFieldConverter.Field568(line.Slice(66, 5)),
                DisplacedThresholdDistance = CifpFieldConverter.Field569(line.Slice(71, 4)),
                ThresholdCrossingHeight = CifpFieldConverter.Field567(line.Slice(75, 2)),
                RunwayWidth = CifpFieldConverter.Field5109(line.Slice(77, 3)),
                TchValueIndicator = CifpSpan.Text(line[80]),
                LocalizerMlsGlsRefPathIdentifier = CifpSpan.Text(line.Slice(81, 4)),
                LocalizerMlsGlsCategoryClass = CifpFieldConverter.Field580(line[85]),
                Stopway = CifpFieldConverter.Field579(line.Slice(86, 4)),
                SecondLocalizerMlsGlsRefPathIdent = CifpSpan.Text(line.Slice(90, 4)),
                SecondLocalizerMlsGlsCategoryClass = CifpFieldConverter.Field580(line[94]),
                RunwayDescription = CifpSpan.Text(line.Slice(101, 22)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.Runways.Add(model);
        }
    }
}