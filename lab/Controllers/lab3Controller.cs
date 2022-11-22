using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab.Context;
using lab.Models;

namespace lab.Controllers
{
    public class lab3Controller : Controller
    {
        private readonly Context.Context _context;

        public lab3Controller(Context.Context context)
        {
            _context = context;
        }

        // GET: lab3
        public async Task<IActionResult> Index()
        {
            return View(await _context.LegoSet.ToListAsync());
        }

        // GET: lab3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab3 = await _context.LegoSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lab3 == null)
            {
                return NotFound();
            }

            return View(lab3);
        }

        // GET: lab3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: lab3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title")] lab3 lab3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lab3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lab3);
        }

        // GET: lab3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab3 = await _context.LegoSet.FindAsync(id);
            if (lab3 == null)
            {
                return NotFound();
            }
            return View(lab3);
        }

        // POST: lab3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Title")] lab3 lab3)
        {
            if (id != lab3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lab3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!lab3Exists(lab3.Id))
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
            return View(lab3);
        }

        // GET: lab3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab3 = await _context.LegoSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lab3 == null)
            {
                return NotFound();
            }

            return View(lab3);
        }

        // POST: lab3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lab3 = await _context.LegoSet.FindAsync(id);
            _context.LegoSet.Remove(lab3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool lab3Exists(string id)
        {
            return _context.LegoSet.Any(e => e.Id == id);
        }
    }
}
