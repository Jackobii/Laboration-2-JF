using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2_JF
{
    public class StartMenu
    {
        public void Start()
        {
            string menuOutput = "Välkommen till Jacob's E-shop";
            string[] menuOptions = {"Logga in", "Registrera", "Avsluta"};
            MenuClass mainMenu = new MenuClass(menuOutput, menuOptions);
            int userIndex = mainMenu.RunMenu();

            if (userIndex == 0)
            {
                LogIn();
            }
            else if (userIndex == 1)
            {
                RegisterNewUser();
            }
            else if (userIndex == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Error! Försök igen!");
                userIndex = mainMenu.RunMenu();
            }
        }
    }
}
