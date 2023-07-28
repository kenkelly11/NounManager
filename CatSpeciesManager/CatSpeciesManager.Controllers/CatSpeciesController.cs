using CatSpeciesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatSpeciesManager.View;
using CatSpeciesManager.Data;

namespace CatSpeciesManager.Controllers
{
    public class CatSpeciesController
    {
        private CatSpeciesView userInterface; 
        private CatSpeciesRepository repository;

        public CatSpeciesController()
        {
            userInterface = new CatSpeciesView(); 
            repository = new CatSpeciesRepository();
        }

        
        public void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                int menuChoice = userInterface.GetMenuChoice();

                switch (menuChoice)
                {
                    case 1:
                        AddCatSpecies();
                        break;
                    case 2:
                        GetAllCatSpecies();
                        break;
                    case 3:
                        SpeciesSearch();
                        break;
                    case 4:
                        EditCatSpecies();
                        break;
                    case 5:
                        RemoveCatSpecies();
                        break;
                    case 6:
                        keepRunning = false;
                        break;
                    
                }
            }
        }
        private void AddCatSpecies() // execute Case 1
        {
            Console.Clear();
            CatSpecies newSpecies = userInterface.GetNewCatInformation();
            CatSpecies addedSpecies = repository.AddCatSpecies(newSpecies);

            if (addedSpecies != null)
            {
                userInterface.DisplaySpecies(addedSpecies);

                userInterface.ShowActionSuccess("added a Cat Species");
            }
            else
            {
                userInterface.ShowActionFailure("add a Cat Species");
            }
        }
         
        public void GetAllCatSpecies() // execute Case 2
        {
            Console.Clear();
            CatSpecies[] allSpecies = repository.GetAllCatSpecies();
            userInterface.DisplayAllCatSpecies(allSpecies);
            
        }

        public void SpeciesSearch() // execute Case 3
        {
            Console.Clear();
            int displaySpeciesID = userInterface.SpeciesSearch();
            CatSpecies catSpecies = repository.FindById(displaySpeciesID);


            if (catSpecies.CatSpeciesID != displaySpeciesID)
            {
                Console.WriteLine("That Cat Species does not exist!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Here is the Cat Species associated with that ID number: ");
                catSpecies.Print(); 
            }


        }

        public void EditCatSpecies() // execute Case 4
        {
            Console.Clear();
            int editId = userInterface.EditCatDisplay(); // returns user ID
            CatSpecies catSpecies = repository.FindById(editId); 


            if (catSpecies.CatSpeciesID != editId)
            {
                Console.WriteLine("There is no Cat Species associated with that ID number.");
            }

            else
            {
                Console.WriteLine("Here is the Cat Species you have selected to edit: ");
                catSpecies.Print();

                Console.WriteLine("Please re-enter this Species' information with any changes you would like to make: ");
                CatSpecies newCat = userInterface.NewSpeciesInformation();

                repository.UpdateSpecies(catSpecies.CatSpeciesID, newCat.Name, newCat.BigCat, newCat.Population, newCat.Pattern, newCat.CatSpeciesID);
            }

            if (catSpecies != null)
            {
                userInterface.DisplaySpecies(catSpecies);

                userInterface.ShowActionSuccess("edited a Cat Species");
            }
            else
            {
                userInterface.ShowActionFailure("edit a Cat Species");
            }

        }

        private void RemoveCatSpecies() // execute Case 5
        {
            Console.Clear();
            CatSpecies catSpecies = userInterface.RemoveSpecies();
            
            Console.WriteLine("Are you sure you would like to remove this Cat Species? (y/n)");
            string correct = Console.ReadLine().ToLower();

            if (correct == "y")
            {
                repository.RemoveCatSpecies(catSpecies.CatSpeciesID);
                userInterface.DisplaySpecies(catSpecies);

                userInterface.ShowActionSuccess("removed a Cat Species");
                Console.WriteLine("");

            }
            else if (correct == "n")
            {
                userInterface.ShowActionFailure("remove a Cat Species");
                return;
            }
        }
    }
}
