using SolidBanking.Statement;

namespace SolidBanking.TransactionLog;

public sealed class BalancedTransactionLog<TTransaction>
    : ITransactionLog<TTransaction>, IStatement<IBalancedTransactionLine>
    where TTransaction: ITransaction
{
    public sealed record BalancedTransaction(int Balance, TTransaction Transaction)
        : IStatementLine<IBalancedTransactionLine>, IBalancedTransactionLine
    {
        public DateOnly Date => Transaction.Date;
        public int Amount => Transaction.Amount;

        public string PrintStatementLine(IStatementLinePrinter<IBalancedTransactionLine> statementLinePrinter) =>
            statementLinePrinter.PrintStatementLine(this);
    }

    private int _balance;
    private readonly ILogStore<BalancedTransaction> _store;

    public BalancedTransactionLog(ILogStore<BalancedTransaction> store) => _store = store;

    public void Add(TTransaction transaction)
    {
        _balance += transaction.Amount;
        _store.Add(new BalancedTransaction(_balance, transaction));
    }

    public string PrintStatement(IStatementPrinter<IBalancedTransactionLine> statementPrinter) =>
        statementPrinter.PrintStatement(_store.Items);
}
