using System;

namespace LAB5OP
{
    class Converter
    {
        const double PIx = 3.141592653589793;
        const double RADIUS = 6378.16;

        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        private static double Radians(double x)
        {
            return x * PIx / 180;
        }
        private static double Degrees(double x)
        {
            return x * 180 / PIx;
        }
        static public Point CartesianToSpherical(Cartesian cartesian)
        {
            float latitude = (float)Radians(cartesian.Latitude);
            float longitude = (float)Radians(cartesian.Longitude);
            var x = RADIUS * Math.Cos(latitude) * Math.Cos(longitude);
            var y = RADIUS * Math.Cos(latitude) * Math.Sin(longitude);
            var z = RADIUS * Math.Sin(latitude);
            return new Point((float)x, (float)y, (float)z);
        }

        static public Tuple<float,float> SphericalToCartesian(Point point)
        {
            var x = point.coordinates[0];
            var y = point.coordinates[1];
            var z = point.coordinates[2];

            var r = Math.Sqrt(x * x + y * y + z * z);
            var lat = Degrees(Math.Asin(z / r));
            var lon = Degrees(Math.Atan2(y, x));

            return new Tuple<float, float>((float)lat, (float)lon);
        }
    }
}
