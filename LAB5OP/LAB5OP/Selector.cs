using System.Collections.Generic;

namespace LAB5OP
{
    class Selector
    {
        public List<Place> Places { get; set; }

        private RTree<Place> tree = new RTree<Place>(); 
        public Selector(List<Place> places)
        {
            this.Places = places;
            addPlacesToTree();
        }
        private void addPlacesToTree()
        {
            foreach (var place in Places)
            {
                tree.Add(place.Point, place);
            }
        }
        private bool satisfyParameters(Place place, string[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (place.Info[i] == null || place.Info[i] != parameters[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Select places in region with center, radius and given parameters
        /// </summary>
        /// <param name="point">Center of region</param>
        /// <param name="radius">Radius of region</param>
        /// <param name="parameters">Parameters: type, subtype, name, address</param>
        /// <returns>Places that satisfy parameters</returns>
        public List<Place> SelectNearest(Cartesian cartesian, float radius, params string[] parameters)
        {
            var nearest = tree.Nearest(Converter.CartesianToSpherical(cartesian), radius);
            var satisfying = new List<Place>();
            foreach (var place in nearest)
            {
                if (satisfyParameters(place, parameters))
                    satisfying.Add(place);
            }
            return satisfying;
        }
    }
}
