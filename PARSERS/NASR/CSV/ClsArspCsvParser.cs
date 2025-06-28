using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.ClsArspCsvDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class ClsArspCsvParser
    {
        public ClsArspDataCollection ParseClsArsp(string filePath)
        {
            var result = new ClsArspDataCollection();

            result.ClsArsp = FebCsvHelper.ProcessLines(
                filePath,
                fields => new ClsArsp
                {
                    EffDate = fields["EFF_DATE"],
                    SiteNo = fields["SITE_NO"],
                    SiteTypeCode = fields["SITE_TYPE_CODE"],
                    StateCode = fields["STATE_CODE"],
                    ArptId = fields["ARPT_ID"],
                    City = fields["CITY"],
                    CountryCode = fields["COUNTRY_CODE"],
                    ClassBAirspace = fields["CLASS_B_AIRSPACE"],
                    ClassCAirspace = fields["CLASS_C_AIRSPACE"],
                    ClassDAirspace = fields["CLASS_D_AIRSPACE"],
                    ClassEAirspace = fields["CLASS_E_AIRSPACE"],
                    AirspaceHrs = fields["AIRSPACE_HRS"],
                    Remark = fields["REMARK"],
                });

            return result;
        }

    }

    public class ClsArspDataCollection
    {
        public List<ClsArsp> ClsArsp { get; set; } = new();
    }
}