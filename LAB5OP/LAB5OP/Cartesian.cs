namespace LAB5OP
{
    class Cartesian
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public Cartesian(float latitude, float longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}
