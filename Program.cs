using FAA_DATA_HANDLER.Generators;
using FAA_DATA_HANDLER.Models.NASR.CSV;
using FAA_DATA_HANDLER.Parsers.NASR.CSV;
using System;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.AptDataModel;
using static FAA_DATA_HANDLER.Models.NASR.CSV.AtcDataModel;

namespace FAA_DATA_HANDLER
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input/output directories
            string userSelectedSourceDirectory = @"C:\Users\ksand\OneDrive\Desktop\ProjFolder\FAA DATA HANDLER\NASR\26_Dec_2024_APT_CSV";
            string userSelectedOutputDirectory = @"C:\Users\ksand\Downloads";

            // DOMAIN: APT
            AptCsvParser aptCsvParser = new AptCsvParser();
            AptDataCollection allParsedAptData = new AptDataCollection();
            Console.WriteLine("Parsing csv files");
            allParsedAptData.AptArs = aptCsvParser.ParseAptArs(Path.Combine(userSelectedSourceDirectory, "APT_ARS.csv")).AptArs;
            allParsedAptData.AptAtt = aptCsvParser.ParseAptAtt(Path.Combine(userSelectedSourceDirectory, "APT_ATT.csv")).AptAtt;
            allParsedAptData.AptBase = aptCsvParser.ParseAptBase(Path.Combine(userSelectedSourceDirectory, "APT_BASE.csv")).AptBase;
            allParsedAptData.AptCon = aptCsvParser.ParseAptCon(Path.Combine(userSelectedSourceDirectory, "APT_CON.csv")).AptCon;
            allParsedAptData.AptRmk = aptCsvParser.ParseAptRmk(Path.Combine(userSelectedSourceDirectory, "APT_RMK.csv")).AptRmk;
            allParsedAptData.AptRwy = aptCsvParser.ParseAptRwy(Path.Combine(userSelectedSourceDirectory, "APT_RWY.csv")).AptRwy;
            allParsedAptData.AptRwyEnd = aptCsvParser.ParseAptRwyEnd(Path.Combine(userSelectedSourceDirectory, "APT_RWY_END.csv")).AptRwyEnd;
            Console.WriteLine("Generating Apt.json");
            GenerateAptJson.Generate(allParsedAptData, userSelectedOutputDirectory);
            Console.WriteLine("Apt data created.");

            // DOMAIN: ATC
            AtcCsvParser atcCsvParser = new AtcCsvParser();
            AtcDataCollection allParsedAtcData = new AtcDataCollection();
            allParsedAtcData.AtcAtis = atcCsvParser.ParseAtcAtis(Path.Combine(userSelectedSourceDirectory, "ATC_ATIS.csv")).AtcAtis;
            allParsedAtcData.AtcBase = atcCsvParser.ParseAtcBase(Path.Combine(userSelectedSourceDirectory, "ATC_BASE.csv")).AtcBase;
            allParsedAtcData.AtcRmk = atcCsvParser.ParseAtcRmk(Path.Combine(userSelectedSourceDirectory, "ATC_RMK.csv")).AtcRmk;
            allParsedAtcData.AtcSvc = atcCsvParser.ParseAtcSvc(Path.Combine(userSelectedSourceDirectory, "ATC_SVC.csv")).AtcSvc;
            // todo: create GenerateAtcJson
            // GenerateAtcJson.Generate(allParsedAtcData, userSelectedOutputDirectory);
            Console.WriteLine("Atc data created.");


            // Console.ReadKey();
        }
    }
}
