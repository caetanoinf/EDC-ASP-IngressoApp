using IngressosAppWeb.Models;
using IngressosAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace IngressosAppWeb.Pages;

public class EditModel : PageModel
{
    private IIngressoService _service;
    private IToastNotification _toastNotification;
    
    public SelectList TipoOptionItems { get; set; }
    public SelectList CategoriaOptionItems { get; set; }

    public EditModel(IIngressoService ingressoService, IToastNotification toastNotification)
    {
        _service = ingressoService;
        _toastNotification = toastNotification;
    }

    [BindProperty]
    public Ingresso Ingresso { get; set; }
    
    [BindProperty]
    public IList<int> CategoriaIds { get; set; }

    public IActionResult OnGet(int id)
    {
        Ingresso = _service.ObterPorId(id);

        if (Ingresso == null)
        {
            return NotFound();
        }

        CategoriaIds = Ingresso.Categorias.Select(item => item.CategoriaId).ToList();

        TipoOptionItems = new SelectList(_service.ObterTodosOsTipos(), nameof(Tipo.TipoId), nameof(Tipo.Nome));
        CategoriaOptionItems = new SelectList(_service.ObterTodasAsCategorias(), nameof(Categoria.CategoriaId),
            nameof(Categoria.Descricao));

        ViewData["Title"] = Ingresso.NomeEvento;

        return Page();
    }

    public IActionResult OnPost()
    {
        Ingresso.Categorias = _service.ObterTodasAsCategorias().Where(item => CategoriaIds.Contains(item.CategoriaId))
            .ToList();
        
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _service.Alterar(Ingresso);
        _toastNotification.AddSuccessToastMessage("Ingresso alterado com sucesso!");

        return RedirectToPage("/Index");
    }

    public IActionResult OnPostDelete()
    {
        _service.Remover(Ingresso.IngressoId);
        _toastNotification.AddInfoToastMessage("Ingresso removido");

        return RedirectToPage("/Index");
    }
}
