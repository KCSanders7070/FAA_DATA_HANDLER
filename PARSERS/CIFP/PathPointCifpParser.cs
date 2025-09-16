using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    public static class PathPointCifpParser
    {
        public static void Parse(string line, CifpDataCollections cifpDataCollections)
        {
            var model = new PathPointCifpDataModel
            {
                // NOTE_TO_NIK: This is the Primary Record (ContinuationRecordNumber = 1 / first line of a record)
                RecordType = line.Substring(0, 1).Trim(),
                CustomerAreaCode = line.Substring(1, 3).Trim(),
                SectionCode = line.Substring(4, 1).Trim(),
                // Blank (Spacing) ??? = line.Substring(5, 1).Trim()
                AirportIdentifier = line.Substring(6, 4).Trim(),
                AirportIcaoLocationCode = line.Substring(10, 2).Trim(),
                SubsectionCode = line.Substring(12, 1).Trim(),
                ApproachProcedrueIdent = line.Substring(13, 6).Trim(),
                RwyHelipadIdentifier = line.Substring(19, 5).Trim(),
                OperationType = line.Substring(24, 2).Trim(),
                ContinuationRecordNumber = line.Substring(26, 1).Trim(),
                RouteIndicator = line.Substring(27, 1).Trim(),
                SbasServeiceProviderId = line.Substring(28, 2).Trim(),
                RefPathDataSelector = line.Substring(30, 2).Trim(),
                RefPathId = line.Substring(32, 4).Trim(),
                ApproachPerformanceDesignator = line.Substring(36, 1).Trim(),
                LandingThresholPointLat = line.Substring(37, 11).Trim(),
                LandingThresholPointLon = line.Substring(48, 12).Trim(),
                LtpEllipsoidHeight = line.Substring(60, 6).Trim(),
                GlidePathAngle = line.Substring(66, 4).Trim(),
                FlightPathAlignmentPointLat = line.Substring(70, 11).Trim(),
                FlightPathAlignmentPointLon = line.Substring(81, 12).Trim(),
                CourseWidthAtThreshold = line.Substring(93, 5).Trim(),
                LengthOffset = line.Substring(98, 4).Trim(),
                PathPointTch = line.Substring(102, 6).Trim(),
                TchUnitsIndicator = line.Substring(108, 1).Trim(),
                Hal = line.Substring(109, 3).Trim(),
                Val = line.Substring(112, 3).Trim(),
                SbasFasDataCrcRemainder = line.Substring(115, 8).Trim(),
                FileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),

                // NOTE_TO_NIK: This is a Continuation Record (ContinuationRecordNumber > 1 / second+ line of a record)
                ContinuationRecordNumber = line.Substring(26, 1).Trim(),
                ApplicationType = line.Substring(27, 1).Trim(),
                FpapEllipsoidHeight = line.Substring(28, 6).Trim(),
                FpapOrthometricHeight = line.Substring(34, 6).Trim(),
                LtpOrthometricHeight = line.Substring(40, 6).Trim(),
                ApproachTypeId = line.Substring(46, 10).Trim(),
                GnssChannelNum = line.Substring(56, 5).Trim(),
                // Blank (Spacing) ??? = line.Substring(61, 10).Trim()
                HeliProcedureCourse = line.Substring(71, 3).Trim(),
                // Blank (Spacing) ??? = line.Substring(74, 49).Trim()
                FileRecordNum = line.Substring(123, 5).Trim(),
                CycleDate = line.Substring(128, 4).Trim(),
            };

            cifpDataCollections.PathPoint.Add(model);
        }
    }
}

