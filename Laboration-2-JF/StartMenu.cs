using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Laboration_2_JF.Customers;
using Laboration_2_JF.Products;

namespace Laboration_2_JF
{
    public class StartMenu
    {
        private CustomerDatabase _cdb = new CustomerDatabase();
        private ProductDatabase _productDb = new ProductDatabase();
        private double _currentCurrency = (double)Currency.Usd;

        public void Start()
        {
            string menuOutput = "Ah... A traveler... Welcome! \nWe don't get many visitors these days.";
            string[] menuOptions = { "Log in", "Register New Customer", "Leave the Store" };
            BuildMenu mainMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = mainMenu.RunMenu();
            // Bygger en meny genom att anropa metoderna i min BuildMenu klass. Får ut menuIndex som en int.
            switch (menuIndex)
                // Switchar menuIndex för att bestämma vad användaren vill göra.
            {
                case 0:
                    LogInCustomer();
                    break;
                case 1:
                    RegisterNewCustomer();
                    break;
                default:
                    Environment.Exit(0); 
                    // Avslutar applikationen
                    break;
            }
        }
        
        public void LogInCustomer() 
            // Metod för att logga in
        {
            Console.Clear();
            Console.WriteLine("Welcome! What is your name: ");
            string username = Console.ReadLine();

            while (username.Equals(string.Empty))
                // Om användarnamn är tomt, acceptera ej!
            {
                Console.WriteLine("You have to give me a name! Try again!");
                username = Console.ReadLine();
                if (username != string.Empty)
                {
                    break;
                }
            }
            if (_cdb.DoesCustomerExist(username))
                // Finns användaren i databasen?
            { 
                while (true)
                { 
                    Console.Clear();
                    Console.WriteLine("Please, what is your password: ");
                    string password = Console.ReadLine();
                    if (_cdb.VerifyCustomerPassword(username, password))
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome {username}!");
                        Customer currentCustomer = _cdb.FetchCustomer(username, password);
                        StoreMenu(currentCustomer);
                        break;
                    }
                    else
                    {
                        string menuOutput = "That was not quite correct. Do you want to try again?";
                        string[] menuOptions = { "Yes, try again", "No, go back!" };
                        var wrongPasswordMenu = new BuildMenu(menuOutput, menuOptions);
                        var menuIndex = wrongPasswordMenu.RunMenu();
                        switch (menuIndex)
                        {
                            case 0: 
                                continue;
                            case 1:
                                Start();
                                break;
                        }
                        break;
                    }
                }
            }
            else if (!_cdb.DoesCustomerExist(username))
            {
                string menuOutput = "I can't find your name in our books... \nAre you a new customer?";
                string[] menuOptions = { "Yes", "No" };
                var wrongPasswordMenu = new BuildMenu(menuOutput, menuOptions);
                var menuIndex = wrongPasswordMenu.RunMenu();
                switch (menuIndex)
                {
                    case 0:
                        RegisterNewCustomer(username);
                        break;
                    case 1:
                        Start();
                        break;
                }

            }
        }
        
