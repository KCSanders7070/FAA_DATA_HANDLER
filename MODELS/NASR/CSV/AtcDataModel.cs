namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class AtcDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// Effective Date
            /// _Src: All Atc_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>The 28 Day NASR Subscription Effective Date in format ‘YYYY/MM/DD’.</remarks>
            public string EffDate { get; set; }

            /// <summary>
            /// Landing Facility Site Number
            /// _Src: All Atc_*.csv files(SITE_NO)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>A unique identifying number but can have a leading zero, contains periods in odd places therefore, keep as string. Examples: "01975.12" and "01979."</remarks>
            public string SiteNo { get; set; }

            /// <summary>
            /// Landing Facility Type Code
            /// _Src: All Atc_*.csv files(SITE_TYPE_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>Facility Codes: AIRPORT (A) _ BALLOONPORT (B) _ SEAPLANE BASE (C) _ GLIDERPORT (G) _ HELIPORT (H) _ ULTRALIGHT (U)</remarks>
            public string SiteTypeCode { get; set; }

            /// <summary>
            /// Facility Type
            /// _Src: All Atc_*.csv files(FACILITY_TYPE)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>ATCT=Air Traffic Control Tower _ ATCT-A/C=ATCT plus Approach Control _ ATCT-RAPCON=ATCT plus Radar Approach Control (USAF ATCT / FAA Approach) _ ATCT-RATCF=ATCT plus Radar Approach Control (Navy ATCT / FAA Approach) _ ATCT-TRACON=ATCT plus Terminal Radar Approach Control _ NON-ATCT=Non-Air Traffic Control Tower _ TRACON=Consolidated TRACON _ ARTCC=Air Route Traffic Control Center _ CERAP=Center Radar Approach Control Facility</remarks>
            public string FacilityType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Atc_*.csv files(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Atc_*.csv files(FACILITY_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Atc_*.csv files(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Atc_*.csv files(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

        }
        #endregion

        #region Atc_ATIS Fields
        public class AtcAtis : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_ATIS.csv(ATIS_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int AtisNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_ATIS.csv(DESCRIPTION)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Description { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_ATIS.csv(ATIS_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AtisHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_ATIS.csv(ATIS_PHONE_NO)
            /// _MaxLength: 18
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? AtisPhoneNo { get; set; }

        }
        #endregion

        #region Atc_BASE Fields
        public class AtcBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(ICAO_ID)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? IcaoId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(FACILITY_NAME)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(REGION_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(TWR_OPERATOR_CODE)
            /// _MaxLength: 6
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TwrOperatorCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(TWR_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TwrCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(TWR_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TwrHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(PRIMARY_APCH_RADIO_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PrimaryApchRadioCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(APCH_P_PROVIDER)
            /// _MaxLength: 700
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ApchPProvider { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(APCH_P_PROV_TYPE_CD)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ApchPProvTypeCd { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(SECONDARY_APCH_RADIO_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SecondaryApchRadioCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(APCH_S_PROVIDER)
            /// _MaxLength: 700
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ApchSProvider { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(APCH_S_PROV_TYPE_CD)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ApchSProvTypeCd { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(PRIMARY_DEP_RADIO_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PrimaryDepRadioCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(DEP_P_PROVIDER)
            /// _MaxLength: 700
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DepPProvider { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(DEP_P_PROV_TYPE_CD)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DepPProvTypeCd { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(SECONDARY_DEP_RADIO_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SecondaryDepRadioCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(DEP_S_PROVIDER)
            /// _MaxLength: 700
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DepSProvider { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(DEP_S_PROV_TYPE_CD)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? DepSProvTypeCd { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(CTL_FAC_APCH_DEP_CALLS)
            /// _MaxLength: 54
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CtlFacApchDepCalls { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(APCH_DEP_OPER_CODE)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ApchDepOperCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(CTL_PRVDING_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CtlPrvdingHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_BASE.csv(SECONDARY_CTL_PRVDING_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? SecondaryCtlPrvdingHrs { get; set; }

        }
        #endregion

        #region Atc_RMK Fields
        public class AtcRmk : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_RMK.csv(LEGACY_ELEMENT_NUMBER)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LegacyElementNumber { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_RMK.csv(TAB_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string TabName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_RMK.csv(REF_COL_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RefColName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_RMK.csv(REMARK_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RemarkNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_RMK.csv(REMARK)
            /// _MaxLength: 1500
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Remark { get; set; }

        }
        #endregion

        #region Atc_SVC Fields
        public class AtcSvc : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ATC_SVC.csv(CTL_SVC)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CtlSvc { get; set; }

        }
        #endregion

    }
}