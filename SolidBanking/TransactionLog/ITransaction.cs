namespace SolidBanking.TransactionLog;

public interface ITransaction
{
    DateOnly Date { get;  }

    int Amount { get; }
}
