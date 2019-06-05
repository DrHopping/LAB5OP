using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LAB5OP
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsParser arguments = new ArgsParser(args);
            List<Place> list = new Reader(arguments.GetDataBaseName()).GetPlacesList();
            Selector selector = new Selector(list);
            Cartesian cartesian = arguments.GetCartesian();
            float radius = arguments.GetRadius();
            var parameters = arguments.GetParameters();
            Place selected = selector.FindOneNearest(cartesian,parameters);
            Console.WriteLine("Nearest entity:");
            Console.WriteLine($"1. {selected.ToString()} Distance: {DistanceCalculator.DistanceBetweenPlaces(selected.Cartesian,cartesian)}");
            //Writer wr = new Writer(selected);
            //wr.PrintToConsole();
            //wr.PrintToFile("output.txt");

            Console.ReadKey();
        }
    }
}
