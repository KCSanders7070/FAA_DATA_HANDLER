using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses the HDR records at the top of a CIFP file.
    /// </summary>
    /// <remarks>
    /// HDR01 needs special handling. The FAA readme states that the Creation Date on Header Record 1
    /// carries no leading zero for a single-digit day, which shifts the Creation Date, Creation Time
    /// and Data Supplier fields one column to the left. Testing index 59 for a blank tells the two
    /// forms apart. This applies to the FAA CIFP only, not to ARINC 424 files generally.
    /// <para>HDR03 through HDR05 are unstructured supplier text with no documented layout and are
    /// deliberately skipped.</para>
    /// </remarks>
    public static class HeaderInfoCifpParser
    {
        /// <summary>Parses one HDR record and appends it to the collection.</summary>
        /// <param name="line">The full header line.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            if (line.Length < 132)
                return;

            string headerIdent = CifpSpan.Text(line.Slice(0, 3));
            string headerNumber = CifpSpan.Text(line.Slice(3, 2));

            HeaderInfoCifpDataModel model;

            switch (headerNumber)
            {
                case "01":
                {
                    // A single-digit creation day shifts everything after it one column to the left.
                    bool creationDateIsShort = line[59] == ' ';
                    int creationDateLength = creationDateIsShort ? 10 : 11;
                    int creationTimeStart = creationDateIsShort ? 51 : 52;
                    int dataSupplierStart = creationDateIsShort ? 60 : 61;

                    model = new HeaderInfoCifpDataModel
                    {
                        HeaderIdent = headerIdent,
                        HeaderNumber = headerNumber,
                        FileName = CifpSpan.Text(line.Slice(5, 15)),
                        VersionNumber = CifpSpan.Text(line.Slice(20, 3)),
                        ProductionTestFlag = CifpSpan.Text(line[23]),
                        RecordLength = CifpSpan.ToInt(line.Slice(24, 4)),
                        RecordCount = CifpSpan.ToInt(line.Slice(28, 7)),
                        CycleDate = CifpSpan.Text(line.Slice(35, 4)),
                        CreationDate = CifpSpan.Text(line.Slice(41, creationDateLength)),
                        CreationTime = CifpSpan.Text(line.Slice(creationTimeStart, 8)),
                        DataSupplierIdent = CifpSpan.Text(line.Slice(dataSupplierStart, 16)),
                        TargetCustomerIdent = CifpSpan.Text(line.Slice(77, 16)),
                        DataPartNumber = CifpSpan.Text(line.Slice(93, 20)),
                        FileCrc = CifpSpan.Text(line.Slice(124, 8)),
                    };
                    break;
                }

                case "02":
                {
                    model = new HeaderInfoCifpDataModel
                    {
                        HeaderIdent = headerIdent,
                        HeaderNumber = headerNumber,
                        ExpDate = CifpSpan.Text(line.Slice(16, 11)),
                        SupplierTextField = CifpSpan.Text(line.Slice(28, 30)),
                        DescriptiveText = CifpSpan.Text(line.Slice(58, 30)),
                    };
                    break;
                }

                default:
                    // HDR03 through HDR05 have no documented structure. Nothing to parse.
                    return;
            }

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.HeaderInfo.Add(model);
        }
    }
}
