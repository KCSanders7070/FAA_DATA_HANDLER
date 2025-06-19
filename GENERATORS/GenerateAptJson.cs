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
using static FAA_DATA_HANDLER.Models.NASR.CSV.AptDataModel;

namespace FAA_DATA_HANDLER.Generators
{
    public static class GenerateAptJson
    {
        public static void Generate(AptDataCollection data, string outputDirectory)
        {
            // Group all base airport records by ArptId, then create a dictionary.
            // Each dictionary key is an airport ID, and the value is an object containing grouped data
            // from various NASR CSV sources for that airport.
            var airportDict = data.AptBase
                .GroupBy(b => b.ArptId)
                .ToDictionary(
                    g => g.Key, // Airport ID
                    g => new    // Aggregated data object per airport
                    {
                        // Extract common fields from the first record in the group.
                        // These are assumed to be the same for all records with the same airport ID.
                        CommonFields = new
                        {
                            g.First().EffDate,
                            g.First().SiteNo,
                            g.First().SiteTypeCode,
                            g.First().StateCode,
                            g.First().ArptId,
                            g.First().City,
                            g.First().CountryCode
                        },

                        // Include the full list of base records for the airport.
                        // This preserves all entries grouped under the same airport ID.
                        Base = g.ToList(),

                        // Get all AptCon records matching the current airport ID.
                        Con = data.AptCon.Where(x => x.ArptId == g.Key).ToList(),

                        // Get all AptArs records for the current airport.
                        // Group by ArsRwyId, then by ArsRwyEndId.
                        // Each final group contains one or more arresting devices with only the device code included.
                        Ars = data.AptArs
                            .Where(x => x.ArptId == g.Key)
                            .GroupBy(x => x.ArsRwyId)
                            .ToDictionary(
                                rg => rg.Key, // Runway ID
                                rg => rg.GroupBy(x => x.ArsRwyEndId)
                                        .ToDictionary(
                                            eg => eg.Key, // Runway end ID
                                            eg => eg.Select(e => new
                                            {
                                                e.ArrestDeviceCode
                                            })
                                        )
                            ),

                        // Get all AptAtt records for the current airport.
                        // Group them by SkedSeqNo to preserve logical groupings (e.g., multiple entries for a time block).
                        // For each group, include the month, day, and hour values defining the attendance period.
                        Att = data.AptAtt
                            .Where(x => x.ArptId == g.Key)
                            .GroupBy(x => x.SkedSeqNo)
                            .ToDictionary(
                                sk => sk.Key,
                                sk => sk.Select(a => new
                                {
                                    a.Month,
                                    a.Day,
                                    a.Hour
                                })
                            ),

                        // Get all AptRmk records for the current airport.
                        // Group them by LegacyElementNumber.
                        // For each group, collect relevant metadata and the actual remark text.
                        Rmk = data.AptRmk
                            .Where(x => x.ArptId == g.Key)
                            .GroupBy(x => x.LegacyElementNumber)
                            .ToDictionary(
                                lk => lk.Key,
                                lk => lk.Select(r => new
                                {
                                    r.TabName,
                                    r.RefColName,
                                    r.Element,
                                    r.RefColSeqNo,
                                    r.Remark
                                })
                            ),

                        // Get all AptRwy records for the current airport.
                        // Group them by RwyRwyId, then for each group, extract physical and structural runway attributes.
                        Rwy = data.AptRwy
                            .Where(x => x.ArptId == g.Key)
                            .GroupBy(x => x.RwyRwyId)
                            .ToDictionary(
                                rk => rk.Key,
                                rk => rk.Select(r => new
                                {
                                    r.RwyLen,
                                    r.RwyWidth,
                                    r.SurfaceTypeCode,
                                    r.Cond,
                                    r.TreatmentCode,
                                    r.Pcn,
                                    r.PavementTypeCode,
                                    r.SubgradeStrengthCode,
                                    r.TirePresCode,
                                    r.DtrmMethodCode,
                                    r.RwyLgtCode,
                                    r.RwyLenSource,
                                    r.LengthSourceDate,
                                    r.GrossWtSw,
                                    r.GrossWtDw,
                                    r.GrossWtDtw,
                                    r.GrossWtDdtw
                                })
                            ),

                        // Get all AptRwyEnd records for the current airport.
                        // Group them first by RwyEndRwyId, then by RwyEndRwyEndId
                        RwyEnd = data.AptRwyEnd
                            .Where(x => x.ArptId == g.Key)
                            .GroupBy(x => x.RwyEndRwyId)
                            .ToDictionary(
                                rk => rk.Key,
                                rk => rk.GroupBy(x => x.RwyEndRwyEndId)
                                        .ToDictionary(
                                            ek => ek.Key,
                                            ek => ek.Select(e => new
                                            {
                                                e.TrueAlignment,
                                                e.IlsType,
                                                e.RightHandTrafficPatFlag,
                                                e.RwyMarkingTypeCode,
                                                e.RwyMarkingCond,
                                                e.RwyEndLatDeg,
                                                e.RwyEndLatMin,
                                                e.RwyEndLatSec,
                                                e.RwyEndLatHemis,
                                                e.RwyEndLatDecimal,
                                                e.RwyEndLongDeg,
                                                e.RwyEndLongMin,
                                                e.RwyEndLongSec,
                                                e.RwyEndLongHemis,
                                                e.RwyEndLongDecimal,
                                                e.RwyEndElev,
                                                e.ThrCrossingHgt,
                                                e.VisualGlidePathAngle,
                                                e.DisplacedThrLatDeg,
                                                e.DisplacedThrLatMin,
                                                e.DisplacedThrLatSec,
                                                e.DisplacedThrLatHemis,
                                                e.LatDisplacedThrDecimal,
                                                e.DisplacedThrLongDeg,
                                                e.DisplacedThrLongMin,
                                                e.DisplacedThrLongSec,
                                                e.DisplacedThrLongHemis,
                                                e.LongDisplacedThrDecimal,
                                                e.DisplacedThrElev,
                                                e.DisplacedThrLen,
                                                e.TdzElev,
                                                e.VgsiCode,
                                                e.RwyVisualRangeEquipCode,
                                                e.RwyVsbyValueEquipFlag,
                                                e.ApchLgtSystemCode,
                                                e.RwyEndLgtsFlag,
                                                e.CntrlnLgtsAvblFlag,
                                                e.TdzLgtAvblFlag,
                                                e.ObstnType,
                                                e.ObstnMrkdCode,
                                                e.FarPart77Code,
                                                e.ObstnClncSlope,
                                                e.ObstnHgt,
                                                e.DistFromThr,
                                                e.CntrlnOffset,
                                                e.CntrlnDirCode,
                                                e.RwyGrad,
                                                e.RwyGradDirection,
                                                e.RwyEndPsnSource,
                                                e.RwyEndPsnDate,
                                                e.RwyEndElevSource,
                                                e.RwyEndElevDate,
                                                e.DsplThrPsnSource,
                                                e.RwyEndDsplThrPsnDate,
                                                e.DsplThrElevSource,
                                                e.RwyEndDsplThrElevDate,
                                                e.TdzElevSource,
                                                e.RwyEndTdzElevDate,
                                                e.TkofRunAvbl,
                                                e.TkofDistAvbl,
                                                e.AcltStopDistAvbl,
                                                e.LndgDistAvbl,
                                                e.LahsoAld,
                                                e.RwyEndIntersectLahso,
                                                e.LahsoDesc,
                                                e.LahsoLat,
                                                e.LatLahsoDecimal,
                                                e.LahsoLong,
                                                e.LongLahsoDecimal,
                                                e.LahsoPsnSource,
                                                e.RwyEndLahsoPsnDate
                                            })
                                        )
                            )
                    }
                );

            // Configure JSON serialization options:
            var options = new JsonSerializerOptions
            {
                // Output JSON in a compact, non-indented format
                WriteIndented = false,

                // Ensure full Unicode character support (e.g., non-ASCII characters)
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),

                // Exclude properties with null values from the output
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull 
            };

            // Serialize the airport dictionary to JSON and write it to the specified output path
            string outputPath = Path.Combine(outputDirectory, "Apt.json");
            File.WriteAllText(outputPath, JsonSerializer.Serialize(airportDict, options));
        }
    }
}
