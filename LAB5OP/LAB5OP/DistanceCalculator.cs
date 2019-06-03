using System;

namespace LAB5OP
{
    static class DistanceCalculator
    {
        const double PIx = 3.141592653589793;
        const double RADIUS = 6378.16;

        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        public static double Radians(double x)
        {
            return x * PIx / 180;
        }

        /// <summary>
        /// Calculate the distance between two places.
        /// </summary>
        public static double DistanceBetweenPlaces(Cartesian c1, Cartesian c2)
        {
            double dlon = Radians(c2.Longitude - c1.Longitude);
            double dlat = Radians(c2.Latitude - c1.Latitude);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(c1.Latitude)) * Math.Cos(Radians(c2.Latitude)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return angle * RADIUS;
        }
    }
}
