namespace Laboration_2_JF.Customers;

public class CustomerDatabase
{
    private List<Customers.Customer> _existingCustomers = new (); // lista över existerande kunder
    private readonly string _docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyCustomersJF.txt");
    // Lägger MyCustomersJF.txt i Mina Dokument på användarens dator
    public CustomerDatabase()
    {
        if (!File.Exists(_docPath)) 
            // Om filen icke existerar, lägg in fördefinierade kunder enligt nedan
        {
            _existingCustomers.AddRange(new[] {
                new Customer("Kalle", "313"),
                new BronzeCustomer("Knatte", "123"),
                new SilverCustomer("Fnatte", "321"),
                new GoldCustomer("Tjatte", "213")

            });
            SaveCustomers(); 
            // Metod för att spara kunderna i listan _existingCustomers till ett .txt document
        }
        else if (File.Exists(_docPath))
        {
            ReadCustomers(); 
            // Metod för att läsa in kunderna från en .txt fil och sedan lägga in i listan _existingCustomers
        }
    }
    
    public void SaveCustomers() 
        // Sparar kunderna i _existingCustomers till ett nytt .txt dokument
    {
        using StreamWriter sw = new StreamWriter(_docPath, false);
        foreach (var customer in _existingCustomers)
        {
            sw.WriteLine(customer);
        }
    }
    
    public void SaveCustomers(Customer newCustomer) 
        // En override på SaveCustomers() metoden som lägger in en nyskapad kund i listan över befintliga kunder
        // och sparar till .txt dokument
    {
        _existingCustomers.Add(newCustomer);
        using StreamWriter sw = new StreamWriter(_docPath, false);
        foreach (var customer in _existingCustomers)
        {
            sw.WriteLine(customer);
        }
    }
    
    public void ReadCustomers() 
        // Metod som läser in all kunder i en .txt fil enligt formatet som jag förbestämt i ToString() overriden i Customer
    {
        using StreamReader sr = new StreamReader(_docPath);
        string readLine = string.Empty;
        string customerUsername = string.Empty;
        string customerPassword = string.Empty;
        string customerMembership = string.Empty;
        List<Products.Product> customerProducts = new List<Products.Product>();

        while ((readLine = sr.ReadLine()) != null)
        {
            if (readLine.StartsWith("Name: "))
            {
                customerUsername = readLine.Substring(6);
            }
            else if (readLine.StartsWith("Password: "))
            {
                customerPassword = readLine.Substring(10);
            }
            else if (readLine.StartsWith("Membership: "))
            {
                customerMembership = readLine.Substring(12);
                // När namn, lösenord och vilken sorts kund man är har lästs in så skapas en ny kund
                // efter dessa specifikationer och läggs in i listan över kunder
                switch (customerMembership) 
                {
                    case "Customer":
                        Customer existingCustomer = new Customer(customerUsername, customerPassword);
                        _existingCustomers.Add(existingCustomer);
                        break;
                    case "BronzeCustomer":
                        BronzeCustomer existingBronzeCustomer = new BronzeCustomer(customerUsername, customerPassword);
                        _existingCustomers.Add(existingBronzeCustomer);
                        break;
                    case "SilverCustomer":
                        SilverCustomer existingSilverCustomer = new SilverCustomer(customerUsername, customerPassword);
                        _existingCustomers.Add(new SilverCustomer(customerUsername, customerPassword));
                        break;
                    case "GoldCustomer":
                        GoldCustomer existingGoldCustomer = new GoldCustomer(customerUsername, customerPassword);
                        _existingCustomers.Add(existingGoldCustomer);
                        break;
                    default:
                        Console.WriteLine("Something went wrong, please try again...");
                        break;
                }
            }
        }
    }
    
    public bool DoesCustomerExist(string username) 
        // Om användaren finns i databasen, returna True. Annars false.
    {
        return _existingCustomers
            .Any(a => a.Username.Equals(username));
    }
    
    public bool VerifyCustomerPassword(string username, string password) 
        // Om användarnamnet matchar med lösenordet, returna true och låter användaren logga in
    {
        return _existingCustomers
            .Any(a => a.Username.Equals(username) && a.VerifyPassword(password));
    }

    public Customer? FetchCustomer(string username, string password)
        // Hämta uppgifter om kunden som man loggar in på
    {
        return _existingCustomers
            .FirstOrDefault(a => a.Username.Equals(username) && a.VerifyPassword(password));
    }
}