using Xunit;
using TP1_POO;

namespace TP1_POO.Tests
{
    public class PlanetTests
    {
        [Fact]
        public void Density_Returns_Correct_Value()
        {
            var p = new Planet("P1", 0, 1000.0, 2.0, 1, 10, PlanetType.ENANO, false);
            double density = p.Density();
            Assert.Equal(500.0, density, 6);
        }

        [Theory]
        [InlineData(509, true)]
        [InlineData(508, false)]
        public void IsExterior_Behaves_As_Expected(int distanceMillionsKm, bool expected)
        {
            var p = new Planet("P", 0, 1.0, 1.0, 1, distanceMillionsKm, PlanetType.GASEOSO, false);
            Assert.Equal(expected, p.IsExterior());
        }

        [Fact]
        public void GetInfoString_Includes_Name_And_Type()
        {
            var p = new Planet("Tierra", 1, 5.97219e24, 1.08321e12, 12742, 149, PlanetType.TERRESTRE, true);
            string info = p.GetInfoString();
            Assert.Contains("Tierra", info);
            Assert.Contains("TERRESTRE", info);
            Assert.Contains("Densidad", info);
        }
    }
}
