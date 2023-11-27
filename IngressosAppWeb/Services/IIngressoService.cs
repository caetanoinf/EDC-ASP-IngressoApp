using IngressosAppWeb.Models;

namespace IngressosAppWeb.Services;

public interface IIngressoService
{
    IList<Ingresso> ObterTodos();
    Ingresso ObterPorId(int ingressoId);
    void Incluir(Ingresso ingresso);
    void Alterar(Ingresso ingresso);
    void Remover(int id);
}
