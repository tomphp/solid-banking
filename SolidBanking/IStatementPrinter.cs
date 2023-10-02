namespace SolidBanking;

public interface IStatementPrinter
{
    string PrintStatement(List<(DateOnly, int)> transactions);
}