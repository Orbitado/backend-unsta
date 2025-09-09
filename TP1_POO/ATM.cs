namespace TP1_POO.ATM
{
    public class ATM
    {
        public decimal CashAvailable { get; private set; }

        public ATM(decimal initialCash)
        {
            CashAvailable = initialCash;
        }

        // Método no usa consola: retorna booleano y mensaje por out
        public bool Withdraw(Card card, string pin, decimal amount, out string message)
        {
            message = "";
            if (card == null) { message = "Tarjeta inválida."; return false; }
            if (card.Pin != pin) { message = "PIN incorrecto."; return false; }
            if (amount <= 0) { message = "Monto inválido."; return false; }
            if (amount > CashAvailable) { message = "Cajero sin efectivo suficiente."; return false; }
            if (amount > card.LinkedAccount.Balance) { message = "Saldo insuficiente en la cuenta."; return false; }

            bool ok = card.LinkedAccount.Withdraw(amount);
            if (!ok) { message = "Error extrayendo saldo."; return false; }

            CashAvailable -= amount;
            message = "Retiro exitoso.";
            return true;
        }

        public void Refill(decimal amount)
        {
            if (amount > 0) CashAvailable += amount;
        }
    }
}
