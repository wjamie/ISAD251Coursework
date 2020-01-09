using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinksAndSnacks.Models;

namespace DrinksAndSnacks.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly ISAD251_JWalkerContext _context;

        public OrderItemsController(ISAD251_JWalkerContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderItems.ToListAsync());
        }

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity")] OrderItems orderItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItems);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }
            return View(orderItems);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,Quantity")] OrderItems orderItems)
        {
            if (id != orderItems.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemsExists(orderItems.OrderId))
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
            return View(orderItems);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItems = await _context.OrderItems
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderItems == null)
            {
                return NotFound();
            }

            return View(orderItems);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItems = await _context.OrderItems.FindAsync(id);
            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderId == id);
        }
    }
}
