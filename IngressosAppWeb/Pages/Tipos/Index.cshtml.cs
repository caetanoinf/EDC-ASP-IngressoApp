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
    public class IndexModel : PageModel
    {
        private readonly IngressosAppWeb.Data.AppDbContext _context;

        public IndexModel(IngressosAppWeb.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Tipo> Tipo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tipo != null)
            {
                Tipo = await _context.Tipo.ToListAsync();
            }
        }
    }
}
