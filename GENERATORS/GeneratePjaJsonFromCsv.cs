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
using static FAA_DATA_HANDLER.Models.NASR.CSV.PjaCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GeneratePjaJsonFromCsv
    {
        public static void Generate(PjaCsvDataCollection data, string outputDirectory)
        {
            var pjaDict = data.PjaBase
                .GroupBy(p => p.PjaId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            PjaId = g.First().PjaId
                        },
                        PjaBase = g.Select(p => new
                        {
                            p.NavId,
                            p.NavType,
                            p.Radial,
                            p.Distance,
                            p.NavaidName,
                            p.StateCode,
                            p.City,
                            p.Latitude,
                            p.LatDecimal,
                            p.Longitude,
                            p.LongDecimal,
                            p.ArptId,
                            p.SiteNo,
                            p.SiteTypeCode,
                            p.DropZoneName,
                            p.MaxAltitude,
                            p.MaxAltitudeTypeCode,
                            p.PjaRadius,
                            p.ChartRequestFlag,
                            p.PublishCriteria,
                            p.Description,
                            p.TimeOfUse,
                            p.FssId,
                            p.FssName,
                            p.PjaUse,
                            p.Volume,
                            p.PjaUser,
                            p.Remark
                        }).ToList(),
                        PjaCon = data.PjaCon
                            .Where(c => c.PjaId == g.Key)
                            .Select(c => new
                            {
                                c.FacId,
                                c.FacName,
                                c.LocId,
                                c.CommercialFreq,
                                c.CommercialChartFlag,
                                c.MilFreq,
                                c.MilChartFlag,
                                c.Sector,
                                c.ContactFreqAltitude
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Pja.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(pjaDict, options));
        }
    }
}
