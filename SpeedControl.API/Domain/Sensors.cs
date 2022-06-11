namespace SpeedControl.API.Domain
{
    public class Sensors
    {       
        public Coordinate Location { get; set; } =  new Coordinate();
        public string Image { get; set; } = string.Empty;
        public int Altitude { get; set; }
        public int Velocity { get; set; }
        public string City { get; set; } = string.Empty;
    }
}
