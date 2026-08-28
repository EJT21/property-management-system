using ApartmentComplex.Data;
using ApartmentComplex.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentComplex.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {

  }
  public DbSet<Apartment> Apartments { get; set; }
}
