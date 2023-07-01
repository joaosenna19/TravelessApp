namespace TravelessApp.Data;

public class Reservation
{
    public string FlightCode { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public int AvailableSeats { get; set; }
    public double Cost { get; set; }
    public string Name { get; set; }
    public string Citizenship { get; set; }
    
    public string ReservationCode { get; set; }

    public bool isActive { get; set; }

    public Reservation(string flightCode, string airline, string from, string to, string day, string time, int availableSeats, double cost, string name, string citizenship, string reservationCode, bool isActive)
    {
        FlightCode = flightCode;
        Airline = airline;
        From = from;
        To = to;
        Day = day;
        Time = time;
        AvailableSeats = availableSeats;
        Cost = cost;
        Name = name;
        Citizenship = citizenship;
        ReservationCode = reservationCode;
        this.isActive = isActive;
    }

    public override string ToString()
    {
        return $"Code: {FlightCode}, Airline: {Airline} From: {From}, " +
               $"To: {To}, Day: {Day}, Time: {Time}, Client: {Name}";
    }
}