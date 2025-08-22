using System.Collections.Generic;

namespace FAA_DATA_HANDLER.Models.CIFP
{
    public sealed class CifpDataCollections
    {
        public List<AirlineTerminalWaypointsCifpDataModel> AirlineTerminalWaypoints { get; } = new();
        public List<AirportApproachProceduresCifpDataModel> AirportApproachProcedures { get; } = new();
        public List<AirportMinimumSectorAltitudeCifpDataModel> AirportMinimumSectorAltitudes { get; } = new();
        public List<AirportsCifpDataModel> Airports { get; } = new();
        public List<AirwaysCifpDataModel> Airways { get; } = new();
        public List<ControlledClassAirspaceBCDCifpDataModel> ControlledClassAirspaceBCD { get; } = new();
        public List<EnrouteWaypointsCifpDataModel> EnrouteWaypoints { get; } = new();
        public List<HeaderInfoCifpDataModel> HeaderInfo { get; } = new();
        public List<HeliportApproachProceduresCifpDataModel> HeliportApproachProcedures { get; } = new();
        public List<HeliportMinimumSectorAltitudeCifpDataModel> HeliportMinimumSectorAltitudes { get; } = new();
        public List<HeliportsCifpDataModel> Heliports { get; } = new();
        public List<HeliportStandardInstrumentDeparturesCifpDataModel> HeliportStandardInstrumentDepartures { get; } = new();
        public List<HeliportTerminalWaypointsCifpDataModel> HeliportTerminalWaypoints { get; } = new();
        public List<LocalizerAndGlideSlopeCifpDataModel> LocalizerAndGlideSlope { get; } = new();
        public List<NnbNavaidsCifpDataModel> NnbNavaids { get; } = new();
        public List<PathPointCifpDataModel> PathPoints { get; } = new();
        public List<RunwaysCifpDataModel> Runways { get; } = new();
        public List<SpecialUseRestrictiveCifpDataModel> SpecialUseRestrictive { get; } = new();
        public List<StandardInstrumentDeparturesCifpDataModel> StandardInstrumentDepartures { get; } = new();
        public List<StandardTerminalArrivalRoutesCifpDataModel> StandardTerminalArrivalRoutes { get; } = new();
        public List<TerminalNavaidsCifpDataModel> TerminalNavaids { get; } = new();
        public List<VhfNavaidsCifpDataModel> VhfNavaids { get; } = new();
    }
}
