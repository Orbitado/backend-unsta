using Xunit;
using TP1_POO.ATM;

namespace TP1_POO.Tests
{
    public class ATMTests
    {
        [Fact]
        public void Withdraw_Succeeds_When_Enough_Balance_And_Cash()
        {
            var acc = new Account("0001", "Juan", 1000m);
            var card = new Card("1111-2222", "Juan", "1234", acc);
            var atm = new ATM(500m);

            bool result = atm.Withdraw(card, "1234", 200m, out string message);

            Assert.True(result);
            Assert.Equal("Retiro exitoso.", message);
            Assert.Equal(800m, acc.Balance);
            Assert.Equal(300m, atm.CashAvailable);
        }

        [Fact]
        public void Withdraw_Fails_When_Wrong_Pin()
        {
            var acc = new Account("0001", "Juan", 1000m);
            var card = new Card("1111-2222", "Juan", "1234", acc);
            var atm = new ATM(500m);

            bool result = atm.Withdraw(card, "0000", 100m, out string message);

            Assert.False(result);
            Assert.Equal("PIN incorrecto.", message);
            Assert.Equal(1000m, acc.Balance);
            Assert.Equal(500m, atm.CashAvailable);
        }
    }
}
