#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Desafio_E_commerce_Dashboard_Local.Data;
using Desafio_E_commerce_Dashboard_Local.Models;

namespace Desafio_E_commerce_Dashboard_Local.Controllers
{
    public class EquipeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equipe
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var Equipe = from s in _context.Equipe
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Equipe = Equipe.Where(s => s.EquipeNome.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Equipe = Equipe.OrderByDescending(s => s.EquipeNome);
                    break;
                case "Date":
                    Equipe = Equipe.OrderBy(s => s.PlacaVeiculo);
                    break;
                case "date_desc":
                    Equipe = Equipe.OrderByDescending(s => s.PlacaVeiculo);
                    break;
                default:
                    Equipe = Equipe.OrderBy(s => s.EquipeNome);
                    break;
            }

            return View(await Equipe.AsNoTracking().ToListAsync());

        }

        // GET: Equipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .FirstOrDefaultAsync(m => m.EquipeID == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // GET: Equipe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipeID,EquipeNome,Descricao,PlacaVeiculo")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipe);
        }

        // GET: Equipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }
            return View(equipe);
        }

        // POST: Equipe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipeID,EquipeNome,Descricao,PlacaVeiculo")] Equipe equipe)
        {
            if (id != equipe.EquipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipeExists(equipe.EquipeID))
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
            return View(equipe);
        }

        // GET: Equipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipe = await _context.Equipe
                .FirstOrDefaultAsync(m => m.EquipeID == id);
            if (equipe == null)
            {
                return NotFound();
            }

            return View(equipe);
        }

        // POST: Equipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            _context.Equipe.Remove(equipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipeExists(int id)
        {
            return _context.Equipe.Any(e => e.EquipeID == id);
        }
    }
}
