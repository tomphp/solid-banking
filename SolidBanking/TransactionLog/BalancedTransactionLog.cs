using SolidBanking.Statement;

namespace SolidBanking.TransactionLog;

public sealed class BalancedTransactionLog : ITransactionLog<BalancedTransactionLog.IBalancedTransactionLine>
{
    public interface IBalancedTransactionLine
    {
        DateOnly Date { get; }
        int Amount { get; }
        int Balance { get; }
    }

    private sealed record BalancedTransaction(int Balance, Transaction Transaction)
        : IStatementLine<IBalancedTransactionLine>, IBalancedTransactionLine
    {
        public DateOnly Date => Transaction.Date;
        public int Amount => Transaction.Amount;

        public string PrintStatementLine(IStatementLinePrinter<IBalancedTransactionLine> statementLinePrinter)
        {
            return statementLinePrinter.PrintStatementLine(this);
        }
    }

    private int _balance;
    private readonly List<BalancedTransaction> _balancedTransactions = new();

    public void Add(Transaction transaction)
    {
        _balance += transaction.Amount;
        _balancedTransactions.Add(new BalancedTransaction(_balance, transaction));
    }

    public string PrintStatement(IStatementPrinter<IBalancedTransactionLine> statementPrinter)
    {
        return statementPrinter.PrintStatement(_balancedTransactions);
    }
}