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
using static FAA_DATA_HANDLER.Models.NASR.CSV.LidCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateLidJsonFromCsv
    {
        public static void Generate(LidCsvDataCollection data, string outputDirectory)
        {
            var lidDict = data.Lid
                .GroupBy(l => l.LocId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate
                        },
                        Lid = g.Select(l => new
                        {
                            l.CountryCode,
                            l.LocId,
                            l.RegionCode,
                            l.State,
                            l.City,
                            l.LidGroup,
                            l.FacType,
                            l.FacName,
                            l.RespArtccId,
                            l.ArtccComputerId,
                            l.FssId
                        }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Lid.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(lidDict, options));
        }
    }
}
