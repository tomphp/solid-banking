using SolidBanking.Statement;
using SolidBanking.TransactionLog;

namespace SolidBanking;

public sealed class BankAccount<TItem>
{
    private readonly ICurrentDateProvider _currentDateProvider;
    private readonly IStatementPrinter<TItem> _statementPrinter;
    private readonly ITransactionLog<TItem> _transactionLog;

    public BankAccount(
        ICurrentDateProvider currentDateProvider,
        IStatementPrinter<TItem> statementPrinter,
        ITransactionLog<TItem> transactionLog
    )
    {
        _currentDateProvider = currentDateProvider;
        _statementPrinter = statementPrinter;
        _transactionLog = transactionLog;
    }

    public void Deposit(int amount) => _transactionLog.Add(new SimpleTransaction(_currentDateProvider.CurrentDate(), amount));

    public void Withdraw(int amount) => _transactionLog.Add(new SimpleTransaction(_currentDateProvider.CurrentDate(), -amount));

    public string PrintStatement() => _transactionLog.PrintStatement(_statementPrinter);
}
