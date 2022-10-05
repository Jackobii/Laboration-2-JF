namespace Laboration_2_JF.Customers;

public class DefaultCustomer
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Products.Products> Cart = new List<Products.Products>();

    public DefaultCustomer(string name, string password)
    {
        Username = name;
        Password = password;
    }
    public virtual double ApplyCustomerDiscount(double input)
    {
        return input;
    }
}