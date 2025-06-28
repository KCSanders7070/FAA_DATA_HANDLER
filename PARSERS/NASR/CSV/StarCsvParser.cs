using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.StarCsvDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class StarCsvParser
    {
        public StarDataCollection ParseStarApt(string filePath)
        {
            var result = new StarDataCollection();

            result.StarApt = FebCsvHelper.ProcessLines(
                filePath,
                fields => new StarApt
                {
                    EffDate = fields["EFF_DATE"],
                    StarComputerCode = fields["STAR_COMPUTER_CODE"],
                    Artcc = fields["ARTCC"],
                    BodyName = fields["BODY_NAME"],
                    AptBodySeq = FebCsvHelper.ParseInt(fields["BODY_SEQ"]),
                    ArptId = fields["ARPT_ID"],
                    RwyEndId = fields["RWY_END_ID"],
                });

            return result;
        }

        public StarDataCollection ParseStarBase(string filePath)
        {
            var result = new StarDataCollection();

            result.StarBase = FebCsvHelper.ProcessLines(
                filePath,
                fields => new StarBase
                {
                    EffDate = fields["EFF_DATE"],
                    ArrivalName = fields["ARRIVAL_NAME"],
                    AmendmentNo = fields["AMENDMENT_NO"],
                    Artcc = fields["ARTCC"],
                    StarAmendEffDate = fields["STAR_AMEND_EFF_DATE"],
                    RnavFlag = fields["RNAV_FLAG"],
                    StarComputerCode = fields["STAR_COMPUTER_CODE"],
                    ServedArpt = fields["SERVED_ARPT"],
                });

            return result;
        }

        public StarDataCollection ParseStarRte(string filePath)
        {
            var result = new StarDataCollection();

            result.StarRte = FebCsvHelper.ProcessLines(
                filePath,
                fields => new StarRte
                {
                    EffDate = fields["EFF_DATE"],
                    StarComputerCode = fields["STAR_COMPUTER_CODE"],
                    Artcc = fields["ARTCC"],
                    RoutePortionType = fields["ROUTE_PORTION_TYPE"],
                    RouteName = fields["ROUTE_NAME"],
                    RteBodySeq = FebCsvHelper.ParseInt(fields["BODY_SEQ"]),
                    TransitionComputerCode = fields["TRANSITION_COMPUTER_CODE"],
                    PointSeq = FebCsvHelper.ParseInt(fields["POINT_SEQ"]),
                    Point = fields["POINT"],
                    IcaoRegionCode = fields["ICAO_REGION_CODE"],
                    PointType = fields["POINT_TYPE"],
                    NextPoint = fields["NEXT_POINT"],
                    ArptRwyAssoc = fields["ARPT_RWY_ASSOC"],
                });

            return result;
        }

    }

    public class StarDataCollection
    {
        public List<StarApt> StarApt { get; set; } = new();
        public List<StarBase> StarBase { get; set; } = new();
        public List<StarRte> StarRte { get; set; } = new();
    }
}