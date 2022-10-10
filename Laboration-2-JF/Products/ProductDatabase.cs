namespace Laboration_2_JF.Products;

public class ProductDatabase
{
    public List<Product> _availableProducts = new ();

    public ProductDatabase()
    {
        _availableProducts.AddRange(new []
        {
            //new Product { ProductName = "Item Name", ProductPrice = 0.0d, ProductDescription = ""},
            new Product { ProductName = "Master Sword", ProductPrice = 6999.90d, ProductDescription = "Originally crafted by the goddess Hylia as the Goddess Sword, it was later forged into the Master Sword. \nIt has the power to vanquish all evil"},
            new Product { ProductName = "Sword of a Thousand Truths", ProductPrice = 1999.90d, ProductDescription = "Long ago, when the World of Warcraft was created, one of the programmers put a sword called The Sword of a Thousand Truths into the game inventory. \nBut the sword was considered to be too powerful for anyone to possess, so it was removed from the game and stored on a one gig flash drive. \nBut it was foretold by Salzman that one day players who could wield the sword might reveal themselves."},
            new Product { ProductName = "Gravity Gun", ProductPrice = 3999.90d, ProductDescription = "Have you ever tried to escape Ravenholm? No? \nYou'd probably still like this weapon. It can directly manipulate objects in the world, allowing them to be used as projectiles against hostiles. \nVery useful!"},
            new Product { ProductName = "Blue Shell", ProductPrice = 699.90d, ProductDescription = "The Blue Shell will seek out whoever is in first position of the race. \nYou're not in a race you say? Who will it blow up then? Buy one and find out..."},
            new Product { ProductName = "Thunderfury, Blessed Blade of the Windseeker", ProductPrice = 2999.90d, ProductDescription = $"Did someone say [Thunderfury, Blessed Blade of the Windseeker]?"},
            new Product { ProductName = "211-V Plasma Cutter", ProductPrice = 1299.90d, ProductDescription = "Found on the blood-spattered decks of the USG Ishimura. \nA tool designed to use ionized gas and plasma energy to chip pieces off boulders so they'll fit in smelting tubes. \nIts primary function allows a short, accurate long range energy blast, while its secondary fire rotates the blade ninety degrees, allowing you to fire vertical or horizontal shots."},
            new Product { ProductName = "Portal Gun - ASHPD", ProductPrice = 9999.90d, ProductDescription = "An experimental tool used to create two portals through which objects can pass. \nUsed in the Aperture Science Enrichment Center's testing tracks, I've successfully gotten a hold of one. \nIt will cost you a fortune..."},
            new Product { ProductName = "Krayt Pearl Lightsaber", ProductPrice = 4999.90d, ProductDescription = "Famously used by the Jedi and the Sith. The kyber crystal in this particular lightsaber is a Krayt Dragon Pearl and it glows a pale yellow. \nYou have to be force-sensitive to be able to use it!..."},
            new Product { ProductName = "Golden Gun", ProductPrice = 1999.90d, ProductDescription = "The signature weapon of killer assassin Francisco Scaramanga. \nThe weapon is a custom-built, single-shot pistol assembled from four seemingly innocuous golden objects: a pen, a lighter, a cigarette case and a cufflink."}
        });
    }
}