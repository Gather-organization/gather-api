using gather_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace gather_api.DbContexts {
  public class GatherContext : DbContext {
    public DbSet<Person> Person { get; set; } = null!;

    public GatherContext(DbContextOptions<GatherContext> options) : base(options) {

    }
  }
}
