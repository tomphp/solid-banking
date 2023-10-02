namespace SolidBanking.TransactionLog;

public interface IBalancedTransactionLine
{
    DateOnly Date { get; }

    int Amount { get; }

    int Balance { get; }
}
