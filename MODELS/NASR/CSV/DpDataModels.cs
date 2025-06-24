namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class DpDataModel
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
            /// _Src: All Dp_*.csv files(DP_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string DpName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Dp_*.csv files(ARTCC)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? Artcc { get; set; }

        }
        #endregion

        #region Dp_APT Fields
        public class DpApt : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: DP_APT.csv(DP_COMPUTER_CODE)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other DP_*.csv files</remarks>
            public string AptDpComputerCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_APT.csv(BODY_NAME)
            /// _MaxLength: 110
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string BodyName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_APT.csv(BODY_SEQ)
            /// _MaxLength: (1,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other DP_*.csv files</remarks>
            public int AptBodySeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_APT.csv(ARPT_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ArptId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_APT.csv(RWY_END_ID)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? RwyEndId { get; set; }

        }
        #endregion

        #region Dp_BASE Fields
        public class DpBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: DP_BASE.csv(AMENDMENT_NO)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string AmendmentNo { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_BASE.csv(DP_AMEND_EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string DpAmendEffDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_BASE.csv(RNAV_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RnavFlag { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_BASE.csv(DP_COMPUTER_CODE)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other DP_*.csv files</remarks>
            public string BaseDpComputerCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_BASE.csv(GRAPHICAL_DP_TYPE)
            /// _MaxLength: 9
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string GraphicalDpType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_BASE.csv(SERVED_ARPT)
            /// _MaxLength: 200
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ServedArpt { get; set; }

        }
        #endregion

        #region Dp_RTE Fields
        public class DpRte : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(DP_COMPUTER_CODE)
            /// _MaxLength: 12
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other DP_*.csv files</remarks>
            public string RteDpComputerCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(ROUTE_PORTION_TYPE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RoutePortionType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(ROUTE_NAME)
            /// _MaxLength: 110
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RouteName { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(BODY_SEQ)
            /// _MaxLength: (1,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other DP_*.csv files</remarks>
            public int RteBodySeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(TRANSITION_COMPUTER_CODE)
            /// _MaxLength: 20
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? TransitionComputerCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(POINT_SEQ)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int PointSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(POINT)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Point { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(ICAO_REGION_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? IcaoRegionCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(POINT_TYPE)
            /// _MaxLength: 25
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string PointType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(NEXT_POINT)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NextPoint { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: DP_RTE.csv(ARPT_RWY_ASSOC)
            /// _MaxLength: 1500
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? ArptRwyAssoc { get; set; }

        }
        #endregion

    }
}