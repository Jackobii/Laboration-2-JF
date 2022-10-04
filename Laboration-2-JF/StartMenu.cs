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
            string[] menuOptions = {"Logga in", "Registrera ny kund", "Avsluta"};
            BuildMenu mainMenu = new BuildMenu(menuOutput, menuOptions);
            int userIndex = mainMenu.RunMenu();

            switch (userIndex)
            {
                case 0:
                    LogInCustomer();
                    break;
                case 1:
                    RegisterNewCustomer();
                    break;
                default:
                    Environment.Exit(0); // Avslutar applikationen
                    break;
            }

            //if (userIndex == 0)
            //{
            //    LogInCustomer();
            //}
            //else if (userIndex == 1)
            //{
            //    RegisterNewCustomer();
            //}
            //else if (userIndex == 2)
            //{
            //    Environment.Exit(0); // Avslutar applikationen
            //}
            //else
            //{
            //    Console.WriteLine("Error! Försök igen!");
            //    userIndex = mainMenu.RunMenu();
            //}
        }
    }
}
