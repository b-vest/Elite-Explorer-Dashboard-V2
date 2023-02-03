using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    public class ElementConvert
    {
        public string? name { get; set; }
        public string? symbol { get; set; }
    }
    public class MaterialsOBject
    {
        public string? Name { get; set; }
        public float Percent { get; set; }
    }

    public class StoredMaterialsObject
    {
        public string? Name { get; set; }
        public int Count { get; set; }
    }

    public class ParentsObject
    {
        public int? Planet { get; set; }
        public int? Star { get; set; }
        public int? Null { get; set; }
    }
    public class FSSBodySignalsObject
    {
        public string? Type_Localised { get; set; }
        public int Count { get; set; }
    }
    public class CompositionObject
    {
        public double Rock { get; set; }
        public double Ice { get; set; }
        public double Metal { get; set; }
    }
    public class AtmosphereCompositionObject
    {
        public string? Name { get; set; }
        public double Percent { get; set; }
    }
    public class Vextors
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }
    public class FSSAllBodiesFound
    {
        public string? @event { get; set; }
        public string? SystemName { get; set; }
        public long SystemAddress { get; set; }
        public int Count { get; set; }
        public string? timestamp { get; set; }
    }

    public class DisembarkObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public int BodyID { get; set; }
        public string? Body { get; set; }
    }
    public class TouchdownObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public string? Body { get; set; }
        public double Latitude { get; set; }
        public double Longidude { get; set; }
        public bool Multicrew { get; set; }
        public bool OnPlanet { get; set; }
        public bool OnStation { get; set; }
        public bool PlayerControlled { get; set; }
        public string? Starsystem { get; set; }
        public long SystemAddress { get; set; }
    }
    public class SAASignalsFoundObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public int BodyID { get; set; }
        public string? BodyName { get; set; }
        public List<FSSBodySignalsObject>? Signals { get; set; }
        public long SystemAddress { get; set; }
    }

    public class SAAScanCompleteObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public int BodyID { get; set; }
        public string? BodyName { get; set; }
        public int EfficiencyTarget { get; set; }
        public int ProbesUsed { get; set; }
        public long SystemAddress { get; set; }
    }
    public class FSDTargetObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public string? Name { get; set; }
        public int RemainingJumpsInRoute { get; set; }
        public string? StarClass { get; set; }
        public long SystemAddress { get; set; }
    }
    public class FSDJumpObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public string? Body { get; set; }
        public int BodyID { get; set; }
        public string? BodyType { get; set; }
        public double FuelLevel { get; set; }
        public double FuelUsed { get; set; }
        public double JumpDist { get; set; }
        public bool MultiCrew { get; set; }
        public int Population { get; set; }
        public List<double>? StarPos { get; set; }
        public string? StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public bool Taxi { get; set; }

    }
    public class MaterialCollectedObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public int? Count { get; set; }
    }
    public class FSSDiscoveryScanObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public int BodyCount { get; set; }
        public int NonBodyCount { get; set; }
        public double Progress { get; set; }
        public long SystemAddress { get; set; }
        public string? SystemName { get; set; }

    }
    public class FuelScoopObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public double Scooped { get; set; }
        public double Total { get; set; }
    }
    public class LoadGameObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public string? Commander { get; set; }
        public int Credits { get; set; }
        public double FuelLevel { get; set; }
        public double FuelCapacity { get; set; }
        public string? GameMode { get; set; }
        public string? gameversion { get; set; }
        public bool Horizons { get; set; }
        public bool Odyssey { get; set; }
        public string? Ship { get; set; }
        public string? ShipIdent { get; set; }
        public string? ShipName { get; set; }

    }
    public class LiftoffObject
    {
        public string? @event { get; set; }
        public string? timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Multicrew { get; set; }
        public bool OnPlanet { get; set; }
        public bool OnStation { get; set; }
        public bool PlayerControlled { get; set; }
        public string? StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public bool Taxi { get; set; }

    }

    public class MusicObject
    {
        public string? timestamp { get; set; }
        public string? @event { get; set; }
        public string? MusicTrack { get; set; }
    }
    public class ScreenshotObject
    {
        public string? @event { get; set; }
        public string? Body { get; set; }
        public string? Filename { get; set; }
        public int Heading { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double Latitude { get; set; }
        public string? System { get; set; }
        public string? timestamp { get; set; }

    }
    public class StartJumpObject
    {
        public string? @event { get; set; }
        public string? JumpType { get; set; }
        public string? StarClass { get; set; }
        public string? Starsystem { get; set; }
        public long SystemAddress { get; set; }
        public string? timestamp { get; set; }
    }

    public class ScanObjectBodyDetailed
    {
        public string? @event { get; set; }
        public double AbsoluteMagnitude { get; set; }
        public int Age_MY { get; set; }
        public double AxialTilt { get; set; }
        public double AscendingNode { get; set; }
        public string? Atmosphere { get; set; }
        public string? AtmosphereType { get; set; }
        public int BodyID { get; set; }
        public string? BodyName { get; set; }
        public double DistanceFromArrivalLS { get; set; }
        public CompositionObject? Composition { get; set; }
        public float Eccentricity { get; set; }
        public bool Landable { get; set; }
        public double MassEM { get; set; }
        public double MeanAnomaly { get; set; }
        public double OrbitalInclination { get; set; }
        public double OrbitalPeriod { get; set; }
        public List<ParentsObject>? Parents { get; set; }
        public double Periapsis { get; set; }
        public string? PlanetClass { get; set; }
        public double Radius { get; set; }
        public double RotationPeriod { get; set; }
        public string? ScanType { get; set; }
        public double SemiMajorAxis { get; set; }
        public string? StarSystem { get; set; }
        public double SurfaceGravity { get; set; }
        public double SurfacePressure { get; set; }
        public double SurfaceTemperature { get; set; }
        public long SystemAddress { get; set; }
        public string? TerraformState { get; set; }
        public bool TidalLock { get; set; }
        public bool WasDiscovered { get; set; }
        public bool WasMapped { get; set; }
        public string? StarType { get; set; }
        public double StellarMass { get; set; }
        public int Sublclass { get; set; }
        public string? Luminosity { get; set; }
        public List<MaterialsOBject>? Materials { get; set; }
        public List<FSSBodySignalsObject>? Signals { get; set; }
        public string? timestamp { get; set; }
        public List<double>? StarPos { get; set; }
        public List<AtmosphereCompositionObject>? AtmosphereComposition { get; set; }

        public double[]? XYZ { get; set; }

        public string? NeighborName { get; set; }

        public int? NeighborID { get; set; }

        public double? NeighborMeters { get; set; }
        public double? NeighborLS { get; set; }

        public int? FoundParent { get; set; }

        public double MeanAnomalyRadians { get; set; }

        public double EccentricAnomaly { get; set; }

        public double TrueAnomaly { get; set; }

        public double InclinationRadians { get; set; }

        public double AscendingNodeRadians { get; set; }

        public double PeriapsisRadians { get; set; }

        public double DistanceToParentMeters { get; set; }

        public double DistancetoParentsLS { get; set; }

        public List<int> Children { get; set; }

        public int GridRow { get; set; }
    }
    public class EDData
    {
        public string? @event { get; set; }
        public string? StarSystem { get; set; }
        public string? BodyName { get; set; }
        public bool Landable { get; set; }
        public string? PlanetClass { get; set; }
        public bool WasMapped { get; set; }
        public string? Atmosphere { get; set; }
        public double OrbitalInclination { get; set; }
        public double SemiMajorAxis { get; set; }
        public long SystemAddress { get; set; }
        public double RotationPeriod { get; set; }
        public string? TerraformState { get; set; }
        public string? AtmosphereType { get; set; }
        public double DistanceFromArrivalLS { get; set; }
        public int BodyID { get; set; }
        public double SurfacePressure { get; set; }
        public double AscendingNode { get; set; }
        public bool WasDiscovered { get; set; }
        public double SurfaceGravity { get; set; }
        public double SurfaceTemperature { get; set; }
        public double MassEM { get; set; }
        public string? Volcanism { get; set; }
        public string? ScanType { get; set; }
        public double Periapsis { get; set; }
        public double AxialTilt { get; set; }
        public double OrbitalPeriod { get; set; }
        public double Radius { get; set; }
        public bool TidalLock { get; set; }
        public double Eccentricity { get; set; }
        public double MeanAnomaly { get; set; }
        public string? Filename { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string? Body { get; set; }
        public double Total { get; set; }
        public double FuelLevel { get; set; }
        public double Scooped { get; set; }
        public string? Name { get; set; }
        public string? Ship { get; set; }
        public string? ShipName { get; set; }
        public string? ShipIdent { get; set; }
        public string? StarType { get; set; }
        public string? Luminosity { get; set; }
        public int Age_MY { get; set; }
        public double StellarMass { get; set; }
        public double AbsoluteMagnitude { get; set; }
        public List<MaterialsOBject>? Materials { get; set; }
        public CompositionObject? Composition { get; set; }
        public List<FSSBodySignalsObject>? Signals { get; set; }
        public List<ParentsObject>? Parents { get; set; }
        public List<StoredMaterialsObject>? Raw { get; set; }
        public string? timestamp { get; set; }
        public List<double>? StarPos { get; set; }
        public List<AtmosphereCompositionObject>? AtmosphereComposition { get; set; }
        public bool PlayerControlled { get; set; }
        public string? SRVType_Localised { get; set; }
        public string? Loadout { get; set; }
        public string? SRVType { get; set; }

        public string? StarClass { get; set; }

        public int RemainingJumpsInRoute { get; set; }

        public string? JumpType { get; set; }

        public string? MusicTrack { get; set; }

        public double FuelMain { get; set; }
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public string? Commander { get; set; }
        public int BodyCount { get; set; }
        public int NonBodyCount { get; set; }

        public double[]? XYZ { get; set; }

        public string? NeighborName { get; set; }

        public int? NeighborID { get; set; }

        public int? FoundParent { get; set; }

        public double? MeanAnomalyRadians { get; set; }

        public double? EccentricAnomaly { get; set; }

        public double? TrueAnomaly { get; set; }

        public double? InclinationRadians { get; set; }

        public double? AscendingNodeRadians { get; set; }

        public double? PeriapsisRadians { get; set; }

        public double? DistanceToParentMeters { get; set; }

        public double? DistancetoParentsLS { get; set; }

        public int[]? Children { get; set; }
        public int? Parent { get; set; }

       

    }
}
