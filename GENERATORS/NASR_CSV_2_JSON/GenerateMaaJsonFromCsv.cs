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
using static FAA_DATA_HANDLER.Models.NASR.CSV.MaaCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateMaaJsonFromCsv
    {
        public static void Generate(MaaCsvDataCollection data, string outputDirectory)
        {
            var maaDict = data.MaaBase
                .GroupBy(m => m.MaaId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().MaaId
                        },
                        MaaBase = g.Select(m => new
                        {
                            m.MaaTypeName,
                            m.NavId,
                            m.NavType,
                            m.NavRadial,
                            m.NavDistance,
                            m.StateCode,
                            m.City,
                            m.BaseLatitude,
                            m.BaseLongitude,
                            m.ArptIds,
                            m.NearestArpt,
                            m.NearestArptDist,
                            m.NearestArptDir,
                            m.MaaName,
                            m.MaxAlt,
                            m.MinAlt,
                            m.MaaRadius,
                            m.Description,
                            m.MaaUse,
                            m.CheckNotams,
                            m.TimeOfUse,
                            m.UserGroupName
                        }).ToList(),
                        MaaCon = data.MaaCon
                            .Where(c => c.MaaId == g.Key)
                            .Select(c => new
                            {
                                c.FreqSeq,
                                c.FacId,
                                c.FacName,
                                c.CommercialFreq,
                                c.CommercialChartFlag,
                                c.MilFreq,
                                c.MilChartFlag
                            }).ToList(),
                        MaaRmk = data.MaaRmk
                            .Where(r => r.MaaId == g.Key)
                            .Select(r => new
                            {
                                r.TabName,
                                r.RefColName,
                                r.RefColSeqNo,
                                r.Remark
                            }).ToList(),
                        MaaShp = data.MaaShp
                            .Where(s => s.MaaId == g.Key)
                            .Select(s => new
                            {
                                s.PointSeq,
                                s.ShpLatitude,
                                s.ShpLongitude
                            }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Maa.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(maaDict, options));
        }
    }
}