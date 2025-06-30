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
using static FAA_DATA_HANDLER.Models.NASR.CSV.AtcCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateAtcJsonFromCsv
    {
        public static void Generate(AtcCsvDataCollection data, string outputDirectory)
        {
            var atcDict = data.AtcBase
                .GroupBy(b => b.FacilityId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().SiteNo,
                            g.First().SiteTypeCode,
                            g.First().FacilityType,
                            g.First().StateCode,
                            g.First().FacilityId,
                            g.First().City,
                            g.First().CountryCode
                        },

                        AtcAtis = data.AtcAtis
                            .Where(x => x.FacilityId == g.Key)
                            .GroupBy(x => x.AtisNo)
                            .ToDictionary(
                                atisKey => atisKey.Key.ToString(),
                                atisGroup => atisGroup.Select(a => new
                                {
                                    AtisNo = a.AtisNo.ToString(),
                                    a.Description,
                                    a.AtisHrs,
                                    a.AtisPhoneNo
                                })
                            ),

                        AtcBase = g.Select(b => new
                        {
                            b.IcaoId,
                            b.FacilityName,
                            b.RegionCode,
                            b.TwrOperatorCode,
                            b.TwrCall,
                            b.TwrHrs,
                            b.PrimaryApchRadioCall,
                            b.ApchPProvider,
                            b.ApchPProvTypeCd,
                            b.SecondaryApchRadioCall,
                            b.ApchSProvider,
                            b.ApchSProvTypeCd,
                            b.PrimaryDepRadioCall,
                            b.DepPProvider,
                            b.DepPProvTypeCd,
                            b.SecondaryDepRadioCall,
                            b.DepSProvider,
                            b.DepSProvTypeCd,
                            b.CtlFacApchDepCalls,
                            b.ApchDepOperCode,
                            b.CtlPrvdingHrs,
                            b.SecondaryCtlPrvdingHrs
                        }).ToList(),

                        AtcRmk = data.AtcRmk
                            .Where(x => x.FacilityId == g.Key)
                            .GroupBy(x => x.RemarkNo)
                            .ToDictionary(
                                rmkKey => rmkKey.Key.ToString(),
                                rmkGroup => rmkGroup.Select(r => new
                                {
                                    RemarkNo = r.RemarkNo.ToString(),
                                    r.LegacyElementNumber,
                                    r.TabName,
                                    r.RefColName,
                                    r.Remark
                                })
                            ),

                        AtcSvc = data.AtcSvc
                            .Where(x => x.FacilityId == g.Key)
                            .Select(s => new
                            {
                                s.CtlSvc
                            }).ToList()
                    }
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Atc.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(atcDict, options));
        }
    }
}
