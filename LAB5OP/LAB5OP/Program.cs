using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LAB5OP
{
    class Program
    {
        static void ConverterTest()
        {
            //float lat = 51.85035f;
            //float lon = 4.351721f;
            //var a = Converter.CartesianToSpherical(lat, lon);
            //Console.WriteLine(a.Item1 + " " + a.Item2 + " " + a.Item3);
            //var b = Converter.SphericalToCartesian(a.Item1, a.Item2, a.Item3);
            //Console.WriteLine(b.Item1 + " " + b.Item2);
        }
        static void DistanceTest()
        {
            RTree<string> tree = new RTree<string>();
            float lat1 = 51.85035f;
            float lon1 = 4.351721f;
            float lat2 = 51.05434f;
            float lon2 = 3.717424f;
            var cart1 = new Cartesian(lat1, lon1);
            var cart2 = new Cartesian(lat2, lon2);


            var p1 = Converter.CartesianToSpherical(cart1);
            var p2 = Converter.CartesianToSpherical(cart2);

            Console.WriteLine(DistanceCalculator.DistanceBetweenPlaces(cart1,cart2));

            tree.Add(p1, "Brussels");

            var a = tree.Nearest(p2, 99);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            ArgsParser arguments = new ArgsParser(args);
            List<Place> list = new Reader(arguments.GetDataBaseName()).GetPlacesList();
            Selector selector = new Selector(list);
            Cartesian cartesian = arguments.GetCartesian();
            float radius = arguments.GetRadius();
            var parameters = arguments.GetParameters();
            List<Place> selected = selector.SelectNearest(cartesian,radius,parameters);
            Writer wr = new Writer(selected);
            wr.PrintToConsole();

            Console.ReadKey();
        }
    }
}
