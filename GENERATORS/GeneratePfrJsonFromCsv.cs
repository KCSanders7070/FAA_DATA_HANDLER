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
using static FAA_DATA_HANDLER.Models.NASR.CSV.PfrCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GeneratePfrJsonFromCsv
    {
        public static void Generate(PfrCsvDataCollection data, string outputDirectory)
        {
            var pfrDict = data.PfrBase
                .GroupBy(p => p.OriginId + "-" + p.DstnId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            OriginId = g.First().OriginId,
                            DstnId = g.First().DstnId
                        },
                        Routes = g
                            .GroupBy(r => r.RouteNo)
                            .ToDictionary(
                                rg => $"RouteNo: {rg.Key}",
                                rg => new
                                {
                                    RouteNo = rg.Key,
                                    PfrTypeCode = rg.First().PfrTypeCode,
                                    PfrBase = rg.Select(p => new
                                    {
                                        p.OriginCity,
                                        p.OriginStateCode,
                                        p.OriginCountryCode,
                                        p.DstnCity,
                                        p.DstnStateCode,
                                        p.DstnCountryCode,
                                        p.SpecialAreaDescrip,
                                        p.AltDescrip,
                                        p.BaseAircraft,
                                        p.Hours,
                                        p.RouteDirDescrip,
                                        p.Designator,
                                        p.NarType,
                                        p.InlandFacFix,
                                        p.CoastalFix,
                                        p.Destination,
                                        p.BaseRouteString
                                    }).ToList(),
                                    PfrRmtFmt = data.PfrRmtFmt
                                        .Where(rf => rf.OriginId == rg.First().OriginId && rf.DstnId == rg.First().DstnId && rf.RouteNo == rg.Key)
                                        .Select(rf => new
                                        {
                                            rf.Orig,
                                            rf.RmtFmtRouteString,
                                            rf.Dest,
                                            rf.Hours1,
                                            rf.Type,
                                            rf.Area,
                                            rf.Altitude,
                                            rf.RmtFmtAircraft,
                                            rf.Direction,
                                            rf.Seq,
                                            rf.Dcntr,
                                            rf.Acntr
                                        }).ToList(),
                                    PfrSeg = data.PfrSeg
                                        .Where(s => s.OriginId == rg.First().OriginId && s.DstnId == rg.First().DstnId && s.RouteNo == rg.Key)
                                        .Select(s => new
                                        {
                                            s.SegmentSeq,
                                            s.SegValue,
                                            s.SegType,
                                            s.StateCode,
                                            s.CountryCode,
                                            s.IcaoRegionCode,
                                            s.NavType,
                                            s.NextSeg
                                        }).ToList()
                                })
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Pfr.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(pfrDict, options));
        }
    }
}
