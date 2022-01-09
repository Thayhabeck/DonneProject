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
    public class CadastroSobrevsController : Controller
    {
        private readonly DonneDbContext _context;

        public CadastroSobrevsController(DonneDbContext context)
        {
            _context = context;
        }

        // GET: CadastroSobrevs
        public async Task<IActionResult> Index()
        {
            var donneDbContext = _context.Sobrevivente.Include(c => c.NomeFuncao);
            return View(await donneDbContext.ToListAsync());
        }

        // GET: CadastroSobrevs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroSobrev = await _context.Sobrevivente
                .Include(c => c.NomeFuncao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroSobrev == null)
            {
                return NotFound();
            }

            return View(cadastroSobrev);
        }

        // GET: CadastroSobrevs/Create
        public IActionResult Create()
        {
            ViewData["NomeFuncaoId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao");
            return View();
        }

        // POST: CadastroSobrevs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,cpf,endereco,email,NomeFuncaoId")] CadastroSobrev cadastroSobrev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroSobrev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NomeFuncaoId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao", cadastroSobrev.NomeFuncaoId);
            return View(cadastroSobrev);
        }

        // GET: CadastroSobrevs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroSobrev = await _context.Sobrevivente.FindAsync(id);
            if (cadastroSobrev == null)
            {
                return NotFound();
            }
            ViewData["NomeFuncaoId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao", cadastroSobrev.NomeFuncaoId);
            return View(cadastroSobrev);
        }

        // POST: CadastroSobrevs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,cpf,endereco,email,NomeFuncaoId")] CadastroSobrev cadastroSobrev)
        {
            if (id != cadastroSobrev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroSobrev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroSobrevExists(cadastroSobrev.Id))
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
            ViewData["NomeFuncaoId"] = new SelectList(_context.Funcao, "Id", "NomeFuncao", cadastroSobrev.NomeFuncaoId);
            return View(cadastroSobrev);
        }

        // GET: CadastroSobrevs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroSobrev = await _context.Sobrevivente
                .Include(c => c.NomeFuncao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroSobrev == null)
            {
                return NotFound();
            }

            return View(cadastroSobrev);
        }

        // POST: CadastroSobrevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroSobrev = await _context.Sobrevivente.FindAsync(id);
            _context.Sobrevivente.Remove(cadastroSobrev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroSobrevExists(int id)
        {
            return _context.Sobrevivente.Any(e => e.Id == id);
        }
    }
}
