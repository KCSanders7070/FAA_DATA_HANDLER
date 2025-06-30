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
using static FAA_DATA_HANDLER.Models.NASR.CSV.NavCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateNavJsonFromCsv
    {
        public static void Generate(NavCsvDataCollection data, string outputDirectory)
        {
            var navDict = data.NavBase
                .GroupBy(n => n.NavId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            NavId = g.First().NavId,
                            NavType = g.First().NavType,
                            StateCode = g.First().StateCode,
                            City = g.First().City,
                            CountryCode = g.First().CountryCode
                        },
                        NavBase = g.Select(n => new
                        {
                            n.NavStatus,
                            n.Name,
                            n.StateName,
                            n.RegionCode,
                            n.CountryName,
                            n.FanMarker,
                            n.Owner,
                            n.Operator,
                            n.NasUseFlag,
                            n.PublicUseFlag,
                            n.NdbClassCode,
                            n.OperHours,
                            n.HighAltArtccId,
                            n.HighArtccName,
                            n.LowAltArtccId,
                            n.LowArtccName,
                            n.LatDeg,
                            n.LatMin,
                            n.LatSec,
                            n.LatHemis,
                            n.LatDecimal,
                            n.LongDeg,
                            n.LongMin,
                            n.LongSec,
                            n.LongHemis,
                            n.LongDecimal,
                            n.SurveyAccuracyCode,
                            n.TacanDmeStatus,
                            n.TacanDmeLatDeg,
                            n.TacanDmeLatMin,
                            n.TacanDmeLatSec,
                            n.TacanDmeLatHemis,
                            n.TacanDmeLatDecimal,
                            n.TacanDmeLongDeg,
                            n.TacanDmeLongMin,
                            n.TacanDmeLongSec,
                            n.TacanDmeLongHemis,
                            n.TacanDmeLongDecimal,
                            n.Elev,
                            n.MagVarn,
                            n.MagVarnHemis,
                            n.MagVarnYear,
                            n.SimulVoiceFlag,
                            n.PwrOutput,
                            n.AutoVoiceIdFlag,
                            n.MntCatCode,
                            n.VoiceCall,
                            n.Chan,
                            n.Freq,
                            n.MkrIdent,
                            n.MkrShape,
                            n.MkrBrg,
                            n.AltCode,
                            n.DmeSsv,
                            n.LowNavOnHighChartFlag,
                            n.ZMkrFlag,
                            n.FssId,
                            n.FssName,
                            n.FssHours,
                            n.NotamId,
                            n.QuadIdent,
                            n.PitchFlag,
                            n.CatchFlag,
                            n.SuaAtcaaFlag,
                            n.RestrictionFlag,
                            n.HiwasFlag
                        }).ToList(),
                        NavCkpt = data.NavCkpt
                            .Where(c => c.NavId == g.Key)
                            .Select(c => new
                            {
                                c.Altitude,
                                c.Brg,
                                c.AirGndCode,
                                c.ChkDesc,
                                c.ArptId,
                                c.StateChkCode
                            }).ToList(),
                        NavRmk = data.NavRmk
                            .Where(r => r.NavId == g.Key)
                            .Select(r => new
                            {
                                r.TabName,
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

            string outputPath = Path.Combine(outputDirectory, "Nav.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(navDict, options));
        }
    }
}
