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
                        Customer loggedInCustomer = new Customer(username, password);
                        StoreMenu(loggedInCustomer);
                        break;
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
            else if (!_cdb.DoesCustomerExist(username))
            {
                string menuOutput = "Den användaren finns inte... \nVill du registrera en ny användare?";
                string[] menuOptions = { "Ja", "Nej" };
                var wrongPasswordMenu = new BuildMenu(menuOutput, menuOptions);
                var menuIndex = wrongPasswordMenu.RunMenu();
                switch (menuIndex)
                {
                    case 0:
                        RegisterNewCustomer(username);
                        break;
                    case 1:
                        break;
                }

            }
        }
        public void RegisterNewCustomer()
        {
            string newUsername;

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
                    RegisterNewCustomer(newUsername);
                    break;
                }
            }
        }
        public void RegisterNewCustomer(string newUsername)
        {
            while (true)
            {
                Console.WriteLine("Var vänlig ange ditt önskade lösenord: ");
                string newPassword = Console.ReadLine();
                if (newPassword.Equals(string.Empty))
                {
                    Console.WriteLine("Du måste ha ett lösenord! Försök igen! \nKlicka på valfri knapp för att gå tillbaka...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    string menuOutput = "Ditt lösenord accepterades! Vilket sorts medlemskap vill du ha? \nVåra olika medlemskapsnivåer: \n";
                    string[] menuOptions = { "Basic Membership", "Bronze Membership", "Silver Membership", "Gold Membership" };
                    var chooseMembershipMenu = new BuildMenu(menuOutput, menuOptions);
                    var menuIndex = chooseMembershipMenu.RunMenu();
                    switch (menuIndex)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Du har valt Basic Membership-nivån! Skapar konto...");
                            Customer newBasicCustomer = new Customer(newUsername, newPassword);
                            _cdb.SaveCustomers(newBasicCustomer);
                            StoreMenu(newBasicCustomer);
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Du har valt Bronze Membership-nivån! Skapar konto...");
                            Customer newBronzeCustomer = new BronzeCustomer(newUsername, newPassword);
                            _cdb.SaveCustomers(newBronzeCustomer);
                            StoreMenu(newBronzeCustomer);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Du har valt Silver Membership-nivån! Skapar konto...");
                            Customer newSilverCustomer = new SilverCustomer(newUsername, newPassword);
                            _cdb.SaveCustomers(newSilverCustomer);
                            StoreMenu(newSilverCustomer);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Du har valt Gold Membership-nivån! Skapar konto...");
                            Customer newGoldCustomer = new GoldCustomer(newUsername, newPassword);
                            _cdb.SaveCustomers(newGoldCustomer);
                            StoreMenu(newGoldCustomer);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Error! Försök igen...");
                            break;
                    }
                    break;
                }
            }
        }
        public void StoreMenu(Customer currentCustomer)
        {
            string menuOutput = $"Du har blivit inloggad! \nVälkommen in i affären {currentCustomer.Username}! Vad vill du göra?";
            string[] menuOptions = { "Handla", "Min Kundvagn", "Mitt Konto", "Logga ut" };
            BuildMenu shopMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = shopMenu.RunMenu();

            switch (menuIndex)
            {
                case 0:
                    ShopMenu();
                    break;
                case 1:
                    ShowCustomerCart(currentCustomer);
                    break;
                case 2:
                    ShowCustomerAccount(currentCustomer);
                    break;
                default:
                    //Spara användaren
                    Start();
                    break;
            }
        }
        public void ShopMenu()
        {

        }
        public void ShowCustomerCart(Customer currentCustomer)
        {
            string menuOutput = $"Det här är din kundvagn:";
            //TODO visa vad du har i kundvagn

            string[] menuOptions = { "Gå tillbaka", "Töm Kundvagn", "Bekräfta order" };
            BuildMenu shopMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = shopMenu.RunMenu();

            switch (menuIndex)
            {
                case 0:
                    StoreMenu(currentCustomer);
                    break;
                case 1:
                    currentCustomer.Cart.Clear();
                    break;
                case 2:
                    PlaceOrder(currentCustomer);
                    break;
                default:
                    Console.WriteLine("Error! Nu har du gjort något knasigt! Försök igen!");
                    break;
            }
        }
        public void PlaceOrder(Customer currentCustomer)
        {
            Console.WriteLine("Tack för din beställning! Din order skickas inom kort. \n Din order:");
            foreach (var product in currentCustomer.Cart)
            {
                //TODO visa antal och produkter!
            }
        }
        public void ShowCustomerAccount(Customer currentCustomer) // Visa customer info genom min ToStrine() override som önskat
        {
            Console.WriteLine(currentCustomer.ToString());
            Console.WriteLine("\nKlicka på valfri tangent för att gå tillbaka...");
            Console.ReadKey();
            StoreMenu(currentCustomer);
        }
    }
}
