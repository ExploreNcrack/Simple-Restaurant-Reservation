using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data;
using RestaurantReservation.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantReservation.Controllers
{
    public class TableController : Controller
    {
        public ApplicationDbContext _context { get; }

        public TableController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            // constructor injection to inject DbCotnext

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FindAvailableTables(ReservationViewModel reservationViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Tables
                    .Where(t => t.NumberOfSeats >= reservationViewModel.NumberOfPeople)
                    .Where(t => !_context.Reservations
                                    .Where(r => r.Table.TableId == t.TableId &&
                                                reservationViewModel.ReservationStart < r.ReservationStart &&
                                                r.ReservationStart < reservationViewModel.ReservationEnd &&
                                                reservationViewModel.ReservationStart < r.ReservationEnd &&
                                                r.ReservationEnd < reservationViewModel.ReservationEnd)
                                    .Select(r => r.Table.TableId)
                                    .ToList()
                                    .Contains(t.TableId)
                           );
            }
            return View();
        }
    }
}
