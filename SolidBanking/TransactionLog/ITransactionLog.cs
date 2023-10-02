namespace SolidBanking.TransactionLog;

public interface ITransactionLog<in TTransaction>
{
    void Add(TTransaction transaction);
}
