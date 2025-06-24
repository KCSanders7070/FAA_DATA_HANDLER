namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class FixDataModel
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
            /// _Src: All Fix_*.csv files(FIX_ID)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FixId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Fix_*.csv files(ICAO_REGION_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string IcaoRegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Fix_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Fix_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Fix_BASE Fields
        public class FixBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(FIX_ID_OLD)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FixIdOld { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(CHARTING_REMARK)
            /// _MaxLength: 38
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ChartingRemark { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(FIX_USE_CODE)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FixUseCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(ARTCC_ID_HIGH)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArtccIdHigh { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(ARTCC_ID_LOW)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ArtccIdLow { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(PITCH_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string PitchFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(CATCH_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CatchFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(SUA_ATCAA_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SuaAtcaaFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(MIN_RECEP_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinRecepAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(COMPULSORY)
            /// _MaxLength: 8
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Compulsory { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_BASE.csv(CHARTS)
            /// _MaxLength: 600
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Charts { get; set; }

        }
        #endregion

        #region Fix_CHRT Fields
        public class FixChrt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_CHRT.csv(CHARTING_TYPE_DESC)
            /// _MaxLength: 22
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ChartingTypeDesc { get; set; }

        }
        #endregion

        #region Fix_NAV Fields
        public class FixNav : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_NAV.csv(NAV_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_NAV.csv(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_NAV.csv(BEARING)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Bearing { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FIX_NAV.csv(DISTANCE)
            /// _MaxLength: (7,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Distance { get; set; }

        }
        #endregion

    }
}