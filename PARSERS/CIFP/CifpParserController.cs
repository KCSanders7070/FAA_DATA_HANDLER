using FAA_DATA_HANDLER.Parsers.CIFP;
using FAA_DATA_HANDLER.PARSERS.CIFP;
using System;
using System.IO;
using System.Xml;

/// <summary>
/// Entry-Point into CIFP Parsing.
/// </summary>
/// <remarks>This class processes the CIFP file named "FAACIFP18" located in the user-specified source directory.
/// It reads the file line by line and delegates parsing to specific parsers based on the content of each line. The
/// parsing logic is determined by the structure and identifiers within the CIFP file.</remarks>
public static class CifpParserController
{
    /// <param name="userSelectedSourceDirectory">The path to the directory selected by the user that contains the CIFP file named "FAACIFP18".</param>
    public static void Parse(string userSelectedSourceDirectory)
    {
        string filePath = Path.Combine(userSelectedSourceDirectory, "FAACIFP18");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            return;
        }

        // Reads each line in CIFP file
        foreach (var line in File.ReadLines(filePath))
        {
            // Prevent crash if line is empty.
            if (line.Length < 13)
                continue;

            // Sends the line to the appropriate parser based on the stated index values.
            switch (true)
            {
                case bool _ when line.StartsWith("HDR"):
                    HeaderInfoCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'C':
                    AirlineTerminalWaypointsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'A':
                    AirportsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'F':
                    AirportApproachProceduresCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'S':
                    AirportMinimumSectorAltitudeCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'E' && line[5] == 'R':
                    AirwaysCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'U' && line[5] == 'C':
                    ControlledClassAirspaceBCDCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'E' && line[5] == 'A':
                    EnrouteWaypointsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'F':
                    HeliportApproachProceduresCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'S':
                    HeliportMinimumSectorAltitudeCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'D':
                    HeliportStandardInstrumentDeparturesCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'C':
                    HeliportTerminalWaypointsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'H' && line[12] == 'A':
                    HeliportsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'I':
                    LocalizerAndGlideSlopeCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'D' && line[5] == 'B':
                    NnbNavaidsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'P':
                    PathPointCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'D':
                    StandardInstrumentDeparturesCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[12] == 'E':
                    StandardTerminalArrivalRoutesCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'U' && line[5] == 'R':
                    SpecialUseRestrictiveCifpParser.Parse(line);
                    break;
                case bool _ when (line[4] == 'A' && line[5] == 'S'):
                    GridMora.Parse(line);
                    break;
                case bool _ when line[4] == 'P' && line[5] == 'N':
                    TerminalNavaidsCifpParser.Parse(line);
                    break;
                case bool _ when line[4] == 'D' && line[5] == ' ':
                    VhfNavaidsCifpParser.Parse(line);
                    break;
                default:
                    break;
            }
        }
    }
}
