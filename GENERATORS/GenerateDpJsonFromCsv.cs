// File: Generators/GenerateDpJson.cs

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
                .GroupBy(b => b.DpName)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            DpComputerCode = g.First().DpComputerCode,
                            DpName = g.First().DpName,
                            Artcc = g.First().Artcc
                        },

                        DpApt = data.DpApt
                            .Where(a => a.DpName == g.Key)
                            .GroupBy(a => a.BodyName)
                            .ToDictionary(
                                b => $"BodyName: {b.Key}",
                                b => b.GroupBy(x => x.AptBodySeq)
                                    .ToDictionary(
                                        s => $"AptBodySeq: {s.Key}",
                                        s => s.GroupBy(x => x.ArptId)
                                            .ToDictionary(
                                                a => $"ArptId: {a.Key}",
                                                a => a.Select(x => new
                                                {
                                                    RwyEndId = x.RwyEndId
                                                }).ToList()
                                            )
                                    )
                            ),

                        DpBase = g
                            .GroupBy(x => x.AmendmentNo)
                            .ToDictionary(
                                a => $"AmendmentNo: {a.Key}",
                                a => a.GroupBy(x => x.DpAmendEffDate)
                                    .ToDictionary(
                                        e => $"DpAmendEffDate: {e.Key}",
                                        e => e.GroupBy(x => x.RnavFlag)
                                            .ToDictionary(
                                                r => $"RnavFlag: {r.Key}",
                                                r => r.GroupBy(x => x.GraphicalDpType)
                                                    .ToDictionary(
                                                        t => $"GraphicalDpType: {t.Key}",
                                                        t => t.Select(x => new
                                                        {
                                                            ServedArpt = x.ServedArpt
                                                        }).ToList()
                                                    )
                                            )
                                    )
                            ),

                        DpRte = data.DpRte
                            .Where(r => r.DpName == g.Key)
                            .GroupBy(r => r.RoutePortionType)
                            .ToDictionary(
                                rp => $"RoutePortionType: {rp.Key}",
                                rp => rp.GroupBy(x => x.RouteName)
                                    .ToDictionary(
                                        rn => $"RouteName: {rn.Key}",
                                        rn => rn.GroupBy(x => x.RteBodySeq)
                                            .ToDictionary(
                                                rb => $"RteBodySeq: {rb.Key}",
                                                rb => rb.GroupBy(x => string.IsNullOrWhiteSpace(x.TransitionComputerCode) ? "BODY" : x.TransitionComputerCode)
                                                    .ToDictionary(
                                                        tc => $"TransitionComputerCode: {tc.Key}",
                                                        tc => tc.OrderBy(x => x.PointSeq)
                                                            .GroupBy(x => x.PointSeq)
                                                            .ToDictionary(
                                                                ps => $"PointSeq: {ps.Key}",
                                                                ps => ps.Select(p => new
                                                                {
                                                                    Point = p.Point,
                                                                    IcaoRegionCode = p.IcaoRegionCode,
                                                                    PointType = p.PointType,
                                                                    NextPoint = p.NextPoint,
                                                                    ArptRwyAssoc = p.ArptRwyAssoc
                                                                }).ToList()
                                                            )
                                                    )
                                            )
                                    )
                            )
                    }
                );

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