using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses HF continuation records into HeliportApproachProceduresContinuationCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.9.5
    /// Approach Level of Service Continuation Records (Heli Approaches Continuation-HF) and were verified
    /// against every HF record in FAACIFP18.
    /// </remarks>
    public static class HeliportApproachProceduresContinuationCifpParser
    {
        /// <summary>
        /// Parses one HF record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new HeliportApproachProceduresContinuationCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                SidStarApproachIdentifier = CifpFieldConverter.Field510(line.Slice(13, 6)),
                RouteType = CifpFieldConverter.Field57(line[19], line[4], line[12]),
                TransitionIdentifier = CifpFieldConverter.Field511(line.Slice(20, 5)),
                SequenceNumber = CifpFieldConverter.Field512(line.Slice(26, 3)),
                FixIdentifier = CifpFieldConverter.Field513(line.Slice(29, 5)),
                FixIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(34, 2)),
                FixSectionCode = CifpSpan.Text(line[36]),
                FixSubsectionCode = CifpSpan.Text(line[37]),
                ContinuationRecordNumber = CifpFieldConverter.Field516(line[38]),
                ApplicationType = CifpFieldConverter.Field591(line[39]),
                FasBlockProvided = CifpFieldConverter.Field5276(line[40]),
                FasBlockProvidedLevelOfServiceName = CifpSpan.Text(line.Slice(41, 10)),
                LnavVnavAuthorizedForSbas = CifpFieldConverter.Field5276(line[51]),
                LnavVnavLevelOfServiceName = CifpSpan.Text(line.Slice(52, 10)),
                LnavAuthorizedForSbas = CifpFieldConverter.Field5276(line[62]),
                LnavLevelOfServiceName = CifpSpan.Text(line.Slice(63, 10)),
                RnpAuthorized1 = CifpFieldConverter.Field5276(line[88]),
                RnpLevelOfServiceValue1 = CifpFieldConverter.Field5297(line.Slice(89, 3)),
                RnpAuthorized2 = CifpFieldConverter.Field5276(line[92]),
                RnpLevelOfServiceValue2 = CifpFieldConverter.Field5297(line.Slice(93, 3)),
                RnpAuthorized3 = CifpFieldConverter.Field5276(line[96]),
                RnpLevelOfServiceValue3 = CifpFieldConverter.Field5297(line.Slice(97, 3)),
                RnpAuthorized4 = CifpFieldConverter.Field5276(line[100]),
                RnpLevelOfServiceValue4 = CifpFieldConverter.Field5297(line.Slice(101, 3)),
                ApproachRouteTypeQualifier1 = CifpFieldConverter.RouteQualifier1(line[118]),
                ApproachRouteTypeQualifier2 = CifpFieldConverter.RouteQualifier2(line[119]),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.HeliportApproachProceduresContinuation.Add(model);
        }
    }
}