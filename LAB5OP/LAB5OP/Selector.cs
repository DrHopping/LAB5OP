using System.Collections.Generic;
using System.Linq;

namespace LAB5OP
{
    class Selector
    {
        public List<Place> Places { get; set; }

        private RTree<Place> tree = new RTree<Place>(); 
        public Selector(List<Place> places)
        {
            this.Places = places;
            AddPlacesToTree();
        }
        private void AddPlacesToTree()
        {
            foreach (var place in Places)
            {
                tree.Add(place.Point, place);
            }
        }

        /// <summary>
        /// Select places in region with center, radius and given parameters
        /// </summary>
        /// <param name="point">Center of region</param>
        /// <param name="radius">Radius of region</param>
        /// <param name="parameters">Parameters: type, subtype, name, address</param>
        /// <returns>Places that satisfy conditions</returns>
        public List<Place> SelectNearest(Point point, float radius, params string[] parameters)
        {
            var nearest = tree.Nearest(point, radius);
            if (parameters.Length > 4) { throw new System.ArgumentException("To many arguments"); }
            var 
        }
    }
}
