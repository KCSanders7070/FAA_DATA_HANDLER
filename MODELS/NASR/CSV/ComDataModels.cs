namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class ComDataModel
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
            /// _Src: All Com_*.csv files(COMM_LOC_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CommLocId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(COMM_TYPE)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CommType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(NAV_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(REGION_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Com_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Com Fields
        public class Com : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(COMM_OUTLET_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CommOutletName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(FACILITY_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(FACILITY_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(ALT_FSS_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AltFssId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(ALT_FSS_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AltFssName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(OPR_HRS)
            /// _MaxLength: 65
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? OprHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(COMM_STATUS_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CommStatusCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(COMM_STATUS_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CommStatusDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: COM.csv(REMARK)
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