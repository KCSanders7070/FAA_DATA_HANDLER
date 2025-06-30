using FAA_DATA_HANDLER.Models.NASR.CSV;
using FAA_DATA_HANDLER.Parsers.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using static FAA_DATA_HANDLER.Models.NASR.CSV.RdrCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateRdrJsonFromCsv
    {
        public static void Generate(RdrCsvDataCollection data, string outputDirectory)
        {
            var rdrDict = data.Rdr
                .GroupBy(r => r.FacilityId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate
                        },
                        Rdr = g.Select(r => new
                        {
                            r.FacilityId,
                            r.FacilityType,
                            r.StateCode,
                            r.CountryCode,
                            r.RadarType,
                            r.RadarNo,
                            r.RadarHrs,
                            r.Remark
                        }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Rdr.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(rdrDict, options));
        }
    }
}
