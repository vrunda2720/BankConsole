using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static int savingsbalance = 0;
        static int currentbalance = 0;
        static int FDbalance = 0;

        static void Main(string[] args)
        {
            //int caseSwitch = 1;

            //switch (caseSwitch)
            //{
            //    case 1:
            //        Console.WriteLine("choice 1");
                        //Console.WriteLine("Your savings account balance is:" + savingsbalance);
                        //Console.WriteLine("Enter your choice:  1.Deposit  2.Withdraw  3.Transfer  4.FD");
                        //string choice = Console.ReadLine();
            //        break;
            //    case 2:
            //        Console.WriteLine("choice 2");
            //        break;
            //    default:
            //        Console.WriteLine("Default case");
            //        break;
            //}
            getbalance();
            Console.ReadLine();
        }

        public static void getbalance()
        {
            Console.WriteLine("Select Account:  1.Savings Account  2.Current Account");
            string account = Console.ReadLine();
            if(account=="1")//saving account select
            {
                Console.WriteLine("Your savings account balance is:" + savingsbalance);
                Console.WriteLine("Enter your choice:  1.Deposit  2.Withdraw  3.Transfer  4.FD");
                string choice = Console.ReadLine();

                if(choice=="1")//savings deposit
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    Deposit(Convert.ToInt32(amount),account);
                    Console.WriteLine("your deposit complete...");
                    Console.WriteLine("Now your saving balance is:" + savingsbalance);
                }
                else if(choice=="2")//savings withdraw
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    
                    if (Convert.ToInt32(amount) > savingsbalance)
                    {
                        Console.WriteLine("Your saving account balance is not enough");
                    }
                    else 
                    {
                        Withdraw(Convert.ToInt32(amount), account);
                        Console.WriteLine("Your withdraw complete...");
                        Console.WriteLine("Now your saving balance is:" + savingsbalance);
                    }
                }
                else if(choice=="3")//savings transfer
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    if (Convert.ToInt32(amount) > savingsbalance)
                    {
                        Console.WriteLine("Your saving account balance is not enough");
                    }
                    else
                    {
                        Transfer(Convert.ToInt32(amount), account);
                        Console.WriteLine("Your Transfer complete...");
                        Console.WriteLine("Now your saving balance is:" + savingsbalance);
                    }
                }
                else if(choice=="4") //savings FD
                {
                    Console.WriteLine("Your Current FD balance is:" + FDbalance);
                    Console.WriteLine("Enter Your choice...   1.Deposit 2.Withdraw");
                    string choice1 = Console.ReadLine();

                    if(choice1=="1")  //Savings FD deposit
                    {
                        Console.WriteLine("Enter amount:");
                        string amount = Console.ReadLine();

                        if (Convert.ToInt32(amount) > savingsbalance)
                        {
                            Console.WriteLine("Your savings balance is not enough.");
                        }
                        else
                        {
                            SavingsFD(Convert.ToInt32(amount), choice1);
                            Console.WriteLine("your FD deposit complete...");
                            Console.WriteLine("Now your FD balance is:" + FDbalance);
                            Console.WriteLine("Your saving balance is:" + savingsbalance);
                        }
                    }

                    else if (choice1 == "2") //savings FD Withdraw
                    {
                        Console.WriteLine("Enter amount..");
                        string amount = Console.ReadLine();

                        if(Convert.ToInt32(amount)>FDbalance)
                        {
                            Console.WriteLine("Your FD balance is not enough.");

                        }
                        else
                        {
                            SavingsFD(Convert.ToInt32(amount), choice1);
                            Console.WriteLine("Your FD withdraw complete...");
                            Console.WriteLine("Now your FD balance is:" + FDbalance);
                            Console.WriteLine("Your saving balance is:" + savingsbalance);

                        }

                    }
                }

            }

           if(account=="2") //Current account select
            {
                Console.WriteLine("Your current account balance is:" + currentbalance);
                Console.WriteLine("Enter your choice:  1.Deposit  2.Withdraw  3.Transfer");
                string choice = Console.ReadLine();

                if (choice == "1") //current deposit
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    Deposit(Convert.ToInt32(amount),account);
                    Console.WriteLine("Your deposit complete...");
                    Console.WriteLine("Now your current balance is:" + currentbalance);
                }
                else if(choice=="2") //current withdraw
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    if (Convert.ToInt32(amount) > currentbalance)
                    {
                        Console.WriteLine("Your current account balance is not enough");
                    }
                    else
                    {
                        Withdraw(Convert.ToInt32(amount), account);
                        Console.WriteLine("Your transfer complete...");
                        Console.WriteLine("Now your current balance is:" + currentbalance);
                    }
                }
                else if (choice == "3")//current Transfer
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    if (Convert.ToInt32(amount) > currentbalance)
                    {
                        Console.WriteLine("Your current account balance is not enough");
                    }
                    else
                    {
                        Transfer(Convert.ToInt32(amount), account);
                        Console.WriteLine("Your transfer complete...");
                        Console.WriteLine("Now your current balance is:" + currentbalance);
                    }
                }

            }
            getbalance();
        }

        public static void Deposit(int amount, string account)
        {
            if (account == "1")
            {
                savingsbalance = savingsbalance + amount;
            }
            else if (account == "2")
            {
                currentbalance = currentbalance + amount;
            }
        }

        public static void Withdraw(int amount,string account)
        {
            if (account == "1")
            {
                savingsbalance = savingsbalance - amount;
            }
            else if (account == "2")
            {
                currentbalance = currentbalance - amount;
            }
        }

        public static void Transfer(int amount,string account)
        {
            if(account=="1")
            {
                savingsbalance = savingsbalance - amount;
                currentbalance = currentbalance + amount;
            }
            else if(account=="2")
            {
                currentbalance = currentbalance - amount;
                savingsbalance = savingsbalance + amount;
            }

        }

        public static void SavingsFD(int amount,string choice1)
        {
            if (choice1 == "1")
            {
                FDbalance = FDbalance + amount;
               savingsbalance= savingsbalance - amount;
            }
            else if(choice1=="2")
            {

                double interest =0.1*amount;
                int  amount1 = amount + Convert.ToInt32( interest) ;
                FDbalance = FDbalance - amount;
                savingsbalance = savingsbalance + amount1;
            }

        }
    }
}
