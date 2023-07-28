using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatSpeciesManager.Models
{
    public class CatSpecies
    {
        public int CatSpeciesID { get; set; }
        public string Name { get; set; }
        public string Pattern { get; set; }
        public bool BigCat { get; set; }
        public int Population { get; set; }

        public CatSpecies()
        {

        }

        public void Print()
        {
            Console.WriteLine("Identification Number: " + CatSpeciesID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Pattern: " + Pattern);
            Console.WriteLine("Big Cat?: " + BigCat);
            Console.WriteLine("Population: " + Population);
            Console.WriteLine("");
        }
    }
}
