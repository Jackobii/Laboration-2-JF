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
        {
            MenuTitle = menuTitle;
            MenuOptions = menuOptions;
            MenuIndex = 0;
        }

        public void DisplayOptions()
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
                    // tuple, för att byta färgerna på den valda grejen
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

        public int RunMenu()
        {
            ConsoleKey userInput;
            do
            {
                Console.Clear();
                DisplayOptions();

                userInput = Console.ReadKey().Key;

                if (userInput == ConsoleKey.UpArrow && MenuIndex != 0)
                {
                    MenuIndex--;
                }
                else if (userInput == ConsoleKey.DownArrow && MenuIndex != (MenuOptions.Length - 1)) {
                    MenuIndex++;
                }
            } while (userInput != ConsoleKey.Enter);
            return MenuIndex;
        }
    }
}
