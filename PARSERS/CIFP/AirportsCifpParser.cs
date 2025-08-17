using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// FAACIFP18 File - Airports (PA) section data
    /// </summary>
    /// <remarks>
    /// Contains reference points for all airports having at least one hard surfaced runway
    /// Additionally, contains all airports required to support Enroute Airway
    /// structure coding for those areas where Airport reference points are used
    /// as enroute airway fixes.
    /// </remarks>

    public static class AirportsCifpParser
    {
        public static void Parse(string line, List<AirportsCifpDataModel> airportsCollection)
        {
            var model = new AirportsCifpDataModel
            {
                RecordType = line.Substring(0, 1).Trim(),
                CustomerAreaCode = line.Substring(1, 3).Trim(),
                SectionCode = line.Substring(4, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(5, 1).Trim()
                AptIcaoIdentifier = line.Substring(6, 4).Trim(),
                AirportIcaoCode = line.Substring(10, 2).Trim(),
                SubsectionCode = line.Substring(12, 1).Trim(),
                AtaIataDesignator = line.Substring(13, 3).Trim(),
                // Reserved (Expansion) ??? = line.Substring(16, 2).Trim()
                // Blank (Spacing) ??? = line.Substring(18, 3).Trim()
                ContinuationRecordNumber = line.Substring(21, 1).Trim(),
                SpdLimitAlt = line.Substring(22, 5).Trim(),
                LongestRwy = line.Substring(27, 3).Trim(),
                IfrCapability = line.Substring(30, 1).Trim(),
                LongestRwySfcCode = line.Substring(31, 1).Trim(),
                AptRefPtLat = line.Substring(32, 9).Trim(),
                AptRefPtLon = line.Substring(41, 10).Trim(),
                MagVar = line.Substring(51, 5).Trim(),
                AptElevation = line.Substring(56, 5).Trim(),
                SpdLimit = line.Substring(61, 3).Trim(),
                RecommendedNavaid = line.Substring(64, 4).Trim(),
                RecommendedNavaidIcaoCode = line.Substring(68, 2).Trim(),
                TransitionsAlt = line.Substring(70, 5).Trim(),
                TransitionLvl = line.Substring(75, 5).Trim(),
                PublicMilitaryIndicator = line.Substring(80, 1).Trim(),
                TimeZone = line.Substring(81, 3).Trim(),
                DaylightIndicator = line.Substring(84, 1).Trim(),
                MagTrueIndicator = line.Substring(85, 1).Trim(),
                DatumCode = line.Substring(86, 3).Trim(),
                // Reserved (Expansion) ??? = line.Substring(89, 4).Trim()
                AptName = line.Substring(93, 30).Trim(),
                FileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),
            };

            airportsCollection.Add(model);
        }
    }
}