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

            var index4 = line[4];
            var index5 = line[5];
            var index12 = line[12];

            // Sends the line to the appropriate parser based on the stated index values.
            switch (true)
            {
                // HEADER INFO
                case bool _ when line.StartsWith("HDR"):
                    HeaderInfoCifpParser.Parse(line, cifpDataCollections);
                    break;

                // AIRLINE TERMINAL WAYPOINTS
                case bool _ when index4 == 'P' && index12 == 'C':
                    // AirlineTerminalWaypointsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // AIRPORTS
                case bool _ when index4 == 'P' && index12 == 'A':
                    AirportsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // RUNWAYS
                case bool _ when index4 == 'P' && index12 == 'G':
                    RunwaysCifpParser.Parse(line, cifpDataCollections);
                    break;

                // AIRPORT APPROACH PROCEDURES
                case bool _ when index4 == 'P' && index12 == 'F':
                    // AirportApproachProceduresCifpParser.Parse(line, cifpDataCollections);
                    break;

                // AIRPORT MINIMUM SECTOR ALTITUDES
                case bool _ when index4 == 'P' && index12 == 'S':
                    // AirportMinimumSectorAltitudeCifpParser.Parse(line, cifpDataCollections);
                    break;

                // AIRWAYS
                case bool _ when index4 == 'E' && index5 == 'R':
                    // AirwaysCifpParser.Parse(line, cifpDataCollections);
                    break;

                // CONTROLLED CLASS AIRSPACE
                case bool _ when index4 == 'U' && index5 == 'C':
                    // ControlledClassAirspaceBCDCifpParser.Parse(line, cifpDataCollections);
                    break;

                // ENROUTE WAYPOINTS
                case bool _ when index4 == 'E' && index5 == 'A':
                    // EnrouteWaypointsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // HELIPORTS
                case bool _ when index4 == 'H' && index12 == 'F':
                    // HeliportApproachProceduresCifpParser.Parse(line, cifpDataCollections);
                    break;

                // HELIPORT MINIMUM SECTOR ALTITUDES
                case bool _ when index4 == 'H' && index12 == 'S':
                    // HeliportMinimumSectorAltitudeCifpParser.Parse(line, cifpDataCollections);
                    break;

                // HELIPORT STANDARD INSTRUMENT DEPARTURES
                case bool _ when index4 == 'H' && index12 == 'D':
                    // HeliportStandardInstrumentDeparturesCifpParser.Parse(line, cifpDataCollections);
                    break;

                // HELIPORT TERMINAL WAYPOINTS
                case bool _ when index4 == 'H' && index12 == 'C':
                    // HeliportTerminalWaypointsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // HELIPORTS
                case bool _ when index4 == 'H' && index12 == 'A':
                    HeliportsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // LOCALIZER AND GLIDE SLOPE
                case bool _ when index4 == 'P' && index12 == 'I':
                    // LocalizerAndGlideSlopeCifpParser.Parse(line, cifpDataCollections);
                    break;

                // NNB NAVAIDS
                case bool _ when index4 == 'D' && index5 == 'B':
                    NdbNavaidsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // PATH POINT
                case bool _ when index4 == 'P' && index12 == 'P':
                    // PathPointCifpParser.Parse(line, cifpDataCollections);
                    break;

                // STANDARD INSTRUMENT DEPARTURES
                case bool _ when index4 == 'P' && index12 == 'D':
                    // StandardInstrumentDeparturesCifpParser.Parse(line, cifpDataCollections);
                    break;

                // STANDARD TERMINAL ARRIVAL ROUTES
                case bool _ when index4 == 'P' && index12 == 'E':
                    // StandardTerminalArrivalRoutesCifpParser.Parse(line, cifpDataCollections);
                    break;

                // SPECIAL USE RESTRICTIVE
                case bool _ when index4 == 'U' && index5 == 'R':
                    // SpecialUseRestrictiveCifpParser.Parse(line, cifpDataCollections);
                    break;

                // GRID MORA
                case bool _ when (index4 == 'A' && index5 == 'S'):
                    // GridMora.Parse(line, cifpDataCollections);
                    break;

                // TERMINAL NAVAIDS
                case bool _ when index4 == 'P' && index5 == 'N':
                    TerminalNavaidsCifpParser.Parse(line, cifpDataCollections);
                    break;

                // VHF NAVAIDS
                case bool _ when index4 == 'D' && index5 == ' ':
                    VhfNavaidsCifpParser.Parse(line, cifpDataCollections);
                    break;
                default:
                    break;
            }
        }
    }
}

