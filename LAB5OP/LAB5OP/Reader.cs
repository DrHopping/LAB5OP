using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LAB5OP
{
    class Reader
    {
        public string FileName { get; }
        public Reader(string fileName)
        {
            this.FileName = fileName;
        }
        public List<Place> GetPlacesList()
        {
            var places = new List<Place>();
            using (StreamReader sr = new StreamReader(FileName))
            {
                string line = "";
                while(true)
                {
                    line = sr.ReadLine();
                    if (line == null) break;
                    var info = line.Split(';');
                    var latitude = float.Parse(info[0]);
                    var longitude = float.Parse(info[1]);
                    var parameters = info.Skip(2).ToArray();
                    places.Add(new Place(new Cartesian(latitude, longitude), parameters));
                }
            }
            return places;
        }
    }
    
}
