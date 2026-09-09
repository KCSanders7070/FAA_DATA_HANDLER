using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses PI records into LocalizerAndGlideSlopeCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.11.1
    /// Airport and Heliport Localizer and Glide Slope (Localizer and Glide Slope-PI) and were verified
    /// against every PI record in FAACIFP18.
    /// </remarks>
    public static class LocalizerAndGlideSlopeCifpParser
    {
        /// <summary>
        /// Parses one PI record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new LocalizerAndGlideSlopeCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                Subsection = CifpSpan.Text(line[12]),
                LocalizerIdentifier = CifpSpan.Text(line.Slice(13, 4)),
                IlsCategory = CifpFieldConverter.Field580(line[17]),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[21]),
                LocalizerFrequency = CifpFieldConverter.Field545(line.Slice(22, 5)),
                RunwayIdentifier = CifpFieldConverter.Field546(line.Slice(27, 5)),
                LocalizerLatitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                LocalizerLongitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                LocalizerBearing = CifpFieldConverter.Field547(line.Slice(51, 4)),
                GlideSlopeLatitude = CifpFieldConverter.Field536(line.Slice(55, 9)),
                GlideSlopeLongitude = CifpFieldConverter.Field537(line.Slice(64, 10)),
                LocalizerPosition = CifpFieldConverter.Field548(line.Slice(74, 4)),
                LocalizerPositionReference = CifpSpan.Text(line[78]),
                GlideSlopePosition = CifpFieldConverter.Field550(line.Slice(79, 4)),
                LocalizerWidth = CifpFieldConverter.Field551(line.Slice(83, 4)),
                GlideSlopeAngle = CifpFieldConverter.Field552(line.Slice(87, 3)),
                StationDeclinationDirection = CifpFieldConverter.Field566DeclinationDirection(line[90]),
                StationDeclinationMagnitude = CifpFieldConverter.Field566DeclinationMagnitude(line.Slice(91, 4)),
                GlideSlopeHeightAtLandingThreshold = CifpFieldConverter.Field567(line.Slice(95, 2)),
                GlideSlopeElevation = CifpFieldConverter.Field574(line.Slice(97, 5)),
                SupportingFacilityId = CifpSpan.Text(line.Slice(102, 4)),
                SupportingFacilityIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(106, 2)),
                SupportingFacilitySectionCode = CifpSpan.Text(line[108]),
                SupportingFacilitySubsectionCode = CifpSpan.Text(line[109]),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.LocalizerAndGlideSlope.Add(model);
        }
    }
}