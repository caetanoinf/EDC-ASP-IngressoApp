using IngressosAppWeb.Models;
using IngressosAppWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IngressosAppWeb.Pages;

public class IndexModel : PageModel
{
    private IIngressoService _service;

    public IList<Ingresso> ListaIngressos { get; private set; }

    public IndexModel(IIngressoService ingressoService)
    {
        _service = ingressoService;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Início";

        ListaIngressos = _service.ObterTodos();
    }
}
