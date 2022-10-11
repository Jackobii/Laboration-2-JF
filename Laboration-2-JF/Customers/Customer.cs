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
    public bool VerifyPassword(string password) // Verifierar att lösenorden stämmer för den kund som försöker logga in
    {
        return password.Equals(Password);
    }
    public virtual double ApplyCustomerDiscount(double input) 
        // En grundmetod för att lägga på discount. Overrideas i barnklasserna för att ge rätt rabatt.
    {
        return input;
    }
    public override string ToString() // ToString implementerad enligt uppgiften.
    {
        string output = string.Empty;
        output += $"Name: {Username}\n";
        output += $"Password: {Password}\n";
        output += $"Membership: {this.GetType().Name}\n";
        return output;
    }
}