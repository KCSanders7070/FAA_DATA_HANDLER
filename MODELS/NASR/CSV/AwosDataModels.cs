namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class AwosDataModel
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
            /// _Src: All Awos_*.csv files(ASOS_AWOS_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AsosAwosId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awos_*.csv files(ASOS_AWOS_TYPE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AsosAwosType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awos_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awos_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awos_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Awos Fields
        public class Awos : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(COMMISSIONED_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CommissionedDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(NAVAID_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NavaidFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? LatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? LatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? LatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? LongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? LongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? LongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(ELEV)
            /// _MaxLength: (6,1)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Elev { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(SURVEY_METHOD_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SurveyMethodCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(PHONE_NO)
            /// _MaxLength: 14
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PhoneNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(SECOND_PHONE_NO)
            /// _MaxLength: 14
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SecondPhoneNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(SITE_NO)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SiteNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(SITE_TYPE_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SiteTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWOS.csv(REMARK)
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