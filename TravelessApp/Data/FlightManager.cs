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
        FlightFilePath = Path.Combine(FileSystem.AppDataDirectory, Path.Combine("TravelessApp", "Data", "res", "flights.csv"));
        FlightFilePath = Path.Combine(FileSystem.AppDataDirectory, Path.Combine("TravelessApp", "Data", "res", "airports.csv"));
        createFlights();
        createAirports();
    }

    private void createAirports()
    {
        
        using var sr = new StreamReader(AirportFilePath);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var values = line.Split(',');
            var code = values[0];
            var fullName = values[1];
            
            Airports.Add(new Airport(code, fullName));
        }

        
    }

    private void createFlights()
    {
        
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

            Flights.Add(new Flight(flightCode, airline, from, to, day, time, availableSeats, cost));
        }
    }
}