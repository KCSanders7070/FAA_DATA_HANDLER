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
using static FAA_DATA_HANDLER.Models.NASR.CSV.AwosCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateAwosJsonFromCsv
    {
        public static void Generate(AwosDataCollection data, string outputDirectory)
        {
            var awosDict = data.Awos
                .GroupBy(a => a.AsosAwosId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        EffDate = g.First().EffDate,
                        g.First().AsosAwosId,
                        g.First().AsosAwosType,
                        g.First().StateCode,
                        g.First().City,
                        g.First().CountryCode,
                        g.First().CommissionedDate,
                        g.First().NavaidFlag,
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
                        g.First().Elev,
                        g.First().SurveyMethodCode,
                        g.First().PhoneNo,
                        g.First().SecondPhoneNo,
                        g.First().SiteNo,
                        g.First().SiteTypeCode,
                        g.First().Remark
                    }
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Awos.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(awosDict, options));
        }
    }
}
