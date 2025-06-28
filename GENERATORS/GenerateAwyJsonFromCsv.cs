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
using static FAA_DATA_HANDLER.Models.NASR.CSV.AwyCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateAwyJsonFromCsv
    {
        public static void Generate(AwyDataCollection data, string outputDirectory)
        {
            var awyDict = data.AwyBase
                .GroupBy(b => b.AwyId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        // Base Fields
                        EffDate = g.First().EffDate,
                        g.First().Regulatory,
                        g.First().AwyLocation,
                        g.First().AwyId,
                        g.First().AwyDesignation,
                        g.First().UpdateDate,
                        g.First().BaseRemark,
                        g.First().AirwayString,

                        SegAlt = data.AwySegAlt
                            .Where(s => s.AwyId == g.Key)
                            .GroupBy(s => s.PointSeq)
                            .ToDictionary(
                                segKey => segKey.Key.ToString(),
                                segGroup => segGroup.Select(s => new
                                {
                                    PointSeq = s.PointSeq.ToString(),
                                    s.FromPoint,
                                    s.FromPtType,
                                    s.NavName,
                                    s.NavCity,
                                    s.Artcc,
                                    s.IcaoRegionCode,
                                    s.StateCode,
                                    s.CountryCode,
                                    s.ToPoint,
                                    s.MagCourse,
                                    s.OppMagCourse,
                                    s.MagCourseDist,
                                    s.ChgovrPt,
                                    s.ChgovrPtName,
                                    s.ChgovrPtDist,
                                    s.AwySegGapFlag,
                                    s.SignalGapFlag,
                                    s.Dogleg,
                                    s.NextMeaPt,
                                    s.MinEnrouteAlt,
                                    s.MinEnrouteAltDir,
                                    s.MinEnrouteAltOpposite,
                                    s.MinEnrouteAltOppositeDir,
                                    s.GpsMinEnrouteAlt,
                                    s.GpsMinEnrouteAltDir,
                                    s.GpsMinEnrouteAltOpposite,
                                    s.GpsMeaOppositeDir,
                                    s.DdIruMea,
                                    s.DdIruMeaDir,
                                    s.DdIMeaOpposite,
                                    s.DdIMeaOppositeDir,
                                    s.MinObstnClncAlt,
                                    s.MinCrossAlt,
                                    s.MinCrossAltDir,
                                    s.MinCrossAltNavPt,
                                    s.MinCrossAltOpposite,
                                    s.MinCrossAltOppositeDir,
                                    s.MinRecepAlt,
                                    s.MaxAuthAlt,
                                    s.MeaGap,
                                    s.ReqdNavPerformance,
                                    s.SegAltRemark
                                })
                            )
                    }
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Awy.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(awyDict, options));
        }
    }
}
