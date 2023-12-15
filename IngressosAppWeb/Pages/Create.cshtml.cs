using IngressosAppWeb.Models;
using IngressosAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace IngressosAppWeb.Pages;

[Authorize]
public class CreateModel : PageModel
{
    private IIngressoService _service;
    private IToastNotification _toastNotification;
    
    public SelectList TipoOptionItems { get; set; }
    public SelectList CategoriaOptionItems { get; set; }

    public CreateModel(IIngressoService ingressoService, IToastNotification toastNotification)
    {
        _service = ingressoService;
        _toastNotification = toastNotification;
    }

    [BindProperty]
    public Ingresso Ingresso { get; set; }
    
    [BindProperty]
    public IList<int> CategoriaIds { get; set; }

    public void OnGet()
    {
        TipoOptionItems = new SelectList(_service.ObterTodosOsTipos(), nameof(Tipo.TipoId), nameof(Tipo.Nome));
        CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(), nameof(Categoria.CategoriaId),
            nameof(Categoria.Descricao));
        ViewData["Title"] = "Adicionar Novo Evento";
    }

    public IActionResult OnPost()
    {
        Ingresso.Categorias = _service.ObterTodasAsCategorias().Where(item => CategoriaIds.Contains(item.CategoriaId))
            .ToList();
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _service.Incluir(Ingresso);
        _toastNotification.AddSuccessToastMessage("Ingresso criado com sucesso!");

        return RedirectToPage("/Index");
    }
}
