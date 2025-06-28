namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class NavCsvDataModel
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
            /// _Src: All Nav_*.csv files(NAV_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NavId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Nav_*.csv files(NAV_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NavType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Nav_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Nav_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Nav_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Nav_BASE Fields
        public class NavBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(NAV_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NavStatus { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Name { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(STATE_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(REGION_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(COUNTRY_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(FAN_MARKER)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FanMarker { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(OWNER)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Owner { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(OPERATOR)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Operator { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(NAS_USE_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string NasUseFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(PUBLIC_USE_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string PublicUseFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(NDB_CLASS_CODE)
            /// _MaxLength: 11
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NdbClassCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(OPER_HOURS)
            /// _MaxLength: 11
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? OperHours { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(HIGH_ALT_ARTCC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? HighAltArtccId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(HIGH_ARTCC_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? HighArtccName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LOW_ALT_ARTCC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LowAltArtccId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LOW_ARTCC_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LowArtccName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int LongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(SURVEY_ACCURACY_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SurveyAccuracyCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_STATUS)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TacanDmeStatus { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? TacanDmeLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? TacanDmeLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? TacanDmeLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TacanDmeLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? TacanDmeLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? TacanDmeLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? TacanDmeLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? TacanDmeLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TacanDmeLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(TACAN_DME_LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? TacanDmeLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(ELEV)
            /// _MaxLength: (6,1)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Elev { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MAG_VARN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MagVarn { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MAG_VARN_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MagVarnHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MAG_VARN_YEAR)
            /// _MaxLength: (4,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MagVarnYear { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(SIMUL_VOICE_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SimulVoiceFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(PWR_OUTPUT)
            /// _MaxLength: (4,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? PwrOutput { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(AUTO_VOICE_ID_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AutoVoiceIdFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MNT_CAT_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MntCatCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(VOICE_CALL)
            /// _MaxLength: 60
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? VoiceCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(CHAN)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Chan { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(FREQ)
            /// _MaxLength: (5,2)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? Freq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MKR_IDENT)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MkrIdent { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MKR_SHAPE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? MkrShape { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(MKR_BRG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? MkrBrg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(ALT_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AltCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(DME_SSV)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DmeSsv { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(LOW_NAV_ON_HIGH_CHART_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LowNavOnHighChartFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(Z_MKR_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ZMkrFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(FSS_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FssId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(FSS_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FssName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(FSS_HOURS)
            /// _MaxLength: 65
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FssHours { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(NOTAM_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NotamId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(QUAD_IDENT)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? QuadIdent { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(PITCH_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PitchFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(CATCH_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CatchFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(SUA_ATCAA_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SuaAtcaaFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(RESTRICTION_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RestrictionFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_BASE.csv(HIWAS_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? HiwasFlag { get; set; }

        }
        #endregion

        #region Nav_CKPT Fields
        public class NavCkpt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_CKPT.csv(ALTITUDE)
            /// _MaxLength: (5,0)
            /// _DataType: int
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int? Altitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_CKPT.csv(BRG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int Brg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_CKPT.csv(AIR_GND_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AirGndCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_CKPT.csv(CHK_DESC)
            /// _MaxLength: 75
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ChkDesc { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_CKPT.csv(ARPT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArptId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_CKPT.csv(STATE_CHK_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string StateChkCode { get; set; }

        }
        #endregion

        #region Nav_RMK Fields
        public class NavRmk : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_RMK.csv(TAB_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TabName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_RMK.csv(REF_COL_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RefColName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_RMK.csv(REF_COL_SEQ_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RefColSeqNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: NAV_RMK.csv(REMARK)
            /// _MaxLength: 600
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Remark { get; set; }

        }
        #endregion

    }
}