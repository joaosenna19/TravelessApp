namespace TravelessApp.Data;

public class Reservation
{
    public string FlightCode { get; set; }
    public string Name { get; set; }
    public string Citizenship { get; set; }
    
    public string ReservationCode { get; set; }

    public bool IsActive { get; set; }

    public Reservation(string flightCode, string name, string citizenship, string reservationCode, bool isActive)
    {
        FlightCode = flightCode;
        Name = name;
        Citizenship = citizenship;
        ReservationCode = reservationCode;
        IsActive = isActive;
    }

    public override string ToString()
    {
        return $"{FlightCode},{Name},{Citizenship},{ReservationCode},{IsActive}";
    }
}
