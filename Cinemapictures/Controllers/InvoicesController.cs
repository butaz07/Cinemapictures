using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinemapictures.Models.Entities;
using System.Text.Json;

namespace Cinemapictures.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly DataContex _context;

        public InvoicesController(DataContex context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContex = _context.Invoices.Include(i => i.Client).Include(i => i.Employee).Include(i => i.Movie);
            return View(await dataContex.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Client)
                .Include(i => i.Employee)
                .Include(i => i.Movie)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        public IActionResult Create()
        {
            var movies = _context.Movies.ToList();
            ViewData["MoviePrices"] = JsonSerializer.Serialize(movies.ToDictionary(m => m.MoviesId, m => m.DailyRentalCost));

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
            ViewData["MovieId"] = new SelectList(movies, "MoviesId", "MovieTitle");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,ClientId,EmployeeId,MovieId,Subtotal,TotalTax,Date,TotalAmount")] Invoice invoice, int NumberOfDays)
        {
            if (ModelState.IsValid)
            {
                invoice.NumberOfDays = NumberOfDays;
                invoice.DueDate = invoice.Date.AddDays(NumberOfDays);
                invoice.FineAmount = 0; // Default fine to 0 on creation

                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var movies = _context.Movies.ToList();
            ViewData["MoviePrices"] = JsonSerializer.Serialize(movies.ToDictionary(m => m.MoviesId, m => m.DailyRentalCost));

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", invoice.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", invoice.EmployeeId);
            ViewData["MovieId"] = new SelectList(movies, "MoviesId", "MovieTitle", invoice.MovieId);
            return View(invoice);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", invoice.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", invoice.EmployeeId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MoviesId", "MovieTitle", invoice.MovieId);
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,ClientId,EmployeeId,MovieId,Subtotal,TotalTax,Date,TotalAmount,NumberOfDays,DueDate,ReturnDate,FineAmount")] Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", invoice.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", invoice.EmployeeId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "MoviesId", "MovieTitle", invoice.MovieId);
            return View(invoice);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Client)
                .Include(i => i.Employee)
                .Include(i => i.Movie)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Action for Rental History
        public async Task<IActionResult> History()
        {
            var rentalHistory = await _context.Invoices
                .Include(i => i.Client)
                .Include(i => i.Movie)
                .OrderByDescending(i => i.Date)
                .ToListAsync();
            return View(rentalHistory);
        }

        // Action to process a return
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            if (invoice.ReturnDate == null) // Only process if not already returned
            {
                invoice.ReturnDate = DateTime.Now;

                if (invoice.ReturnDate.Value.Date > invoice.DueDate.Date)
                {
                    invoice.FineAmount = (decimal)invoice.TotalAmount * 0.05m;
                }

                _context.Update(invoice);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(History));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}