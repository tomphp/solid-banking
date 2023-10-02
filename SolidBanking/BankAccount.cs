namespace SolidBanking;

public sealed class BankAccount
{
    private readonly List<(DateOnly, int)> _transactions = new();
    private readonly ICurrentDateProvider _currentDateProvider;
    private readonly IStatementPrinter _statementPrinter;

    public BankAccount(ICurrentDateProvider currentDateProvider, IStatementPrinter statementPrinter)
    {
        _currentDateProvider = currentDateProvider;
        _statementPrinter = statementPrinter;
    }

    public void Deposit(int amount)
    {
        _transactions.Add((CurrentDate(), amount));
    }

    public void Withdraw(int amount)
    {
        throw new NotImplementedException();
    }

    public string PrintStatement() => _statementPrinter.PrintStatement(_transactions);

    private DateOnly CurrentDate()
    {
        return _currentDateProvider.CurrentDate();
    }
}