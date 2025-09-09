using System.Text;

namespace TP1_POO
{
    public enum PlanetType
    {
        GASEOSO,
        TERRESTRE,
        ENANO
    }

    public class Planet
    {
        public string? Name { get; set; } = null;
        public int SatelliteCount { get; set; } = 0;
        public double MassKg { get; set; } = 0.0;
        public double VolumeKm3 { get; set; } = 0.0;
        public int DiameterKm { get; set; } = 0;
        public int DistanceMillionKm { get; set; } = 0;
        public PlanetType Type { get; set; } = PlanetType.ENANO;
        public bool Observable { get; set; } = false;

        private const double AU_IN_KM = 149_597_870.0;
        private const double ASTEROID_BELT_UPPER_AU = 3.4;
        private const double ASTEROID_BELT_UPPER_MILLIONS_KM = ASTEROID_BELT_UPPER_AU * AU_IN_KM / 1_000_000.0;

        public Planet(
            string name,
            int satelliteCount,
            double massKg,
            double volumeKm3,
            int diameterKm,
            int distanceMillionKm,
            PlanetType type,
            bool observable)
        {
            Name = name;
            SatelliteCount = satelliteCount;
            MassKg = massKg;
            VolumeKm3 = volumeKm3;
            DiameterKm = diameterKm;
            DistanceMillionKm = distanceMillionKm;
            Type = type;
            Observable = observable;
        }

        public Planet() { }

        public string GetInfoString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("----- PLANET INFO -----");
            sb.AppendLine($"Nombre: {Name ?? "null"}");
            sb.AppendLine($"Satélites: {SatelliteCount}");
            sb.AppendLine($"Masa (kg): {MassKg}");
            sb.AppendLine($"Volumen (km³): {VolumeKm3}");
            sb.AppendLine($"Diámetro (km): {DiameterKm}");
            sb.AppendLine($"Distancia media al Sol (millones km): {DistanceMillionKm}");
            sb.AppendLine($"Tipo: {Type}");
            sb.AppendLine($"Observable a simple vista: {Observable}");
            sb.AppendLine($"Densidad (kg/km³): {Density():F6}");
            sb.AppendLine($"¿Es planeta exterior? {(IsExterior() ? "Sí" : "No")}");
            sb.AppendLine("------------------------");
            return sb.ToString();
        }

        public override string ToString() => GetInfoString();

        public double Density()
        {
            if (VolumeKm3 == 0.0)
            {
                return 0.0;
            }
            return MassKg / VolumeKm3;
        }

        public bool IsExterior()
        {
            return DistanceMillionKm > ASTEROID_BELT_UPPER_MILLIONS_KM;
        }
    }
}
