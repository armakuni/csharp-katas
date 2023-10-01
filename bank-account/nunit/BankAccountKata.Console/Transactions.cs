namespace BankAccountKata.Console
{
    public class Transactions
    {
        private readonly SortedList<DateTime, int> _transactions = new();

        internal void Add(DateTime dateTime, int depositAmount) =>
            _transactions.Add(dateTime, depositAmount);

        internal void Deposit(DateTime dateTime, int depositAmount) =>
            Add(dateTime, -depositAmount);

        internal void PrintStatement(StatementPrinter printer) => 
            printer.PrintStatement(_transactions);
    }
}
