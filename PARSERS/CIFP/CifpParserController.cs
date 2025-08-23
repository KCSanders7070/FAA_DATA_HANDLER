using FAA_DATA_HANDLER.Parsers.CIFP;
using FAA_DATA_HANDLER.PARSERS.CIFP;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using FAA_DATA_HANDLER.Models.CIFP;

/// <summary>
/// Entry-Point into CIFP Parsing.
/// </summary>
/// <remarks>This class processes the CIFP file named "FAACIFP18" located in the user-specified source directory.
/// It reads the file line by line and delegates parsing to specific parsers based on the content of each line. The
/// parsing logic is determined by the structure and identifiers within the CIFP file.</remarks>
public static class CifpParserController
{
    /// <param name="faaCifp18FilePath">The path to the directory selected by the user that contains the CIFP file named "FAACIFP18".</param>
    public static void Parse(string faaCifp18FilePath, CifpDataCollections cifpDataCollections)
    {
        if (!File.Exists(faaCifp18FilePath))
        {
            Console.WriteLine($"File not found: {faaCifp18FilePath}");
            return;
        }

        // Reads each line in CIFP file
        foreach (var line in File.ReadLines(faaCifp18FilePath))
        {
            // Skip blank/whitespace lines and anything shorter than 13 chars.
            if (string.IsNullOrWhiteSpace(line) || line.Length < 13)
                continue;

            // Sends the line to the appropriate parser based on the stated index values.
            switch (true)
            {
                case bool _ when line.StartsWith("HDR"):
                    // HeaderInfoCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'C':
                    // AirlineTerminalWaypointsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'A':
                    AirportsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'G':
                    RunwaysCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'F':
                    // AirportApproachProceduresCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'S':
                    // AirportMinimumSectorAltitudeCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'E' && line[5] == 'R':
                    // AirwaysCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'U' && line[5] == 'C':
                    // ControlledClassAirspaceBCDCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'E' && line[5] == 'A':
                    // EnrouteWaypointsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'F':
                    // HeliportApproachProceduresCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'S':
                    // HeliportMinimumSectorAltitudeCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'D':
                    // HeliportStandardInstrumentDeparturesCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'C':
                    // HeliportTerminalWaypointsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'A':
                    HeliportsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'I':
                    // LocalizerAndGlideSlopeCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'D' && line[5] == 'B':
                    // NnbNavaidsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'P':
                    // PathPointCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'D':
                    // StandardInstrumentDeparturesCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'E':
                    // StandardTerminalArrivalRoutesCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'U' && line[5] == 'R':
                    // SpecialUseRestrictiveCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when (line[4] == 'A' && line[5] == 'S'):
                    // GridMora.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'P' && line[5] == 'N':
                    // TerminalNavaidsCifpParser.Parse(line, cifpDataCollections);
                    break;
                case bool _ when line[4] == 'D' && line[5] == ' ':
                    // VhfNavaidsCifpParser.Parse(line, cifpDataCollections);
                    break;
                default:
                    break;
            }
        }
    }
}
