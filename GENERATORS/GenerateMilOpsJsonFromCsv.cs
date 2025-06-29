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
using static FAA_DATA_HANDLER.Models.NASR.CSV.MilOpsCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateMilOpsJsonFromCsv
    {
        public static void Generate(MilOpsCsvDataCollection data, string outputDirectory)
        {
            var milOpsDict = data.MilOps
                .GroupBy(m => m.ArptId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate
                        },
                        MilOps = g.Select(m => new
                        {
                            m.SiteNo,
                            m.SiteTypeCode,
                            m.StateCode,
                            m.ArptId,
                            m.City,
                            m.CountryCode,
                            m.MilOpsOperCode,
                            m.MilOpsCall,
                            m.MilOpsHrs,
                            m.AmcpHrs,
                            m.PmsvHrs,
                            m.Remark
                        }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "MilOps.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(milOpsDict, options));
        }
    }
}