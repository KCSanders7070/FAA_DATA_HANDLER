using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses ER records into AirwaysCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.6.1
    /// Enroute Airways (Airways-ER) and were verified against every ER record in FAACIFP18.
    /// </remarks>
    public static class AirwaysCifpParser
    {
        /// <summary>
        /// Parses one ER record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new AirwaysCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                RouteIdentifier = CifpSpan.Text(line.Slice(13, 5)),
                SequenceNumber = CifpFieldConverter.Field512(line.Slice(25, 4)),
                FixIdentifier = CifpFieldConverter.Field513(line.Slice(29, 5)),
                FixIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(34, 2)),
                FixSectionCode = CifpSpan.Text(line[36]),
                FixSubsectionCode = CifpSpan.Text(line[37]),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[38]),
                WaypointDescriptionCodeFixType = CifpFieldConverter.Field517FixType(line[39]),
                WaypointDescriptionCodeFlyOverOrEndOfSegment = CifpFieldConverter.Field517FlyOverOrEndOfSegment(line[40]),
                WaypointDescriptionCodeFixFunction1 = CifpFieldConverter.Field517FixFunction1(line[41]),
                WaypointDescriptionCodeFixFunction2 = CifpFieldConverter.Field517FixFunction2(line[42]),
                BoundaryCode = CifpFieldConverter.Field518(line[43]),
                RouteType = CifpFieldConverter.Field57(line[44], line[36], line[37]),
                Level = CifpFieldConverter.Field519(line[45]),
                DirectionRestriction = CifpSpan.Text(line[46]),
                CruiseTableIndicator = CifpSpan.Text(line.Slice(47, 2)),
                EuIndicator = CifpFieldConverter.Field5164(line[49]),
                RecommendedNavaid = CifpSpan.Text(line.Slice(50, 4)),
                RecommendedNavaidIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(54, 2)),
                Rnp = CifpFieldConverter.Field5211(line.Slice(56, 3)),
                Theta = CifpFieldConverter.Field524(line.Slice(62, 4)),
                Rho = CifpFieldConverter.Field525(line.Slice(66, 4)),
                OutboundMagneticCourse = CifpFieldConverter.Field526(line.Slice(70, 4)),
                RouteDistanceFrom = CifpFieldConverter.Field527(line.Slice(74, 4)),
                InboundMagneticCourse = CifpFieldConverter.Field528(line.Slice(78, 4)),
                MinimumAltitude1 = CifpFieldConverter.Field530(line.Slice(83, 5)),
                MinimumAltitude2 = CifpFieldConverter.Field530(line.Slice(88, 5)),
                MaximumAltitude = CifpFieldConverter.Field5127(line.Slice(93, 5)),
                FixRadiusTransitionIndicator = CifpFieldConverter.Field5254(line.Slice(98, 3)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.Airways.Add(model);
        }
    }
}