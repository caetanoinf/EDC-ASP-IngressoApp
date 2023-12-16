using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IngressosAppWeb.Data;
using IngressosAppWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace IngressosAppWeb.Pages.Tipos
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IngressosAppWeb.Data.AppDbContext _context;

        public DeleteModel(IngressosAppWeb.Data.AppDbContext context)
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

            var tipo = await _context.Tipo.FirstOrDefaultAsync(m => m.TipoId == id);

            if (tipo == null)
            {
                return NotFound();
            }
            else 
            {
                Tipo = tipo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tipo == null)
            {
                return NotFound();
            }
            var tipo = await _context.Tipo.FindAsync(id);

            if (tipo != null)
            {
                Tipo = tipo;
                _context.Tipo.Remove(Tipo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
