using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IngressosAppWeb.Data;
using IngressosAppWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace IngressosAppWeb.Pages.Tipos
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IngressosAppWeb.Data.AppDbContext _context;

        public CreateModel(IngressosAppWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tipo Tipo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tipo == null || Tipo == null)
            {
                return Page();
            }

            _context.Tipo.Add(Tipo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
