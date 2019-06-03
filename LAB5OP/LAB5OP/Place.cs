namespace LAB5OP
{ 
    class Place
    {
        public Cartesian Cartesian { get; set; }
        public Point Point { get; set; }
        public string[] Info { get; set; }
        public Place(Cartesian cartesian, params string[] info)
        {
            this.Cartesian = cartesian;
            this.Info = info;
            this.Point = Converter.CartesianToSpherical(cartesian);
        }
    }
}
