namespace TP1_POO.ATM
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public string Pin { get; set; } // en la práctica no guardar PIN en texto plano
        public Account LinkedAccount { get; set; }

        public Card(string cardNumber, string holderName, string pin, Account account)
        {
            CardNumber = cardNumber;
            HolderName = holderName;
            Pin = pin;
            LinkedAccount = account;
        }
    }
}
