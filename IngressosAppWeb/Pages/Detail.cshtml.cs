using IngressosAppWeb.Models;
using IngressosAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IngressosAppWeb.Pages;

public class DetailModel : PageModel
{
    private IIngressoService _service;

    public DetailModel(IIngressoService ingressoService)
    {
        _service = ingressoService;
    }

    public Ingresso Ingresso { get; private set; }
    public Tipo Tipo { get; private set; }

    public IActionResult OnGet(int id)
    {
        Ingresso = _service.ObterPorId(id);
        Tipo = _service.ObterTodosOsTipos().SingleOrDefault(item => item.TipoId == Ingresso.TipoId);

        if (Ingresso == null)
        {
            return NotFound();
        }

        ViewData["Title"] = Ingresso.NomeEvento;

        return Page();
    }
}
