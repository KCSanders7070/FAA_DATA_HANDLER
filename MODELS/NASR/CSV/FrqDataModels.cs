namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class FrqDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All Frq_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string EffDate { get; set; }

        }
        #endregion

        #region Frq Fields
        public class Frq : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(FACILITY)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Facility { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(FAC_NAME)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FacName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(FACILITY_TYPE)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(ARTCC_OR_FSS_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArtccOrFssId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(CPDLC)
            /// _MaxLength: 100
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Cpdlc { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(TOWER_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TowerHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SERVICED_FACILITY)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ServicedFacility { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SERVICED_FAC_NAME)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ServicedFacName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SERVICED_SITE_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ServicedSiteType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? LatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public double? LongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SERVICED_CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ServicedCity { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SERVICED_STATE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ServicedState { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SERVICED_COUNTRY)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ServicedCountry { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(TOWER_OR_COMM_CALL)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TowerOrCommCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(PRIMARY_APPROACH_RADIO_CALL)
            /// _MaxLength: 26
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? PrimaryApproachRadioCall { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(FREQ)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Freq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(SECTORIZATION)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Sectorization { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(FREQ_USE)
            /// _MaxLength: 600
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FreqUse { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: FRQ.csv(REMARK)
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