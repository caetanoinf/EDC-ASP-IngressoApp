using IngressosAppWeb.Models;

namespace IngressosAppWeb.Services;

public interface IIngressoService
{
    IList<Ingresso> ObterTodos();
    IList<Tipo> ObterTodosOsTipos();
    IList<Categoria> ObterTodasAsCategorias();
    
    Ingresso ObterPorId(int ingressoId);
    void Incluir(Ingresso ingresso);
    void Alterar(Ingresso ingresso);
    void Remover(int id);
}
