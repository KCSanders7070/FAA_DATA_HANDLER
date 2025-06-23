using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.HpfDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class HpfCsvParser
    {
        public HpfDataCollection ParseHpfBase(string filePath)
        {
            var result = new HpfDataCollection();

            result.HpfBase = FebCsvHelper.ProcessLines(
                filePath,
                fields => new HpfBase
                {
                    EffDate = fields["EFF_DATE"],
                    HpName = fields["HP_NAME"],
                    HpNo = fields["HP_NO"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    FixId = fields["FIX_ID"],
                    IcaoRegionCode = fields["ICAO_REGION_CODE"],
                    NavId = fields["NAV_ID"],
                    NavType = fields["NAV_TYPE"],
                    HoldDirection = fields["HOLD_DIRECTION"],
                    HoldDegOrCrs = fields["HOLD_DEG_OR_CRS"],
                    Azimuth = fields["AZIMUTH"],
                    CourseInboundDeg = FebCsvHelper.ParseNullableInt(fields["COURSE_INBOUND_DEG"]),
                    TurnDirection = fields["TURN_DIRECTION"],
                    LegLengthDist = FebCsvHelper.ParseNullableInt(fields["LEG_LENGTH_DIST"]),
                });

            return result;
        }

        public HpfDataCollection ParseHpfChrt(string filePath)
        {
            var result = new HpfDataCollection();

            result.HpfChrt = FebCsvHelper.ProcessLines(
                filePath,
                fields => new HpfChrt
                {
                    EffDate = fields["EFF_DATE"],
                    HpName = fields["HP_NAME"],
                    HpNo = fields["HP_NO"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    ChartingTypeDesc = fields["CHARTING_TYPE_DESC"],
                });

            return result;
        }

        public HpfDataCollection ParseHpfRmk(string filePath)
        {
            var result = new HpfDataCollection();

            result.HpfRmk = FebCsvHelper.ProcessLines(
                filePath,
                fields => new HpfRmk
                {
                    EffDate = fields["EFF_DATE"],
                    HpName = fields["HP_NAME"],
                    HpNo = fields["HP_NO"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    TabName = fields["TAB_NAME"],
                    RefColName = fields["REF_COL_NAME"],
                    RefColSeqNo = FebCsvHelper.ParseInt(fields["REF_COL_SEQ_NO"]),
                    Remark = fields["REMARK"],
                });

            return result;
        }

        public HpfDataCollection ParseHpfSpdAlt(string filePath)
        {
            var result = new HpfDataCollection();

            result.HpfSpdAlt = FebCsvHelper.ProcessLines(
                filePath,
                fields => new HpfSpdAlt
                {
                    EffDate = fields["EFF_DATE"],
                    HpName = fields["HP_NAME"],
                    HpNo = fields["HP_NO"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    SpeedRange = fields["SPEED_RANGE"],
                    Altitude = fields["ALTITUDE"],
                });

            return result;
        }

    }

    public class HpfDataCollection
    {
        public List<HpfBase> HpfBase { get; set; } = new();
        public List<HpfChrt> HpfChrt { get; set; } = new();
        public List<HpfRmk> HpfRmk { get; set; } = new();
        public List<HpfSpdAlt> HpfSpdAlt { get; set; } = new();
    }
}