namespace SolidBanking.Statement;

public interface IStatementLinePrinter<in TItem>
{
    public string PrintStatementLine(TItem item);
}
