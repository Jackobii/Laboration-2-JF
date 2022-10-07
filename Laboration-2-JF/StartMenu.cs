using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboration_2_JF.Customers;

namespace Laboration_2_JF
{
    public class StartMenu
    {
        private CustomerDatabase _cdb = new CustomerDatabase();

        public void Start()
        {
            string menuOutput = "Välkommen till Jacob's E-shop";
            string[] menuOptions = { "Logga in", "Registrera ny kund", "Avsluta" };
            BuildMenu mainMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = mainMenu.RunMenu();

            switch (menuIndex)
            {
                case 0:
                    LogInCustomer();
                    break;
                case 1:
                    RegisterNewCustomer();
                    break;
                default:
                    Environment.Exit(0); // Avslutar applikationen
                    break;
            }
        }
        public void LogInCustomer()
        {
            Console.Clear();
            Console.WriteLine($"");
            Console.WriteLine("Välkommen till min affär! Var vänlig skriv in ditt användarnamn: ");
            string username = Console.ReadLine();

            while (username.Equals(string.Empty))
            {
                Console.WriteLine("Du måste välja ett användarnamn! Försök igen!");
                username = Console.ReadLine();
                if (username != string.Empty)
                {
                    break;
                }
            }
            if (_cdb.DoesCustomerExist(username))
            { 
                while (true)
                { 
                    Console.Clear();
                    Console.WriteLine("Var vänlig skriv in ditt lösenord: ");
                    string password = Console.ReadLine();
                    if (_cdb.VerifyCustomerPassword(username, password))
                    {
                        Console.Clear();
                        Console.WriteLine($"Välkommen {username}!");
                        //TODO Logga in personen
                    }
                    else
                    {
                        string menuOutput = "Fel lösenord, vill du försöka igen?";
                        string[] menuOptions = { "Försök igen", "Avsluta" };
                        var wrongPasswordMenu = new BuildMenu(menuOutput, menuOptions);
                        var menuIndex = wrongPasswordMenu.RunMenu();
                        switch (menuIndex)
                        {
                            case 0: 
                                continue;
                            case 1:
                                break;
                        }
                        break;
                    }
                }
            }
        }
        public void RegisterNewCustomer()
        {
            string newUsername;
            string newPassword;
            Customer newCustomer;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ange ditt önskade användarnamn: ");
                newUsername = Console.ReadLine();
                if (newUsername.Equals(string.Empty))
                {
                    Console.WriteLine("Användarnamnet kan inte vara tomt! Försök igen! \nKlicka på valfri knapp för att gå tillbaka...");
                    Console.ReadKey();
                    continue;
                }
                else if (_cdb.DoesCustomerExist(newUsername))
                {
                    Console.WriteLine("Användarnamnet existerar redan! Försök med något annat! \nKlicka på valfri knapp för att gå tillbaka...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    Console.Write("Användarnamnet var tillgängligt! ");
                    while (true)
                    {
                        Console.WriteLine("Var vänlig ange ditt önskade lösenord: ");
                        newPassword = Console.ReadLine();
                        if (newPassword.Equals(string.Empty))
                        {
                            Console.WriteLine("Du måste ha ett lösenord! Försök igen! \nKlicka på valfri knapp för att gå tillbaka...");
                            Console.ReadKey();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Ditt lösenord accepterades! Vilket sorts medlemskap vill du ha?");
                            string menuOutput = "Våra olika medlemskapsnivåer: \n";
                            string[] menuOptions = { "Basic Membership", "Bronze Membership", "Silver Membership", "Gold Membership" };
                            var chooseMembershipMenu = new BuildMenu(menuOutput, menuOptions);
                            var menuIndex = chooseMembershipMenu.RunMenu();
                            switch (menuIndex)
                            {
                                case 0:
                                    Console.Clear();
                                    Console.WriteLine("Du har valt Basic Membership-nivån! Skapar konto...");
                                    //newCustomer = Customer(newUsername, newPassword);
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Du har valt Bronze Membership-nivån! Skapar konto...");
                                    //newCustomer = BronzeCustomer(newUsername, newPassword);
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Du har valt Silver Membership-nivån! Skapar konto...");
                                    //newCustomer = SilverCustomer(newUsername, newPassword);
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Du har valt Gold Membership-nivån! Skapar konto...");
                                    //newCustomer = GoldCustomer(newUsername, newPassword);
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Error! Försök igen...");
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
