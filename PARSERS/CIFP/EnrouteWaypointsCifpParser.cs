using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses EA records into EnrouteWaypointsCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.4.1
    /// Waypoint (Enroute Waypoints-EA) and were verified against every EA record in FAACIFP18.
    /// </remarks>
    public static class EnrouteWaypointsCifpParser
    {
        /// <summary>
        /// Parses one EA record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new EnrouteWaypointsCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                RegionCode = CifpFieldConverter.Field541(line.Slice(6, 4)),
                RegionIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                Subsection = CifpSpan.Text(line[12]),
                WaypointIdentifier = CifpFieldConverter.Field513(line.Slice(13, 5)),
                WaypointIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(19, 2)),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[21]),
                WaypointTypeFormation = CifpFieldConverter.Field542WaypointFormation(line[26]),
                WaypointTypeFunction = CifpFieldConverter.Field542WaypointFunction(line[27]),
                WaypointTypeProcedurePublication = CifpFieldConverter.Field542ProcedurePublication(line[28]),
                WaypointUsageRnav = CifpFieldConverter.Field582RnavUsage(line[29]),
                WaypointUsageAltitudeStructure = CifpFieldConverter.Field582AltitudeStructure(line[30]),
                WaypointLatitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                WaypointLongitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                DynamicMagVariation = CifpFieldConverter.Field539(line.Slice(74, 5)),
                DatumCode = CifpSpan.Text(line.Slice(84, 3)),
                NameFormatIndicatorFormat1 = CifpFieldConverter.Field5196NameFormat1(line[95]),
                NameFormatIndicatorFormat2 = CifpFieldConverter.Field5196NameFormat2(line[96]),
                NameFormatIndicatorFormat3 = CifpFieldConverter.Field5196NameFormat3(line[97]),
                WaypointNameDescription = CifpSpan.Text(line.Slice(98, 25)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.EnrouteWaypoints.Add(model);
        }
    }
}