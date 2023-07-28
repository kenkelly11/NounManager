using CatSpeciesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatSpeciesManager.View
{
    public class UserIO
    {
        // prompts the user for a string
        public string ReadString(string prompt)
        {
            string userInput = "";

            while (userInput == "")
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine().Trim();

                if (userInput == "")
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
            }

            return userInput;
        }

        // prompts the user for an int
        public int ReadInt(string prompt, int min = 0, int max = 1000000000)
        {
            int output;

            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out output))
                {
                    if (output >= min && output <= max)
                    {
                        break; 
                    }

                    else
                    {
                        Console.WriteLine("That number was not between {0} and {1}. Please try again.", 0, 9);
                    }
                }

                else
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }

            }

            return output;
        }

        // prompts the user for a bool value
        public bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                if (userInput == "Y")
                {
                    return true;
                }
                else if (userInput == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("That was not a valid input! Please try again.");
                }

            }

        }

    }

}
