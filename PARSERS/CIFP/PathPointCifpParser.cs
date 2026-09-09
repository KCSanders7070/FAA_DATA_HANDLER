using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses PP records into PathPointCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.28.1
    /// Path Point (Path Point-PP) and were verified against every PP record in FAACIFP18.
    /// </remarks>
    public static class PathPointCifpParser
    {
        /// <summary>
        /// Parses one PP record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new PathPointCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                ApproachProcedureIdent = CifpFieldConverter.Field510(line.Slice(13, 6)),
                RunwayOrHelipadIdentifier = CifpSpan.Text(line.Slice(19, 5)),
                OperationType = CifpFieldConverter.Field5223(line.Slice(24, 2)),
                ContinuationRecordNumber = CifpFieldConverter.Field516(line[26]),
                RouteIndicator = CifpSpan.Text(line[27]),
                SbasServiceProviderIdentifier = CifpFieldConverter.Field5255(line.Slice(28, 2)),
                ReferencePathDataSelector = CifpFieldConverter.Field5256(line.Slice(30, 2)),
                ReferencePathIdentifier = CifpSpan.Text(line.Slice(32, 4)),
                ApproachPerformanceDesignator = CifpFieldConverter.Field5258(line[36]),
                LandingThresholdPointLatitude = CifpFieldConverter.Field5267(line.Slice(37, 11)),
                LandingThresholdPointLongitude = CifpFieldConverter.Field5268(line.Slice(48, 12)),
                LtpEllipsoidHeight = CifpFieldConverter.Field5225(line.Slice(60, 6)),
                GlidePathAngle = CifpFieldConverter.Field5226(line.Slice(66, 4)),
                FlightPathAlignmentPointLatitude = CifpFieldConverter.Field5267(line.Slice(70, 11)),
                FlightPathAlignmentPointLongitude = CifpFieldConverter.Field5268(line.Slice(81, 12)),
                CourseWidthAtThreshold = CifpFieldConverter.Field5228(line.Slice(93, 5)),
                LengthOffset = CifpFieldConverter.Field5259(line.Slice(98, 4)),
                PathPointTch = CifpFieldConverter.Field5265(line.Slice(102, 6), line[108]),
                TchUnitsIndicator = CifpFieldConverter.Field5266(line[108]),
                Hal = CifpFieldConverter.Field5263(line.Slice(109, 3)),
                Val = CifpFieldConverter.Field5264(line.Slice(112, 3)),
                SbasFasDataCrcRemainder = CifpFieldConverter.Field5229(line.Slice(115, 8)),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.PathPoint.Add(model);
        }
    }
}