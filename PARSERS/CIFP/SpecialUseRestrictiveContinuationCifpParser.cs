using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses UR continuation records into SpecialUseRestrictiveContinuationCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.18.2
    /// Restrictive Airspace Continuation Records (Special Use Airspace_Continuation-UR) and were verified
    /// against every UR record in FAACIFP18.
    /// </remarks>
    public static class SpecialUseRestrictiveContinuationCifpParser
    {
        /// <summary>
        /// Parses one UR record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new SpecialUseRestrictiveContinuationCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                AirspaceIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(6, 2)),
                RestrictiveType = CifpFieldConverter.Field5128(line[8]),
                RestrictiveAirspaceDesignation = CifpFieldConverter.Field5129(line.Slice(9, 10)),
                MultipleCode = CifpFieldConverter.Field5130(line[19]),
                SequenceNumber = CifpFieldConverter.Field512(line.Slice(20, 4)),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[24]),
                ApplicationType = CifpFieldConverter.Field591(line[25]),
                TimeCode = CifpFieldConverter.Field5131(line[26]),
                Notam = CifpSpan.ToFlag(line[27]),
                TimeIndicator = CifpSpan.Text(line[28]),
                TimeofOperations1DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(29, 2)),
                TimeofOperations1StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(31, 4)),
                TimeofOperations1EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(35, 4)),
                TimeofOperations2DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(39, 2)),
                TimeofOperations2StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(41, 4)),
                TimeofOperations2EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(45, 4)),
                TimeofOperations3DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(49, 2)),
                TimeofOperations3StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(51, 4)),
                TimeofOperations3EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(55, 4)),
                TimeofOperations4DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(59, 2)),
                TimeofOperations4StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(61, 4)),
                TimeofOperations4EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(65, 4)),
                TimeofOperations5DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(69, 2)),
                TimeofOperations5StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(71, 4)),
                TimeofOperations5EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(75, 4)),
                TimeofOperations6DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(79, 2)),
                TimeofOperations6StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(81, 4)),
                TimeofOperations6EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(85, 4)),
                TimeofOperations7DayRange = CifpFieldConverter.Field5195DayRange(line.Slice(89, 2)),
                TimeofOperations7StartTime = CifpFieldConverter.Field5195StartTime(line.Slice(91, 4)),
                TimeofOperations7EndTime = CifpFieldConverter.Field5195EndTime(line.Slice(95, 4)),
                ControllingAgency = CifpFieldConverter.Field5140(line.Slice(99, 24)),
                FileRecordNumber = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.SpecialUseRestrictiveContinuation.Add(model);
        }
    }
}