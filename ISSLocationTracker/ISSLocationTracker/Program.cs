using ISSLocationTracker.Models;
using ISSLocationTracker.Services;

public class Program {
    public static async Task Main() {
        Console.WriteLine("ISS Location Tracker");
        Console.WriteLine("--------------------");

        Console.Write("Enter update interval in seconds (minimum 0.5): ");

        double intervalSeconds;

        while (!double.TryParse(Console.ReadLine(), out intervalSeconds) || intervalSeconds < 0.5) {
            Console.Write("Please enter a value of 0.5 or greater: ");
        }

        int delay = (int)(intervalSeconds * 1000);

        var service = new ISSLocationService();
        var printer = new ISSLocationPrinter();

        while (true) {
            Console.Clear();

            Console.WriteLine("ISS Location Tracker");
            Console.WriteLine("--------------------");
            Console.WriteLine();

            var location = await service.GetLocationAsync();

            if (location != null) {
                printer.Print(location);
            }
            else {
                printer.PrintError();
            }

            Console.WriteLine();
            Console.WriteLine($"Updating again in {intervalSeconds} second(s)...");

            await Task.Delay(delay);
        }
    }
}