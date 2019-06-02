namespace LAB5OP
{
    public class Point
    {
        private const int DIMENSIONS = 3;

        internal float[] coordinates;

        public Point(float x, float y, float z)
        {
            coordinates = new float[DIMENSIONS];
            coordinates[0] = x;
            coordinates[1] = y;
            coordinates[2] = z;
        }
    }
}
