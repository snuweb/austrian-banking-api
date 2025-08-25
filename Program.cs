using System;

namespace BankingAPI;

// See https://aka.ms/new-console-template for more information

public class Program 
{

    public static void Main(string[] args)
    {
    Bank myBank = new Bank("ErstBank", "20111", "GIBAATWW","Feldkirch");
    Bank myBankTwo  = new Bank("Reifeisan", "3200", "RLNWAATWW", "Feldkirch");        
    //Console.WriteLine($"Banking System Austria the Best Bank so far is {myBank.BankName}");
    BankAccount myBankAccount = new BankAccount(12,"Sarifcoin",3233.0m, 3233.0m, 91);    
    //Console.WriteLine($"Waa Second Object Of Banking System: {myBankTwo.BankName}");
    myBank.CreateAccount(32,"Dalxoreeye", 100.0m, 800.0m, 14, "Mr Dhuun", 500.0m, "123-464-6344-63");    
    //myBank.PrintAllBankAccounts();
    myBank.CreateAccount(45, "Mohamed", 130.0m, 290.0m, 22, "Mr Xaaji Euro", 400.0m, "1914-42342-324-3531914-4-353" );
    myBank.PrintAllBankAccounts();
    Console.WriteLine($"One Of The bigest Banks in Austria is: {myBank.ToString()}");    
    Console.WriteLine($"One of The Bigest Banks in Austria  is: {myBankTwo}");

    // Deposit Testing beging here!
    var testAccount = myBank.CreateAccount(17, "Test Account", 88.0m, 39.0m,  23, "Xariif Magaalo", 154.0m , "141-353-55-555-3335");
    Console.WriteLine($" Before Deposit test {testAccount.Account_Balance}");

    testAccount.Deposit(9999.0m);
    Console.WriteLine($"After Deposited {testAccount.Account_Balance:C}");
    Console.WriteLine($"Before large Depostit: €{testAccount.Account_Balance:N2}" );
    testAccount.Deposit(10000.0m);
    Console.WriteLine($"Warning This is Larg some of Money!!!");
    Console.WriteLine($"You Deposited: €  {testAccount.Account_Balance:N2}");

    // Test Withdraw function
    


    // testWithdraw = myBankAccount.Withdraw(35030.0m);
    myBankAccount.Withdraw(5.0m);
   //Console.WriteLine($"Withraw happned: {withdraw}"); 

    }

}

