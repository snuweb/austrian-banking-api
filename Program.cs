using System;
using System.Data;
using Microsoft.VisualBasic;

namespace BankingAPI;

// See https://aka.ms/new-console-template for more information

public class Program
{

    public static void Main(string[] args)
    {
        Bank myBank = new Bank("ErstBank", "20111", "GIBAATWW", "Feldkirch");
        Bank myBankTwo = new Bank("Reifeisan", "3200", "RLNWAATWW", "Feldkirch");
        //Console.WriteLine($"Banking System Austria the Best Bank so far is {myBank.BankName}");
        BankAccount myBankAccount = new BankAccount(12, "Sarifcoin", 33535334, 3233.0m, 3233.0m, 9371);
        //Console.WriteLine($"Waa Second Object Of Banking System: {myBankTwo.BankName}");
        myBank.CreateAccount(32, "Dalxoreeye", 23532532, 100.0m, 800.0m, 14, "Mr Dhuun", 500.0m, "123-464-6344-63");
        //myBank.PrintAllBankAccounts();
        myBank.CreateAccount(45, "Mohamed", 323233, 130.0m, 290.0m, 22, "Mr Xaaji Euro", 400.0m, "1914-42342-324-3531914-4-353");
        myBank.PrintAllBankAccounts();
        Console.WriteLine($"One Of The bigest Banks in Austria is: {myBank.ToString()}");
        Console.WriteLine($"One of The Bigest Banks in Austria  is: {myBankTwo}");

        // Deposit Testing beging here!
        var testAccount = myBank.CreateAccount(17, "Test Account", 53432532, 88.0m, 39.0m, 23, "Xariif Magaalo", 154.0m, "141-353-55-555-3335");
        Console.WriteLine($" Before Deposit test {testAccount.Account_Balance}");

        testAccount.Deposit(9999.0m);
        Console.WriteLine($"After Deposited {testAccount.Account_Balance:C}");
        Console.WriteLine($"Before large Depostit: €{testAccount.Account_Balance:N2}");
        testAccount.Deposit(10000.0m);
        Console.WriteLine($"Warning This is Larg some of Money!!!");
        Console.WriteLine($"You Deposited: €  {testAccount.Account_Balance:N2}");

        // testWithdraw = myBankAccount.Withdraw(35030.0m);
        myBankAccount.Withdraw(10.0m);
        //Console.WriteLine($"Withraw happned: {withdraw}"); 

        // Transfer method

        Console.WriteLine("\n=== TRANSFER TEST ===");
        var sender = myBank.CreateAccount(100, "Muniiro", 11111, 300.0m, 300.0m, 1234, "No take talo!", 0, "1234-1345");
        var receiver = myBank.CreateAccount(101, "Ilhan", 22222, 100.0m, 100.0m, 5478, "Hayi Raac", 0, "9867-35353");

        Console.WriteLine($"Before Transfer Muniro €{sender.Account_Balance:N2}");

        try
        {

            bool sucess = sender.Transfer(receiver, 160.0m);
            Console.WriteLine($"Transfer sucess: {sucess}");
            Console.WriteLine($"After: Muniiro €{sender.Account_Balance}");

        }

        catch (ArgumentException ex)
        {
            Console.WriteLine($"It failed due low balance! {ex.Message} ");

        }

        Console.WriteLine("\n=== SENDER'S TRANSACTION HISTORY ===");
        sender.ShowLastTransactions();

        Console.WriteLine("\n=== RECEIVER'S TRANSACTION HISTORY ===");
        receiver.ShowLastTransactions();

        // Printing the Balance of the Receiver if he got the money to his account
        Console.WriteLine($"Reciver Blance after he/she got the amount in the account. € {receiver.Account_Balance}");
        Console.WriteLine($"Sender after he/she received: € {sender.Account_Balance}");

        // Printing Fat Accounts 
        Console.WriteLine("\n ==== Start from here Fat Accounts");
        var fatFinder = myBank.FindWithHighBalance(23.0m);
        foreach (var accounts in fatFinder)
        {
            Console.WriteLine($"Account Name: {accounts.Customer_Name} Account Balance: {accounts.Account_Balance}");
        }

        testAccount.ShowLastTransactions();

        Console.WriteLine("\n ==== Testing last Transections ====");
        var lastThree = testAccount.GetLastTransactions(3);
        Console.WriteLine($"Sender has  {lastThree.Count} recent transactions: ");

        foreach (var tx in lastThree)
        {
            Console.WriteLine($" {tx.TransactionType}: €{tx.Amount} at {tx.Timestamp:yyyy-MM-dd HH:mm}");
        }

        Console.WriteLine($"\n ==== Transection History with Data Time ===============");
        var yestarday = DateTime.Now.AddDays(-1);
        var tomorrow = DateTime.Now.AddDays(1);
        var resentTX = testAccount.GetTransactionsByRange(yestarday, tomorrow);
        Console.WriteLine($"Rescent Transactoins  {resentTX.Count} i found. ");

        // Transaction By Type Get

        Console.WriteLine("\n  === Transaction By Type startis here");
        var trxType = testAccount.GetTransactionsByType("Deposit");
        foreach (var trx in trxType)
        {
            Console.WriteLine($"Deposit € {trx.Amount} Timestamp: {trx.Timestamp}  Balance After Deposit: € {trx.BalanceAfter} ");
        }
        //  Console.WriteLine($"The Transectoin list of {trxType} are found! ");

        // Query Practice 
        int[] queryArray = [0, 1, 2, 3, 4, 5, 6, 7];

        var queryVar = from quer in queryArray
                       where (quer % 2) == 0
                       select quer;

        foreach (int n in queryArray)
        {
            Console.WriteLine("{0,1}", n);
        }

    }

}


