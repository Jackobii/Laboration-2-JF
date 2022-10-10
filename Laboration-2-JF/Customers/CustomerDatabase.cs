namespace Laboration_2_JF.Customers;

public class CustomerDatabase
{
    private List<Customers.Customer> _existingCustomers = new ();
    private readonly string _docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyCustomersJF.txt");

    public CustomerDatabase()
    {
        if (!File.Exists(_docPath))
        {
            _existingCustomers.AddRange(new[] {
                new Customer("Kalle", "313"),
                new BronzeCustomer("Knatte", "123"),
                new SilverCustomer("Fnatte", "321"),
                new GoldCustomer("Tjatte", "213")

            });
            SaveCustomers();
        }
        else if (File.Exists(_docPath))
        {
            ReadCustomers();
        }
    }
    public void SaveCustomers()
    {
        using StreamWriter sw = new StreamWriter(_docPath, false);
        foreach (var customer in _existingCustomers)
        {
            sw.WriteLine(customer);
        }
    }
    public void SaveCustomers(Customer newCustomer)
    {
        _existingCustomers.Add(newCustomer);
        using StreamWriter sw = new StreamWriter(_docPath, false);
        foreach (var customer in _existingCustomers)
        {
            sw.WriteLine(customer);
        }
    }
    public void ReadCustomers()
    {
        using StreamReader sr = new StreamReader(_docPath);
        string readLine = string.Empty;
        string customerUsername = string.Empty;
        string customerPassword = string.Empty;
        string customerMembership = string.Empty;
        List<Products.Product> customerProducts = new List<Products.Product>();
        Console.WriteLine();

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

                switch (customerMembership.Trim()) // Trim om det skulle hamnat några galna mellanslag i klassnamnet
                {
                    case "Customer":
                        Customer existingCustomer = new Customer(customerUsername, customerPassword);
                        _existingCustomers.Add(existingCustomer);
                        break;
                    case "BronzeCustomer":
                        Customer existingBronzeCustomer = new BronzeCustomer(customerUsername, customerPassword);
                        _existingCustomers.Add(existingBronzeCustomer);
                        break;
                    case "SilverCustomer":
                        Customer existingSilverCustomer = new SilverCustomer(customerUsername, customerPassword);
                        _existingCustomers.Add(existingSilverCustomer);
                        break;
                    case "GoldCustomer":
                        Customer existingGoldCustomer = new GoldCustomer(customerUsername, customerPassword);
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
    {
        return _existingCustomers
            .Any(a => a.Username.Equals(username));
    }
    public bool VerifyCustomerPassword(string username, string password)
    {
        return _existingCustomers
            .Any(a => a.Username.Equals(username) && a.VerifyPassword(password));
    }
}