using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    public static class TerminalNavaidsCifpParser
    {
        public static void Parse(string line, CifpDataCollections cifpDataCollections)
        {
            var model = new TerminalNavaidsCifpDataModel
            {
                RecordType = line.Substring(0, 1).Trim(),
                CustomerAreaCode = line.Substring(1, 3).Trim(),
                SectionCode = line.Substring(4, 1).Trim(),
                SubsectionCode = line.Substring(5, 1).Trim(),
                AptIcaoIdentifier = line.Substring(6, 4).Trim(),
                AirportIcaoLocationCode = line.Substring(10, 2).Trim(),
                // Blank (Spacing) ??? = line.Substring(12, 1).Trim()
                NdbIdentifier = line.Substring(13, 4).Trim(),
                // Blank (Spacing) ??? = line.Substring(17, 2).Trim()
                NavaidIcaoLocationCode = line.Substring(19, 2).Trim(),
                ContinuationRecordNumber = line.Substring(21, 1).Trim(),
                NdbFreq = line.Substring(22, 5).Trim(),
                NavaidClassNavaidType1 = line.Substring(27, 1).Trim(),
                NavaidClassNavaidType2 = line.Substring(28, 1).Trim(),
                NavaidClassRangePower = line.Substring(29, 1).Trim(),
                NavaidClassAddInfo = line.Substring(30, 1).Trim(),
                NavaidClassCollocation = line.Substring(31, 1).Trim(),
                NdbLat = line.Substring(32, 9).Trim(),
                NdbLon = line.Substring(41, 10).Trim(),
                // Blank (Spacing) ??? = line.Substring(51, 23).Trim()
                MagVar = line.Substring(74, 5).Trim(),
                // Blank (Spacing) ??? = line.Substring(79, 6).Trim()
                // Reserved (Expansion) ??? = line.Substring(85, 5).Trim()
                DatumCode = line.Substring(90, 3).Trim(),
                NdbName = line.Substring(93, 30).Trim(),
                FileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),
            };

            cifpDataCollections.TerminalNavaids.Add(model);
        }
    }
}