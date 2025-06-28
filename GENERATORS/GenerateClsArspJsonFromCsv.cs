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
using static FAA_DATA_HANDLER.Models.NASR.CSV.ClsArspCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateClsArspJsonFromCsv
    {
        public static void Generate(ClsArspCsvDataCollection data, string outputDirectory)
        {
            var airspaceDict = data.ClsArsp
                .GroupBy(x => x.ArptId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new
                    {
                        x.EffDate,
                        x.SiteNo,
                        x.SiteTypeCode,
                        x.StateCode,
                        x.ArptId,
                        x.City,
                        x.CountryCode,
                        x.ClassBAirspace,
                        x.ClassCAirspace,
                        x.ClassDAirspace,
                        x.ClassEAirspace,
                        x.AirspaceHrs,
                        x.Remark
                    }).First() // Each ArptId expected to have a single record
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "ClsArsp.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(airspaceDict, options));
        }
    }
}
