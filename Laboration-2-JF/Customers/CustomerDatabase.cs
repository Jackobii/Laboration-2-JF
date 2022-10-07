namespace Laboration_2_JF.Customers;

public class CustomerDatabase
{
    private List<Customers.Customer> _existingCustomers = new ();
    private string _docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyCustomersJF.txt");

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
        if (File.Exists(_docPath))
        {
            string readLine = string.Empty;
            using StreamReader sr = new StreamReader(_docPath);

            while ((readLine = sr.ReadLine()) != null)
            {
                Console.WriteLine(readLine);
            }
        }
    }
    public void SaveCustomers()
    {
        using StreamWriter sw = new StreamWriter(_docPath);
        foreach (var customer in _existingCustomers)
        {
            sw.WriteLine(customer);
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