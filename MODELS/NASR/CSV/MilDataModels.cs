namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class MilDataModel
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

        }
        #endregion

        #region Mil_OPS Fields
        public class MilOps : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(SITE_NO)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SiteNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(SITE_TYPE_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SiteTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(ARPT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ArptId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(MIL_OPS_OPER_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MilOpsOperCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(MIL_OPS_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MilOpsCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(MIL_OPS_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MilOpsHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(AMCP_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AmcpHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(PMSV_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PmsvHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MIL_OPS.csv(REMARK)
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