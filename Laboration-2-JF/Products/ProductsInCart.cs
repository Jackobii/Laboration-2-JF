namespace Laboration_2_JF.Products;

public class ProductsInCart
    // För att inte bloata kundvagnen men massa rader så gör jag ett nytt objekt med produkt + antal
{
    public Product ProductInCart { get; set; }
    public int ProductAmount { get; set; }
}