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
using static FAA_DATA_HANDLER.Models.NASR.CSV.DpDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateDpJsonFromCsv
    {
        public static void Generate(DpDataCollection data, string outputDirectory)
        {
            var dpDict = data.DpBase
                .GroupBy(d => d.DpName)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        commonFields = new
                        {
                            effDate = g.First().EffDate,
                            dpComputerCode = g.First().DpComputerCode,
                            dpName = g.First().DpName,
                            artcc = g.First().Artcc
                        },
                        dpApt = data.DpApt
                            .Where(x => x.DpName == g.Key)
                            .Select(x => new
                            {
                                x.BodyName,
                                x.AptBodySeq,
                                x.ArptId,
                                x.RwyEndId
                            }).ToList(),

                        dpBase = new
                        {
                            amendmentNo = g.First().AmendmentNo,
                            dpAmendEffDate = g.First().DpAmendEffDate,
                            rnavFlag = g.First().RnavFlag,
                            graphicalDpType = g.First().GraphicalDpType,
                            servedArpt = g.First().ServedArpt.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList()
                        },

                        dpRte = data.DpRte
                            .Where(r => r.DpName == g.Key)
                            .GroupBy(r => new { r.RoutePortionType, r.RouteName, r.RteBodySeq, r.TransitionComputerCode })
                            .Select(rg => new
                            {
                                rg.Key.RoutePortionType,
                                rg.Key.RouteName,
                                rg.Key.RteBodySeq,
                                rg.Key.TransitionComputerCode,
                                segments = rg.Select(r => new
                                {
                                    r.PointSeq,
                                    r.Point,
                                    r.IcaoRegionCode,
                                    r.PointType,
                                    r.NextPoint,
                                    arptRwyAssoc = string.IsNullOrEmpty(r.ArptRwyAssoc) ? null : r.ArptRwyAssoc.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList()
                                }).ToList()
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Dp.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(dpDict, options));
        }
    }
}
