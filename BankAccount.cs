using System;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime;


namespace BankingAPI;

public class BankAccount
{
    private static int _accountCounter = 1;
    public int Id { get; set; }
    public string Customer_Name { get; private set; }
    public int AccountNumber { get; private set; }
    public string AccountId { get; private set; }
    public decimal Account_Balance { get; private set; }
    public int Pin { get; private set; }
    public decimal Initial_Deposit { get; private set; }
    public string? Nickname { get; private set; }
    public decimal? CreditLimit { get; private set; }
    public string? PhoneNumber { get; private set; }
    private  List<Transaction> _transactions = new List<Transaction>();
    public BankAccount(int id, string customer_Name, int accountNumber, decimal account_Balance, decimal initial_Deposit,
            int pin, string? nickname = null, decimal? creditLimit = null, string? phoneNumber = null)
    {
        // Add these validation patterns one by one:

        Nickname = nickname;
        CreditLimit = creditLimit;
        PhoneNumber = phoneNumber;
        // 1. First, validate the ID (should be positive)
        // Pattern: if (id <= 0) throw  ArgumentException("message", nameof(id));
        if (id <= 0)
            throw new ArgumentException("Id ga number sii posative ah", nameof(id));
        // 2. Then validate customer name (null/empty check)
        if (string.IsNullOrWhiteSpace(customer_Name))
            throw new ArgumentException("Fadlan Magaca macamilka geli", nameof(customer_Name));

        // AccountNumber check if  null 
        if (accountNumber == 0) throw new ArgumentException("Account Number should not be null or empty", nameof(accountNumber));
        // Pattern: if (string.IsNullOrWhiteSpace(customer_Name)) ...

        // 3. Validate account balance (cannot be negative)
        if (account_Balance < 0)
            throw new ArgumentException("Balance 1 kama yaraano karo! lacag 0 ka badan ku shub!", nameof(account_Balance));
        // Pattern: if (account_Balance < 0) ...

        // 4. Business rule: initialDeposit should match account_Balance
        if (initial_Deposit <= 0)
            throw  new ArgumentException("Balanace should not be null or negative", nameof(initial_Deposit));
        // Pattern: if (initialDeposit != account_Balance) ...

        // 5. Finally assign the validated values
        Id = id;
        Customer_Name = customer_Name.Trim();
        AccountNumber = accountNumber;
        Account_Balance = account_Balance;
        Initial_Deposit = initial_Deposit;
        Pin = pin;
        AccountId = $"ACCOUNT_AT_{_accountCounter++:D3}";


        // ... continue with others
    }

    public void Deposit(decimal amount)
    {

        // check the edge cases

        if (amount <= 0) throw new ArgumentException("The amount should be Posative!", nameof(amount));


        // warning if the money is more then the usaul and later flag it if they proceed.
        if (amount >= 10000)
        {

            Console.WriteLine("That is large sume of Money!");
        }

        // update the balannce 

        Account_Balance += amount;

        var transaction =  new Transaction(
            "Deposit",
            amount,
            DateTime.Now,
            this.AccountId,
            this.Account_Balance
        );

        // add now the transaction 
        _transactions.Add(transaction);


    }

    // Withdraw 
    public void Withdraw(decimal amount)
    {

        // Edch Case
        if (amount < 10) throw new ArgumentException("Please choose the minumum of withraw 10 Euros ..", nameof(amount));

        // Balance check if zero no withdraw .. 
        if (amount > Account_Balance) throw new  ArgumentException("Your Balance is insuficent!", nameof(amount));
        // update the balance and make the withdraw happen
        Account_Balance -= amount;

        Console.WriteLine($"Your withdrawal money is being processed please wait! {amount}");
        //Thread.Sleep(3000);
        Console.WriteLine("Please take your Money!");

        var transaction = new  Transaction(
            "Self-service withdrawal",
            amount,
            DateTime.Now,
            this.AccountId,
            this.Account_Balance
        );

        _transactions.Add(transaction);
    }

    // Transfer Method
    public bool Transfer(BankAccount destinationAccount, decimal amount)
    {

        // Check null and and negative numbers 
        if (destinationAccount == null) throw new ArgumentNullException(nameof(destinationAccount));
        // Check amount 
        if (amount <= 0)
            throw new ArgumentException("Transfer amount must be posative", nameof(amount));
        // Same Account check
        if (destinationAccount.Id == this.Id)
            throw new ArgumentException("Can not transfer to same account!", nameof(destinationAccount.Id));

        //Balance Check
        if (amount > this.Account_Balance)
            throw new ArgumentException("Your account balance is in sufficent!", nameof(amount));

        // make the transer
        this.Account_Balance -= amount;
        destinationAccount.Account_Balance += amount;

        // Transaction register

        var transaction = new  Transaction(
            "TRANSFER_SEND",
            amount,
            DateTime.Now,
            this.AccountId,
            this.Account_Balance,
            this.AccountId,
            destinationAccount.AccountId
        );


        // _transactions(senderTransaction);
        _transactions.Add(transaction);

        var receivedTransection = new  Transaction(
            "TRANSFER_RECEIVER",
            amount,
            DateTime.Now,
            destinationAccount.AccountId,
            destinationAccount.Account_Balance,
            this.AccountId,
            destinationAccount.AccountId
            
            );
        destinationAccount.RecordTransaction(receivedTransection);
        //_transactions.Add(receivedTransection);
        // save the Receiver transaction deteils 
        //  destinationAccount._transactions.Add(receivedTransection);



        return true;
    }

    public void RecordTransaction(Transaction transaction)
    {


        if (transaction == null) throw new ArgumentNullException("This is Null Value not allowed", nameof(transaction));

        _transactions.Add(transaction);
      
        
    }


    // Test Transaction 

    public void ShowLastTransactions()
    {
        if (_transactions.Count == 0)
        {
            Console.WriteLine("There is not Transaction at all!");
            return;
        }
        var lastTransaction = _transactions[_transactions.Count - 1];
        Console.WriteLine($"Printing Transactions: {lastTransaction.TransactionType} Transaction Amount: {lastTransaction.Amount}");
    }
}

