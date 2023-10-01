using BankAccountKata.Console;

var printer = new StatementPrinter(Console.Out);
var accountService = new AccountService(printer);


accountService.Withdraw(DateTime.Now, 100);
accountService.PrintStatement();