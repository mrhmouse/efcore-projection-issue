using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ProjectionErrors
{
    public static class Program
    {
        public static void Main()
        {
            var options = new DbContextOptionsBuilder().UseSqlServer("Data Source=(local);Initial Catalog=example_db;Integrated Security=true").Options;
            var context = new ExampleContext(options);

            var items = context.PointsOfInterest.Select(p => new Foo
            {
                Label = p.Label,
                Location = p.X.HasValue && p.Y.HasValue
                    ? new Location { X = p.X.Value, Y = p.Y.Value }
                    : (Location?)null,
            });

            Console.WriteLine("Items:");
            foreach (var item in items)
                Console.WriteLine($"- {item.Location?.X}, {item.Location?.Y}");
        }
    }
}
