using IngressosAppWeb.Data;
using IngressosAppWeb.Models;
using Newtonsoft.Json;

namespace IngressosAppWeb.Services.Data;

public class IngressoService : IIngressoService
{
    private AppDbContext _context;
    
    public IngressoService(AppDbContext context)
    {
        _context = context;
    }

    public IList<Ingresso> ObterTodos()
    {
        return _context.Ingresso.ToList();
    }

    public IList<Tipo> ObterTodosOsTipos()
    {
        return _context.Tipo.ToList();
    }

    public IList<Categoria> ObterTodasAsCategorias()
    {
        return _context.Categoria.ToList();
    }

    public Ingresso ObterPorId(int ingressoId)
    {
        return _context.Ingresso.SingleOrDefault(item => item.IngressoId == ingressoId);
    }

    public void Incluir(Ingresso ingresso)
    {
        _context.Ingresso.Add(ingresso);
        _context.SaveChanges();
    }

    public void Remover(int id)
    {
        var ingressoEncontrado = ObterPorId(id);
        _context.Ingresso.Remove(ingressoEncontrado);
        _context.SaveChanges();
    }

    public void Alterar(Ingresso ingresso)
    {
        var ingressoEncontrado = ObterPorId(ingresso.IngressoId);
        ingressoEncontrado.NomeEvento = ingresso.NomeEvento;
        ingressoEncontrado.DataEvento = ingresso.DataEvento;
        ingressoEncontrado.Descricao = ingresso.Descricao;
        ingressoEncontrado.ImagemUrl = ingresso.ImagemUrl;
        ingressoEncontrado.Valor = ingresso.Valor;
        ingressoEncontrado.Disponivel = ingresso.Disponivel;
        ingressoEncontrado.QuantidadeDisponivel = ingresso.QuantidadeDisponivel;
        ingressoEncontrado.Localizacao = ingresso.Localizacao;
        ingressoEncontrado.Categorias = ingresso.Categorias;
        ingressoEncontrado.TipoId = ingresso.TipoId;

        _context.SaveChanges();
    }
}
