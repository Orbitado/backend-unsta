namespace TP1_POO.ATM
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, string owner, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;
            if (amount > Balance) return false;
            Balance -= amount;
            return true;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) return;
            Balance += amount;
        }
    }
}
