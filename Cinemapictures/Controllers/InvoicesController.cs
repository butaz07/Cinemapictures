
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinemapictures.Models.Entities;

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
           
            var dataContex = _context.Invoices.Include(i => i.Client).Include(i => i.Employee);

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
                .FirstOrDefaultAsync(m => m.InvoiceId == id); 
            if (invoice == null)
            {
                return NotFound();
            }

            
            return View(invoice);
        }

        
        public IActionResult Create()
        {
            
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name");
            

            
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,ClientId,EmployeeId,MovieId,RentId,Subtotal,TotalTax,Date,TotalAmount")] Invoice invoice)
        {
          

            
            if (ModelState.IsValid)
            {
                
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name", invoice.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Name", invoice.EmployeeId);
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
            return View(invoice);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceId,ClientId,EmployeeId,MovieId,RentId,Subtotal,TotalTax,Date,TotalAmount")] Invoice invoice)
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

        
        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}
