namespace Laboration_2_JF.Customers;

public class Customer
{
    public string Username { get; private set; }
    public string Password { get; set; }
    public List<Products.ProductsInCart> Cart { get; set; } = new List<Products.ProductsInCart>();

    public Customer(string name, string password)
    {
        Username = name;
        Password = password;
        Cart = new();
    }
    public bool VerifyPassword(string password)
    {
        return password.Equals(Password);
    }
    public virtual double ApplyCustomerDiscount(double input)
    {
        return input;
    }
    public override string ToString()
    {
        string output = string.Empty;
        output += $"Name: {Username}\n";
        output += $"Password: {Password}\n";
        output += $"Membership: {this.GetType().Name}\n";
        output += "Cart contains: \n-";
        foreach (var product in Cart)
        {
            //TODO visa det som finns i carten
        }
        return output;
    }
}