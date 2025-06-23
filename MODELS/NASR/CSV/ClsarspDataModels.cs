namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class ClsArspDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string EffDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(SITE_NO)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SiteNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(SITE_TYPE_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SiteTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(ARPT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ArptId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All CLS_ARSP_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region ClsArsp Fields
        public class ClsArsp : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: CLS_ARSP.csv(CLASS_B_AIRSPACE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ClassBAirspace { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CLS_ARSP.csv(CLASS_C_AIRSPACE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ClassCAirspace { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CLS_ARSP.csv(CLASS_D_AIRSPACE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ClassDAirspace { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CLS_ARSP.csv(CLASS_E_AIRSPACE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ClassEAirspace { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CLS_ARSP.csv(AIRSPACE_HRS)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AirspaceHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: CLS_ARSP.csv(REMARK)
            /// _MaxLength: 1500
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Remark { get; set; }

        }
        #endregion

    }
}