namespace BankAccountKata.Console
{
    public class StatementPrinter {
        
        private readonly TextWriter _writer;

        public StatementPrinter(TextWriter writer)
        {
            _writer = writer;
        }

        public void PrintStatement(SortedList<DateTime, int> transactions)
        {
            static string Format(KeyValuePair<DateTime, int> transaction, int total) => 
                $"{transaction.Key.ToShortDateString()} || {transaction.Value} || {total}";

            var runningTotal = 0;
            var lines = transactions
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
