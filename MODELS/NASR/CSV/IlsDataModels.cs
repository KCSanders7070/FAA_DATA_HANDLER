namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class IlsDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string EffDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(SITE_NO)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SiteNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(SITE_TYPE_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SiteTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(ARPT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ArptId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(RWY_END_ID)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RwyEndId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(ILS_LOC_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string IlsLocId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Ils_*.csv files(SYSTEM_TYPE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SystemTypeCode { get; set; }

        }
        #endregion

        #region Ils_BASE Fields
        public class IlsBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(STATE_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(REGION_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(RWY_LEN)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RwyLen { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(RWY_WIDTH)
            /// _MaxLength: (4,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RwyWidth { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(CATEGORY)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Category { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(OWNER)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Owner { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(OPERATOR)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Operator { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(APCH_BEAR)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double ApchBear { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(MAG_VAR)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int MagVar { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(MAG_VAR_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string MagVarHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(COMPONENT_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string BaseComponentStatus { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(COMPONENT_STATUS_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string BaseComponentStatusDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int BaseLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int BaseLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double BaseLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string BaseLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double BaseLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int BaseLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int BaseLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double BaseLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string BaseLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double BaseLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LAT_LONG_SOURCE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string? BaseLatLongSourceCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(SITE_ELEVATION)
            /// _MaxLength: (6,1)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double? BaseSiteElevation { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(LOC_FREQ)
            /// _MaxLength: (6,2)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LocFreq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_BASE.csv(BK_COURSE_STATUS_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? BkCourseStatusCode { get; set; }

        }
        #endregion

        #region Ils_DME Fields
        public class IlsDme : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(COMPONENT_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string DmeComponentStatus { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(COMPONENT_STATUS_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string DmeComponentStatusDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int DmeLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int DmeLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double DmeLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string DmeLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double DmeLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int DmeLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int DmeLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double DmeLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string DmeLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double DmeLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(LAT_LONG_SOURCE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string? DmeLatLongSourceCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(SITE_ELEVATION)
            /// _MaxLength: (6,1)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double? DmeSiteElevation { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_DME.csv(CHANNEL)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Channel { get; set; }

        }
        #endregion

        #region Ils_GS Fields
        public class IlsGs : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(COMPONENT_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string GsComponentStatus { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(COMPONENT_STATUS_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string GsComponentStatusDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int GsLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int GsLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double GsLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string GsLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double GsLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int GsLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int GsLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double GsLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string GsLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double GsLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(LAT_LONG_SOURCE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string? GsLatLongSourceCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(SITE_ELEVATION)
            /// _MaxLength: (6,1)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double? GsSiteElevation { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(G_S_TYPE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string GSTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(G_S_ANGLE)
            /// _MaxLength: (4,2)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double GSAngle { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_GS.csv(G_S_FREQ)
            /// _MaxLength: (6,2)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double GSFreq { get; set; }

        }
        #endregion

        #region Ils_MKR Fields
        public class IlsMkr : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(ILS_COMP_TYPE_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string MkrIlsCompTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(COMPONENT_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string MkrComponentStatus { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(COMPONENT_STATUS_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string MkrComponentStatusDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int MkrLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int MkrLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double MkrLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string MkrLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double MkrLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int MkrLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public int MkrLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double MkrLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string MkrLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double MkrLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LAT_LONG_SOURCE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string? MkrLatLongSourceCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(SITE_ELEVATION)
            /// _MaxLength: (6,1)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public double? MkrSiteElevation { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(MKR_FAC_TYPE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string MkrFacTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(MARKER_ID_BEACON)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MarkerIdBeacon { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(COMPASS_LOCATOR_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CompassLocatorName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(FREQ)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Freq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(NAV_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_MKR.csv(LOW_POWERED_NDB_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LowPoweredNdbStatus { get; set; }

        }
        #endregion

        #region Ils_RMK Fields
        public class IlsRmk : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_RMK.csv(TAB_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TabName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_RMK.csv(ILS_COMP_TYPE_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ILS_*.csv files</remarks>
            public string? RmkIlsCompTypeCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_RMK.csv(REF_COL_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RefColName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_RMK.csv(REF_COL_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RefColSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ILS_RMK.csv(REMARK)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Remark { get; set; }

        }
        #endregion

    }
}