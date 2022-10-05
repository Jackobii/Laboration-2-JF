namespace Laboration_2_JF.Customers;

public class SilverCustomer : DefaultCustomer
{
    public SilverCustomer(string name, string password) : base(name, password)
    {

    }
    public override double ApplyCustomerDiscount(double input)
    {
        return (input * 0.9d);
    }
}