using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2_JF
{
    public class BuildMenu
    {
        private string MenuTitle;
        private string[] MenuOptions;
        private int MenuIndex;

        public BuildMenu(string menuTitle, string[] menuOptions) 
            // Ta emot en meny titel (header), de olika valen och initierar MenUIndex som håller koll på ditt val 
        {
            MenuTitle = menuTitle;
            MenuOptions = menuOptions;
            MenuIndex = 0;
        }

        public void DisplayOptions() // Metod för att bygga menyn.
        {
            Console.WriteLine(MenuTitle);

            for (int i = 0; i < MenuOptions.Length; i++)
            {
                string currentChoice = MenuOptions[i];
                string currentChoiceMarker;

                if (i == MenuIndex)
                {
                    currentChoiceMarker = ">";
                    (Console.BackgroundColor, Console.ForegroundColor) =
                        (Console.ForegroundColor, Console.BackgroundColor); 
                    // tuple, för att invertera färgerna på det markerade valet
                }
                else
                {
                    // Håller menyn på samma plats oavsett var markören är
                    currentChoiceMarker = " ";
                }
                Console.WriteLine($"{currentChoiceMarker}{currentChoice}");
                Console.ResetColor();
            }
        }

        public int RunMenu(string beforeMenuMessage = "", string afterMenuMessage = "")
        {
            ConsoleKey userInput;
            do
            {
                Console.Clear();

                Console.Write(beforeMenuMessage);
                DisplayOptions();
                Console.Write(afterMenuMessage);

                userInput = Console.ReadKey().Key; // läser vilken tangent du klickar på, bara upp, ner och enter gör något.

                if (userInput == ConsoleKey.UpArrow && MenuIndex != 0) 
                    // flytta upp, kan inte fly ur menyn
                {
                    MenuIndex--;
                }
                else if (userInput == ConsoleKey.DownArrow && MenuIndex != (MenuOptions.Length - 1)) 
                    // flytta ner, kan inte fly ur menyn
                {
                    MenuIndex++;
                }
            } while (userInput != ConsoleKey.Enter);
            //när enter klickas, returnera en int med MenuIndex värde för att välja det markerade valet
            return MenuIndex;
        }

        public int RunShopMenu(Currency currentCurrency,double currentCurrencyConversion,double[] productPrice,string[] afterMenuMessage) 
            // override för att kunna visa product descriptions! Tar in en array med alla descriptions så att dom kan visas.
        {
            ConsoleKey userInput;
            do
            {
                Console.Clear();
                DisplayOptions();
                Console.Write("\n\n" + afterMenuMessage[MenuIndex] + $"\n\nThat one will cost you {productPrice[MenuIndex]*currentCurrencyConversion} {(Currency)currentCurrency}");

                userInput = Console.ReadKey().Key;

                if (userInput == ConsoleKey.UpArrow && MenuIndex != 0)
                {
                    MenuIndex--;
                }
                else if (userInput == ConsoleKey.DownArrow && MenuIndex != (MenuOptions.Length - 1))
                {
                    MenuIndex++;
                }
            } while (userInput != ConsoleKey.Enter);

            return MenuIndex;
        }
    }
}
