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
using static FAA_DATA_HANDLER.Models.NASR.CSV.StarCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateStarJsonFromCsv
    {
        public static void Generate(StarCsvDataCollection data, string outputDirectory)
        {
            var starDict = data.StarBase
                .GroupBy(s => s.StarComputerCode)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().StarComputerCode,
                            g.First().Artcc
                        },
                        StarApt = data.StarApt
                            .Where(a => a.StarComputerCode == g.Key)
                            .Select(a => new
                            {
                                a.BodyName,
                                a.AptBodySeq,
                                a.ArptId,
                                a.RwyEndId
                            }).ToList(),
                        StarBase = g.Select(b => new
                        {
                            b.ArrivalName,
                            b.AmendmentNo,
                            b.StarAmendEffDate,
                            b.RnavFlag,
                            b.ServedArpt
                        }).ToList(),
                        StarRte = data.StarRte
                            .Where(r => r.StarComputerCode == g.Key)
                            .GroupBy(r => new { r.RoutePortionType, r.RouteName, r.RteBodySeq, r.TransitionComputerCode })
                            .Select(rg => new
                            {
                                rg.Key.RoutePortionType,
                                rg.Key.RouteName,
                                rg.Key.RteBodySeq,
                                rg.Key.TransitionComputerCode,
                                Segments = rg.Select(r => new
                                {
                                    r.PointSeq,
                                    r.Point,
                                    r.IcaoRegionCode,
                                    r.PointType,
                                    r.NextPoint,
                                    r.ArptRwyAssoc
                                }).ToList()
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Star.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(starDict, options));
        }
    }
}