namespace BankAccountKata.Console
{
    public class AccountService : IAccountService
    {
        private readonly TextWriter _writer;
        private readonly SortedList<DateTime, int> _transactions = new();

        public AccountService(TextWriter writer) =>
            _writer = writer;

        public void Deposit(DateTime dateTime, int depositAmount) =>
            _transactions.Add(dateTime, depositAmount);

        public void Withdraw(DateTime dateTime, int depositAmount) =>
            Deposit(dateTime, -depositAmount);

        public void PrintStatement()
        {
            static string Format(KeyValuePair<DateTime, int> transaction, int total) => 
                $"{transaction.Key.ToShortDateString()} || {transaction.Value} || {total}";

            var runningTotal = 0;
            var lines = _transactions
                .Select(transaction =>
                {
                    runningTotal += transaction.Value;
                    return Format(transaction, runningTotal);
                })
                .Concat(new[] { "Date      || Amount || Balance" })
                .Reverse();

            _writer.Write(string.Join(Environment.NewLine, lines));
        }

    }
}
