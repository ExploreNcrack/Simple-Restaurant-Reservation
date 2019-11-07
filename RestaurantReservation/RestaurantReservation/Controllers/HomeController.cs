using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Data;
using RestaurantReservation.Models;

namespace RestaurantReservation.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext _context { get; }

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
            var MaxSeat = 10;
            if (_context.Tables.Any())
            {
                MaxSeat = _context.Tables
                    .AsNoTracking()
                    .Select(t => t.NumberOfSeats)
                    .Max(t => t);
            }
            ViewBag.MaxSeat = MaxSeat;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
