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
        static public Tuple<float,float,float> CartesianToSpherical(float latitude,float longitude)
        {
            latitude = (float)Radians(latitude);
            longitude = (float)Radians(longitude);
            var x = RADIUS * Math.Cos(latitude) * Math.Cos(longitude);
            var y = RADIUS * Math.Cos(latitude) * Math.Sin(longitude);
            var z = RADIUS * Math.Sin(latitude);
            return new Tuple<float, float, float>((float)x, (float)y, (float)z);
        }

        static public Tuple<float,float> SphericalToCartesian(float x, float y, float z)
        {
            var r = Math.Sqrt(x * x + y * y + z * z);
            var lat = Degrees(Math.Asin(z / r));
            var lon = Degrees(Math.Atan2(y, x));
            return new Tuple<float, float>((float)lat, (float)lon);
        }
    }
}
