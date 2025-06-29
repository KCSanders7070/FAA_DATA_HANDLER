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
using static FAA_DATA_HANDLER.Models.NASR.CSV.MtrCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateMtrJsonFromCsv
    {
        public static void Generate(MtrCsvDataCollection data, string outputDirectory)
        {
            var mtrDict = data.MtrBase
                .GroupBy(m => m.RouteTypeCode + m.RouteId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            RouteTypeCode = g.First().RouteTypeCode,
                            RouteId = g.First().RouteId,
                            Artcc = g.First().Artcc
                        },
                        MtrAgy = data.MtrAgy
                            .Where(a => a.RouteTypeCode + a.RouteId == g.Key)
                            .Select(a => new
                            {
                                a.AgencyType,
                                a.AgencyName,
                                a.Station,
                                a.Address,
                                a.City,
                                a.StateCode,
                                a.ZipCode,
                                a.CommercialNo,
                                a.DsnNo,
                                a.Hours
                            }).ToList(),
                        MtrBase = g.Select(b => new
                        {
                            b.Fss,
                            b.TimeOfUse
                        }).ToList(),
                        MtrPt = data.MtrPt
                            .Where(p => p.RouteTypeCode + p.RouteId == g.Key)
                            .Select(p => new
                            {
                                p.RoutePtId,
                                p.RoutePtSeq,
                                p.NextRoutePtId,
                                p.SegmentText,
                                p.LatDeg,
                                p.LatMin,
                                p.LatSec,
                                p.LatHemis,
                                p.LatDecimal,
                                p.LongDeg,
                                p.LongMin,
                                p.LongSec,
                                p.LongHemis,
                                p.LongDecimal,
                                p.NavId,
                                p.NavaidBearing,
                                p.NavaidDist
                            }).ToList(),
                        MtrSop = data.MtrSop
                            .Where(s => s.RouteTypeCode + s.RouteId == g.Key)
                            .Select(s => new
                            {
                                s.SopSeqNo,
                                s.SopText
                            }).ToList(),
                        MtrTerr = data.MtrTerr
                            .Where(t => t.RouteTypeCode + t.RouteId == g.Key)
                            .Select(t => new
                            {
                                t.TerrainSeqNo,
                                t.TerrainText
                            }).ToList(),
                        MtrWdth = data.MtrWdth
                            .Where(w => w.RouteTypeCode + w.RouteId == g.Key)
                            .Select(w => new
                            {
                                w.WidthSeqNo,
                                w.WidthText
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Mtr.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(mtrDict, options));
        }
    }
}
