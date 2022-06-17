using System;
using System.Collections.Generic;

namespace bankApp
{
    public class Bank
    {

        public int balance;
        public int generatedAccountNo;
        public string Username;
        public int AccountNO;
        public int AccountNO2;
        public string value;
        public int value2;
        public Dictionary<int, string> mydictionary = new Dictionary<int, string>();
        public Dictionary<int, int> mydictionary2 = new Dictionary<int, int>();


        public void StartApp()
        {
            bool loopBreak1 = true;
            while (loopBreak1 == true)
            {
                Console.WriteLine("**************************************************************************");
                Console.WriteLine("\nPress 1 to Create an account");
                Console.WriteLine("Press 2 to Login to your account");
                Console.WriteLine("Press 3 to Exit");
                int mainMenuInput = Convert.ToInt32(Console.ReadLine());


                switch (mainMenuInput)
                {
                    case 1:
                        signUp();
                        break;
                    case 2:
                        login();
                        break;

                    case 3:
                        Console.WriteLine("\nThank you for chosing sterling!");
                        loopBreak1 = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid entry Please try again!!!");
                        break;
                }
            }
        }


        public void signUp()
        {
            balance = 0;
            Console.Write("\nEnter a Username: ");
            Username = Console.ReadLine();
            if (Username == " " || Username == string.Empty)
            {
                Console.WriteLine("\nField can't be empty");
                Console.WriteLine("**************************************************************************");
                return;
            }
            else if (Username.Length <= 2)
            {
                Console.WriteLine("\nUsername too short!!!");
                Console.WriteLine("**************************************************************************");
                return;
            }

            generateAccountNo();
            AccountNO = AccountNO2 = generatedAccountNo;
            mydictionary.Add(AccountNO, Username);
            mydictionary2.Add(AccountNO2, balance);


            Console.WriteLine("**************************************************************************");
            Console.WriteLine("\nRegistration Successful!");
            Console.WriteLine("\nHello " + Username.ToUpper() + "!" + "\n Your Account Number is: " + AccountNO + "\n");
            Console.WriteLine("**************************************************************************");
        }

        public void login()
        {
            Console.Write("\nEnter Account Number to Login: ");
            AccountNO = Convert.ToInt32(Console.ReadLine());
            bool hasValue2 = mydictionary2.TryGetValue(AccountNO2, out value2);
            bool hasValue = mydictionary.TryGetValue(AccountNO, out value);
            if (hasValue && hasValue2)
            {
                Console.WriteLine("\nYour bal is " + value2);
                Console.WriteLine("\nHello! " + value.ToUpper());
                Console.WriteLine("Welcome back ;)");
                Menu();
            }
                
            else
            {
                Console.WriteLine("Oops!!! Account does not exist");
            }
        }

        public void generateAccountNo()
        {
            Random rnd = new Random();
            for (float r = 0; r < 1; r++)
            {
                generatedAccountNo = rnd.Next();
            }
        }


        public void Menu()
        {
            bool loopBreak = true;
            while (loopBreak == true)
            {
                Console.WriteLine("**************************************************************************");
                Console.WriteLine("\nPress 1 to Deposit");
                Console.WriteLine("Press 2 to Withdraw");
                Console.WriteLine("Press 3 to Check Balance");
                Console.WriteLine("Press 4 to Logout");
                int serviceInput = Convert.ToInt32(Console.ReadLine());

                switch (serviceInput)
                {
                    case 1:
                        this.Deposit();
                        break;
                    case 2:
                        this.Withdraw();
                        break;

                    case 3:
                        this.Balance();
                        break;

                    case 4:
                        Console.WriteLine("\n**************************************************************************");
                        Console.Write("\nAre you sure you want to logout?  Y/N: ");
                        string choice = Console.ReadLine().ToUpper();
                        if (choice == "Y")
                        {
                            loopBreak = false;
                            StartApp();
                        }
                        else if (choice == "N")
                        {
                            continue;
                        }
                        Console.WriteLine("\nResponse can only be 'Y/N' ");
                        Console.WriteLine("**************************************************************************");
                        goto case 4;

                    default:
                        Console.WriteLine("\nInvalid entry Please try again!!!");
                        break;
                }
            }
        }
        public void Operator()
        {
            mydictionary2.Add(AccountNO2, balance);

        }

        public void Deposit()
        {
            Console.WriteLine("**************************************************************************");

            Console.Write("Please enter the amount you want to deposit to your account: ");

            int depositedAmount = Convert.ToInt32(Console.ReadLine());
            bool hasValue2 = mydictionary2.TryGetValue(AccountNO2, out value2);
            int deposite = depositedAmount + value2;
                value2 = deposite;
                Console.WriteLine(value2);

                Console.WriteLine("\nCongratulations! \n#" + depositedAmount + " just landed in your account");
        }

        public void Withdraw()
        {
            Console.WriteLine("**************************************************************************");

            Console.Write("\nPlease enter the amount you want to withdraw from your account: \n");

            int withdrawalAmount = Convert.ToInt32(Console.ReadLine());
            int withdrawnAmount = value2 - withdrawalAmount;
            value2 = withdrawnAmount;

            if (withdrawalAmount <= value2)
            {
                Console.WriteLine("\nYour withdrawal of #" + withdrawalAmount + " was successful\n");
            }
            else
            {
                Console.WriteLine("\nYour withdrawal of #" + withdrawalAmount + " was unsuccessful due to insufficient balance. please check your balance and try again!\n");

            }
        }

        public void Balance()
        {
            Console.WriteLine("**************************************************************************");

            if (value2 <= 0)
            {
                Console.WriteLine(value2);

                Console.WriteLine("\nYour account balance is currently empty kindly deposit some money\n");
            }
            else
            {
                Console.WriteLine("\nYour account balance is #" + value2);
            }
        }
    }
}