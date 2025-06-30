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
using static FAA_DATA_HANDLER.Models.NASR.CSV.HpfCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateHpfJsonFromCsv
    {
        public static void Generate(HpfCsvDataCollection data, string outputDirectory)
        {
            var hpfDict = data.HpfBase
                .GroupBy(h => h.HpName)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            HpName = g.First().HpName,
                            HpNo = g.First().HpNo,
                            StateCode = g.First().StateCode,
                            CountryCode = g.First().CountryCode
                        },
                        HpfBase = g.Select(h => new
                        {
                            h.FixId,
                            h.IcaoRegionCode,
                            h.NavId,
                            h.NavType,
                            h.HoldDirection,
                            h.HoldDegOrCrs,
                            h.Azimuth,
                            h.CourseInboundDeg,
                            h.TurnDirection,
                            h.LegLengthDist
                        }).ToList(),
                        HpfChrt = data.HpfChrt
                            .Where(c => c.HpName == g.Key)
                            .Select(c => new
                            {
                                c.ChartingTypeDesc
                            }).ToList(),
                        HpfRm = data.HpfRmk
                            .Where(r => r.HpName == g.Key)
                            .Select(r => new
                            {
                                r.TabName,
                                r.RefColName,
                                r.RefColSeqNo,
                                r.Remark
                            }).ToList(),
                        HpfSpdAlt = data.HpfSpdAlt
                            .Where(s => s.HpName == g.Key)
                            .Select(s => new
                            {
                                s.SpeedRange,
                                s.Altitude
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Hpf.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(hpfDict, options));
        }
    }
}
