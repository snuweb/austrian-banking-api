
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BankingAPI;

public class Bank
{


public int Id{get; private set; }
public string BankName {get; private set; }
public string BankCode {get; private set; }
public string SwiftCode {get; private set; }
public string Address {get; private set; }


public List<BankAccount> Accounts {get; private set; }
public DateTime EstablishedDate {get; private set; }


public Bank(string bankName, string bankCode, string swiftCode, string address )
{
    BankName = bankName;
    BankCode = bankCode;
    SwiftCode = swiftCode;
    Address = address;
    Accounts = new List<BankAccount>();
    EstablishedDate = DateTime.Now;
Console.WriteLine($"Bank `{BankName}` fully initialized");
}


public BankAccount CreateAccount( int id, string customer_Name, int accountNumber, decimal account_Balance, decimal initial_Deposit, int pin,
      string nickname , decimal creditLimit, string phoneNumber )
{
    
    // TODO: We`ll implement this step by step
    
    int accountId = Accounts.Count + 1;

  BankAccount newAccount = new BankAccount(id, customer_Name, accountNumber, account_Balance, initial_Deposit, pin, nickname, creditLimit, phoneNumber );
    
    
    Accounts.Add(newAccount);


    return newAccount;



}


public void PrintAllBankAccounts()  
{

    decimal balancetotal = 0m;

foreach(BankAccount account in Accounts)
{    
Console.WriteLine($"Customer Name: {account.Customer_Name} Balance: $ {account.Account_Balance:C} initailDeposit: $ {account.Initial_Deposit:C}");
    // TODO: Print all bank accounts
balancetotal += account.Account_Balance;   
string displayName = account.Nickname ?? account.Customer_Name;
Console.WriteLine($"{displayName}");
Console.WriteLine($"Phone Number: {account.PhoneNumber:F0}");
}



}

    // Find High Value Accounts 
    public List<BankAccount> FindWithHighBalance(decimal minimumBalance)
    {

        //check  Edge Cases
        
        if (minimumBalance < 0) throw new ArgumentException("Minumal value should be Posative. ", nameof(minimumBalance));

        var fatAccounts = Accounts.Where(account => account.Account_Balance >= minimumBalance).ToList();

  

        return fatAccounts;

    }





    

public override string ToString()
    {


        return $"Bank: {BankName} | Code: {BankCode} | SwiftCode: {SwiftCode} Address: {Address} | Accounts: {Accounts.Count} ";
    }
}