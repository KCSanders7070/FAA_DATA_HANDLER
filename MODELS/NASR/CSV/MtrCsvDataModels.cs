namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class MtrCsvDataModel
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
            /// _Src: All Mtr_*.csv files(ROUTE_TYPE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RouteTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Mtr_*.csv files(ROUTE_ID)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RouteId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Mtr_*.csv files(ARTCC)
            /// _MaxLength: 80
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Artcc { get; set; }

        }
        #endregion

        #region Mtr_AGY Fields
        public class MtrAgy : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(AGENCY_TYPE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AgencyType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(AGENCY_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AgencyName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(STATION)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Station { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(ADDRESS)
            /// _MaxLength: 35
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Address { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(CITY)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(ZIP_CODE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ZipCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(COMMERCIAL_NO)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CommercialNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(DSN_NO)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DsnNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_AGY.csv(HOURS)
            /// _MaxLength: 175
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Hours { get; set; }

        }
        #endregion

        #region Mtr_BASE Fields
        public class MtrBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_BASE.csv(FSS)
            /// _MaxLength: 160
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Fss { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_BASE.csv(TIME_OF_USE)
            /// _MaxLength: 175
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TimeOfUse { get; set; }

        }
        #endregion

        #region Mtr_PT Fields
        public class MtrPt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(ROUTE_PT_SEQ)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RoutePtSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(ROUTE_PT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RoutePtId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(NEXT_ROUTE_PT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NextRoutePtId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(SEGMENT_TEXT)
            /// _MaxLength: 228
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SegmentText { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(NAV_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(NAVAID_BEARING)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? NavaidBearing { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_PT.csv(NAVAID_DIST)
            /// _MaxLength: (4,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? NavaidDist { get; set; }

        }
        #endregion

        #region Mtr_SOP Fields
        public class MtrSop : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_SOP.csv(SOP_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int SopSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_SOP.csv(SOP_TEXT)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SopText { get; set; }

        }
        #endregion

        #region Mtr_TERR Fields
        public class MtrTerr : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_TERR.csv(TERRAIN_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int TerrainSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_TERR.csv(TERRAIN_TEXT)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TerrainText { get; set; }

        }
        #endregion

        #region Mtr_WDTH Fields
        public class MtrWdth : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_WDTH.csv(WIDTH_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int WidthSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: MTR_WDTH.csv(WIDTH_TEXT)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string WidthText { get; set; }

        }
        #endregion

    }
}