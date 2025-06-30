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
using static FAA_DATA_HANDLER.Models.NASR.CSV.FixCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateFixJsonFromCsv
    {
        public static void Generate(FixCsvDataCollection data, string outputDirectory)
        {
            var fixDict = data.FixBase
                .GroupBy(f => f.FixId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().FixId,
                            g.First().IcaoRegionCode,
                            g.First().StateCode,
                            g.First().CountryCode
                        },
                        FixBase = new
                        {
                            g.First().LatDeg,
                            g.First().LatMin,
                            g.First().LatSec,
                            g.First().LatHemis,
                            g.First().LatDecimal,
                            g.First().LongDeg,
                            g.First().LongMin,
                            g.First().LongSec,
                            g.First().LongHemis,
                            g.First().LongDecimal,
                            g.First().FixIdOld,
                            g.First().ChartingRemark,
                            g.First().FixUseCode,
                            g.First().ArtccIdHigh,
                            g.First().ArtccIdLow,
                            g.First().PitchFlag,
                            g.First().CatchFlag,
                            g.First().SuaAtcaaFlag,
                            g.First().MinRecepAlt,
                            g.First().Compulsory,
                            g.First().Charts
                        },
                        FixChrt = data.FixChrt
                            .Where(c => c.FixId == g.Key)
                            .Select(c => new
                            {
                                c.ChartingTypeDesc
                            }).ToList(),
                        FixNav = data.FixNav
                            .Where(n => n.FixId == g.Key)
                            .Select(n => new
                            {
                                n.NavId,
                                n.NavType,
                                n.Bearing,
                                n.Distance
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Fix.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(fixDict, options));
        }
    }
}
