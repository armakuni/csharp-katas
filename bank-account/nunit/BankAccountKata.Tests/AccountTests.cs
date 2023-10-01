namespace BankAccountKata.Tests
{
    internal class AccountTests
    {
        private IAccountService _accountService;
        private StringWriter _statementOutput;

        [SetUp] 
        public void SetUp() {
            _statementOutput = new StringWriter();
            var statementPrinter = new StatementPrinter(_statementOutput);
            _accountService = new AccountService(statementPrinter);
        }

        [TearDown] 
        public void TearDown()
        {
            _statementOutput.Dispose();
        }

        [Test]
        public void WhenIPrintAStatement_ItStartsWithHeaders() {
            _accountService.PrintStatement();
            var actual = _statementOutput.ToString();
            Assert.That(actual, Does.StartWith("Date      || Amount || Balance"));
        }

        [TestCase("10-01-2012", 1000)]
        public void GivenADeposit_WhenIPrintAStatement_ItIncludesTheTransaction(string depositDate, int depositAmount)
        {
            // A
            _accountService.Deposit(DateTime.Parse(depositDate), depositAmount);
            // A
            _accountService.PrintStatement();
            // A
            var actual = _statementOutput.ToString().Split(Environment.NewLine)[1];
            Assert.That(actual, Does.StartWith("10/01/2012 || 1000"));
        }

        [TestCase("14-01-2012", 500)]
        public void GivenAWithdrawal_WhenIPrintAStatement_ItIncludesTheTransaction(string depositDate, int depositAmount)
        {
            // A
            _accountService.Withdraw(DateTime.Parse(depositDate), depositAmount);
            // A
            _accountService.PrintStatement();
            // A
            var actual = _statementOutput.ToString().Split(Environment.NewLine)[1];
            Assert.That(actual, Does.StartWith("14/01/2012 || -500"));
        }

        [Test]
        public void GivenMultipleTransactions_WhenIPrintAStatement_TransactionsAreListedInReverseDateOrder()
        {
            // A
            _accountService.Withdraw(DateTime.Parse("14-01-2012"), 500);
            _accountService.Deposit(DateTime.Parse("10-01-2012"), 1000);
            _accountService.Deposit(DateTime.Parse("13-01-2012"), 2000);
            // A
            _accountService.PrintStatement();
            // A
            var actual = _statementOutput.ToString().Split(Environment.NewLine);
            Assert.That(actual.Skip(1), Is.Ordered.Descending);
        }

        [Test]
        public void GivenMultipleTransactions_WhenIPrintAStatement_ARunningTotalBalanceIsShown()
        {
            // A
            _accountService.Withdraw(DateTime.Parse("14-01-2012"), 500);
            _accountService.Deposit(DateTime.Parse("10-01-2012"), 1000);
            _accountService.Deposit(DateTime.Parse("13-01-2012"), 2000);
            // A
            _accountService.PrintStatement();
            // A
            var actual = _statementOutput.ToString().Split(Environment.NewLine)
                .Skip(1).Select(line => line.Split("||")[2].Trim());
            Assert.That(actual, Is.EquivalentTo(new[] { "2500", "3000", "1000"}));

        }
    }
}
