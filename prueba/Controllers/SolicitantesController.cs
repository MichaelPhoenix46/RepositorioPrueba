using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Models;
using prueba.ViewModel;
using webApp_Mono_UCNE_2_2020.Clases;

namespace prueba.Controllers
{
    public class SolicitantesController : Controller
    {
        private readonly AppDbContext _context;
        public ErrorResponse Error { get; set; }

        public SolicitantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Solicitantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Solicitantes.ToListAsync());
        }

        // GET: Solicitantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.SolicitanteID == id);
            if (solicitante == null)
            {
                return NotFound();
            }

            return View(solicitante);
        }

        // GET: Solicitantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SolicitanteID,NombreSolicitante,Numero,InfoPersonaId,Ocupacion")] InfoSolicitanteViewModel solicitante)
        {

            if (ModelState.IsValid)
            {
                var result = await CrearVehiculoAsync(solicitante);
                return RedirectToAction(nameof(Index));
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitantes.FindAsync(id);
            if (solicitante == null)
            {
                return NotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SolicitanteID,NombreSolicitante,Numero")] Solicitante solicitante)
        {
            if (id != solicitante.SolicitanteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitanteExists(solicitante.SolicitanteID))
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
            return View(solicitante);
        }

        // GET: Solicitantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitante = await _context.Solicitantes
                .FirstOrDefaultAsync(m => m.SolicitanteID == id);
            if (solicitante == null)
            {
                return NotFound();
            }

            return View(solicitante);
        }

        // POST: Solicitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitante = await _context.Solicitantes.FindAsync(id);
            _context.Solicitantes.Remove(solicitante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitanteExists(int id)
        {
            return _context.Solicitantes.Any(e => e.SolicitanteID == id);
        }


        public async Task<ErrorResponse> CrearVehiculoAsync(InfoSolicitanteViewModel solicitante)
        {

            Solicitante newsolicitante = new Solicitante()
            {
                NombreSolicitante = solicitante.NombreSolicitante,
                Numero = solicitante.Numero

            };
            try
            {
                await _context.Solicitantes.AddAsync(newsolicitante);
                await _context.SaveChangesAsync();

                InfoPersonal info = new InfoPersonal()
                {
                    InfoPersonaId = solicitante.InfoPersonaId,
                    Ocupacion = solicitante.Ocupacion
                };

                await _context.InfoPersonales.AddAsync(info);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
                //_logger.LogDebug(ex, "No se pudo actualizar el registro.");
            }

            return this.Error;
        }
    }
}
     
    

