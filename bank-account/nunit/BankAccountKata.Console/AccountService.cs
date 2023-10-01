namespace BankAccountKata.Console
{
    public class AccountService : IAccountService
    {        
        private readonly StatementPrinter _printer;

        private readonly Transactions _transactions = new();

        public AccountService(StatementPrinter printer) =>
            _printer = printer;

        public void Deposit(DateTime dateTime, int depositAmount) =>
            _transactions.Add(dateTime, depositAmount);

        public void Withdraw(DateTime dateTime, int depositAmount) =>
            _transactions.Deposit(dateTime, depositAmount);

        public void PrintStatement() =>
            _transactions.PrintStatement(_printer);
    }
}
