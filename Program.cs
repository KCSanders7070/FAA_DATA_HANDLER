using FAA_DATA_HANDLER.GENERATORS.NASR_CSV_2_JSON;
using FAA_DATA_HANDLER.Parsers.NASR.CSV;
using System;
using System.IO;

namespace FAA_DATA_HANDLER
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input/output directories
            string userSelectedSourceDirectory = @"C:\Users\ksand\Downloads";
            string userSelectedOutputDirectory = @"C:\Users\ksand\Downloads";

            bool parseAptNasrCsv = false;
            bool parseAtcNasrCsv = false;
            bool parseAwyNasrCsv = false;
            bool parseArbNasrCsv = false;
            bool parseAwosNasrCsv = false;
            bool parseClsArspNasrCsv = false;
            bool parseCdrNasrCsv = false;
            bool parseComNasrCsv = false;
            bool parseDpNasrCsv = false;
            bool parseFixNasrCsv = false;
            bool parseFssNasrCsv = false;
            bool parseFrqNasrCsv = false;
            bool parseHpfNasrCsv = false;
            bool parseIlsNasrCsv = false;
            bool parseLidNasrCsv = false;
            bool parseMilOpsNasrCsv = false;
            bool parseMtrNasrCsv = false;
            bool parseMaaNasrCsv = false;
            bool parseNavNasrCsv = false;
            bool parsePjaNasrCsv = false;
            bool parsePfrNasrCsv = false;
            bool parseRdrNasrCsv = false;
            bool parseStarNasrCsv = false;
            bool parseWxlNasrCsv = false;

            if (parseAptNasrCsv)
            {
                Console.WriteLine("Parsing APT csv files");
                AptCsvParser aptCsvParser = new AptCsvParser();
                AptCsvDataCollection allParsedAptData = new AptCsvDataCollection();
                allParsedAptData.AptArs = aptCsvParser.ParseAptArs(Path.Combine(userSelectedSourceDirectory, "APT_ARS.csv")).AptArs;
                allParsedAptData.AptAtt = aptCsvParser.ParseAptAtt(Path.Combine(userSelectedSourceDirectory, "APT_ATT.csv")).AptAtt;
                allParsedAptData.AptBase = aptCsvParser.ParseAptBase(Path.Combine(userSelectedSourceDirectory, "APT_BASE.csv")).AptBase;
                allParsedAptData.AptCon = aptCsvParser.ParseAptCon(Path.Combine(userSelectedSourceDirectory, "APT_CON.csv")).AptCon;
                allParsedAptData.AptRmk = aptCsvParser.ParseAptRmk(Path.Combine(userSelectedSourceDirectory, "APT_RMK.csv")).AptRmk;
                allParsedAptData.AptRwy = aptCsvParser.ParseAptRwy(Path.Combine(userSelectedSourceDirectory, "APT_RWY.csv")).AptRwy;
                allParsedAptData.AptRwyEnd = aptCsvParser.ParseAptRwyEnd(Path.Combine(userSelectedSourceDirectory, "APT_RWY_END.csv")).AptRwyEnd;

                Console.WriteLine("Generating Apt.json");
                GenerateAptJsonFromCsv.Generate(allParsedAptData, userSelectedOutputDirectory);
                Console.WriteLine("Apt data created.");
            }

            if (parseAtcNasrCsv)
            {
                Console.WriteLine("Parsing Atc csv files");
                AtcCsvParser atcCsvParser = new AtcCsvParser();
                AtcCsvDataCollection allParsedAtcData = new AtcCsvDataCollection();
                allParsedAtcData.AtcAtis = atcCsvParser.ParseAtcAtis(Path.Combine(userSelectedSourceDirectory, "ATC_ATIS.csv")).AtcAtis;
                allParsedAtcData.AtcBase = atcCsvParser.ParseAtcBase(Path.Combine(userSelectedSourceDirectory, "ATC_BASE.csv")).AtcBase;
                allParsedAtcData.AtcRmk = atcCsvParser.ParseAtcRmk(Path.Combine(userSelectedSourceDirectory, "ATC_RMK.csv")).AtcRmk;
                allParsedAtcData.AtcSvc = atcCsvParser.ParseAtcSvc(Path.Combine(userSelectedSourceDirectory, "ATC_SVC.csv")).AtcSvc;

                Console.WriteLine("Generating Atc.json");
                GenerateAtcJsonFromCsv.Generate(allParsedAtcData, userSelectedOutputDirectory);
                Console.WriteLine("Atc data created.");
            }

            if (parseAwyNasrCsv)
            {
                Console.WriteLine("Parsing Awy csv files");
                AwyCsvParser awyCsvParser = new AwyCsvParser();
                AwyCsvDataCollection allParsedAwyData = new AwyCsvDataCollection();
                allParsedAwyData.AwyBase = awyCsvParser.ParseAwyBase(Path.Combine(userSelectedSourceDirectory, "AWY_BASE.csv")).AwyBase;
                allParsedAwyData.AwySegAlt = awyCsvParser.ParseAwySegAlt(Path.Combine(userSelectedSourceDirectory, "AWY_SEG_ALT.csv")).AwySegAlt;

                Console.WriteLine("Generating Awy.json");
                GenerateAwyJsonFromCsv.Generate(allParsedAwyData, userSelectedOutputDirectory);
                Console.WriteLine("Awy data created.");
            }

            if (parseArbNasrCsv)
            {
                Console.WriteLine("Parsing Arb csv files");
                ArbCsvParser arbCsvParser = new ArbCsvParser();
                ArbCsvDataCollection allParsedArbData = new ArbCsvDataCollection();
                allParsedArbData.ArbBase = arbCsvParser.ParseArbBase(Path.Combine(userSelectedSourceDirectory, "ARB_BASE.csv")).ArbBase;
                allParsedArbData.ArbSeg = arbCsvParser.ParseArbSeg(Path.Combine(userSelectedSourceDirectory, "ARB_SEG.csv")).ArbSeg;

                Console.WriteLine("Generating Arb.json");
                GenerateArbJsonFromCsv.Generate(allParsedArbData, userSelectedOutputDirectory);
                Console.WriteLine("Arb data created.");
            }

            if (parseAwosNasrCsv)
            {
                Console.WriteLine("Parsing Awos csv files");
                AwosCsvParser awosCsvParser = new AwosCsvParser();
                AwosCsvDataCollection allParsedAwosData = new AwosCsvDataCollection();
                allParsedAwosData.Awos = awosCsvParser.ParseAwos(Path.Combine(userSelectedSourceDirectory, "AWOS.csv")).Awos;

                Console.WriteLine("Generating Awos.json");
                GenerateAwosJsonFromCsv.Generate(allParsedAwosData, userSelectedOutputDirectory);
                Console.WriteLine("Awos data created.");
            }

            if (parseClsArspNasrCsv)
            {
                Console.WriteLine("Parsing ClsArsp csv files");
                ClsArspCsvParser ClsArspCsvParser = new ClsArspCsvParser();
                ClsArspCsvDataCollection allParsedClsArspData = new ClsArspCsvDataCollection();
                allParsedClsArspData.ClsArsp = ClsArspCsvParser.ParseClsArsp(Path.Combine(userSelectedSourceDirectory, "CLS_ARSP.csv")).ClsArsp;

                Console.WriteLine("Generating ClsArsp.json");
                GenerateClsArspJsonFromCsv.Generate(allParsedClsArspData, userSelectedOutputDirectory);
                Console.WriteLine("ClsArsp data created.");
            }

            if (parseCdrNasrCsv)
            {
                Console.WriteLine("Parsing Cdr csv files");
                CdrCsvParser cdrCsvParser = new CdrCsvParser();
                CdrCsvDataCollection allParsedCdrData = new CdrCsvDataCollection();
                allParsedCdrData.Cdr = cdrCsvParser.ParseCdr(Path.Combine(userSelectedSourceDirectory, "CDR.csv")).Cdr;

                Console.WriteLine("Generating Cdr.json");
                GenerateCdrJsonFromCsv.Generate(allParsedCdrData, userSelectedOutputDirectory);
                Console.WriteLine("Cdr data created.");
            }

            if (parseComNasrCsv)
            {
                Console.WriteLine("Parsing Com csv files");
                ComCsvParser comCsvParser = new ComCsvParser();
                ComCsvDataCollection allParsedComData = new ComCsvDataCollection();
                allParsedComData.Com = comCsvParser.ParseCom(Path.Combine(userSelectedSourceDirectory, "COM.csv")).Com;

                Console.WriteLine("Generating Com.json");
                GenerateComJsonFromCsv.Generate(allParsedComData, userSelectedOutputDirectory);
                Console.WriteLine("Com data created.");
            }

            if (parseDpNasrCsv)
            {
                Console.WriteLine("Parsing Dp csv files");
                DpCsvParser dpCsvParser = new DpCsvParser();
                DpCsvDataCollection allParsedDpData = new DpCsvDataCollection();
                allParsedDpData.DpApt = dpCsvParser.ParseDpApt(Path.Combine(userSelectedSourceDirectory, "DP_APT.csv")).DpApt;
                allParsedDpData.DpBase = dpCsvParser.ParseDpBase(Path.Combine(userSelectedSourceDirectory, "DP_BASE.csv")).DpBase;
                allParsedDpData.DpRte = dpCsvParser.ParseDpRte(Path.Combine(userSelectedSourceDirectory, "DP_RTE.csv")).DpRte;

                Console.WriteLine("Generating Dp.json");
                GenerateDpJsonFromCsv.Generate(allParsedDpData, userSelectedOutputDirectory);
                Console.WriteLine("Dp data created.");
            }

            if (parseFixNasrCsv)
            {
                Console.WriteLine("Parsing Fix csv files");
                FixCsvParser fixCsvParser = new FixCsvParser();
                FixCsvDataCollection allParsedFixData = new FixCsvDataCollection();
                allParsedFixData.FixBase = fixCsvParser.ParseFixBase(Path.Combine(userSelectedSourceDirectory, "FIX_BASE.csv")).FixBase;
                allParsedFixData.FixChrt = fixCsvParser.ParseFixChrt(Path.Combine(userSelectedSourceDirectory, "FIX_CHRT.csv")).FixChrt;
                allParsedFixData.FixNav = fixCsvParser.ParseFixNav(Path.Combine(userSelectedSourceDirectory, "FIX_NAV.csv")).FixNav;

                Console.WriteLine("Generating Fix.json");
                GenerateFixJsonFromCsv.Generate(allParsedFixData, userSelectedOutputDirectory);
                Console.WriteLine("Fix data created.");
            }

            if (parseFssNasrCsv)
            {
                Console.WriteLine("Parsing Fss csv files");
                FssCsvParser fssCsvParser = new FssCsvParser();
                FssCsvDataCollection allParsedFssData = new FssCsvDataCollection();
                allParsedFssData.FssBase = fssCsvParser.ParseFssBase(Path.Combine(userSelectedSourceDirectory, "FSS_BASE.csv")).FssBase;
                allParsedFssData.FssRmk = fssCsvParser.ParseFssRmk(Path.Combine(userSelectedSourceDirectory, "FSS_RMK.csv")).FssRmk;

                Console.WriteLine("Generating Fss.json");
                GenerateFssJsonFromCsv.Generate(allParsedFssData, userSelectedOutputDirectory);
                Console.WriteLine("Fss data created.");
            }

            if (parseFrqNasrCsv)
            {
                Console.WriteLine("Parsing Frq csv files");
                FrqCsvParser frqCsvParser = new FrqCsvParser();
                FrqCsvDataCollection allParsedFrqData = new FrqCsvDataCollection();
                allParsedFrqData.Frq = frqCsvParser.ParseFrq(Path.Combine(userSelectedSourceDirectory, "FRQ.csv")).Frq;

                Console.WriteLine("Generating Frq.json");
                GenerateFrqJsonFromCsv.Generate(allParsedFrqData, userSelectedOutputDirectory);
                Console.WriteLine("Frq data created.");
            }

            if (parseHpfNasrCsv)
            {
                Console.WriteLine("Parsing Hpf csv files");
                HpfCsvParser hpfCsvParser = new HpfCsvParser();
                HpfCsvDataCollection allParsedHpfData = new HpfCsvDataCollection();
                allParsedHpfData.HpfBase = hpfCsvParser.ParseHpfBase(Path.Combine(userSelectedSourceDirectory, "HPF_BASE.csv")).HpfBase;
                allParsedHpfData.HpfChrt = hpfCsvParser.ParseHpfChrt(Path.Combine(userSelectedSourceDirectory, "HPF_CHRT.csv")).HpfChrt;
                allParsedHpfData.HpfRmk = hpfCsvParser.ParseHpfRmk(Path.Combine(userSelectedSourceDirectory, "HPF_RMK.csv")).HpfRmk;
                allParsedHpfData.HpfSpdAlt = hpfCsvParser.ParseHpfSpdAlt(Path.Combine(userSelectedSourceDirectory, "HPF_SPD_ALT.csv")).HpfSpdAlt;

                Console.WriteLine("Generating Hpf.json");
                GenerateHpfJsonFromCsv.Generate(allParsedHpfData, userSelectedOutputDirectory);
                Console.WriteLine("Hpf data created.");
            }

            if (parseIlsNasrCsv)
            {
                Console.WriteLine("Parsing Ils csv files");
                IlsCsvParser ilsCsvParser = new IlsCsvParser();
                IlsCsvDataCollection allParsedIlsData = new IlsCsvDataCollection();
                allParsedIlsData.IlsBase = ilsCsvParser.ParseIlsBase(Path.Combine(userSelectedSourceDirectory, "ILS_BASE.csv")).IlsBase;
                allParsedIlsData.IlsDme = ilsCsvParser.ParseIlsDme(Path.Combine(userSelectedSourceDirectory, "ILS_DME.csv")).IlsDme;
                allParsedIlsData.IlsGs = ilsCsvParser.ParseIlsGs(Path.Combine(userSelectedSourceDirectory, "ILS_GS.csv")).IlsGs;
                allParsedIlsData.IlsMkr = ilsCsvParser.ParseIlsMkr(Path.Combine(userSelectedSourceDirectory, "ILS_MKR.csv")).IlsMkr;
                allParsedIlsData.IlsRmk = ilsCsvParser.ParseIlsRmk(Path.Combine(userSelectedSourceDirectory, "ILS_RMK.csv")).IlsRmk;

                Console.WriteLine("Generating Ils.json");
                GenerateIlsJsonFromCsv.Generate(allParsedIlsData, userSelectedOutputDirectory);
                Console.WriteLine("Ils data created.");
            }

            if (parseLidNasrCsv)
            {
                Console.WriteLine("Parsing Lid csv files");
                LidCsvParser lidCsvParser = new LidCsvParser();
                LidCsvDataCollection allParsedLidData = new LidCsvDataCollection();
                allParsedLidData.Lid = lidCsvParser.ParseLid(Path.Combine(userSelectedSourceDirectory, "LID.csv")).Lid;

                Console.WriteLine("Generating Lid.json");
                GenerateLidJsonFromCsv.Generate(allParsedLidData, userSelectedOutputDirectory);
                Console.WriteLine("Lid data created.");
            }

            if (parseMilOpsNasrCsv)
            {
                Console.WriteLine("Parsing MilOps csv files");
                MilOpsCsvParser milCsvParser = new MilOpsCsvParser();
                MilOpsCsvDataCollection allParsedMilData = new MilOpsCsvDataCollection();
                allParsedMilData.MilOps = milCsvParser.ParseMilOps(Path.Combine(userSelectedSourceDirectory, "MIL_OPS.csv")).MilOps;

                Console.WriteLine("Generating MilOps.json");
                GenerateMilOpsJsonFromCsv.Generate(allParsedMilData, userSelectedOutputDirectory);
                Console.WriteLine("MilOps data created.");
            }

            if (parseMtrNasrCsv)
            {
                Console.WriteLine("Parsing Mtr csv files");
                MtrCsvParser mtrCsvParser = new MtrCsvParser();
                MtrCsvDataCollection allParsedMtrData = new MtrCsvDataCollection();
                allParsedMtrData.MtrAgy = mtrCsvParser.ParseMtrAgy(Path.Combine(userSelectedSourceDirectory, "MTR_AGY.csv")).MtrAgy;
                allParsedMtrData.MtrBase = mtrCsvParser.ParseMtrBase(Path.Combine(userSelectedSourceDirectory, "MTR_BASE.csv")).MtrBase;
                allParsedMtrData.MtrPt = mtrCsvParser.ParseMtrPt(Path.Combine(userSelectedSourceDirectory, "MTR_PT.csv")).MtrPt;
                allParsedMtrData.MtrSop = mtrCsvParser.ParseMtrSop(Path.Combine(userSelectedSourceDirectory, "MTR_SOP.csv")).MtrSop;
                allParsedMtrData.MtrTerr = mtrCsvParser.ParseMtrTerr(Path.Combine(userSelectedSourceDirectory, "MTR_TERR.csv")).MtrTerr;
                allParsedMtrData.MtrWdth = mtrCsvParser.ParseMtrWdth(Path.Combine(userSelectedSourceDirectory, "MTR_WDTH.csv")).MtrWdth;

                Console.WriteLine("Generating Mtr.json");
                GenerateMtrJsonFromCsv.Generate(allParsedMtrData, userSelectedOutputDirectory);
                Console.WriteLine("Mtr data created.");
            }

            if (parseMaaNasrCsv)
            {
                Console.WriteLine("Parsing Maa csv files");
                MaaCsvParser maaCsvParser = new MaaCsvParser();
                MaaCsvDataCollection allParsedMaaData = new MaaCsvDataCollection();
                allParsedMaaData.MaaBase = maaCsvParser.ParseMaaBase(Path.Combine(userSelectedSourceDirectory, "MAA_BASE.csv")).MaaBase;
                allParsedMaaData.MaaCon = maaCsvParser.ParseMaaCon(Path.Combine(userSelectedSourceDirectory, "MAA_CON.csv")).MaaCon;
                allParsedMaaData.MaaRmk = maaCsvParser.ParseMaaRmk(Path.Combine(userSelectedSourceDirectory, "MAA_RMK.csv")).MaaRmk;
                allParsedMaaData.MaaShp = maaCsvParser.ParseMaaShp(Path.Combine(userSelectedSourceDirectory, "MAA_SHP.csv")).MaaShp;

                Console.WriteLine("Generating Maa.json");
                GenerateMaaJsonFromCsv.Generate(allParsedMaaData, userSelectedOutputDirectory);
                Console.WriteLine("Maa data created.");
            }

            if (parseNavNasrCsv)
            {
                Console.WriteLine("Parsing Nav csv files");
                NavCsvParser navCsvParser = new NavCsvParser();
                NavCsvDataCollection allParsedNavData = new NavCsvDataCollection();
                allParsedNavData.NavBase = navCsvParser.ParseNavBase(Path.Combine(userSelectedSourceDirectory, "NAV_BASE.csv")).NavBase;
                allParsedNavData.NavCkpt = navCsvParser.ParseNavCkpt(Path.Combine(userSelectedSourceDirectory, "NAV_CKPT.csv")).NavCkpt;
                allParsedNavData.NavRmk = navCsvParser.ParseNavRmk(Path.Combine(userSelectedSourceDirectory, "NAV_RMK.csv")).NavRmk;

                Console.WriteLine("Generating Nav.json");
                GenerateNavJsonFromCsv.Generate(allParsedNavData, userSelectedOutputDirectory);
                Console.WriteLine("Nav data created.");
            }

            if (parsePjaNasrCsv)
            {
                Console.WriteLine("Parsing Pja csv files");
                PjaCsvParser pjaCsvParser = new PjaCsvParser();
                PjaCsvDataCollection allParsedPjaData = new PjaCsvDataCollection();
                allParsedPjaData.PjaBase = pjaCsvParser.ParsePjaBase(Path.Combine(userSelectedSourceDirectory, "PJA_BASE.csv")).PjaBase;
                allParsedPjaData.PjaCon = pjaCsvParser.ParsePjaCon(Path.Combine(userSelectedSourceDirectory, "PJA_CON.csv")).PjaCon;

                Console.WriteLine("Generating Pja.json");
                GeneratePjaJsonFromCsv.Generate(allParsedPjaData, userSelectedOutputDirectory);
                Console.WriteLine("Pja data created.");
            }

            if (parsePfrNasrCsv)
            {
                Console.WriteLine("Parsing Pfr csv files");
                PfrCsvParser pfrCsvParser = new PfrCsvParser();
                PfrCsvDataCollection allParsedPfrData = new PfrCsvDataCollection();
                allParsedPfrData.PfrBase = pfrCsvParser.ParsePfrBase(Path.Combine(userSelectedSourceDirectory, "PFR_BASE.csv")).PfrBase;
                allParsedPfrData.PfrRmtFmt = pfrCsvParser.ParsePfrRmtFmt(Path.Combine(userSelectedSourceDirectory, "PFR_RMT_FMT.csv")).PfrRmtFmt;
                allParsedPfrData.PfrSeg = pfrCsvParser.ParsePfrSeg(Path.Combine(userSelectedSourceDirectory, "PFR_SEG.csv")).PfrSeg;

                Console.WriteLine("Generating Pfr.json");
                GeneratePfrJsonFromCsv.Generate(allParsedPfrData, userSelectedOutputDirectory);
                Console.WriteLine("Pfr data created.");
            }

            if (parseRdrNasrCsv)
            {
                Console.WriteLine("Parsing Rdr csv files");
                RdrCsvParser rdrCsvParser = new RdrCsvParser();
                RdrCsvDataCollection allParsedRdrData = new RdrCsvDataCollection();
                allParsedRdrData.Rdr = rdrCsvParser.ParseRdr(Path.Combine(userSelectedSourceDirectory, "RDR.csv")).Rdr;

                Console.WriteLine("Generating Rdr.json");
                GenerateRdrJsonFromCsv.Generate(allParsedRdrData, userSelectedOutputDirectory);
                Console.WriteLine("Rdr data created.");
            }

            if (parseStarNasrCsv)
            {
                Console.WriteLine("Parsing Star csv files");
                StarCsvParser starCsvParser = new StarCsvParser();
                StarCsvDataCollection allParsedStarData = new StarCsvDataCollection();
                allParsedStarData.StarApt = starCsvParser.ParseStarApt(Path.Combine(userSelectedSourceDirectory, "STAR_APT.csv")).StarApt;
                allParsedStarData.StarBase = starCsvParser.ParseStarBase(Path.Combine(userSelectedSourceDirectory, "STAR_BASE.csv")).StarBase;
                allParsedStarData.StarRte = starCsvParser.ParseStarRte(Path.Combine(userSelectedSourceDirectory, "STAR_RTE.csv")).StarRte;

                Console.WriteLine("Generating Star.json");
                GenerateStarJsonFromCsv.Generate(allParsedStarData, userSelectedOutputDirectory);
                Console.WriteLine("Star data created.");
            }

            if (parseWxlNasrCsv)
            {
                Console.WriteLine("Parsing Wxl csv files");
                WxlCsvParser wxlCsvParser = new WxlCsvParser();
                WxlCsvDataCollection allParsedWxlData = new WxlCsvDataCollection();
                allParsedWxlData.WxlBase = wxlCsvParser.ParseWxlBase(Path.Combine(userSelectedSourceDirectory, "WXL_BASE.csv")).WxlBase;
                allParsedWxlData.WxlSvc = wxlCsvParser.ParseWxlSvc(Path.Combine(userSelectedSourceDirectory, "WXL_SVC.csv")).WxlSvc;

                Console.WriteLine("Generating Wxl.json");
                GenerateWxlJsonFromCsv.Generate(allParsedWxlData, userSelectedOutputDirectory);
                Console.WriteLine("Wxl data created.");
            }
        }
    }
}
