namespace TravelessApp.Data;

public class ReservationManager
{
    public string ReservationFilePath { get; }
    
    
    public static List<Reservation> Reservations { get; private set; }
    public static List<Flight> Flights { get; private set; }

    public ReservationManager()
    {
        Flights = FlightManager.Flights;
        ReservationFilePath = @"C:\Users\joaor\OneDrive\Desktop\Programming\C#\Projects\TravelessApp\TravelessApp\Data\res\reservations.csv";
        Reservations = createReservations();
    }

    private List<Reservation> createReservations()
    {
        var reservations = new List<Reservation>();

        using var sr = new StreamReader(ReservationFilePath);
        string line;
        while ((line = sr.ReadLine()) == null)
        {
            var values = line.Split(',');
            var flightCode = values[0];
            var name = values[1];
            var citizenship = values[2];
            var reservationCode = values[3];
            var isActive = bool.Parse(values[4]);
            
            reservations.Add(new Reservation(flightCode, name, citizenship, reservationCode, isActive));
        }
        
        return reservations;
    }
    
    public static string GenerateReservationCode()
    {
       var random = new Random();
        string reservationCode;

        do
        {
            var randomNumber = random.Next(1000, 10000);
            var randomLetter = (char)random.Next('A', 'Z' + 1);
            reservationCode = $"{randomLetter}{randomNumber}";
        }
        while (Reservations.Any(reservation => reservation.ReservationCode == reservationCode));

        return reservationCode;
    }

}