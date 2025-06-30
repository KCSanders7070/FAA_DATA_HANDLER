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
using static FAA_DATA_HANDLER.Models.NASR.CSV.FssCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateFssJsonFromCsv
    {
        public static void Generate(FssCsvDataCollection data, string outputDirectory)
        {
            var fssDict = data.FssBase
                .GroupBy(f => f.FssId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().FssId,
                            g.First().Name,
                            g.First().City,
                            g.First().StateCode,
                            g.First().CountryCode
                        },
                        FssBase = new
                        {
                            g.First().UpdateDate,
                            g.First().FssFacType,
                            g.First().VoiceCall,
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
                            g.First().OprHours,
                            g.First().FacStatus,
                            g.First().AlternateFss,
                            g.First().WeaRadarFlag,
                            g.First().PhoneNo,
                            g.First().TollFreeNo
                        },
                        FssRmk = data.FssRmk
                            .Where(r => r.FssId == g.Key)
                            .Select(r => new
                            {
                                r.RefColName,
                                r.RefColSeqNo,
                                r.Remark
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Fss.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(fssDict, options));
        }
    }
}
