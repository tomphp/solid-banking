namespace SolidBanking.TransactionLog;

public class InMemoryLogStore<TItem> : ILogStore<TItem>
{
    private readonly List<TItem> _items = new();

    public void Add(TItem item) => _items.Add(item);

    public IEnumerable<TItem> Items => _items;
}
