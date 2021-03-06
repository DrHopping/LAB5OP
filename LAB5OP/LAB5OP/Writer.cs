﻿using System;
using System.Collections.Generic;
using System.IO;

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
        public void PrintToFile(string fileName)
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("We found next entities in the sector:");
                for (int i = 0; i < places.Count; i++)
                {
                    sw.WriteLine($"{i + 1}. {places[i].ToString()}");
                }
            }
        }

    }
}
