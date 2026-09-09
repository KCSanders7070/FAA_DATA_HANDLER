using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses UC records into ControlledClassAirspaceBCDCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.25.1
    /// Controlled Airspace (Class B, C, and D Airspace-UC) and were verified against every UC record in
    /// FAACIFP18.
    /// </remarks>
    public static class ControlledClassAirspaceBCDCifpParser
    {
        /// <summary>
        /// Parses one UC record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new ControlledClassAirspaceBCDCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                AirspaceIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(6, 2)),
                AirspaceType = CifpFieldConverter.Field5213(line[8]),
                AirspaceCenter = CifpSpan.Text(line.Slice(9, 5)),
                AirspaceCenterSectionCode = CifpSpan.Text(line[14]),
                AirspaceCenterSubsectionCode = CifpSpan.Text(line[15]),
                AirspaceClassification = CifpFieldConverter.Field5215(line[16]),
                MultipleCode = CifpFieldConverter.Field5130(line[19]),
                SequenceNumber = CifpFieldConverter.Field512(line.Slice(20, 4)),
                ContinuationRecordNumber = CifpFieldConverter.Field516(line[24]),
                Level = CifpFieldConverter.Field519(line[25]),
                TimeCode = CifpFieldConverter.Field5131(line[26]),
                Notam = CifpSpan.ToFlag(line[27]),
                BoundaryViaPathType = CifpFieldConverter.Field5118PathType(line[30]),
                BoundaryViaIsEndOfDescription = CifpFieldConverter.Field5118IsEndOfDescription(line[31]),
                Latitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                Longitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                ArcOriginLatitude = CifpFieldConverter.Field536(line.Slice(51, 9)),
                ArcOriginLongitude = CifpFieldConverter.Field537(line.Slice(60, 10)),
                ArcDistance = CifpFieldConverter.Field5119(line.Slice(70, 4)),
                ArcBearing = CifpFieldConverter.Field5120(line.Slice(74, 4)),
                Rnp = CifpFieldConverter.Field5211(line.Slice(78, 3)),
                LowerLimit = CifpFieldConverter.Field5121(line.Slice(81, 5)),
                LowerLimitUnitIndicator = CifpFieldConverter.Field5133(line[86]),
                UpperLimit = CifpFieldConverter.Field5121(line.Slice(87, 5)),
                UpperLimitUnitIndicator = CifpFieldConverter.Field5133(line[92]),
                ControlledAirspaceName = CifpSpan.Text(line.Slice(93, 30)),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.ControlledClassAirspaceBCD.Add(model);
        }
    }
}