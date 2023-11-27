using IngressosAppWeb.Models;
using IngressosAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace IngressosAppWeb.Pages;

public class CreateModel : PageModel
{
    private IIngressoService _service;
    private IToastNotification _toastNotification;

    public CreateModel(IIngressoService ingressoService, IToastNotification toastNotification)
    {
        _service = ingressoService;
        _toastNotification = toastNotification;
    }

    [BindProperty]
    public Ingresso Ingresso { get; set; }

    public void OnGet()
    {
        ViewData["Title"] = "Adicionar Novo Evento";
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _service.Incluir(Ingresso);
        _toastNotification.AddSuccessToastMessage("Ingresso criado com sucesso!");

        return RedirectToPage("/Index");
    }
}
