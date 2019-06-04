using System;
using System.Collections.Generic;

namespace LAB5OP
{
    class Writer
    {
        private List<Place> places;
        public Writer(List<Place> places)
        {
            this.places = places;
        }

        public void PrintToConsole()
        {
            Console.WriteLine("We found next entities in the sector:");
            for (int i = 0; i < places.Count; i++)
            {
                Console.WriteLine($"{i+1}. {places[i].ToString()}");
            }
        }

    }
}
