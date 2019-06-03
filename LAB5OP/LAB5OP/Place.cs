namespace LAB5OP
{ 
    class Place
    {
        public Cartesian Cartesian { get; set; }
        public Point Point { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Address { get; set; }
        public Place(Cartesian cartesian, string type, string subtype, string address)
        {
            this.Cartesian = cartesian;
            this.Type = type;
            this.Subtype = subtype;
            this.Address = address;
            this.Point = Converter.CartesianToSpherical(cartesian);
        }
    }
}
