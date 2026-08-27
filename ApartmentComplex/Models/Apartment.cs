using System.ComponentModel.DataAnnotations;
namespace ApartmentComplex.Models;

public class Apartment
{

  public int Id { get; set; }

  [Required]
  [Display(Name = "Unit Number")]
  public string UnitNumber { get; set; } = string.Empty;

  [Range(0, 10)]
  public int Bedrooms { get; set; }

  [Required]
  [Range(0.01, 1000000)]
  [DataType(DataType.Currency)]
  public decimal MonthlyRent { get; set; }

  [Display(Name = "Occupied")]
  public bool IsOccupied { get; set; }
}
