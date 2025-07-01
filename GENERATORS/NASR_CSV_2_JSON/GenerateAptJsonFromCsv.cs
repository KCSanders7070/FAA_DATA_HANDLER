using FAA_DATA_HANDLER.Models.NASR.CSV;
using FAA_DATA_HANDLER.Parsers.NASR.CSV;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static FAA_DATA_HANDLER.Models.NASR.CSV.AptCsvDataModel;

public static class GenerateAptJsonFromCsv
{
    public static void Generate(AptCsvDataCollection data, string outputDirectory)
    {
        string outputPath = Path.Combine(outputDirectory, "Apt.json");
        var options = new JsonWriterOptions
        {
            Indented = false,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        // Group datasets once to avoid redundant filtering
        var arsByAirport = data.AptArs.GroupBy(x => x.ArptId).ToDictionary(g => g.Key);
        var attByAirport = data.AptAtt.GroupBy(x => x.ArptId).ToDictionary(g => g.Key);
        var conByAirport = data.AptCon.GroupBy(x => x.ArptId).ToDictionary(g => g.Key);
        var rmkByAirport = data.AptRmk.GroupBy(x => x.ArptId).ToDictionary(g => g.Key);
        var rwyByAirport = data.AptRwy.GroupBy(x => x.ArptId).ToDictionary(g => g.Key);
        var rwyEndByAirport = data.AptRwyEnd.GroupBy(x => x.ArptId).ToDictionary(g => g.Key);

        using FileStream fs = File.Create(outputPath);
        using Utf8JsonWriter writer = new Utf8JsonWriter(fs, options);

        writer.WriteStartObject(); // Start of root JSON object

        foreach (var g in data.AptBase.GroupBy(b => b.ArptId))
        {
            string airportId = g.Key;
            writer.WritePropertyName(airportId);
            writer.WriteStartObject();

            // Common fields
            var first = g.First();
            writer.WritePropertyName("CommonFields");
            writer.WriteStartObject();
            writer.WriteString("EffDate", first.EffDate);
            writer.WriteString("SiteNo", first.SiteNo);
            writer.WriteString("SiteTypeCode", first.SiteTypeCode);
            writer.WriteString("StateCode", first.StateCode);
            writer.WriteString("ArptId", first.ArptId);
            writer.WriteString("City", first.City);
            writer.WriteString("CountryCode", first.CountryCode);
            writer.WriteEndObject();

            // Base
            writer.WritePropertyName("Base");
            JsonSerializer.Serialize(writer, g.ToList());

            // Con
            writer.WritePropertyName("Con");
            JsonSerializer.Serialize(writer, conByAirport.TryGetValue(airportId, out var cons) ? cons.ToList() : new List<AptCon>());

            // Ars
            writer.WritePropertyName("Ars");
            if (arsByAirport.TryGetValue(airportId, out var arsGroup))
            {
                writer.WriteStartObject();
                foreach (var rwyGroup_other in arsGroup.GroupBy(x => x.ArsRwyId))
                {
                    writer.WritePropertyName(rwyGroup_other.Key);
                    writer.WriteStartObject();
                    foreach (var endGroup in rwyGroup_other.GroupBy(x => x.ArsRwyEndId))
                    {
                        writer.WritePropertyName(endGroup.Key);
                        JsonSerializer.Serialize(writer, endGroup.Select(e => new { e.ArrestDeviceCode }));
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject(); writer.WriteEndObject();
            }

            // Att
            writer.WritePropertyName("Att");
            if (attByAirport.TryGetValue(airportId, out var attGroup))
            {
                writer.WriteStartObject();
                foreach (var skedGroup in attGroup.GroupBy(x => x.SkedSeqNo))
                {
                    writer.WritePropertyName(skedGroup.Key.ToString());
                    JsonSerializer.Serialize(writer, skedGroup.Select(a => new { a.Month, a.Day, a.Hour }));
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject(); writer.WriteEndObject();
            }

            // Rmk
            writer.WritePropertyName("Rmk");
            if (rmkByAirport.TryGetValue(airportId, out var rmkGroup))
            {
                writer.WriteStartObject();
                foreach (var rmk in rmkGroup.GroupBy(x => x.LegacyElementNumber))
                {
                    writer.WritePropertyName(rmk.Key);
                    JsonSerializer.Serialize(writer, rmk.Select(r => new {
                        r.TabName,
                        r.RefColName,
                        r.Element,
                        r.RefColSeqNo,
                        r.Remark
                    }));
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject(); writer.WriteEndObject();
            }

            // Rwy
            writer.WritePropertyName("Rwy");
            if (rwyByAirport.TryGetValue(airportId, out var rwyGroup))
            {
                writer.WriteStartObject();
                foreach (var rwy in rwyGroup.GroupBy(x => x.RwyRwyId))
                {
                    writer.WritePropertyName(rwy.Key);
                    JsonSerializer.Serialize(writer, rwy.Select(r => new {
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
                    }));
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject(); writer.WriteEndObject();
            }

            // RwyEnd
            writer.WritePropertyName("RwyEnd");
            if (rwyEndByAirport.TryGetValue(airportId, out var rwyEndGroup))
            {
                writer.WriteStartObject();
                foreach (var rwyEnd in rwyEndGroup.GroupBy(x => x.RwyEndRwyId))
                {
                    writer.WritePropertyName(rwyEnd.Key);
                    writer.WriteStartObject();
                    foreach (var end in rwyEnd.GroupBy(x => x.RwyEndRwyEndId))
                    {
                        writer.WritePropertyName(end.Key);
                        JsonSerializer.Serialize(writer, end.Select(e => new {
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
                        }));
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject(); writer.WriteEndObject();
            }

            writer.WriteEndObject(); // End airport object
        }

        writer.WriteEndObject(); // End root object
        writer.Flush();
    }
}
