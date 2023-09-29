namespace BankAccountKata.Console
{
    public interface IAccountService
    {
        void Deposit(DateTime dateTime, int depositAmount);
        void PrintStatement();
        void Withdraw(DateTime dateTime, int depositAmount);
    }
}