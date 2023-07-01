namespace TravelessApp.Data;

public class Flight
{
    public string FlightCode { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public int AvailableSeats { get; set; }
    public double Cost { get; set; }

    public Flight(string flightCode, string airline, string from, string to, string day, string time, int availableSeats, double cost)
    {
        FlightCode = flightCode;
        Airline = airline;
        From = from;
        To = to;
        Day = day;
        Time = time;
        AvailableSeats = availableSeats;
        Cost = cost;
    }

    public override string ToString()
    {
        return
            $"Code: {FlightCode}, Airline: {Airline} From: {From}, To: {To}, Day: {Day}, Time: {Time}";
    }
}