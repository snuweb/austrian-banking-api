using System;
namespace BankingAPI;



public class Transaction
{
    // Required properties - every transaction has these
    public string TransactionId { get; private set; }
    public string TransactionType { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string OwnerAccountId { get; private set; }
    public decimal BalanceAfter { get; private set; }

    // Optional properties - only for transfers
    public string? SenderAccountId { get; private set; }
    public string? ReceiverAccountId { get; private set; }

    // TODO: Constructor will go here

    public Transaction(string transactionType, decimal amount, DateTime timestamp, string ownerAccountId, decimal balanceAfter, string? senderAccountId = null, string? receiverAccountId = null)
    {
        TransactionId = Guid.NewGuid().ToString();

        // edge Cases
        if (string.IsNullOrWhiteSpace(transactionType))
            throw new ArgumentException("Transection can not be empty or null", nameof(transactionType));

        if (amount <= 0)
            throw new ArgumentException("Amount should be positive ", nameof(amount));

        if (string.IsNullOrWhiteSpace(ownerAccountId))
            throw new ArgumentException("Account Id can not be null or 0 ", nameof(ownerAccountId));

        TransactionType = transactionType;
        Amount = amount;
        OwnerAccountId = ownerAccountId;
        Timestamp = timestamp;
        BalanceAfter = balanceAfter;
        SenderAccountId = senderAccountId;
        ReceiverAccountId = receiverAccountId;



    }
}