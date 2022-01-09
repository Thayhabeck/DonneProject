using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DonneProject.Data;
using DonneProject.Models;

namespace DonneProject.Controllers
{
    public class CadastroParceirosController : Controller
    {
        private readonly DonneDbContext _context;

        public CadastroParceirosController(DonneDbContext context)
        {
            _context = context;
        }

        // GET: CadastroParceiros
        public async Task<IActionResult> Index()
        {
            var donneDbContext = _context.Parceiro.Include(c => c.NomeArea);
            return View(await donneDbContext.ToListAsync());
        }

        // GET: CadastroParceiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroParceiro = await _context.Parceiro
                .Include(c => c.NomeArea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroParceiro == null)
            {
                return NotFound();
            }

            return View(cadastroParceiro);
        }

        // GET: CadastroParceiros/Create
        public IActionResult Create()
        {
            ViewData["NomeAreaId"] = new SelectList(_context.Atuacao, "Id", "NomeArea");
            return View();
        }

        // POST: CadastroParceiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RZsocial,Nome,cnpj,email,NomeAreaId")] CadastroParceiro cadastroParceiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroParceiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NomeAreaId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao", cadastroParceiro.NomeAreaId);
            return View(cadastroParceiro);
        }

        // GET: CadastroParceiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroParceiro = await _context.Parceiro.FindAsync(id);
            if (cadastroParceiro == null)
            {
                return NotFound();
            }
            ViewData["NomeAreaId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao", cadastroParceiro.NomeAreaId);
            return View(cadastroParceiro);
        }

        // POST: CadastroParceiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RZsocial,Nome,cnpj,email,NomeAreaId")] CadastroParceiro cadastroParceiro)
        {
            if (id != cadastroParceiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroParceiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroParceiroExists(cadastroParceiro.Id))
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
            ViewData["NomeAreaId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao", cadastroParceiro.NomeAreaId);
            return View(cadastroParceiro);
        }

        // GET: CadastroParceiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroParceiro = await _context.Parceiro
                .Include(c => c.NomeArea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroParceiro == null)
            {
                return NotFound();
            }

            return View(cadastroParceiro);
        }

        // POST: CadastroParceiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroParceiro = await _context.Parceiro.FindAsync(id);
            _context.Parceiro.Remove(cadastroParceiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroParceiroExists(int id)
        {
            return _context.Parceiro.Any(e => e.Id == id);
        }
    }
}
