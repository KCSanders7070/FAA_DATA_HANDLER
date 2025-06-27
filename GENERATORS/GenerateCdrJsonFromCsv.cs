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
using static FAA_DATA_HANDLER.Models.NASR.CSV.CdrDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateCdrJsonFromCsv
    {
        public static void Generate(CdrDataCollection data, string outputDirectory)
        {
            var cdrDict = data.Cdr
                .GroupBy(x => x.Rcode)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => new
                    {
                        x.Rcode,
                        x.Orig,
                        x.Dest,
                        x.Depfix,
                        x.RouteString,
                        x.Dcntr,
                        x.Acntr,
                        x.Tcntrs,
                        x.Coordreq,
                        x.Play,
                        x.Naveqp,
                        x.Length
                    }).First() // Each Rcode expected to have a single record
                );

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            string outputPath = Path.Combine(outputDirectory, "Cdr.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(cdrDict, options));
        }
    }
}
