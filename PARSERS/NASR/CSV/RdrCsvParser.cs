using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.RdrDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class RdrCsvParser
    {
        public RdrDataCollection ParseRdr(string filePath)
        {
            var result = new RdrDataCollection();

            result.Rdr = FebCsvHelper.ProcessLines(
                filePath,
                fields => new Rdr
                {
                    EffDate = fields["EFF_DATE"],
                    FacilityId = fields["FACILITY_ID"],
                    FacilityType = fields["FACILITY_TYPE"],
                    StateCode = fields["STATE_CODE"],
                    CountryCode = fields["COUNTRY_CODE"],
                    RadarType = fields["RADAR_TYPE"],
                    RadarNo = FebCsvHelper.ParseInt(fields["RADAR_NO"]),
                    RadarHrs = fields["RADAR_HRS"],
                    Remark = fields["REMARK"],
                });

            return result;
        }

    }

    public class RdrDataCollection
    {
        public List<Rdr> Rdr { get; set; } = new();
    }
}