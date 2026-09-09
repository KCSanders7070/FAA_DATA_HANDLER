using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses PP continuation records into PathPointContinuationCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.28.2
    /// Path Point Continuation (Path Point Continuation-PP) and were verified against every PP record in
    /// FAACIFP18.
    /// </remarks>
    public static class PathPointContinuationCifpParser
    {
        /// <summary>
        /// Parses one PP record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new PathPointContinuationCifpDataModel
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
                ApplicationType = CifpFieldConverter.Field591(line[27]),
                FpapEllipsoidHeight = CifpFieldConverter.Field5225(line.Slice(28, 6)),
                FpapOrthometricHeight = CifpFieldConverter.Field5227(line.Slice(34, 6)),
                LtpOrthometricHeight = CifpFieldConverter.Field5227(line.Slice(40, 6)),
                ApproachTypeIdentifier = CifpSpan.Text(line.Slice(46, 10)),
                GnssChannelNumber = CifpFieldConverter.Field5244(line.Slice(56, 5)),
                HelicopterProcedureCourse = CifpSpan.ToInt(line.Slice(71, 3)),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.PathPointContinuation.Add(model);
        }
    }
}