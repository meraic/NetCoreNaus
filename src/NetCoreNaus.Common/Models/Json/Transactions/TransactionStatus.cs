namespace NetCoreNaus.Common.Models.Json.Transactions
{
    public enum TransactionStatus
    {
        All,
        FinalOnly,
        FinalWithReversals,
        AllMarkedForExport,
        FinalOnlyMarkedForExport,
        FinalWithReversalsMarkedForExport,
        Unknown
    }
}
