namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class MaaCsvDataModel
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
            /// _Src: All Maa_*.csv files(MAA_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string MaaId { get; set; }

        }
        #endregion

        #region Maa_BASE Fields
        public class MaaBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(MAA_TYPE_NAME)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string MaaTypeName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NAV_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NAV_RADIAL)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? NavRadial { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NAV_DISTANCE)
            /// _MaxLength: (7,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? NavDistance { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(CITY)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(LATITUDE)
            /// _MaxLength: 14
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other MAA_*.csv files</remarks>
            public string? BaseLatitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(LONGITUDE)
            /// _MaxLength: 15
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other MAA_*.csv files</remarks>
            public string? BaseLongitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(ARPT_IDS)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArptIds { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NEAREST_ARPT)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NearestArpt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NEAREST_ARPT_DIST)
            /// _MaxLength: (7,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? NearestArptDist { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(NEAREST_ARPT_DIR)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NearestArptDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(MAA_NAME)
            /// _MaxLength: 120
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MaaName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(MAX_ALT)
            /// _MaxLength: 8
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MaxAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(MIN_ALT)
            /// _MaxLength: 8
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MinAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(MAA_RADIUS)
            /// _MaxLength: (4,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? MaaRadius { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(DESCRIPTION)
            /// _MaxLength: 450
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Description { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(MAA_USE)
            /// _MaxLength: 8
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MaaUse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(CHECK_NOTAMS)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CheckNotams { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(TIME_OF_USE)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TimeOfUse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_BASE.csv(USER_GROUP_NAME)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? UserGroupName { get; set; }

        }
        #endregion

        #region Maa_CON Fields
        public class MaaCon : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(FREQ_SEQ)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int FreqSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(FAC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FacId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(FAC_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(COMMERCIAL_FREQ)
            /// _MaxLength: (7,3)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double CommercialFreq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(COMMERCIAL_CHART_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CommercialChartFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(MIL_FREQ)
            /// _MaxLength: (7,3)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? MilFreq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_CON.csv(MIL_CHART_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MilChartFlag { get; set; }

        }
        #endregion

        #region Maa_RMK Fields
        public class MaaRmk : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_RMK.csv(TAB_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TabName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_RMK.csv(REF_COL_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RefColName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_RMK.csv(REF_COL_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RefColSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_RMK.csv(REMARK)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Remark { get; set; }

        }
        #endregion

        #region Maa_SHP Fields
        public class MaaShp : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_SHP.csv(POINT_SEQ)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int PointSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_SHP.csv(LATITUDE)
            /// _MaxLength: 14
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other MAA_*.csv files</remarks>
            public string ShpLatitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MAA_SHP.csv(LONGITUDE)
            /// _MaxLength: 15
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other MAA_*.csv files</remarks>
            public string ShpLongitude { get; set; }

        }
        #endregion

    }
}