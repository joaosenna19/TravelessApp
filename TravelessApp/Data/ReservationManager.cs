namespace TravelessApp.Data;

public class ReservationManager
{
    private static string ReservationFilePath { get; set; }


    private static List<Reservation> Reservations = new();
    public static List<Flight> Flights { get; private set; }

    public ReservationManager()
    {
        Flights = FlightManager.Flights;
        ReservationFilePath = @"C:\Users\joaor\OneDrive\Desktop\Programming\C#\Projects\TravelessApp\TravelessApp\Data\res\reservations.csv";
        CreateReservations();
    }
    
    public static List<Reservation> GetReservations()
    {
        return Reservations;
    }

    private void CreateReservations()
    {
        var reservations = new List<Reservation>();

        using var sr = new StreamReader(ReservationFilePath);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            var values = line.Split(',');
            var flightCode = values[0];
            var name = values[1];
            var citizenship = values[2];
            var reservationCode = values[3];
            var isActive = bool.Parse(values[4]);
            
            reservations.Add(new Reservation(flightCode, name, citizenship, reservationCode, isActive));
        }

        Reservations = reservations;
    }
    
    public static string GenerateReservationCode()
    {
        Random random = new Random();
        string reservationCode;

        do
        {
            int randomNumber = random.Next(1000, 10000);
            char randomLetter = (char)random.Next('A', 'Z' + 1);
            reservationCode = $"{randomLetter}{randomNumber}";
        }
        while (Reservations.Any(reservation => reservation.ReservationCode == reservationCode));

        return reservationCode;
    }


    public static Reservation CreateNewReservation(Flight flight, string name, string citizenship, string reservationCode)
    {
        var newReservation = new Reservation(flight.FlightCode, name, citizenship, reservationCode, true);
        return newReservation;
    }

    public static void WriteOnReservationFile()
    {
        using var wr = new StreamWriter(ReservationFilePath);
        foreach (var reservation in Reservations)
        {
            wr.WriteLine(reservation);
        }
    }

}