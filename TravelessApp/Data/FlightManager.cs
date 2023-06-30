using Microsoft.Maui.Controls.Shapes;
using Path = System.IO.Path;

namespace TravelessApp.Data;

public class FlightManager
{
    private string FlightFilePath { get; }
    private string AirportFilePath { get; }
    public static List<Flight> Flights { get; private set; }
    public static List<Airport> Airports { get; private set; }
    

    public FlightManager()
    {
        FlightFilePath = @"C:\Users\joaor\OneDrive\Desktop\Programming\C#\Projects\TravelessApp\TravelessApp\Data\res\flights.csv";
        AirportFilePath = @"C:\Users\joaor\OneDrive\Desktop\Programming\C#\Projects\TravelessApp\TravelessApp\Data\res\airports.csv";
        Flights = createFlights();
        Airports = createAirports();
    }

    private List<Airport> createAirports()
    {
        var airports = new List<Airport>();
        
        using var sr = new StreamReader(AirportFilePath);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var values = line.Split(',');
            var code = values[0];
            var fullName = values[1];
            
            airports.Add(new Airport(code, fullName));
        }

        return airports;
    }

    private List<Flight> createFlights()
    {
        var flights = new List<Flight>();
        
        using var sr = new StreamReader(FlightFilePath);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var values = line.Split(',');
            var flightCode = values[0];
            var airline = values[1];
            var from = values[2];
            var to = values[3];
            var day = values[4];
            var time = values[5];
            var availableSeats = int.Parse(values[6]);
            var cost = double.Parse(values[7]);

            flights.Add(new Flight(flightCode, airline, from, to, day, time, availableSeats, cost));
        }

        return flights;
    }
}