        public void RegisterNewCustomer() 
            // Registrera ny kund
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ah, a new customer. Welcome! What is your name? ");
                string newUsername = Console.ReadLine();
                if (newUsername.Equals(string.Empty))
                {
                    Console.WriteLine("You have to give me a name! \nPress any button to go back...");
                    Console.ReadKey();
                    continue;
                }
                else if (_cdb.DoesCustomerExist(newUsername))
                {
                    Console.WriteLine("Are you trying to impersonate someone else? No, tell me your real name! \nPress any button to go back...");
                    Console.ReadKey();
                    continue;
                }
                else 
                    // Om man fått ett giltligt användarnamn, hoppa över till nästa metod (För att inte upprepa mig själv)
                {
                    RegisterNewCustomer(newUsername);
                    break;
                }
            }
        }
        
        public void RegisterNewCustomer(string newUsername)
            // Ange ett lösenord och registrera som ny kund med olika kundnivåer
        {
            while (true)
            {
                Console.WriteLine("Please choose a password: ");
                string newPassword = Console.ReadLine();
                if (newPassword.Equals(string.Empty))
                {
                    Console.WriteLine("You have to have a password! So that we know it's really you. Lots of skinchangers out here these days... \nPress any button to go back...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    string menuOutput = "Your password has been accepted! What kind of membership do you want?? \nMembership levels: \n";
                    string[] menuOptions = { "Basic Membership", "Bronze Membership", "Silver Membership", "Gold Membership" };
                    var chooseMembershipMenu = new BuildMenu(menuOutput, menuOptions);
                    var menuIndex = chooseMembershipMenu.RunMenu();
                    switch (menuIndex) 
                        // Väljer vilken kundnivå man vill ha
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("You chose the Basic Membership! Let me just write that down...");
                            Customer newBasicCustomer = new Customer(newUsername, newPassword);
                            _cdb.SaveCustomers(newBasicCustomer);
                            StoreMenu(newBasicCustomer);
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("You chose the Bronze Membership! Let me just write that down...");
                            Customer newBronzeCustomer = new BronzeCustomer(newUsername, newPassword);
                            _cdb.SaveCustomers(newBronzeCustomer);
                            StoreMenu(newBronzeCustomer);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You chose the Silver Membership! Let me just write that down...");
                            Customer newSilverCustomer = new SilverCustomer(newUsername, newPassword);
                            _cdb.SaveCustomers(newSilverCustomer);
                            StoreMenu(newSilverCustomer);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You chose the Gold Membership! Let me just write that down...");
                            Customer newGoldCustomer = new GoldCustomer(newUsername, newPassword);
                            _cdb.SaveCustomers(newGoldCustomer);
                            StoreMenu(newGoldCustomer);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Error! Try again...");
                            break;
                    }
                    break;
                }
            }
        }
        
        public void StoreMenu(Customer currentCustomer)
        {
            string menuOutput = $"Welcome to the Store {currentCustomer.Username}! What do you want to do?";
            string[] menuOptions = { "Browse", "My Cart", "My Info", "Change Currency", "Leave the Store" };
            BuildMenu storeMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = storeMenu.RunMenu();

            switch (menuIndex)
            {
                case 0:
                    ShopMenu(currentCustomer);
                    break;
                case 1:
                    ShowCustomerCart(currentCustomer);
                    break;
                case 2:
                    ShowCustomerAccount(currentCustomer);
                    break;
                case 3:
                    ChangeCurrency(currentCustomer);
                    break;
                default:
                    Start();
                    break;
            }
        }
        
        public void ShopMenu(Customer currentCustomer) // Visar alla varor man kan köpa + description och pris i de olika valutorna.
        {
            string shopMenuTitle = $"Welcome to my little corner store of curiosities. So many choices to be made...\n";
            string[] createShopMenu = new string[_productDb._availableProducts.Count];
            double[] productPrice = new double[_productDb._availableProducts.Count];
            string[] productDescription = new string[_productDb._availableProducts.Count];
            for (int i = 0; i < _productDb._availableProducts.Count; i++)
            {
                createShopMenu[i] = _productDb._availableProducts[i].ProductName.ToString();
                productPrice[i] = _productDb._availableProducts[i].ProductPrice;
                productDescription[i] = _productDb._availableProducts[i].ProductDescription;
            }
            BuildMenu shopMenu = new BuildMenu(shopMenuTitle, createShopMenu);
            int menuIndex = shopMenu.RunShopMenu((Currency)_currentCurrency, _currentCurrency, productPrice, productDescription);

            Console.WriteLine($"\nOh, interested in the {_productDb._availableProducts[menuIndex].ProductName} eh... \n\nThat will be {_productDb._availableProducts[menuIndex].ProductPrice*_currentCurrency} {(Currency)_currentCurrency}!");
            
            Console.WriteLine("How many do you want?");

            int productAmount;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int userAmount) && userAmount >= 0)
                {
                    // Om användaren matar in ett tal:
                    productAmount = userAmount;
                    break;
                }
                else
                {
                    // Om användaren inte matar in något giltigt
                    Console.WriteLine("I don't understand! You have to tell me how many you want!");
                }
            }

            if (productAmount == 0)
            {
                //Lägg inte till en vara
            }
            else
                // Lägg till vara
            {
                ProductsInCart newItem = new ProductsInCart();
                newItem.ProductAmount = productAmount;
                newItem.ProductInCart = _productDb._availableProducts[menuIndex];
                currentCustomer.Cart.Add(newItem);
            }
            menuIndex = YesNoMenu();
            switch (menuIndex)
            {
                case 0:
                    ShopMenu(currentCustomer);
                    break;
                case 1:
                    StoreMenu(currentCustomer);
                    break;
                default:
                    Console.WriteLine("Error! Try again!");
                    break;
            }
        }
        
        public void ShowCustomerCart(Customer currentCustomer)
        {
            string printCart = $"Your cart contains: \n";
            foreach (var product in currentCustomer.Cart) // Visar carten och hur mycket grejerna kostar + en total
            {
                printCart += $"{product.ProductAmount} x {product.ProductInCart.ProductName} for a price of {product.ProductAmount*product.ProductInCart.ProductPrice*_currentCurrency} {(Currency)_currentCurrency}    ({product.ProductInCart.ProductPrice*_currentCurrency}/each)\n";
            }

            double total =
                (Products.Product.CalculateTotalPrice(currentCustomer, currentCustomer.Cart) * _currentCurrency); 
            // Anropar metoden som räknar ut totalen av allt i kundvagnen.

            printCart += $"The total of all these splendid items will amount to... {Math.Round(total, 2)} {(Currency)_currentCurrency}";

            if (!currentCustomer.GetType().Name.Equals("Customer")) 
                // Om du är pluskund av något slag
            {
                printCart += $"\nSeeing that you are a {currentCustomer.GetType().Name}, I will give you a discount at checkout...";
            }

            string[] menuOptions = { "Go back", "Empty cart", "Place order" };
            BuildMenu shopMenu = new BuildMenu("Welcome to your cart!", menuOptions);
            int menuIndex = shopMenu.RunMenu(afterMenuMessage:printCart);

            switch (menuIndex)
            {
                case 0:
                    StoreMenu(currentCustomer);
                    break;
                case 1:
                    currentCustomer.Cart.Clear();
                    ShowCustomerCart(currentCustomer);
                    break;
                case 2:
                    PlaceOrder(currentCustomer);
                    ShowCustomerCart(currentCustomer);
                    break;
                default:
                    Console.WriteLine("Error! Something went wrong! Try again!");
                    break;
            }
        }
        
        public void PlaceOrder(Customer currentCustomer) 
            // Metod för att lägga en order. Visar även hur mycket du ska betala efter rabatt beroende på kundnivå
        {
            Console.Clear();
            Console.WriteLine("Ah, we have come to an agreement! Thank you for your patronage! \nYou recieved:");

            foreach (var product in currentCustomer.Cart)
            {
                Console.WriteLine($"{product.ProductAmount} x {product.ProductInCart.ProductName} for {(_currentCurrency)*(product.ProductInCart.ProductPrice)*(product.ProductAmount)}");
            }

            double total =
                (Products.Product.CalculateTotalPrice(currentCustomer, currentCustomer.Cart) * _currentCurrency);

            Console.WriteLine($"The total price of these items were {Math.Round(total), 2} {(Currency)_currentCurrency} \n");
            if (!currentCustomer.GetType().Name.Equals("Customer")) 
                // Om man är någon sorts pluskund, apply discount!
            {
                Console.WriteLine($"However, since you are a {currentCustomer.GetType().Name}, we can afford to give you a discount... \n" +
                                  $"How about you just pay {Math.Round(currentCustomer.ApplyCustomerDiscount(total), 2)} {(Currency)_currentCurrency} instead?");
            }
            currentCustomer.Cart.Clear();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
        public void ShowCustomerAccount(Customer currentCustomer) // Visa customer info genom min ToString() override som önskat
        {
            Console.Clear();
            Console.WriteLine(currentCustomer.ToString());
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            StoreMenu(currentCustomer);
        }
        
        public void ChangeCurrency(Customer currentCustomer)
            // Menu som bestämmer vilken valuta som ska visas i affären, genom användning av Enum
        {
            string menuOutput = $"What currency do you wish to pay in?";
            string[] menuOptions = { "USD", "Wow Gold", "Simoleans", "Rupees" };
            BuildMenu storeMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = storeMenu.RunMenu();

            switch (menuIndex)
            {
                case 0:
                    _currentCurrency = (double)Currency.Usd;
                    StoreMenu(currentCustomer);
                    break;
                case 1:
                    _currentCurrency = (double)Currency.WoWGold;
                    StoreMenu(currentCustomer);
                    break;
                case 2:
                    _currentCurrency = (double)Currency.Simoleans;
                    StoreMenu(currentCustomer);
                    break;
                case 3:
                    _currentCurrency = (double)Currency.Rupees;
                    StoreMenu(currentCustomer);
                    break;
                default:
                    Console.WriteLine("Something went wrong, please try again!");
                    break;
            }
        }

        public int YesNoMenu() 
            // En enkel metod för att skapa en Yes/No meny. Användes mindre än jag trodde den skulle...
        {
            string menuOutput = "The item has been added to your cart! Anything else?";
            string[] menuOptions = { "Yes", "No" };
            BuildMenu yesNoMenu = new BuildMenu(menuOutput, menuOptions);
            int menuIndex = yesNoMenu.RunMenu();
            return menuIndex;
        }
    }
}
