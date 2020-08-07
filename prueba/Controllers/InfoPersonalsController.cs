using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Controllers
{
    public class InfoPersonalsController : Controller
    {
        private readonly AppDbContext _context;

        public InfoPersonalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InfoPersonals
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfoPersonales.ToListAsync());
        }

        // GET: InfoPersonals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoPersonal = await _context.InfoPersonales
                .FirstOrDefaultAsync(m => m.InfoPersonaId == id);
            if (infoPersonal == null)
            {
                return NotFound();
            }

            return View(infoPersonal);
        }

        // GET: InfoPersonals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoPersonals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InfoPersonaId,Ocupacion")] InfoPersonal infoPersonal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoPersonal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoPersonal);
        }

        // GET: InfoPersonals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoPersonal = await _context.InfoPersonales.FindAsync(id);
            if (infoPersonal == null)
            {
                return NotFound();
            }
            return View(infoPersonal);
        }

        // POST: InfoPersonals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InfoPersonaId,Ocupacion")] InfoPersonal infoPersonal)
        {
            if (id != infoPersonal.InfoPersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoPersonal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoPersonalExists(infoPersonal.InfoPersonaId))
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
            return View(infoPersonal);
        }

        // GET: InfoPersonals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoPersonal = await _context.InfoPersonales
                .FirstOrDefaultAsync(m => m.InfoPersonaId == id);
            if (infoPersonal == null)
            {
                return NotFound();
            }

            return View(infoPersonal);
        }

        // POST: InfoPersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoPersonal = await _context.InfoPersonales.FindAsync(id);
            _context.InfoPersonales.Remove(infoPersonal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoPersonalExists(int id)
        {
            return _context.InfoPersonales.Any(e => e.InfoPersonaId == id);
        }
    }
}
