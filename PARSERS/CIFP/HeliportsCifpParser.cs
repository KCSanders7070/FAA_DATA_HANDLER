using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Heliports (PA) section data
    /// </summary>
    /// <remarks>
    /// Contains information for heliports.
    /// </remarks>
    public static class HeliportsCifpParser
    {
        public static void Parse(string line, CifpDataCollections cifpDataCollections)
        {
            var model = new HeliportsCifpDataModel
            {
                RecordType = line.Substring(0, 1).Trim(),
                CustomerAreaCode = line.Substring(1, 3).Trim(),
                SectionCode = line.Substring(4, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(5, 1).Trim()
                HeliportIdentifier = line.Substring(6, 4).Trim(),
                HeliportIcaoCode = line.Substring(10, 2).Trim(),
                SubsectionCode = line.Substring(12, 1).Trim(),
                AtaIataDesignator = line.Substring(13, 3).Trim(),
                PadIdentifier = line.Substring(16, 5).Trim(),
                ContinuationRecordNumber = line.Substring(21, 1).Trim(),
                SpeedLimitAltitude = line.Substring(22, 5).Trim(),
                DatumCode = line.Substring(27, 3).Trim(),
                IfrCapability = line.Substring(30, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(31, 1).Trim()
                Latitude = line.Substring(32, 9).Trim(),
                Longitude = line.Substring(41, 10).Trim(),
                MagVar = line.Substring(51, 5).Trim(),
                HeliportElevation = line.Substring(56, 5).Trim(),
                SpeedLimit = line.Substring(61, 3).Trim(),
                RecommendedVhfNavaid = line.Substring(64, 4).Trim(),
                NavaidIcaoCode = line.Substring(68, 2).Trim(),
                TransitionAlt = line.Substring(70, 5).Trim(),
                TransitionLvl = line.Substring(75, 5).Trim(),
                PublicMilitaryIndicator = line.Substring(80, 1).Trim(),
                TimeZone = line.Substring(81, 3).Trim(),
                DaylightIndicator = line.Substring(84, 1).Trim(),
                PadDeimensions = line.Substring(85, 6).Trim(),
                MagTrueIndicator = line.Substring(91, 1).Trim(),
                // Reserved (Expansion) ??? = line.Substring(92, 1).Trim()
                HeliportName = line.Substring(93, 30).Trim(),
                FileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),
            };

            cifpDataCollections.Heliports.Add(model);
        }
    }
}