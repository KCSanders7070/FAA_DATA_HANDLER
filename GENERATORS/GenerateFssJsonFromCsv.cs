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

namespace FAA_DATA_HANDLER.Generators
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
                            EffDate = g.First().EffDate,
                            FssId = g.First().FssId,
                            Name = g.First().Name,
                            City = g.First().City,
                            StateCode = g.First().StateCode,
                            CountryCode = g.First().CountryCode
                        },
                        FssBase = new
                        {
                            UpdateDate = g.First().UpdateDate,
                            FssFacType = g.First().FssFacType,
                            VoiceCall = g.First().VoiceCall,
                            LatDeg = g.First().LatDeg,
                            LatMin = g.First().LatMin,
                            LatSec = g.First().LatSec,
                            LatHemis = g.First().LatHemis,
                            LatDecimal = g.First().LatDecimal,
                            LongDeg = g.First().LongDeg,
                            LongMin = g.First().LongMin,
                            LongSec = g.First().LongSec,
                            LongHemis = g.First().LongHemis,
                            LongDecimal = g.First().LongDecimal,
                            OprHours = g.First().OprHours,
                            FacStatus = g.First().FacStatus,
                            AlternateFss = g.First().AlternateFss,
                            WeaRadarFlag = g.First().WeaRadarFlag,
                            PhoneNo = g.First().PhoneNo,
                            TollFreeNo = g.First().TollFreeNo
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
