namespace Laboration_2_JF.Customers;

public class GoldCustomer : Customer
{
    public GoldCustomer(string name, string password) : base(name, password)
    {

    }
    public override double ApplyCustomerDiscount(double input) // Override för att ge rätt rabatt i kassan
    {
        return (input * 0.85d);
    }
}