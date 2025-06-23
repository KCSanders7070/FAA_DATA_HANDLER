namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class AwyDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All Awy_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string EffDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awy_*.csv files(REGULATORY)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Regulatory { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awy_*.csv files(AWY_LOCATION)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AwyLocation { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Awy_*.csv files(AWY_ID)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AwyId { get; set; }

        }
        #endregion

        #region Awy_BASE Fields
        public class AwyBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_BASE.csv(AWY_DESIGNATION)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AwyDesignation { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_BASE.csv(UPDATE_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string UpdateDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_BASE.csv(REMARK)
            /// _MaxLength: 1500
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other AWY_*.csv files</remarks>
            public string? BaseRemark { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_BASE.csv(AIRWAY_STRING)
            /// _MaxLength: 1500
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AirwayString { get; set; }

        }
        #endregion

        #region Awy_SEG_ALT Fields
        public class AwySegAlt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(POINT_SEQ)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int PointSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(FROM_POINT)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FromPoint { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(FROM_PT_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FromPtType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(NAV_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(NAV_CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavCity { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(ARTCC)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Artcc { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(ICAO_REGION_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? IcaoRegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(TO_POINT)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ToPoint { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MAG_COURSE)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? MagCourse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(OPP_MAG_COURSE)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? OppMagCourse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MAG_COURSE_DIST)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? MagCourseDist { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(CHGOVR_PT)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ChgovrPt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(CHGOVR_PT_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ChgovrPtName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(CHGOVR_PT_DIST)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? ChgovrPtDist { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(AWY_SEG_GAP_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AwySegGapFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(SIGNAL_GAP_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SignalGapFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(DOGLEG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Dogleg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(NEXT_MEA_PT)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NextMeaPt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_ENROUTE_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinEnrouteAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_ENROUTE_ALT_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MinEnrouteAltDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_ENROUTE_ALT_OPPOSITE)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinEnrouteAltOpposite { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_ENROUTE_ALT_OPPOSITE_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MinEnrouteAltOppositeDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(GPS_MIN_ENROUTE_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? GpsMinEnrouteAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(GPS_MIN_ENROUTE_ALT_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? GpsMinEnrouteAltDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(GPS_MIN_ENROUTE_ALT_OPPOSITE)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? GpsMinEnrouteAltOpposite { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(GPS_MEA_OPPOSITE_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? GpsMeaOppositeDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(DD_IRU_MEA)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? DdIruMea { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(DD_IRU_MEA_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DdIruMeaDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(DD_I_MEA_OPPOSITE)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? DdIMeaOpposite { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(DD_I_MEA_OPPOSITE_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DdIMeaOppositeDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_OBSTN_CLNC_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinObstnClncAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_CROSS_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinCrossAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_CROSS_ALT_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MinCrossAltDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_CROSS_ALT_NAV_PT)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MinCrossAltNavPt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_CROSS_ALT_OPPOSITE)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinCrossAltOpposite { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_CROSS_ALT_OPPOSITE_DIR)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MinCrossAltOppositeDir { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MIN_RECEP_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MinRecepAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MAX_AUTH_ALT)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MaxAuthAlt { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(MEA_GAP)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MeaGap { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(REQD_NAV_PERFORMANCE)
            /// _MaxLength: (4,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? ReqdNavPerformance { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: AWY_SEG_ALT.csv(REMARK)
            /// _MaxLength: 1500
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other AWY_*.csv files</remarks>
            public string? SegAltRemark { get; set; }

        }
        #endregion

    }
}