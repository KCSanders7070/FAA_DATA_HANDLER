using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Runways (PG) section data
    /// </summary>
    public static class RunwaysCifpParser
    {
        public static void Parse(string line, CifpDataCollections cifpDataCollections)
        {
            var model = new RunwaysCifpDataModel
            {
                RecordType = line.Substring(0, 1).Trim(),
                CustomerAreaCode = line.Substring(1, 3).Trim(),
                SectionCode = line.Substring(4, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(5, 1).Trim()
                AirportIdentifier = line.Substring(6, 4).Trim(),
                AirportIcaoCode = line.Substring(10, 2).Trim(),
                SubsectionCode = line.Substring(12, 1).Trim(),
                RwyId = line.Substring(13, 5).Trim(),
                // Blank (Spacing) ??? = line.Substring(18, 3).Trim()
                ContinuationRecordNumber = line.Substring(21, 1).Trim(),
                RwyLength = line.Substring(22, 5).Trim(),
                RwyMagBearing = line.Substring(27, 4).Trim(),
                // Blank (Spacing) ??? = line.Substring(31, 1).Trim()
                RwyLat = line.Substring(32, 9).Trim(),
                RwyLong = line.Substring(41, 10).Trim(),
                RwyGradient = line.Substring(51, 5).Trim(),
                // Blank (Spacing) ??? = line.Substring(56, 4).Trim()
                EllipsoidHeight = line.Substring(60, 6).Trim(),
                LandingThresholdElev = line.Substring(66, 5).Trim(),
                DisplayedThresholdDistance = line.Substring(71, 4).Trim(),
                ThresholdCrossingHeight = line.Substring(75, 2).Trim(),
                RwyWidth = line.Substring(77, 3).Trim(),
                TchValueIndicator = line.Substring(80, 1).Trim(),
                LocMlsGlsRefPathIdentifier = line.Substring(81, 4).Trim(),
                LocMlsGlsCategoryClass = line.Substring(85, 1).Trim(),
                Stopway = line.Substring(86, 4).Trim(),
                SecondLocMlsGlsRefPathIdentifier = line.Substring(90, 4).Trim(),
                SecondLocMlsGlsCategoryClass = line.Substring(94, 1).Trim(),
                // Reserved (Expansion) ??? = line.Substring(95, 6).Trim()
                RwyDescription = line.Substring(101, 22).Trim(),
                FileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),
            };

            cifpDataCollections.Runways.Add(model);
        }
    }
}