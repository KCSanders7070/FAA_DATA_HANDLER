namespace FAA_DATA_HANDLER.Models.NASR.CSV
{
    public class ArbDataModel
    {
        #region Common Fields
        public class CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: All Arb_*.csv files(EFF_DATE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string EffDate { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Arb_*.csv files(LOCATION_ID)
            /// _MaxLength: 4
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LocationId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: All Arb_*.csv files(LOCATION_NAME)
            /// _MaxLength: 30
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? LocationName { get; set; }

        }
        #endregion

        #region Arb_BASE Fields
        public class ArbBase : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(COMPUTER_ID)
            /// _MaxLength: 3
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string ComputerId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(ICAO_ID)
            /// _MaxLength: 7
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? IcaoId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LOCATION_TYPE)
            /// _MaxLength: 5
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string LocationType { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(CITY)
            /// _MaxLength: 40
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string City { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(STATE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? State { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(COUNTRY_CODE)
            /// _MaxLength: 2
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string CountryCode { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int BaseLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int BaseLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double BaseLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public string BaseLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double BaseLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int BaseLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int BaseLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double BaseLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public string BaseLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double BaseLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_BASE.csv(CROSS_REF)
            /// _MaxLength: 50
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? CrossRef { get; set; }

        }
        #endregion

        #region Arb_SEG Fields
        public class ArbSeg : CommonFields
        {
            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(REC_ID)
            /// _MaxLength: 14
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string RecId { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(ALTITUDE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Altitude { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(TYPE)
            /// _MaxLength: 10
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string Type { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(POINT_SEQ)
            /// _MaxLength: (4,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public int PointSeq { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LAT_DEG)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int SegLatDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LAT_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int SegLatMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LAT_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double SegLatSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LAT_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public string SegLatHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LAT_DECIMAL)
            /// _MaxLength: (10,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double SegLatDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LONG_DEG)
            /// _MaxLength: (3,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int SegLongDeg { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LONG_MIN)
            /// _MaxLength: (2,0)
            /// _DataType: int
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public int SegLongMin { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LONG_SEC)
            /// _MaxLength: (6,4)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double SegLongSec { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LONG_HEMIS)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public string SegLongHemis { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(LONG_DECIMAL)
            /// _MaxLength: (11,8)
            /// _DataType: double
            /// _Nullable: No
            /// </summary>
            /// <remarks>PropertyName changed due to identical column name in other ARB_*.csv files</remarks>
            public double SegLongDecimal { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(BNDRY_PT_DESCRIP)
            /// _MaxLength: 300
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? BndryPtDescrip { get; set; }

            /// <summary>
            /// NoTitleYet
            /// _Src: ARB_SEG.csv(NAS_DESCRIP_FLAG)
            /// _MaxLength: 1
            /// _DataType: string
            /// _Nullable: Yes
            /// </summary>
            /// <remarks>NoRemarksYet</remarks>
            public string? NasDescripFlag { get; set; }

        }
        #endregion

    }
}