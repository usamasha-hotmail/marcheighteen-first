using System.Reflection;
using System.Text.Json;
using Contoso.Spaces.Console.Models;
using Out = Colorful.Console;

namespace Contoso.Spaces.Console
{
    internal class Program
    {
        /// <summary>
        /// Console app to list available rentals.
        /// </summary>
        /// <param name="seats">Minimum number of seats in results</param>
        static async Task Main(int? seats)
        {
            int seatFilter = 0;
            if (seats.HasValue) {
                seatFilter = seats.Value;
                Out.WriteLine($"Seat Filter: {seatFilter:00}");
            }

            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Data.locations.json"))
            {
                await foreach (Location location in JsonSerializer.DeserializeAsyncEnumerable<Location>(stream))
                {
                    if (location.Rooms.Any(r => r.Seats >= seatFilter))
                    {
                        Out.WriteLine();
                        Out.WriteLine(location.Name);
                        Out.WriteLine(location.MailingAddress);
                        Out.WriteLine("Rooms:");
                        Out.WriteLine($"\t{nameof(Room.Description),-25}\t{nameof(Room.Seats),-2}\t{nameof(Room.MonthlyRate),8:C}");
                        foreach(Room room in location.Rooms.Where(r => r.Seats >= seatFilter))
                        {
                            Out.WriteLine($"\t{room.Description,-25}\t{room.Seats,-2}\t{room.MonthlyRate,8:C}");
                        }
                    }
                }
            }

        }
    }
}