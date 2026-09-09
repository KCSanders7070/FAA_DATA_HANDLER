using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// Every record parsed out of one FAACIFP18 file, grouped by record type.
    /// </summary>
    /// <remarks>
    /// Continuation records are kept in their own lists rather than nested under their primary,
    /// because a continuation carries a different field layout entirely. Match one to its primary
    /// on the key columns the two share - for approaches that is airport, procedure identifier,
    /// transition identifier, sequence number and both route qualifiers.
    /// </remarks>
    public sealed class CifpDataCollections
    {
        /// <summary>Header records (HDR01 and HDR02) from the top of the file.</summary>
        public List<HeaderInfoCifpDataModel> HeaderInfo { get; } = new();

        /// <summary>Grid MORA (AS) records. 241 in cycle 2607.</summary>
        public List<GridMoraCifpDataModel> GridMora { get; } = new();

        /// <summary>VHF Navaids (D) records. 2,083 in cycle 2607.</summary>
        public List<VhfNavaidsCifpDataModel> VhfNavaids { get; } = new();

        /// <summary>NDB Navaids (DB) records. 392 in cycle 2607.</summary>
        public List<NdbNavaidsCifpDataModel> NdbNavaids { get; } = new();

        /// <summary>Enroute Waypoints (EA) records. 32,401 in cycle 2607.</summary>
        public List<EnrouteWaypointsCifpDataModel> EnrouteWaypoints { get; } = new();

        /// <summary>Airways (ER) records. 19,099 in cycle 2607.</summary>
        public List<AirwaysCifpDataModel> Airways { get; } = new();

        /// <summary>Heliports (HA) records. 6,134 in cycle 2607.</summary>
        public List<HeliportsCifpDataModel> Heliports { get; } = new();

        /// <summary>Heliport Terminal Waypoints (HC) records. 9 in cycle 2607.</summary>
        public List<HeliportTerminalWaypointsCifpDataModel> HeliportTerminalWaypoints { get; } = new();

        /// <summary>Heliport SIDs (HD) records. 15 in cycle 2607.</summary>
        public List<HeliportStandardInstrumentDeparturesCifpDataModel> HeliportStandardInstrumentDepartures { get; } = new();

        /// <summary>Heliport Approach Procedures (HF) records. 23 in cycle 2607.</summary>
        public List<HeliportApproachProceduresCifpDataModel> HeliportApproachProcedures { get; } = new();

        /// <summary>Heliport MSA (HS) records. 5 in cycle 2607.</summary>
        public List<HeliportMinimumSectorAltitudeCifpDataModel> HeliportMinimumSectorAltitude { get; } = new();

        /// <summary>Airports (PA) records. 13,321 in cycle 2607.</summary>
        public List<AirportsCifpDataModel> Airports { get; } = new();

        /// <summary>Terminal Waypoints (PC) records. 37,626 in cycle 2607.</summary>
        public List<TerminalWaypointsCifpDataModel> TerminalWaypoints { get; } = new();

        /// <summary>SIDs (PD) records. 34,605 in cycle 2607.</summary>
        public List<StandardInstrumentDeparturesCifpDataModel> StandardInstrumentDepartures { get; } = new();

        /// <summary>STARs (PE) records. 44,148 in cycle 2607.</summary>
        public List<StandardTerminalArrivalRoutesCifpDataModel> StandardTerminalArrivalRoutes { get; } = new();

        /// <summary>Airport Approach Procedures (PF) records. 122,323 in cycle 2607.</summary>
        public List<AirportApproachProceduresCifpDataModel> AirportApproachProcedures { get; } = new();

        /// <summary>Runways (PG) records. 16,805 in cycle 2607.</summary>
        public List<RunwaysCifpDataModel> Runways { get; } = new();

        /// <summary>Localizer and Glide Slope (PI) records. 1,280 in cycle 2607.</summary>
        public List<LocalizerAndGlideSlopeCifpDataModel> LocalizerAndGlideSlope { get; } = new();

        /// <summary>Terminal Navaids (PN) records. 189 in cycle 2607.</summary>
        public List<TerminalNavaidsCifpDataModel> TerminalNavaids { get; } = new();

        /// <summary>Path Point (PP) records. 4,905 in cycle 2607.</summary>
        public List<PathPointCifpDataModel> PathPoint { get; } = new();

        /// <summary>Airport MSA (PS) records. 6,045 in cycle 2607.</summary>
        public List<AirportMinimumSectorAltitudeCifpDataModel> AirportMinimumSectorAltitude { get; } = new();

        /// <summary>Class B, C and D Airspace (UC) records. 13,135 in cycle 2607.</summary>
        public List<ControlledClassAirspaceBCDCifpDataModel> ControlledClassAirspaceBCD { get; } = new();

        /// <summary>Special Use Airspace (UR) records. 28,819 in cycle 2607.</summary>
        public List<SpecialUseRestrictiveCifpDataModel> SpecialUseRestrictive { get; } = new();

        /// <summary>Heliport Approach Procedures (HF) continuation records. 1 in cycle 2607.</summary>
        public List<HeliportApproachProceduresContinuationCifpDataModel> HeliportApproachProceduresContinuation { get; } = new();

        /// <summary>Airport Approach Procedures (PF) continuation records. 6,741 in cycle 2607.</summary>
        public List<AirportApproachProceduresContinuationCifpDataModel> AirportApproachProceduresContinuation { get; } = new();

        /// <summary>Path Point (PP) continuation records. 4,905 in cycle 2607.</summary>
        public List<PathPointContinuationCifpDataModel> PathPointContinuation { get; } = new();

        /// <summary>Special Use Airspace (UR) continuation records. 1,175 in cycle 2607.</summary>
        public List<SpecialUseRestrictiveContinuationCifpDataModel> SpecialUseRestrictiveContinuation { get; } = new();

    }
}