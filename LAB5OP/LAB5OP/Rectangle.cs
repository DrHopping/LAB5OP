using System;

namespace LAB5OP
{
    public class Rectangle
    {
        internal const int DIMENSIONS = 3;
        internal float[] max;
        internal float[] min;

        public Rectangle(float x1, float y1, float x2, float y2, float z1, float z2)
        {
            min = new float[DIMENSIONS];
            max = new float[DIMENSIONS];
            set(x1, y1, x2, y2, z1, z2);
        }

        public Rectangle(float[] min, float[] max)
        {
            this.min = new float[DIMENSIONS];
            this.max = new float[DIMENSIONS];

            set(min, max);
        }

        internal void set(float x1, float y1, float x2, float y2, float z1, float z2)
        {
            min[0] = Math.Min(x1, x2);
            min[1] = Math.Min(y1, y2);
            min[2] = Math.Min(z1, z2);
            max[0] = Math.Max(x1, x2);
            max[1] = Math.Max(y1, y2);
            max[2] = Math.Max(z1, z2);
        }

        internal void set(float[] min, float[] max)
        {
            System.Array.Copy(min, 0, this.min, 0, DIMENSIONS);
            System.Array.Copy(max, 0, this.max, 0, DIMENSIONS);
        }

        internal Rectangle copy()
        {
            return new Rectangle(min, max);
        }

        internal bool intersects(Rectangle r)
        {
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (max[i] < r.min[i] || min[i] > r.max[i])
                {
                    return false;
                }
            }
            return true;
        }

        internal void add(Rectangle r)
        {
            for (int i = 0; i < DIMENSIONS; i++)
            {
                if (r.min[i] < min[i])
                {
                    min[i] = r.min[i];
                }
                if (r.max[i] > max[i])
                {
                    max[i] = r.max[i];
                }
            }
        }

        internal float area()
        {
            return (max[0] - min[0]) * (max[1] - min[1]);
        }

        internal float enlargement(Rectangle r)
        {
            float enlargedArea = (Math.Max(max[0], r.max[0]) - Math.Min(min[0], r.min[0])) *
                                 (Math.Max(max[1], r.max[1]) - Math.Min(min[1], r.min[1]));

            return enlargedArea - area();
        }
    }
}
