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
using static FAA_DATA_HANDLER.Models.NASR.CSV.IlsCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateIlsJsonFromCsv
    {
        public static void Generate(IlsCsvDataCollection data, string outputDirectory)
        {
            var ilsDict = data.IlsBase
                .GroupBy(i => i.SiteNo)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            EffDate = g.First().EffDate,
                            SiteNo = g.First().SiteNo,
                            SiteTypeCode = g.First().SiteTypeCode,
                            StateCode = g.First().StateCode,
                            ArptId = g.First().ArptId,
                            City = g.First().City,
                            CountryCode = g.First().CountryCode,
                            RwyEndId = g.First().RwyEndId,
                            IlsLocId = g.First().IlsLocId,
                            SystemTypeCode = g.First().SystemTypeCode
                        },
                        IlsBase = new
                        {
                            g.First().StateName,
                            g.First().RegionCode,
                            g.First().RwyLen,
                            g.First().RwyWidth,
                            g.First().Category,
                            g.First().Owner,
                            g.First().Operator,
                            g.First().ApchBear,
                            g.First().MagVar,
                            g.First().MagVarHemis,
                            g.First().BaseComponentStatus,
                            g.First().BaseComponentStatusDate,
                            g.First().BaseLatDeg,
                            g.First().BaseLatMin,
                            g.First().BaseLatSec,
                            g.First().BaseLatHemis,
                            g.First().BaseLatDecimal,
                            g.First().BaseLongDeg,
                            g.First().BaseLongMin,
                            g.First().BaseLongSec,
                            g.First().BaseLongHemis,
                            g.First().BaseLongDecimal,
                            g.First().BaseLatLongSourceCode,
                            g.First().BaseSiteElevation,
                            g.First().LocFreq,
                            g.First().BkCourseStatusCode
                        },
                        IlsDme = data.IlsDme
                            .Where(d => d.SiteNo == g.Key)
                            .Select(d => new
                            {
                                d.DmeComponentStatus,
                                d.DmeComponentStatusDate,
                                d.DmeLatDeg,
                                d.DmeLatMin,
                                d.DmeLatSec,
                                d.DmeLatHemis,
                                d.DmeLatDecimal,
                                d.DmeLongDeg,
                                d.DmeLongMin,
                                d.DmeLongSec,
                                d.DmeLongHemis,
                                d.DmeLongDecimal,
                                d.DmeLatLongSourceCode,
                                d.DmeSiteElevation,
                                d.Channel
                            }).ToList(),
                        IlsGs = data.IlsGs
                            .Where(gs => gs.SiteNo == g.Key)
                            .Select(gs => new
                            {
                                gs.GsComponentStatus,
                                gs.GsComponentStatusDate,
                                gs.GsLatDeg,
                                gs.GsLatMin,
                                gs.GsLatSec,
                                gs.GsLatHemis,
                                gs.GsLatDecimal,
                                gs.GsLongDeg,
                                gs.GsLongMin,
                                gs.GsLongSec,
                                gs.GsLongHemis,
                                gs.GsLongDecimal,
                                gs.GsLatLongSourceCode,
                                gs.GsSiteElevation,
                                gs.GSTypeCode,
                                gs.GSAngle,
                                gs.GSFreq
                            }).ToList(),
                        IlsMkr = data.IlsMkr
                            .Where(m => m.SiteNo == g.Key)
                            .Select(m => new
                            {
                                m.MkrIlsCompTypeCode,
                                m.MkrComponentStatus,
                                m.MkrComponentStatusDate,
                                m.MkrLatDeg,
                                m.MkrLatMin,
                                m.MkrLatSec,
                                m.MkrLatHemis,
                                m.MkrLatDecimal,
                                m.MkrLongDeg,
                                m.MkrLongMin,
                                m.MkrLongSec,
                                m.MkrLongHemis,
                                m.MkrLongDecimal,
                                m.MkrLatLongSourceCode,
                                m.MkrSiteElevation,
                                m.MkrFacTypeCode,
                                m.MarkerIdBeacon,
                                m.CompassLocatorName,
                                m.Freq,
                                m.NavId,
                                m.NavType,
                                m.LowPoweredNdbStatus
                            }).ToList(),
                        IlsRmk = data.IlsRmk
                            .Where(r => r.SiteNo == g.Key)
                            .Select(r => new
                            {
                                r.TabName,
                                r.RmkIlsCompTypeCode,
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

            string outputPath = Path.Combine(outputDirectory, "Ils.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(ilsDict, options));
        }
    }
}
