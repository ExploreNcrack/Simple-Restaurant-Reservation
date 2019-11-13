using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Data;
using RestaurantReservation.Models;
using RestaurantReservation.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantReservation.Controllers
{
    public class TableController : Controller
    {
        public ApplicationDbContext _context { get; }

        public TableController(ApplicationDbContext applicationDbContext)
        {
            // constructor injection to inject DbCotnext
            _context = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.Tables.OrderBy(t => t.TableNumber).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TableCreateViewModel tableCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                Table newTable = new Table
                {
                    TableNumber = tableCreateViewModel.TableNumber,
                    NumberOfSeats = tableCreateViewModel.NumberOfSeats,
                    Description = tableCreateViewModel.Description
                };

                _context.Tables.Add(newTable);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); 
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            var tableViewModel = new TableEditViewModel
            {
                Id = table.TableId,
                TableNumber = table.TableNumber,
                Description = table.Description,
                NumberOfSeats = table.NumberOfSeats
            };
            return View(tableViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TableEditViewModel tableEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Table oldTable = await _context.Tables.FindAsync(tableEditViewModel.Id);
                if (oldTable == null)
                {
                    return NotFound();
                }

                oldTable.TableNumber = tableEditViewModel.TableNumber;
                oldTable.NumberOfSeats = tableEditViewModel.NumberOfSeats;
                oldTable.Description = tableEditViewModel.Description;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> FindAvailableTables(ReservationViewModel reservationViewModel)
        {
            if (ModelState.IsValid)
            {
                var AllAvailableTables = await _context.Tables
                     .AsNoTracking()
                     .Where(t => t.NumberOfSeats >= reservationViewModel.NumberOfPeople)
                     .Where(t => !_context.Reservations
                                     .Any(r => r.Table.TableId == t.TableId && (
                                                 (reservationViewModel.ReservationStart < r.ReservationStart && r.ReservationStart < reservationViewModel.ReservationEnd)
                                                  ||
                                                 (reservationViewModel.ReservationStart > r.ReservationStart && r.ReservationEnd > reservationViewModel.ReservationStart) )
                                         )
                            )
                     .ToListAsync();
                return PartialView("TablesPartial", AllAvailableTables);
            }
            return BadRequest();
        }
    }
}
