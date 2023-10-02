using SolidBanking.Statement;
using SolidBanking.TransactionLog;

namespace SolidBanking;

public sealed class BankAccount<TTransactionLog, TStatementLine>
    where TTransactionLog: ITransactionLog<SimpleTransaction>, IStatement<TStatementLine>
{
    private readonly ICurrentDateProvider _currentDateProvider;
    private readonly IStatementPrinter<TStatementLine> _statementPrinter;
    private readonly TTransactionLog _transactionLog;

    public BankAccount(
        ICurrentDateProvider currentDateProvider,
        IStatementPrinter<TStatementLine> statementPrinter,
        TTransactionLog transactionLog
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
