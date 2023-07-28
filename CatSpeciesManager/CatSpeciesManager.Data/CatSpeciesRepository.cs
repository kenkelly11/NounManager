using CatSpeciesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatSpeciesManager.Data
{
    public class CatSpeciesRepository
    {
        CatSpecies[] species;

        public CatSpeciesRepository()
        {
            species = new CatSpecies[10];

            CatSpecies lion = new CatSpecies();
            lion.Name = "Lion";
            lion.Population = 182932;
            lion.Pattern = "Golden Brown, Solid";
            lion.BigCat = true;
            lion.CatSpeciesID = 0;

            species[0] = lion;



            CatSpecies tiger = new CatSpecies
            {
                Name = "Tiger",
                Population = 27383,
                Pattern = "Black and Orange, Striped",
                BigCat = true,
                CatSpeciesID = 1
            };

            species[1] = tiger;

        }

        public CatSpecies AddCatSpecies(CatSpecies catSpecies)
        {
            for (int i = 0; i < species.Length; i++)
            {
                if (species[i] == null) // adds the species to the first open index in the array; that becomes it's ID number.
                {
                    catSpecies.CatSpeciesID = i;
                    species[i] = catSpecies;
                    return catSpecies;
                }
            }

            return catSpecies;
        }

        public CatSpecies[] GetAllCatSpecies()
        { 
            return species;
        }



        // loops through the array to find the species associated with the selected ID
        public CatSpecies FindById(int catSpeciesID)
        {
            CatSpecies speciesId = new CatSpecies();

            for (int i = 0; i < species.Length; i++)
            {

                if (species[i] == null)
                {
                    continue;
                }


                if (species[i].CatSpeciesID == catSpeciesID)
                {
                    speciesId = species[i];
                }

            }

            return speciesId;
        }


        public void RemoveCatSpecies(int catSpeciesID)
        {
            for (int i = 0; i < species.Length; i++)
            {

                if (species[i] == null)
                {
                    continue;
                }


                if (species[i].CatSpeciesID == catSpeciesID)
                {
                    species[i].Population = 0;
                    species[i].Pattern = null;
                    species[i].Name = null;
                    species[i].BigCat = false;
                    // ID becomes an empty spot in the array
                }

            }

        }

        public void UpdateSpecies(int id, string newName, bool newBigCat, int newPop, string newPattern, int newId)
        {
            for (int i = 0; i < species.Length; i++)
            {

                if (species[i] == null)
                {
                    continue;
                }


                if (species[i].CatSpeciesID == id)
                {
                    species[i].Name = newName;
                    species[i].BigCat = newBigCat;
                    species[i].Population = newPop;
                    species[i].Pattern = newPattern;
                    species[i].CatSpeciesID = newId;
                }

            }

        }

    }

}
