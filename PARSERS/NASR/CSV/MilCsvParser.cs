using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.MilCsvDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class MilCsvParser
    {
        public MilDataCollection ParseMilOps(string filePath)
        {
            var result = new MilDataCollection();

            result.MilOps = FebCsvHelper.ProcessLines(
                filePath,
                fields => new MilOps
                {
                    EffDate = fields["EFF_DATE"],
                    SiteNo = fields["SITE_NO"],
                    SiteTypeCode = fields["SITE_TYPE_CODE"],
                    StateCode = fields["STATE_CODE"],
                    ArptId = fields["ARPT_ID"],
                    City = fields["CITY"],
                    CountryCode = fields["COUNTRY_CODE"],
                    MilOpsOperCode = fields["MIL_OPS_OPER_CODE"],
                    MilOpsCall = fields["MIL_OPS_CALL"],
                    MilOpsHrs = fields["MIL_OPS_HRS"],
                    AmcpHrs = fields["AMCP_HRS"],
                    PmsvHrs = fields["PMSV_HRS"],
                    Remark = fields["REMARK"],
                });

            return result;
        }

    }

    public class MilDataCollection
    {
        public List<MilOps> MilOps { get; set; } = new();
    }
}