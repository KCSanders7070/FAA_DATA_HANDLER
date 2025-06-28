namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class PfrCsvDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// Effective Date
            /// _Src: All Apt_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>The 28 Day NASR Subscription Effective Date in format ‘YYYY/MM/DD’.</remarks>
            public string EffDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Pfr_*.csv files(ORIGIN_ID)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string OriginId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Pfr_*.csv files(DSTN_ID)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string DstnId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Pfr_*.csv files(PFR_TYPE_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string PfrTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Pfr_*.csv files(ROUTE_NO)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RouteNo { get; set; }

        }
        #endregion

        #region Pfr_BASE Fields
        public class PfrBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(ORIGIN_CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? OriginCity { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(ORIGIN_STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? OriginStateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(ORIGIN_COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string OriginCountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(DSTN_CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DstnCity { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(DSTN_STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DstnStateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(DSTN_COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string DstnCountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(SPECIAL_AREA_DESCRIP)
            /// _MaxLength: 75
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SpecialAreaDescrip { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(ALT_DESCRIP)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AltDescrip { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(AIRCRAFT)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other PFR_*.csv files</remarks>
            public string? BaseAircraft { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(HOURS)
            /// _MaxLength: 15
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Hours { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(ROUTE_DIR_DESCRIP)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RouteDirDescrip { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(DESIGNATOR)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Designator { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(NAR_TYPE)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NarType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(INLAND_FAC_FIX)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? InlandFacFix { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(COASTAL_FIX)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CoastalFix { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(DESTINATION)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Destination { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_BASE.csv(ROUTE_STRING)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RouteString { get; set; }

        }
        #endregion

        #region Pfr_RMT_FMT Fields
        public class PfrRmtFmt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(ORIG)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Orig { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(ROUTE STRING)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RouteString { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(DEST)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Dest { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(HOURS1)
            /// _MaxLength: 15
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Hours1 { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(TYPE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Type { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(AREA)
            /// _MaxLength: 75
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Area { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(ALTITUDE)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Altitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(AIRCRAFT)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other PFR_*.csv files</remarks>
            public string? RmtFmtAircraft { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(DIRECTION)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Direction { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(SEQ)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int Seq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(DCNTR)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Dcntr { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_RMT_FMT.csv(ACNTR)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Acntr { get; set; }

        }
        #endregion

        #region Pfr_SEG Fields
        public class PfrSeg : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(SEGMENT_SEQ)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int SegmentSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(SEG_VALUE)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SegValue { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(SEG_TYPE)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SegType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(ICAO_REGION_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? IcaoRegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PFR_SEG.csv(NEXT_SEG)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NextSeg { get; set; }

        }
        #endregion

    }
}