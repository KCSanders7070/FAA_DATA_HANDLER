using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses D records into VhfNavaidsCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.2.1
    /// VHF NAVAID (VHF Navaids-D) and were verified against every D record in FAACIFP18.
    /// </remarks>
    public static class VhfNavaidsCifpParser
    {
        /// <summary>
        /// Parses one D record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new VhfNavaidsCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                SubsectionCode = CifpSpan.Text(line[5]),
                AirportIcaoIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                VorIdentifier = CifpSpan.Text(line.Slice(13, 4)),
                VorIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(19, 2)),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[21]),
                VorFrequency = CifpFieldConverter.Field534(line.Slice(22, 5), line[4], line[5]),
                NavaidClassType1 = CifpFieldConverter.Field535NavaidType1(line[27]),
                NavaidClassType2 = CifpFieldConverter.Field535NavaidType2(line[28]),
                NavaidClassRangePower = CifpFieldConverter.Field535RangePower(line[29]),
                NavaidClassAdditionalInformation = CifpFieldConverter.Field535AdditionalInformation(line[30]),
                NavaidClassCollocation = CifpFieldConverter.Field535Collocation(line[31]),
                VorLatitude = CifpFieldConverter.Field536(line.Slice(32, 9)),
                VorLongitude = CifpFieldConverter.Field537(line.Slice(41, 10)),
                DmeIdent = CifpSpan.Text(line.Slice(51, 4)),
                DmeLatitude = CifpFieldConverter.Field536(line.Slice(55, 9)),
                DmeLongitude = CifpFieldConverter.Field537(line.Slice(64, 10)),
                StationDeclinationDirection = CifpFieldConverter.Field566DeclinationDirection(line[74]),
                StationDeclinationMagnitude = CifpFieldConverter.Field566DeclinationMagnitude(line.Slice(75, 4)),
                DmeElevation = CifpFieldConverter.Field540(line.Slice(79, 5)),
                FigureOfMerit = CifpFieldConverter.Field5149(line[84]),
                IlsDmeBias = CifpFieldConverter.Field590(line.Slice(85, 2)),
                FrequencyProtection = CifpSpan.ToInt(line.Slice(87, 3)),
                DatumCode = CifpSpan.Text(line.Slice(90, 3)),
                VorName = CifpSpan.Text(line.Slice(93, 30)),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.VhfNavaids.Add(model);
        }
    }
}