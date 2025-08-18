using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FAA_DATA_HANDLER.Models.CIFP;

namespace FAA_DATA_HANDLER.GENERATORS.CIFP_2_JSON
{
    /// <summary>
    /// Writes a single JSON file of airports keyed by AptIcaoIdentifier, sorted by that key.
    /// Only uses <see cref="CifpDataCollections.Airports"/>.
    /// </summary>
    public static class GenerateAirportJsonFromCifp
    {
        /// <param name="outputFilePath">Destination JSON file path.</param>
        /// <param name="cifpDataCollections">Source collections (only Airports is used).</param>
        public static void Write(string outputFilePath, CifpDataCollections cifpDataCollections)
        {
            // SortedDictionary guarantees enumeration order for JSON keys.
            var sorted = new SortedDictionary<string, AirportsCifpDataModel>(StringComparer.Ordinal);

            foreach (var airport in cifpDataCollections.Airports)
            {
                if (airport == null) continue;
                var icao = airport.AptIcaoIdentifier?.Trim();
                if (string.IsNullOrEmpty(icao)) continue;
                sorted[icao] = airport; // Last-wins if duplicates appear.
            }

            var json = JsonSerializer.Serialize(sorted, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(outputFilePath, json);
        }
    }
}
