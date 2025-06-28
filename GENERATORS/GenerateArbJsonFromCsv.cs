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
using static FAA_DATA_HANDLER.Models.NASR.CSV.ArbCsvDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateArbJsonFromCsv
    {
        public static void Generate(ArbCsvDataCollection data, string outputDirectory)
        {
            var arbDict = data.ArbBase
                .GroupBy(b => b.LocationId)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        // Common Fields
                        EffDate = g.First().EffDate,
                        LocationId = g.First().LocationId,
                        LocationName = g.First().LocationName,

                        // Base Fields
                        g.First().ComputerId,
                        g.First().IcaoId,
                        g.First().LocationType,
                        g.First().City,
                        g.First().State,
                        g.First().CountryCode,
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
                        g.First().CrossRef,

                        // Segments grouped by PointSeq
                        Seg = data.ArbSeg
                            .Where(s => s.LocationId == g.Key)
                            .GroupBy(s => s.PointSeq)
                            .ToDictionary(
                                segKey => segKey.Key.ToString(),
                                segGroup => segGroup.Select(s => new
                                {
                                    PointSeq = s.PointSeq.ToString(),
                                    s.RecId,
                                    s.Altitude,
                                    s.Type,
                                    s.BndryPtDescrip,
                                    s.NasDescripFlag,
                                    s.SegLatDeg,
                                    s.SegLatMin,
                                    s.SegLatSec,
                                    s.SegLatHemis,
                                    s.SegLatDecimal,
                                    s.SegLongDeg,
                                    s.SegLongMin,
                                    s.SegLongSec,
                                    s.SegLongHemis,
                                    s.SegLongDecimal
                                })
                            )
                    }
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Arb.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(arbDict, options));
        }
    }
}
