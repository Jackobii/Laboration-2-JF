namespace Laboration_2_JF.Customers;

public class Customer
{
    public string Username { get; private set; }
    public string Password { get; set; }
    public List<Products.Products> Cart { get; private set; } = new List<Products.Products>();

    public Customer(string name, string password)
    {
        Username = name;
        Password = password;
    }
    public bool VerifyPassword(string password)
    {
        return password.Equals(Password);
    }
    public virtual double ApplyCustomerDiscount(double input)
    {
        return input;
    }
    
    public static void CreateNewCustomer(string username, string password, Customer customer)
    {

    }
}