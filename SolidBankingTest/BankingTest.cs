using SolidBanking;
using SolidBanking.Statement;
using SolidBanking.TransactionLog;

namespace SolidBankingTest;

public class BankingTest
{
    private readonly MockCurrentDateProvider _currentDateProvider;
    private readonly BankAccount<BalancedTransactionLog.IBalancedTransactionLine> _bankAccount;

    public BankingTest()
    {
        _currentDateProvider = new MockCurrentDateProvider();
        _bankAccount = new BankAccount<BalancedTransactionLog.IBalancedTransactionLine>(
            _currentDateProvider,
            new TabbedStatementPrinter(),
            new BalancedTransactionLog(new InMemoryLogStore<BalancedTransactionLog.BalancedTransaction>())
        );
    }

    [Fact]
    public void PrintStatementReturnsOnlyHeadingWhenNoTransactions()
    {
        var statement = _bankAccount.PrintStatement();

        Assert.Equal(
            "Date\tAmount\tBalance",
            statement
        );
    }

    [Fact]
    public void PrintStatementReturnsDepositTransaction()
    {
        _currentDateProvider.SetCurrentDate(new DateOnly(2020, 5, 1));
        _bankAccount.Deposit(500);

        var statement = _bankAccount.PrintStatement();

        Assert.Equal(
            "Date\tAmount\tBalance\n" +
            "2020-05-01\t+500\t500",
            statement
        );
    }

    [Fact]
    public void PrintStatementReturnsMultipleDepositTransactionsOnTheSameDay()
    {
        _currentDateProvider.SetCurrentDate(new DateOnly(2020, 5, 1));
        _bankAccount.Deposit(500);
        _bankAccount.Deposit(100);

        var statement = _bankAccount.PrintStatement();

        Assert.Equal(
            "Date\tAmount\tBalance\n" +
            "2020-05-01\t+500\t500\n" +
            "2020-05-01\t+100\t600",
            statement
        );
    }

    [Fact]
    public void PrintStatementReturnsMultipleDepositTransactionsOnDifferentDays()
    {
        _currentDateProvider.SetCurrentDate(new DateOnly(2020, 5, 1));
        _bankAccount.Deposit(500);
        _currentDateProvider.SetCurrentDate(new DateOnly(2020, 6, 3));
        _bankAccount.Deposit(100);

        var statement = _bankAccount.PrintStatement();

        Assert.Equal(
            "Date\tAmount\tBalance\n" +
            "2020-05-01\t+500\t500\n" +
            "2020-06-03\t+100\t600",
            statement
        );
    }

    [Fact]
    public void PrintStatementReturnsMultipleWithdrawelsTransactionsOnDifferentDays()
    {
        _currentDateProvider.SetCurrentDate(new DateOnly(2020, 5, 1));
        _bankAccount.Withdraw(500);
        _currentDateProvider.SetCurrentDate(new DateOnly(2020, 6, 3));
        _bankAccount.Withdraw(100);

        var statement = _bankAccount.PrintStatement();

        Assert.Equal(
            "Date\tAmount\tBalance\n" +
            "2020-05-01\t-500\t-500\n" +
            "2020-06-03\t-100\t-600",
            statement
        );
    }
}
