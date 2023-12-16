using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IngressosAppWeb.Data;
using IngressosAppWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace IngressosAppWeb.Pages.Tipos
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IngressosAppWeb.Data.AppDbContext _context;

        public EditModel(IngressosAppWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tipo Tipo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tipo == null)
            {
                return NotFound();
            }

            var tipo =  await _context.Tipo.FirstOrDefaultAsync(m => m.TipoId == id);
            if (tipo == null)
            {
                return NotFound();
            }
            Tipo = tipo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(Tipo.TipoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TipoExists(int id)
        {
          return (_context.Tipo?.Any(e => e.TipoId == id)).GetValueOrDefault();
        }
    }
}
