namespace Laboration_2_JF.Products;

public class Product
{
    public string ProductName { get; set; } = string.Empty;
    public double ProductPrice { get; set; }
    public string ProductDescription { get; set; } = string.Empty;

    public static double CalculateTotalPrice(Customers.Customer currentCustomer, List<ProductsInCart> cart) 
        // Metod för att kalkylera totala priset för en kundvagn
    {
        double totalPrice = 0;
        foreach (var product in cart)
        {
            totalPrice += (product.ProductInCart.ProductPrice*product.ProductAmount);
        }
        return totalPrice;
    }
}
