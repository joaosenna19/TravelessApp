using Microsoft.Maui.Controls.Shapes;

namespace TravelessApp.Data;

public class FlightManager
{
    private string FilePath { get; }
    private List<Flight> Flights { get; }

    public FlightManager(string filePath)
    {
        FilePath = filePath;
        Flights = null;
    }

    private List<Flight> createFlights()
    {
        var flights = new List<Flight>();

        using var sr = new StreamReader(FilePath);
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