public class Location
{
    public double Lon { get; set; }
    public double Lat { get; set; }

    public string LatLonFormatted => $"{Lat.ToString().Replace(',', '.')}, {Lon.ToString().Replace(',', '.')}";
}

public class AirportResponse
{
    public string Country { get; set; }
    public string City_iata { get; set; }
    public string Iata { get; set; }
    public string City { get; set; }
    public string Country_iata { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
}