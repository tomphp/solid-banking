namespace SolidBanking.Statement;

public interface IStatementLinePrinter<in TItem>
{
    string PrintStatementLine(TItem item);
}
