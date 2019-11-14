using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Data;
using RestaurantReservation.Models;
using RestaurantReservation.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantReservation.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        public ApplicationDbContext _context { get; }
        public readonly ILogger<Reservation> logger;

        public ReservationController(ApplicationDbContext applicationDbContext, ILogger<Reservation> logger)
        {
            this.logger = logger;
            _context = applicationDbContext;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = await _context.Reservations.AsNoTracking().Include(r => r.Table).OrderBy(r => r.ReservationStart).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Confirm(ReservationViewModel reservationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Table = await _context.Tables.FindAsync(reservationViewModel.TableId);
            if (Table == null)
            {
                return NotFound();
            }
            ViewBag.TableNumber = Table.TableNumber;
            ViewBag.Description = Table.Description;
            return View(reservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel reservationVeiwModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Reservation reservation = new Reservation
            {
                ReservationStart = reservationVeiwModel.ReservationStart,
                ReservationEnd = reservationVeiwModel.ReservationEnd,
                NumberOfPeople = reservationVeiwModel.NumberOfPeople,
                TableId = reservationVeiwModel.TableId
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