/*
ARINC 424 Data Structure:

	Master Airline Content
	
		Navaid Section (D)
			VHF Navaid Section (D), Subsection (Blank)
			NDB Navaid Section (D), Subsection (B)
	
		Enroute Section
			Enroute Waypoint Section (E), Subsection (A)
			Enroute Airway Marker Section (E), Subsection (M)
			Holding Patterns (E), Subsection (P)
			Enroute Airways Section (E), Subsection (R)
			Enroute Airways Restrictions Section (E), Subsection (U)
			Enroute Communications Section (E), Subsection (V)
	
		Airport Section (P)
			Airport Reference Points Section (P), Subsection (A)
			Airport Gates Section (P), Subsection (B)
			Airport Terminal Waypoints Section (P), Subsection (C)
			Airport Standard Instrument Departures (SIDs) Section (P), Subsection (D)
			Airport Standard Terminal Arrival Routes (STARs) Section (P), Subsection (E)
			Airport Approaches Section (P), Subsection (F)
			Airport Runway Section (P), Subsection (G)
			Airport and Heliport Localizer/Glide Slope Section (P), Subsection (I)
			Airport and Heliport MLS Section (P), Subsection (L)
			Airport and Heliport Marker/Locator Marker Section (P), Subsection (M)
			MSA Section (P), Subsection (S)
			Airport Communications Section (P), Subsection (V)
			Airport and Heliport Terminal NDB Section (P), Subsection (N)
			Airport and Heliport Path Point Section (P), Subsection (P)
			Flight Planning Arrival/Departure Data Record Section (P), Subsection (R)
			GNSS Landing System (GLS) Section (P), Subsection (T)
			Airport Terminal Arrival Altitude Section (P), Subsection (K)
	
		Company Route and Alternation Destination Section (R)
			Company Route Section (R), Subsection (Blank)
			The Alternate Record Section (R), Subsection (A)
	
		Special Use Airspace Section (U)
			Restrictive Airspace Section (U), Subsection (R)
			FIR/UIR Section (U), Subsection (F)
			Controlled Airspace Section (U), Subsection (C)
	
		Cruising Table Section (T)
			Cruising Tables Section (T), Subsection (C)
			Geographical Reference Table Section (T), Subsection (G)
	
		MORA Section (A), Subsection (S)
	
		Preferred Routes Section (E), Subsection (T)
	
	Master Helicopter Content
		Jointly and Specifically Used Sections/Subsections
		Heliport Section (H), Subsection (A)
		Heliport Terminal Waypoints Section (H), Subsection (C)
		Heliport Standard Instrument Departures (SIDs) Section (H), Subsection (D)
		Heliport Standard Terminal Arrival Routes (STARs) Section (H), Subsection (E)
		Heliport Approaches Section (H), Subsection (F)
		Heliport MSA Section (H), Subsection (S)
		Heliport Communications Section (H), Subsection (V)
		Heliport Terminal Arrival Area Section (H), Subsection (K)

| Section Code | Section Name   | Subsection Code | Subsection Name             |
|--------------|----------------|------------------|------------------------------|
| A            | MORA           | S                | Grid MORA                    |
| D            | Navaid         |                  | VHF Navaid                   |
|              |                | B                | NDB Navaid                   |
| E            | Enroute        | A                | Waypoints                    |
|              |                | M                | Airway Markers               |
|              |                | P                | Holding Patterns             |
|              |                | R                | Airways and Routes           |
|              |                | T                | Preferred Routes             |
|              |                | U                | Airway Restrictions          |
|              |                | V                | Communications               |
| H            | Heliport       | A                | Pads                         |
|              |                | C                | Terminal Waypoints           |
|              |                | D                | SIDs                         |
|              |                | E                | STARs                        |
|              |                | F                | Approach Procedures          |
|              |                | K                | TAA                          |
|              |                | S                | MSA                          |
|              |                | V                | Communications               |
| P            | Airport        | A                | Reference Points             |
|              |                | B                | Gates                        |
|              |                | C                | Terminal Waypoints           |
|              |                | D                | SIDs                         |
|              |                | E                | STARs                        |
|              |                | F                | Approach Procedures          |
|              |                | G                | Runways                      |
|              |                | I                | Localizer/Glide Slope        |
|              |                | K                | TAA                          |
|              |                | L                | MLS                          |
|              |                | M                | Localizer Marker             |
|              |                | N                | Terminal NDB                 |
|              |                | P                | Path Point                   |
|              |                | Q                | Flt Planning ARR/DEP         |
|              |                | S                | MSA                          |
|              |                | T                | GLS Station                  |
|              |                | V                | Communications               |
| R            | Company Routes |                  | Company Routes               |
|              |                | A                | Alternate Records            |
| T            | Tables         | C                | Cruising Tables              |
|              |                | G                | Geographical Reference       |
|              |                | N                | RNAV Name Table              |
| U            | Airspace       | C                | Controlled Airspace          |
|              |                | F                | FIR/UIR                      |
|              |                | R                | Restrictive Airspace         |


FAA CIFP Data Structure:

	Airports and heliports (PA and HA)
	Runways (PG)
	VHF Navaids (D)
	NDB Navaids (DB)
	Terminal Navaids (PN)
	Localizer and Glide Slope Records (PI)
	Path Point Records, Primary and Continuation (PP)
	MSA Records (PS and HS)
	Enroute Waypoints (EA)
	Terminal Waypoints (PC and HC)
	SIDs (PD)
	STARs (PE)
	Approaches, including Level of Service continuation records (PF and HF)
	Airways (ER)
	Class B, C, and D Airspace (UC)
	Special Use Airspace, Primary and Continuation (UR)
	Grid MORA (AS)
*/