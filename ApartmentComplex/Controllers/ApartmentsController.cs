using ApartmentComplex.Data;
using ApartmentComplex.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartmentComplex.Controllers;

public class ApartmentsController : Controller
{
  private readonly ApplicationDbContext _context;

  public ApartmentsController(ApplicationDbContext context)
  {
    _context = context;
  }

  //Get : Apartments
  public async Task<IActionResult> Index()
  {
    return View(await _context.Apartments.ToListAsync());
  }

  //Get Apartments/Details/5
  public async Task<IActionResult> Details(int? id)
  {
    if(id == null)
      return NotFound();
  
  var apartment = await _context.Apartments.FirstOrDefaultAsync(m => m.Id == id);
  if (apartment == null)
  {
    return NotFound();
  }
  return View(apartment);
  }

  // GET: Apartments/Create
  public IActionResult Create()
  {
      return View();
  }

  //Post Apartments/Create
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create([Bind("Id, UnitNumber,Bedrooms,Bathrooms,MonthlyRent,IsOccupied")] Apartment apartment)
  {
    if(ModelState.IsValid)
    {
      _context.Add(apartment);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
    return View(apartment);
  }
}