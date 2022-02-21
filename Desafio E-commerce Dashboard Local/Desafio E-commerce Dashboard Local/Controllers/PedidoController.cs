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
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var Pedidos = from s in _context.Pedido
                          select s;
            Pedidos = _context.Pedido.Include(p => p.Equipe).Include(p => p.Produto); // Importante estar nesta ordem
            switch (sortOrder)
            {
                case "name_desc":
                    Pedidos = Pedidos.OrderByDescending(s => s.DataCriacao);
                    break;
                case "Date":
                    Pedidos = Pedidos.OrderBy(s => s.DataEntrega);
                    break;
                case "date_desc":
                    Pedidos = Pedidos.OrderByDescending(s => s.DataEntrega);
                    break;
                default:
                    Pedidos = Pedidos.OrderBy(s => s.DataCriacao);
                    break;
            }

            return View(await Pedidos.AsNoTracking().ToListAsync());

        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Equipe)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["EquipeID"] = new SelectList(_context.Equipe, "EquipeID", "EquipeNome");
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoID,DataCriacao,DataEntrega,Endereco,ProdutoID,EquipeID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeID"] = new SelectList(_context.Equipe, "EquipeID", "EquipeNome", pedido.EquipeID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", pedido.ProdutoID);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["EquipeID"] = new SelectList(_context.Equipe, "EquipeID", "EquipeNome", pedido.EquipeID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", pedido.ProdutoID);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoID,DataCriacao,DataEntrega,Endereco,ProdutoID,EquipeID")] Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoID))
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
            ViewData["EquipeID"] = new SelectList(_context.Equipe, "EquipeID", "EquipeNome", pedido.EquipeID);
            ViewData["ProdutoID"] = new SelectList(_context.Produto, "ProdutoId", "ProdutoNome", pedido.ProdutoID);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Equipe)
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.PedidoID == id);
        }
    }
}
