using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    public static class LocalizerAndGlideSlopeCifpParser
    {
        public static void Parse(string line, CifpDataCollections cifpDataCollections)
        {
            var model = new LocalizerAndGlideSlopeCifpDataModel
            {
                RecordType = line.Substring(0, 1).Trim(),
                CustomerAreaCode = line.Substring(1, 3).Trim(),
                SectionCode = line.Substring(4, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(5, 1).Trim()
                AirportIdentifier = line.Substring(6, 4).Trim(),
                AirportIcaoLocationCode = line.Substring(10, 2).Trim(),
                SubsectionCode = line.Substring(12, 1).Trim(),
                LocId = line.Substring(13, 4).Trim(),
                IlsCat = line.Substring(17, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(18, 3).Trim()
                ContinuationRecordNumber = line.Substring(21, 1).Trim(),
                LocFreq = line.Substring(22, 5).Trim(),
                RwyId = line.Substring(27, 5).Trim(),
                LocLat = line.Substring(32, 9).Trim(),
                LocLon = line.Substring(41, 10).Trim(),
                LocBearing = line.Substring(51, 4).Trim(),
                GlideSlopeLat = line.Substring(55, 9).Trim(),
                GlideSlopeLon = line.Substring(64, 10).Trim(),
                LocPosition = line.Substring(74, 4).Trim(),
                LocPositionReference = line.Substring(78, 1).Trim(),
                GlideSlopePosition = line.Substring(79, 4).Trim(),
                LocWidth = line.Substring(83, 4).Trim(),
                GlideSlopeAngle = line.Substring(87, 3).Trim(),
                StationDeclination = line.Substring(90, 5).Trim(),
                GlideSlopeHeightAtLandingThreshold = line.Substring(95, 2).Trim(),
                GlideSlopeElevation = line.Substring(97, 5).Trim(),
                SupportingFacId = line.Substring(102, 4).Trim(),
                SupportingFacIcaoLocationCode = line.Substring(106, 2).Trim(),
                SupportingFacSectionCode = line.Substring(108, 1).Trim(),
                SupportingFacSubsectionCode = line.Substring(109, 1).Trim(),
                // Reserved (Expansion) ??? = line.Substring(110, 13).Trim()
                FileRecordNoFileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),
            };

            cifpDataCollections.LocalizerAndGlideSlope.Add(model);
        }
    }
}