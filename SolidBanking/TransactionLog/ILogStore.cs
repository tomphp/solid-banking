namespace SolidBanking.TransactionLog;

public interface ILogStore<TItem>
{
    void Add(TItem item);

    IEnumerable<TItem> Items { get; }
}
