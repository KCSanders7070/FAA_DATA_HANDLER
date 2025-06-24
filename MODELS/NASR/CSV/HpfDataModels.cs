namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class HpfDataModel
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
            /// _Src: All Hpf_*.csv files(HP_NAME)
            /// _MaxLength: 80
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string HpName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Hpf_*.csv files(HP_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int HpNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Hpf_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Hpf_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Hpf_BASE Fields
        public class HpfBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(FIX_ID)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FixId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(ICAO_REGION_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? IcaoRegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(NAV_ID)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(HOLD_DIRECTION)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? HoldDirection { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(HOLD_DEG_OR_CRS)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? HoldDegOrCrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(AZIMUTH)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Azimuth { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(COURSE_INBOUND_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? CourseInboundDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(TURN_DIRECTION)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TurnDirection { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_BASE.csv(LEG_LENGTH_DIST)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? LegLengthDist { get; set; }

        }
        #endregion

        #region Hpf_CHRT Fields
        public class HpfChrt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_CHRT.csv(CHARTING_TYPE_DESC)
            /// _MaxLength: 22
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ChartingTypeDesc { get; set; }

        }
        #endregion

        #region Hpf_RMK Fields
        public class HpfRmk : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_RMK.csv(TAB_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TabName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_RMK.csv(REF_COL_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RefColName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_RMK.csv(REF_COL_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RefColSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_RMK.csv(REMARK)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Remark { get; set; }

        }
        #endregion

        #region Hpf_SpdAlt Fields
        public class HpfSpdAlt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_SPD_ALT.csv(SPEED_RANGE)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string SpeedRange { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: HPF_SPD_ALT.csv(ALTITUDE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Altitude { get; set; }

        }
        #endregion

    }
}