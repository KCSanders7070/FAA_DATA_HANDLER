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
using static FAA_DATA_HANDLER.Models.NASR.CSV.FrqCsvDataModel;

namespace FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON
{
    public static class GenerateFrqJsonFromCsv
    {
        public static void Generate(FrqCsvDataCollection data, string outputDirectory)
        {
            var frqDict = data.Frq
                .GroupBy(f => f.Facility)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        g.First().EffDate,
                        Frq = g.Select(f => new
                        {
                            f.Facility,
                            f.FacName,
                            f.FacilityType,
                            f.ArtccOrFssId,
                            f.Cpdlc,
                            f.TowerHrs,
                            f.ServicedFacility,
                            f.ServicedFacName,
                            f.ServicedSiteType,
                            f.LatDecimal,
                            f.LongDecimal,
                            f.ServicedCity,
                            f.ServicedState,
                            f.ServicedCountry,
                            f.TowerOrCommCall,
                            f.PrimaryApproachRadioCall,
                            f.Freq,
                            f.Sectorization,
                            f.FreqUse,
                            f.Remark
                        }).ToList()
                    });

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Frq.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(frqDict, options));
        }
    }
}
