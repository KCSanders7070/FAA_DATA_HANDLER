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
using static FAA_DATA_HANDLER.Models.NASR.CSV.ComDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateComJsonFromCsv
    {
        public static void Generate(ComDataCollection data, string outputDirectory)
        {
            var comDict = data.Com
                .GroupBy(x => x.CommLocId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new
                    {
                        x.EffDate,
                        x.CommLocId,
                        x.CommType,
                        x.NavId,
                        x.NavType,
                        x.City,
                        x.StateCode,
                        x.RegionCode,
                        x.CountryCode,
                        x.CommOutletName,
                        x.LatDeg,
                        x.LatMin,
                        x.LatSec,
                        x.LatHemis,
                        x.LatDecimal,
                        x.LongDeg,
                        x.LongMin,
                        x.LongSec,
                        x.LongHemis,
                        x.LongDecimal,
                        x.FacilityId,
                        x.FacilityName,
                        x.AltFssId,
                        x.AltFssName,
                        x.OprHrs,
                        x.CommStatusCode,
                        x.CommStatusDate,
                        x.Remark
                    }).First()
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Com.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(comDict, options));
        }
    }
}
