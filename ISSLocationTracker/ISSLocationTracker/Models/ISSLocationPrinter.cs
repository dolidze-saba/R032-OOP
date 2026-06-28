namespace ISSLocationTracker.Models {

    public class ISSLocationPrinter {
        public void Print(ISSLocation location) {
            Console.WriteLine($"Time: {DateTime.Now:T}\n");
            Console.WriteLine($"Satellite : {location.Name}");
            Console.WriteLine($"Latitude  : {location.Latitude:F4}");
            Console.WriteLine($"Longitude : {location.Longitude:F4}");
            Console.WriteLine($"Altitude  : {location.Altitude:F2} kilometers");
            Console.WriteLine($"Velocity  : {location.Velocity:F2} km/h");
            Console.WriteLine($"Visibility: {location.Visibility}");
        }

        public void PrintError() {
            Console.WriteLine("Could not fetch ISS location.");
        }
    }
}
