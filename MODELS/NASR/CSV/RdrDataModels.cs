namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class RdrDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All Rdr_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string EffDate { get; set; }

        }
        #endregion

        #region Rdr Fields
        public class Rdr : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(FACILITY_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(FACILITY_TYPE)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string FacilityType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(STATE_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? StateCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(RADAR_TYPE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RadarType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(RADAR_NO)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int RadarNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(RADAR_HRS)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RadarHrs { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: RDR.csv(REMARK)
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