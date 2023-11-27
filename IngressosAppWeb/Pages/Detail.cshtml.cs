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

    public IActionResult OnGet(int id)
    {
        Ingresso = _service.ObterPorId(id);

        if (Ingresso == null)
        {
            return NotFound();
        }

        ViewData["Title"] = Ingresso.NomeEvento;

        return Page();
    }
}
