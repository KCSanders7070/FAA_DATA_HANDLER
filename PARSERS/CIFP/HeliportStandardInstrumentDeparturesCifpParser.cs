using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses HD records into HeliportStandardInstrumentDeparturesCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.9.1
    /// Airport SID (SIDs-PD) and were verified against every HD record in FAACIFP18.
    /// </remarks>
    public static class HeliportStandardInstrumentDeparturesCifpParser
    {
        /// <summary>
        /// Parses one HD record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new HeliportStandardInstrumentDeparturesCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                SidStarApproachIdentifierBasicIndicator = CifpFieldConverter.Field59BasicIndicator(line.Slice(13, 5)),
                SidStarApproachIdentifierValidityIndicator = CifpFieldConverter.Field59ValidityIndicator(line[13]),
                RouteType = CifpFieldConverter.Field57(line[19], line[4], line[12]),
                TransitionIdentifier = CifpFieldConverter.Field511(line.Slice(20, 5)),
                SequenceNumber = CifpFieldConverter.Field512(line.Slice(26, 3)),
                FixIdentifier = CifpFieldConverter.Field513(line.Slice(29, 5)),
                FixIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(34, 2)),
                FixSectionCode = CifpSpan.Text(line[36]),
                FixSubsectionCode = CifpSpan.Text(line[37]),
                ContinuationRecordNumber = CifpFieldConverter.Field516(line[38]),
                WaypointDescriptionCodeFixType = CifpFieldConverter.Field517FixType(line[39]),
                WaypointDescriptionCodeFlyOverOrEndOfSegment = CifpFieldConverter.Field517FlyOverOrEndOfSegment(line[40]),
                WaypointDescriptionCodeFixFunction1 = CifpFieldConverter.Field517FixFunction1(line[41]),
                WaypointDescriptionCodeFixFunction2 = CifpFieldConverter.Field517FixFunction2(line[42]),
                TurnDirection = CifpFieldConverter.Field520(line[43]),
                Rnp = CifpFieldConverter.Field5211(line.Slice(44, 3)),
                PathAndTermination = CifpFieldConverter.Field521(line.Slice(47, 2)),
                TurnDirectionValid = CifpFieldConverter.Field522(line[49]),
                RecommendedNavaid = CifpSpan.Text(line.Slice(50, 4)),
                RecommendedNavaidIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(54, 2)),
                ArcRadius = CifpFieldConverter.Field5204(line.Slice(56, 6)),
                Theta = CifpFieldConverter.Field524(line.Slice(62, 4)),
                Rho = CifpFieldConverter.Field525(line.Slice(66, 4)),
                MagneticCourse = CifpFieldConverter.Field526(line.Slice(70, 4)),
                RouteDistanceHoldingDistanceOrTime = CifpFieldConverter.Field527(line.Slice(74, 4)),
                RecdNavSection = CifpSpan.Text(line[78]),
                RecdNavSubsection = CifpSpan.Text(line[79]),
                AltitudeDescription = CifpSpan.Text(line[82]),
                AtcIndicator = CifpFieldConverter.Field581(line[83]),
                Altitude1 = CifpFieldConverter.Field530(line.Slice(84, 5)),
                Altitude2 = CifpFieldConverter.Field530(line.Slice(89, 5)),
                TransitionAltitude = CifpFieldConverter.Field553(line.Slice(94, 5)),
                SpeedLimit = CifpFieldConverter.Field572(line.Slice(99, 3)),
                VerticalAngle = CifpFieldConverter.Field570(line.Slice(102, 4)),
                CenterFixOrTaaProcedureTurnIndicator = CifpSpan.Text(line.Slice(106, 5)),
                MultipleCodeOrTaaSectorIdentifier = CifpSpan.Text(line[111]),
                PointReferenceIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(112, 2)),
                PointSectionCode = CifpSpan.Text(line[114]),
                PointSubsectionCode = CifpSpan.Text(line[115]),
                GnssFmsIndication = CifpFieldConverter.Field5222(line[116]),
                SpeedLimitDescription = CifpFieldConverter.Field5261(line[117]),
                ApchRouteQualifier1 = CifpFieldConverter.RouteQualifier1(line[118]),
                ApchRouteQualifier2 = CifpFieldConverter.RouteQualifier2(line[119]),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.HeliportStandardInstrumentDepartures.Add(model);
        }
    }
}