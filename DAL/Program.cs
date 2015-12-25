using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Fridge f = FridgeDataAccess.GetFridge(1);
            Console.WriteLine(f.Name);
            Console.ReadLine();
        }
    }
}
