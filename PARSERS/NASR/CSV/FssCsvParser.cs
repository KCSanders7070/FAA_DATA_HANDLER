using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.FssCsvDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class FssCsvParser
    {
        public FssDataCollection ParseFssBase(string filePath)
        {
            var result = new FssDataCollection();

            result.FssBase = FebCsvHelper.ProcessLines(
                filePath,
                fields => new FssBase
                {
                    EffDate = fields["EFF_DATE"],
                    FssId = fields["FSS_ID"],
                    Name = fields["NAME"],
                    UpdateDate = fields["UPDATE_DATE"],
                    FssFacType = fields["FSS_FAC_TYPE"],
                    VoiceCall = fields["VOICE_CALL"],
                    City = fields["CITY"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    LatDeg = FebCsvHelper.ParseInt(fields["LAT_DEG"]),
                    LatMin = FebCsvHelper.ParseInt(fields["LAT_MIN"]),
                    LatSec = FebCsvHelper.ParseDouble(fields["LAT_SEC"]),
                    LatHemis = fields["LAT_HEMIS"],
                    LatDecimal = FebCsvHelper.ParseDouble(fields["LAT_DECIMAL"]),
                    LongDeg = FebCsvHelper.ParseInt(fields["LONG_DEG"]),
                    LongMin = FebCsvHelper.ParseInt(fields["LONG_MIN"]),
                    LongSec = FebCsvHelper.ParseDouble(fields["LONG_SEC"]),
                    LongHemis = fields["LONG_HEMIS"],
                    LongDecimal = FebCsvHelper.ParseDouble(fields["LONG_DECIMAL"]),
                    OprHours = fields["OPR_HOURS"],
                    FacStatus = fields["FAC_STATUS"],
                    AlternateFss = fields["ALTERNATE_FSS"],
                    WeaRadarFlag = fields["WEA_RADAR_FLAG"],
                    PhoneNo = fields["PHONE_NO"],
                    TollFreeNo = fields["TOLL_FREE_NO"],
                });

            return result;
        }

        public FssDataCollection ParseFssRmk(string filePath)
        {
            var result = new FssDataCollection();

            result.FssRmk = FebCsvHelper.ProcessLines(
                filePath,
                fields => new FssRmk
                {
                    EffDate = fields["EFF_DATE"],
                    FssId = fields["FSS_ID"],
                    Name = fields["NAME"],
                    City = fields["CITY"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    RefColName = fields["REF_COL_NAME"],
                    RefColSeqNo = FebCsvHelper.ParseInt(fields["REF_COL_SEQ_NO"]),
                    Remark = fields["REMARK"],
                });

            return result;
        }

    }

    public class FssDataCollection
    {
        public List<FssBase> FssBase { get; set; } = new();
        public List<FssRmk> FssRmk { get; set; } = new();
    }
}