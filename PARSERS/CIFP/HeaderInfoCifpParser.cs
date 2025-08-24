using FAA_DATA_HANDLER.Models.CIFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    public static class HeaderInfoCifpParser
    {
        public static void Parse(string line, CifpDataCollections cifpDataCollections)
        {
            var headerIdent = line.Substring(0, 3).Trim();
            var headerNumber = line.Substring(3, 2).Trim();

            switch (headerNumber)
            {
                // HDR01 - Header Record 1
                case "01":
                    {
                        /*  
                            The Creation Date on Header Record 1 will not contain a leading ‘zero’
                            or < blank > if the date is only one digit.As a result, the
                            Creation Date, Creation Time, and Data Supplier fields will be
                            shifted one space to the left.
                            Checking index 59 for a space is a reliable way to determine
                            if the fields are shifted left or not.
                            Note: This only applies to the "FAA" CIFP Data File.
                        */
                        bool creationDateIsShort = line[59] == ' ';
                        int creationDateLength = creationDateIsShort ? 10 : 11;
                        int creationTimeStart = creationDateIsShort ? 51 : 52;
                        int dataSupplierStart = creationDateIsShort ? 60 : 61;

                        var model = new HeaderInfoCifpDataModel
                        {
                            HeaderIdent = headerIdent,
                            HeaderNumber = headerNumber,
                            FileName = line.Substring(5, 15).Trim(),
                            VersionNumber = line.Substring(20, 3).Trim(),
                            ProductionTestFlag = line.Substring(23, 1).Trim(),
                            RecordLength = line.Substring(24, 4).Trim(),
                            RecordCount = line.Substring(28, 7).Trim(),
                            CycleDate = line.Substring(35, 4).Trim(),
                            // Blank (Spacing) ??? = line.Substring(39, 2).Trim()
                            CreationDate = line.Substring(41, creationDateLength).Trim(), // Length can be 10 or 11 depending on if index 59 is a space
                            CreationTime = line.Substring(creationTimeStart, 8).Trim(), // index can be 51 or 52 depending on if index 59 is a space
                            // Blank (Spacing) ??? = line.Substring(60, 1).Trim()
                            DataSupplierIdent = line.Substring(dataSupplierStart, 16).Trim(), // index can be 60 or 61 depending on if index 59 is a space
                            TargetCustomerIdent = line.Substring(77, 16).Trim(),
                            DataPartNumber = line.Substring(93, 20).Trim(),
                            // Reserved (Expansion) ??? = line.Substring(113, 11).Trim()
                            FileCrc = line.Substring(124, 8).Trim(),
                        };

                        cifpDataCollections.HeaderInfo.Add(model);
                        break;
                    }

                //  HDR02 - Header Record 2
                case "02":
                    {
                        var model = new HeaderInfoCifpDataModel
                        {
                            HeaderIdent = headerIdent,
                            HeaderNumber = headerNumber,
                            ExpDate = line.Substring(16, 11).Trim(),
                            // Blank (Spacing) ??? = line.Substring(27, 1).Trim()
                            SupplierTextField = line.Substring(28, 30).Trim(),
                            DescriptiveText = line.Substring(58, 30).Trim(),
                            // Reserved (Expansion) ??? = line.Substring(88, 43).Trim()
                        };

                        cifpDataCollections.HeaderInfo.Add(model);
                        break;
                    }

                default:
                    /*
                        ignore header numbers that are not 01 or 02,
                        as they are not clearly defined in documentation,
                        not regulated, and generally not needed.
                    */
                    return;
            }
        }
    }
}