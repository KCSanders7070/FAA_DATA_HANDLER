namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class LidDataModel
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

        }
        #endregion

        #region Lid Fields
        public class Lid : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(LOC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LocId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(REGION_CODE)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(STATE)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? State { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(LID_GROUP)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LidGroup { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(FAC_TYPE)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(FAC_NAME)
            /// _MaxLength: 75
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FacName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(RESP_ARTCC_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RespArtccId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(ARTCC_COMPUTER_ID)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArtccComputerId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: LID.csv(FSS_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? FssId { get; set; }

        }
        #endregion

    }
}