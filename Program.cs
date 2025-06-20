using CsvHelper;
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
            string userSelectedSourceDirectory = @"C:\Users\ksand\OneDrive\Desktop\ProjFolder\FAA DATA HANDLER\NASR\12_Jun_2025_ATC_CSV";
            string userSelectedOutputDirectory = @"C:\Users\ksand\Downloads";

            bool parseApt = false;
            bool parseAtc = true;
            bool parseAwy = false;
            bool parseArb = false;
            bool parseAwos = false;
            bool parseClsArsp = false;
            bool parseCdr = false;
            bool parseCom = false;
            bool parseDp = false;
            bool parseFix = false;
            bool parseFss = false;
            bool parseFrq = false;
            bool parseHpf = false;
            bool parseIls = false;
            bool parseLid = false;
            bool parseMilOps = false;
            bool parseMtr = false;
            bool parseMaa = false;
            bool parseNav = false;
            bool parsePja = false;
            bool parsePfr = false;
            bool parseRdr = false;
            bool parseStar = false;
            bool parseWxl = false;

            // DOMAIN: APT
            if (parseApt)
            {
                Console.WriteLine("Parsing APT csv files");
                AptCsvParser aptCsvParser = new AptCsvParser();
                AptDataCollection allParsedAptData = new AptDataCollection();
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
            }

            // DOMAIN: ATC
            if (parseAtc)
            {
                Console.WriteLine("Parsing Atc csv files");
                AtcCsvParser atcCsvParser = new AtcCsvParser();
                AtcDataCollection allParsedAtcData = new AtcDataCollection();
                allParsedAtcData.AtcAtis = atcCsvParser.ParseAtcAtis(Path.Combine(userSelectedSourceDirectory, "ATC_ATIS.csv")).AtcAtis;
                allParsedAtcData.AtcBase = atcCsvParser.ParseAtcBase(Path.Combine(userSelectedSourceDirectory, "ATC_BASE.csv")).AtcBase;
                allParsedAtcData.AtcRmk = atcCsvParser.ParseAtcRmk(Path.Combine(userSelectedSourceDirectory, "ATC_RMK.csv")).AtcRmk;
                allParsedAtcData.AtcSvc = atcCsvParser.ParseAtcSvc(Path.Combine(userSelectedSourceDirectory, "ATC_SVC.csv")).AtcSvc;

                Console.WriteLine("Generating Atc.json");
                GenerateAtcJson.Generate(allParsedAtcData, userSelectedOutputDirectory);
                Console.WriteLine("Atc data created.");
            }

            // DOMAIN: AWY
            if (parseAwy)
            {
            }

            // DOMAIN: ARB
            if (parseArb)
            {
            }

            // DOMAIN: AWOS
            if (parseAwos)
            {
            }

            // DOMAIN: CLS_ARSP
            if (parseClsArsp)
            {
            }

            // DOMAIN: CDR
            if (parseCdr)
            {
            }

            // DOMAIN: COM
            if (parseCom)
            {
            }

            // DOMAIN: DP
            if (parseDp)
            {
            }

            // DOMAIN: FIX
            if (parseFix)
            {
            }

            // DOMAIN: FSS
            if (parseFss)
            {
            }

            // DOMAIN: FRQ
            if (parseFrq)
            {
            }

            // DOMAIN: HPF
            if (parseHpf)
            {
            }

            // DOMAIN: ILS
            if (parseIls)
            {
            }

            // DOMAIN: LID
            if (parseLid)
            {
            }

            // DOMAIN: MIL_OPS
            if (parseMilOps)
            {
            }

            // DOMAIN: MTR
            if (parseMtr)
            {
            }

            // DOMAIN: MAA
            if (parseMaa)
            {
            }

            // DOMAIN: NAV
            if (parseNav)
            {
            }

            // DOMAIN: PJA
            if (parsePja)
            {
            }

            // DOMAIN: PFR
            if (parsePfr)
            {
            }

            // DOMAIN: RDR
            if (parseRdr)
            {
            }

            // DOMAIN: STAR
            if (parseStar)
            {
            }

            // DOMAIN: WXL
            if (parseWxl)
            {
            }
        }
    }
}
