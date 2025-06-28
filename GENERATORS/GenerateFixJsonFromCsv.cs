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

namespace FAA_DATA_HANDLER.Generators
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
                            EffDate = g.First().EffDate,
                            FixId = g.First().FixId,
                            IcaoRegionCode = g.First().IcaoRegionCode,
                            StateCode = g.First().StateCode,
                            CountryCode = g.First().CountryCode
                        },
                        FixBase = new
                        {
                            LatDeg = g.First().LatDeg,
                            LatMin = g.First().LatMin,
                            LatSec = g.First().LatSec,
                            LatHemis = g.First().LatHemis,
                            LatDecimal = g.First().LatDecimal,
                            LongDeg = g.First().LongDeg,
                            LongMin = g.First().LongMin,
                            LongSec = g.First().LongSec,
                            LongHemis = g.First().LongHemis,
                            LongDecimal = g.First().LongDecimal,
                            FixIdOld = g.First().FixIdOld,
                            ChartingRemark = g.First().ChartingRemark,
                            FixUseCode = g.First().FixUseCode,
                            ArtccIdHigh = g.First().ArtccIdHigh,
                            ArtccIdLow = g.First().ArtccIdLow,
                            PitchFlag = g.First().PitchFlag,
                            CatchFlag = g.First().CatchFlag,
                            SuaAtcaaFlag = g.First().SuaAtcaaFlag,
                            MinRecepAlt = g.First().MinRecepAlt,
                            Compulsory = g.First().Compulsory,
                            Charts = g.First().Charts
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
