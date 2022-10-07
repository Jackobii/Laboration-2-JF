namespace Laboration_2_JF.Customers;

public class BronzeCustomer : Customer 
{
    public BronzeCustomer(string name, string password) : base(name, password)
    {

    }
    public override double ApplyCustomerDiscount(double input)
    {
        return (input * 0.95d);

    }
}