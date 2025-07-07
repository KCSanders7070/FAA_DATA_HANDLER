using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAA_DATA_HANDLER.MODELS.CIFP.AIRLINE
{
    /// <summary>
    /// Model properties for VHF Navaid Section (D), Subsection (Blank).
    /// </summary>
    public class VhfNavaidCifpDataModel
    {
        #region Common Fields
        /// <summary>
        /// Defines common model properties shared by all Records in the VHF Navaid Section.
        /// </summary>
        public class CommonFields
        {
            /// <summary>Record Type _Field: 5.2 _Index: 0 _Width: 1</summary>
            /// <remarks>PlaceHolderRemarks</remarks>
            public string? RecordType { get; set; }

            /// <summary>Customer/Area Code _Field: 5.3 _Index: 1 _Width: 3</summary>
            /// <remarks>PlaceHolderRemarks</remarks>
            public string? CustomerAreaCode { get; set; }

            // TODO: other Common Fields here
        }
        #endregion

        #region VHF NAVAID Primary Records
        /// <summary>
        /// Defines properties for the VHF Navaid Section - Primary Records.
        /// </summary>
        public class PrimaryRecords : CommonFields
        {
            /// <summary>Continuation Record # _Field: 5.16 _Index: 21 _Width: 1</summary>
            /// <remarks>PlaceHolderRemarks</remarks>
            public string? ContinuationRecordNo { get; set; }

            /// <summary>VOR Frequency _Field: 5.34 _Index: 22 _Width: 5</summary>
            /// <remarks>PlaceHolderRemarks</remarks>
            public string? VorFrequency { get; set; }

            // TODO: other Primary Record Fields here
        }
        #endregion

        #region VHF NAVAID Continuation Records
        /// <summary>
        /// Defines properties for the VHF Navaid Section - Continuation Records.
        /// </summary>
        public class ContinuationRecords : CommonFields
        {
            /// <summary>Continuation Record # _Field: 5.16 _Index: 21 _Width: 1</summary>
            /// <remarks>PlaceHolderRemarks</remarks>
            public string? ContinuationRecordNo { get; set; }

            /// <summary>Application Type _Field: 5.91 _Index: 22 _Width: 1</summary>
            /// <remarks>PlaceHolderRemarks</remarks>
            public string? ApplicationType { get; set; }

            // TODO: other Continuation Record Fields here
        }
        #endregion




    }
}