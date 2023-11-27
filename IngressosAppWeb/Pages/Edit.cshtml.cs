using IngressosAppWeb.Models;
using IngressosAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace IngressosAppWeb.Pages;

public class EditModel : PageModel
{
    private IIngressoService _service;
    private IToastNotification _toastNotification;

    public EditModel(IIngressoService ingressoService, IToastNotification toastNotification)
    {
        _service = ingressoService;
        _toastNotification = toastNotification;
    }

    [BindProperty]
    public Ingresso Ingresso { get; set; }

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

    public IActionResult OnPost()
    {
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
