using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web.Script.Serialization;

namespace ConsoleApp2
{
    class Program
    {
        static int savingsbalance = 0;
        static int currentbalance = 0;
        static int FDbalance = 0;
        static string username1;
        static string password1;


        static void Main(string[] args)
        {
            Console.WriteLine("select option: 1.SignUp  2.Login  3.Logindata ");
            string option = Console.ReadLine();

            if (option == "1")//signup
            {
                Console.WriteLine("Enter your Username:");
                string username = Console.ReadLine();   //username from user
                Console.WriteLine("Password:");
                string password = Console.ReadLine();   //password from user

                Login l1 = new Login();   //login class stores username and password enter by user
                l1.UserName = username;
                l1.PassWord = password;

                if (File.Exists(@"C:\Users\Public\TestFolder\Login.txt"))                      //if login file exist
                {
                    string read = File.ReadAllText(@"C:\Users\Public\TestFolder\Login.txt");   //read file from path
                    if (read == string.Empty)                                                  //If login file is empty
                    {

                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string jsonData = js.Serialize(l1);
                        JObject loginObject = JObject.Parse(jsonData);                          //create json array
                        JArray loginArray = new JArray();
                        loginArray.Add(loginObject);                                            

                        System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\Login.txt", loginArray.ToString());
                    }
                    else               //if in login file there is data                                                         
                    {
                        List<Login> logins = JsonConvert.DeserializeObject<List<Login>>(read);
                        logins.Add(l1);
                        string newjson = JsonConvert.SerializeObject(logins);
                        System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\Login.txt", newjson);

                    }
                    username1 = username;
                    password1 = password;

                }
                else   //if login file does not exist
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonData = js.Serialize(l1);
                    JObject loginObject = JObject.Parse(jsonData);
                    JArray loginArray = new JArray();
                    loginArray.Add(loginObject);
                    System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\Login.txt", loginArray.ToString());
                    username1 = username;
                    password1 = password;

                }




            }

            else if (option == "2")  //login 
            {
                Console.WriteLine("Enter your Username:");
                string username = Console.ReadLine();
                string read = File.ReadAllText(@"C:\Users\Public\TestFolder\Login.txt");
                List<Login> logins = JsonConvert.DeserializeObject<List<Login>>(read);
                string password = string.Empty;
                foreach(var login in logins)
                {
                    if(username==login.UserName)
                    {
                        password = login.PassWord;
                    }
                }
                Console.WriteLine("Enter password");
                string userpassword = Console.ReadLine();
                if(password==userpassword)
                {
                    Console.WriteLine("Login successful");
                    username1 = username;
                    password1 = password;

                }
                else
                {
                    Console.WriteLine("Invalid Password");

                }
            }





            if (File.Exists(string.Format(@"C:\Users\Public\TestFolder\{0}.txt", username1)))
            {
                string read = File.ReadAllText(string.Format(@"C:\Users\Public\TestFolder\{0}.txt", username1));
                Account a1 = JsonConvert.DeserializeObject<Account>(read);

                savingsbalance = a1.savingsBalance;
                currentbalance = a1.currentBalance;
                FDbalance = a1.fdBalance;
            }
            getbalance();
            Console.ReadLine();
        }

        public static void getbalance()
        {
            Console.WriteLine("Select Account:  1.Savings Account  2.Current Account 3.Save and Quit ");
            string account = Console.ReadLine();

            if (account == "1")//saving account select
            {
                Console.WriteLine("Your savings account balance is:" + savingsbalance);
                Console.WriteLine("Enter your choice:  1.Deposit  2.Withdraw  3.Transfer  4.FD");
                string choice = Console.ReadLine();

                if (choice == "1")//savings deposit
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    Deposit(Convert.ToInt32(amount), account);
                    Console.WriteLine("your deposit complete...");
                    Console.WriteLine("Now your saving balance is:" + savingsbalance);
                }
                else if (choice == "2")//savings withdraw
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
                else if (choice == "3")//savings transfer
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
                else if (choice == "4") //savings FD
                {
                    Console.WriteLine("Your Current FD balance is:" + FDbalance);
                    Console.WriteLine("Enter Your choice...   1.Deposit 2.Withdraw");
                    string choice1 = Console.ReadLine();

                    if (choice1 == "1")  //Savings FD deposit
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

                        if (Convert.ToInt32(amount) > FDbalance)
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

            if (account == "2") //Current account select
            {
                Console.WriteLine("Your current account balance is:" + currentbalance);
                Console.WriteLine("Enter your choice:  1.Deposit  2.Withdraw  3.Transfer");
                string choice = Console.ReadLine();

                if (choice == "1") //current deposit
                {
                    Console.WriteLine("Enter amount");
                    string amount = Console.ReadLine();
                    Deposit(Convert.ToInt32(amount), account);
                    Console.WriteLine("Your deposit complete...");
                    Console.WriteLine("Now your current balance is:" + currentbalance);
                }
                else if (choice == "2") //current withdraw
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

            else if (account == "3") //save and quit
            {
                Account a1 = new Account();
                a1.savingsBalance = savingsbalance;
                a1.currentBalance = currentbalance;
                a1.fdBalance = FDbalance;

                string data = JsonConvert.SerializeObject(a1, Formatting.Indented);
                File.WriteAllText(string.Format(@"c:\users\public\testfolder\{0}.txt",username1), data);
            }

            
            getbalance();
        }


        public static void Deposit(int amount, string account)
            {
                if (account=="1")
                {
                    savingsbalance = savingsbalance + amount;
                }
            
            else if (account == "2")
                {
                    currentbalance = currentbalance + amount;
                }
            }
        

            public static void Withdraw(int amount, string account)
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

            public static void Transfer(int amount, string account)
            {
                if (account == "1")
                {
                    savingsbalance = savingsbalance - amount;
                    currentbalance = currentbalance + amount;
                }
                else if (account == "2")
                {
                    currentbalance = currentbalance - amount;
                    savingsbalance = savingsbalance + amount;
                }

            }

            public static void SavingsFD(int amount, string choice1)
            {
                if (choice1 == "1")
                {
                    FDbalance = FDbalance + amount;
                    savingsbalance = savingsbalance - amount;
                }
                else if (choice1 == "2")
                {

                    double interest = 0.1 * amount;
                    int amount1 = amount + Convert.ToInt32(interest);
                    FDbalance = FDbalance - amount;
                    savingsbalance = savingsbalance + amount1;
                }

            }

        }
    }

