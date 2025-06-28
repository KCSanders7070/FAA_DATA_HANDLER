namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class WxlCsvDataModel
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
            /// _Src: All Wxl_*.csv files(WEA_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string WeaId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Wxl_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Wxl_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Wxl_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Wxl_BASE Fields
        public class WxlBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(ELEV)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int Elev { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_BASE.csv(SURVEY_METHOD_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SurveyMethodCode { get; set; }

        }
        #endregion

        #region Wxl_SVC Fields
        public class WxlSvc : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_SVC.csv(WEA_SVC_TYPE_CODE)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string WeaSvcTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: WXL_SVC.csv(WEA_AFFECT_AREA)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? WeaAffectArea { get; set; }

        }
        #endregion

    }
}