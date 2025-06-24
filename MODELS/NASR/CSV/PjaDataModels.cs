namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class PjaDataModel
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
            /// _Src: All Pja_*.csv files(PJA_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string PjaId { get; set; }

        }
        #endregion

        #region Pja_BASE Fields
        public class PjaBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(NAV_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(RADIAL)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Radial { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(DISTANCE)
            /// _MaxLength: (7,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Distance { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(NAVAID_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavaidName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(CITY)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(LATITUDE)
            /// _MaxLength: 14
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Latitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(LONGITUDE)
            /// _MaxLength: 15
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Longitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(ARPT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArptId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(SITE_NO)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SiteNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(SITE_TYPE_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SiteTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(DROP_ZONE_NAME)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DropZoneName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(MAX_ALTITUDE)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MaxAltitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(MAX_ALTITUDE_TYPE_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MaxAltitudeTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(PJA_RADIUS)
            /// _MaxLength: (4,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? PjaRadius { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(CHART_REQUEST_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ChartRequestFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(PUBLISH_CRITERIA)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PublishCriteria { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(DESCRIPTION)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Description { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(TIME_OF_USE)
            /// _MaxLength: 150
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TimeOfUse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(FSS_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FssId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(FSS_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FssName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(PJA_USE)
            /// _MaxLength: 8
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PjaUse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(VOLUME)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Volume { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(PJA_USER)
            /// _MaxLength: 150
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PjaUser { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_BASE.csv(REMARK)
            /// _MaxLength: 600
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Remark { get; set; }

        }
        #endregion

        #region Pja_CON Fields
        public class PjaCon : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(FAC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FacId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(FAC_NAME)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(LOC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LocId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(COMMERCIAL_FREQ)
            /// _MaxLength: (7,3)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double CommercialFreq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(COMMERCIAL_CHART_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CommercialChartFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(MIL_FREQ)
            /// _MaxLength: (7,3)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? MilFreq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(MIL_CHART_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MilChartFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(SECTOR)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Sector { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: PJA_CON.csv(CONTACT_FREQ_ALTITUDE)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ContactFreqAltitude { get; set; }

        }
        #endregion

    }
}