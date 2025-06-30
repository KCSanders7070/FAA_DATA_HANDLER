// File: FAA_DATA_HANDLER/Generators/GenerateWxlJsonFromCsv.cs
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
using static FAA_DATA_HANDLER.Models.NASR.CSV.WxlCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateWxlJsonFromCsv
    {
        public static void Generate(WxlCsvDataCollection data, string outputDirectory)
        {
            var wxlDict = data.WxlBase
                .GroupBy(w => w.WeaId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().WeaId,
                            g.First().City,
                            g.First().StateCode,
                            g.First().CountryCode
                        },
                        WxlBase = g.Select(b => new
                        {
                            b.LatDeg,
                            b.LatMin,
                            b.LatSec,
                            b.LatHemis,
                            b.LatDecimal,
                            b.LongDeg,
                            b.LongMin,
                            b.LongSec,
                            b.LongHemis,
                            b.LongDecimal,
                            b.Elev,
                            b.SurveyMethodCode
                        }).ToList(),
                        WxlSvc = data.WxlSvc
                            .Where(s => s.WeaId == g.Key)
                            .Select(s => new
                            {
                                s.WeaSvcTypeCode,
                                s.WeaAffectArea
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Wxl.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(wxlDict, options));
        }
    }
}
