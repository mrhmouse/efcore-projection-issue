using Microsoft.EntityFrameworkCore;

namespace ProjectionErrors
{
    public class ExampleContext : DbContext
    {
        public ExampleContext(DbContextOptions options) : base(options) { }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}
