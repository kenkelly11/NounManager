using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatSpeciesManager.Models;

namespace CatSpeciesManager.View
{
    public class CatSpeciesView
    {
        private UserIO userIO; 

        public CatSpeciesView()
        {
            userIO = new UserIO(); 
        }

        public int GetMenuChoice()
        {
            Console.WriteLine("Enter a choice from the menu below: ");
            Console.WriteLine("1. Add Cat Species");
            Console.WriteLine("2. Show All Cat Species");
            Console.WriteLine("3. Look Up Cat Species");
            Console.WriteLine("4. Edit Cat Species");
            Console.WriteLine("5. Remove Cat Species");
            Console.WriteLine("6. Exit the Program");
            int userChoice = userIO.ReadInt("Enter your choice: ", 1, 7);

            return userChoice;
        }

        // gets new cat information from the user
        public CatSpecies GetNewCatInformation() 
        {
            CatSpecies species = new CatSpecies();

            species.Name = userIO.ReadString("\nEnter the species' name: ");
            species.Population = userIO.ReadInt("Enter the species' estimated population: ");
            species.Pattern = userIO.ReadString("Enter the species' fur pattern: ");
            species.BigCat = userIO.ReadBool("Enter Y if the species is in the Big Cat size classification (N for negative): ");
            // species.CatSpeciesID = userIO.ReadInt("Enter the species' identification number: ");

            return species;
        }

        // gets the new cat information for the Edit function
        public CatSpecies NewSpeciesInformation()
        {
            CatSpecies species = new CatSpecies();

            species.Name = userIO.ReadString("\nEnter the species' new name: ");
            species.Population = userIO.ReadInt("Enter the species' new estimated population: "); 
            species.Pattern = userIO.ReadString("Enter the species' new fur pattern: ");
            species.BigCat = userIO.ReadBool("Enter Y if the species is in the Big Cat size classification (N for negative): ");
            species.CatSpeciesID = userIO.ReadInt("Enter the species' new identification number: ");

            return species;
        }

        // shows the species object to the user
        public void DisplaySpecies(CatSpecies species)
        {
            if (species == null)
            {
                return;
            }

            Console.WriteLine("\nIdentification Number: {0}", species.CatSpeciesID);
            Console.WriteLine("Name: {0}", species.Name);
            Console.WriteLine("Fur Pattern: {0}", species.Pattern);
            Console.WriteLine("Big Cat?: {0}", species.BigCat);
            Console.WriteLine("Population: {0}", species.Population);
        }

        
        public CatSpecies[] DisplayAllCatSpecies(CatSpecies[] speciesToDisplay)  
        {
            Console.WriteLine("Here is every Cat Species that has been stored: "); 

            for (int i = 0; i < speciesToDisplay.Length; i++)
            {
                DisplaySpecies(speciesToDisplay[i]);
            }

            return speciesToDisplay;
        }

        
        public int SpeciesSearch()
        {

            CatSpecies cats = new CatSpecies();

            return userIO.ReadInt("Enter a Cat Species ID number.");


        }

        public CatSpecies RemoveSpecies()
        {
            CatSpecies catSpecies = new CatSpecies();

            Console.WriteLine("You are about to permanently remove a Cat Species.");
            catSpecies.CatSpeciesID = userIO.ReadInt("Enter the ID number of the Cat Species you would like to remove.");

            return catSpecies;
        }

        
        public int EditCatDisplay()
        {
            CatSpecies catSpecies = new CatSpecies();

            Console.WriteLine("You are about to edit an existing Cat Species.");
            return userIO.ReadInt("Enter the ID of the Cat Species you would like to edit.");
        }

        
        public void ShowActionSuccess(string actionName)
        {
            Console.WriteLine("\nYou successfully {0}!", actionName);
        }

        public void ShowActionFailure(string actionName)
        {
            Console.WriteLine("\nYou failed to {0}!", actionName);
        }
    }
}
