namespace TravelessApp.Data;

public class ReservationManager
{
    private static string ReservationFilePath { get; set; }


    public static List<Reservation> Reservations { get; set; }
    public static List<Flight> Flights { get; private set; }

    public ReservationManager()
    {
        Flights = FlightManager.Flights;
        ReservationFilePath = @"C:\Users\joaor\OneDrive\Desktop\Programming\C#\Projects\TravelessApp\TravelessApp\Data\res\reservations.csv";
        Reservations = CreateReservations();
        AssociateFlight();
    }
    
  

    private List<Reservation> CreateReservations()
    {
        var reservations = new List<Reservation>();

        if (new FileInfo(ReservationFilePath).Length <= 0) return reservations;
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

        return reservations;
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
    
    private void AssociateFlight()
    {
        foreach (var reservation in Reservations)
        {
            foreach (var flight in Flights.Where(flight => flight.FlightCode == reservation.FlightCode))
            {
                reservation.FlightAssociated = flight;
            }
        }
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