namespace SolidBanking.TransactionLog;

public interface ILogStore<TItem>
{
    public void Add(TItem item);

    public IEnumerable<TItem> Items { get; }
}
