using FAA_DATA_HANDLER.HELPERS.CIFP;
using FAA_DATA_HANDLER.Models.CIFP;
using System;

namespace FAA_DATA_HANDLER.Parsers.CIFP
{
    /// <summary>
    /// Parses PS records into AirportMinimumSectorAltitudeCifpDataModel.
    /// </summary>
    /// <remarks>
    /// Slices the 132-character record with ReadOnlySpan&lt;char&gt; so no intermediate strings are
    /// allocated for columns the model does not keep. Column boundaries come from ARINC 424 layout 4.1.20.1
    /// Airport MSA (MSA-PS) and were verified against every PS record in FAACIFP18.
    /// </remarks>
    public static class AirportMinimumSectorAltitudeCifpParser
    {
        /// <summary>
        /// Parses one PS record and appends it to the collection.
        /// </summary>
        /// <param name="line">The full 132-character record.</param>
        /// <param name="cifpDataCollections">Destination for the parsed model.</param>
        /// <param name="keepRawRecord">When true, the source line is stored on the model.</param>
        public static void Parse(ReadOnlySpan<char> line, CifpDataCollections cifpDataCollections, bool keepRawRecord = false)
        {
            var model = new AirportMinimumSectorAltitudeCifpDataModel
            {
                RecordType = CifpFieldConverter.Field52(line[0]),
                CustomerAreaCode = CifpSpan.Text(line.Slice(1, 3)),
                SectionCode = CifpSpan.Text(line[4]),
                AirportIdentifier = CifpSpan.Text(line.Slice(6, 4)),
                AirportIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(10, 2)),
                SubsectionCode = CifpSpan.Text(line[12]),
                MsaCenter = CifpFieldConverter.Field5144(line.Slice(13, 5)),
                MsaIcaoLocationCode = CifpFieldConverter.Field514(line.Slice(18, 2)),
                MsaSectionCode = CifpSpan.Text(line[20]),
                MsaSubsectionCode = CifpSpan.Text(line[21]),
                MultipleCode = CifpFieldConverter.Field5130(line[22]),
                ContinuationRecordNo = CifpFieldConverter.Field516(line[38]),
                SectorBearing1StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(42, 3)),
                SectorBearing1EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(45, 3)),
                SectorAltitude1 = CifpFieldConverter.Field5147(line.Slice(48, 3)),
                SectorRadius1 = CifpFieldConverter.Field5145(line.Slice(51, 2)),
                SectorBearing2StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(53, 3)),
                SectorBearing2EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(56, 3)),
                SectorAltitude2 = CifpFieldConverter.Field5147(line.Slice(59, 3)),
                SectorRadius2 = CifpFieldConverter.Field5145(line.Slice(62, 2)),
                SectorBearing3StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(64, 3)),
                SectorBearing3EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(67, 3)),
                SectorAltitude3 = CifpFieldConverter.Field5147(line.Slice(70, 3)),
                SectorRadius3 = CifpFieldConverter.Field5145(line.Slice(73, 2)),
                SectorBearing4StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(75, 3)),
                SectorBearing4EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(78, 3)),
                SectorAltitude4 = CifpFieldConverter.Field5147(line.Slice(81, 3)),
                SectorRadius4 = CifpFieldConverter.Field5145(line.Slice(84, 2)),
                SectorBearing5StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(86, 3)),
                SectorBearing5EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(89, 3)),
                SectorAltitude5 = CifpFieldConverter.Field5147(line.Slice(92, 3)),
                SectorRadius5 = CifpFieldConverter.Field5145(line.Slice(95, 2)),
                SectorBearing6StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(97, 3)),
                SectorBearing6EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(100, 3)),
                SectorAltitude6 = CifpFieldConverter.Field5147(line.Slice(103, 3)),
                SectorRadius6 = CifpFieldConverter.Field5145(line.Slice(106, 2)),
                SectorBearing7StartBearing = CifpFieldConverter.Field5146StartBearing(line.Slice(108, 3)),
                SectorBearing7EndBearing = CifpFieldConverter.Field5146EndBearing(line.Slice(111, 3)),
                SectorAltitude7 = CifpFieldConverter.Field5147(line.Slice(114, 3)),
                SectorRadius7 = CifpFieldConverter.Field5145(line.Slice(117, 2)),
                MagneticTrueIndicator = CifpFieldConverter.Field5165(line[119]),
                FileRecordNo = CifpSpan.Text(line.Slice(123, 5)),
                CycleDate = CifpFieldConverter.Field532(line.Slice(128, 4)),
            };

            if (keepRawRecord)
                model.RawRecord = line.ToString();

            cifpDataCollections.AirportMinimumSectorAltitude.Add(model);
        }
    }
}