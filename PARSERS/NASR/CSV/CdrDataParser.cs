using FAA_DATA_HANDLER.Models.NASR.CSV;
using System;
using System.Collections.Generic;
using System.IO;
using static FAA_DATA_HANDLER.Models.NASR.CSV.CdrDataModel;

namespace FAA_DATA_HANDLER.Parsers.NASR.CSV
{
    public class CdrCsvParser
    {
        public CdrDataCollection ParseCdr(string filePath)
        {
            var result = new CdrDataCollection();

            result.Cdr = FebCsvHelper.ProcessLines(
                filePath,
                fields => new Cdr
                {
                    Rcode = fields["RCode"],
                    Orig = fields["Orig"],
                    Dest = fields["Dest"],
                    Depfix = fields["DepFix"],
                    Route string = fields["Route String"],
                    Dcntr = fields["DCNTR"],
                    Acntr = fields["ACNTR"],
                    Tcntrs = fields["TCNTRs"],
                    Coordreq = fields["CoordReq"],
                    Play = fields["Play"],
                    Naveqp = FebCsvHelper.ParseInt(fields["NavEqp"]),
                    Length = FebCsvHelper.ParseNullableInt(fields["Length"]),
                });

            return result;
        }

    }

    public class CdrDataCollection
    {
        public List<Cdr> Cdr { get; set; } = new();
    }
}