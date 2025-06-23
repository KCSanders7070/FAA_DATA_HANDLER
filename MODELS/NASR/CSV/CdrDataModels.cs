namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class CdrDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All Cdr_*.csv files(RCODE)
            /// _MaxLength: 8
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Rcode { get; set; }

        }
        #endregion

        #region Cdr Fields
        public class Cdr : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(ORIG)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Orig { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(DEST)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Dest { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(DEPFIX)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Depfix { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(ROUTE STRING)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RouteString { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(DCNTR)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Dcntr { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(ACNTR)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Acntr { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(TCNTRS)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Tcntrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(COORDREQ)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Coordreq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(PLAY)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Play { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(NAVEQP)
            /// _MaxLength: (1,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int Naveqp { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CDR.csv(LENGTH)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? Length { get; set; }

        }
        #endregion

    }
}