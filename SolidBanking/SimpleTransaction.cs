using SolidBanking.TransactionLog;

namespace SolidBanking;

public sealed record SimpleTransaction(DateOnly Date, int Amount) : ITransaction;
