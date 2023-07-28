using CatSpeciesManager.Controllers;
using CatSpeciesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatSpeciesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            CatSpeciesController controller = new CatSpeciesController();
            controller.Run();
        }

    }

}
