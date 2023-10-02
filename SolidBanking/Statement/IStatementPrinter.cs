namespace SolidBanking.Statement;

public interface IStatementPrinter<in TItem>
{
    string PrintStatement(IEnumerable<IStatementLine<TItem>> transactions);
}
