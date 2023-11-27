using IngressosAppWeb.Models;
using Newtonsoft.Json;

namespace IngressosAppWeb.Services;

public class IngressoService : IIngressoService
{
    private IList<Ingresso> _ingressos;
       
    public IngressoService()
    {
        CarregarIngressos();
    }
    
    private void CarregarIngressos()
    {
       _ingressos = new List<Ingresso>
        {
            new() {
                IngressoId = 1,
                NomeEvento = "Show de Comédia com Laura Mendes",
                DataEvento = DateTime.Parse("2023-12-01T20:00:00"),
                Descricao = "Prepare-se para uma noite cheia de risadas e diversão no vibrante show de comédia ao vivo com Laura Mendes. Com seu humor inteligente e carisma cativante, Laura vai garantir uma experiência memorável para todos. Não perca este espetáculo imperdível!",
                ImagemUrl = "/images/eventos/comedia.jpeg",
                Valor = 50.00,
                Disponivel = true,
                QuantidadeDisponivel = 500,
                IngressoEstudante = false,
                Localizacao = "Teatro Municipal, São Paulo",
                Categoria = "Teatro"
            },
            new() {
                IngressoId = 2,
                NomeEvento = "Show de Reggae com The Groove",
                DataEvento = DateTime.Parse("2023-11-15T19:30:00"),
                Descricao = "Deixe-se envolver pela energia positiva e pelos ritmos contagiante do show de reggae ao vivo com The Groove Explorers. Uma noite repleta de boa música, vibes positivas e momentos inesquecíveis aguardam por você. Venha fazer parte deste espetáculo único!",
                ImagemUrl = "/images/eventos/reggae.jpeg",
                Valor = 40.00,
                Disponivel = true,
                QuantidadeDisponivel = 300,
                IngressoEstudante = false,
                Localizacao = "Arena Reggae, Rio de Janeiro",
                Categoria = "Show"
            },
            new() {
                IngressoId = 3,
                NomeEvento = "Show Gospel com Voices of Faith",
                DataEvento = DateTime.Parse("2023-11-25T18:00:00"),
                Descricao = "Experimente uma noite de inspiração e espiritualidade no show gospel ao vivo com Voices of Faith. Com poderosas vozes e mensagens tocantes, este evento promete elevar sua alma e proporcionar momentos de reflexão profunda. Não perca essa experiência única!",
                ImagemUrl =  "/images/eventos/gospel.jpeg",
                Valor = 35.00,
                Disponivel = true,
                QuantidadeDisponivel = 200,
                IngressoEstudante = false,
                Localizacao = "Igreja da Paz, Belo Horizonte",
                Categoria = "Show"
            },
            new() {
                IngressoId = 4,
                NomeEvento = "Festa de São João Tradicional",
                DataEvento = DateTime.Parse("2023-06-24T21:00:00"),
                Descricao = "Entre no clima animado da festa tradicional de São João. Com muita música, dança, e comidas típicas, esta festa é a celebração perfeita para toda a família. A Praça Principal de Campina Grande será transformada em um cenário de alegria e tradição.",
                ImagemUrl =  "/images/eventos/sj.jpeg",
                Valor = 25.00,
                Disponivel = true,
                QuantidadeDisponivel = 1000,
                IngressoEstudante = false,
                Localizacao = "Praça Principal, Campina Grande",
                Categoria = "Festa"
            },
            new() {
                IngressoId = 5,
                NomeEvento = "Evento de F1 em Interlagos",
                DataEvento = DateTime.Parse("2023-10-08T13:30:00"),
                Descricao = "Sinta a adrenalina do automobilismo no empolgante evento de Fórmula 1 em Interlagos. Os melhores pilotos, carros de alta performance e uma atmosfera eletrizante aguardam você. Não perca a oportunidade de testemunhar essa emocionante competição!",
                ImagemUrl =  "/images/eventos/f1.jpeg",
                Valor = 75.00,
                Disponivel = true,
                QuantidadeDisponivel = 800,
                IngressoEstudante = false,
                Localizacao = "Autódromo de Interlagos, São Paulo",
                Categoria = "Esporte"
            },
            new() {
                IngressoId = 6,
                NomeEvento = "Aula de Artes com Prof. Carolina Silva",
                DataEvento = DateTime.Parse("2023-09-10T15:00:00"),
                Descricao = "Explore sua criatividade e participe de uma aula de artes única com a Professora Carolina Silva. Com pincéis, tela e muita inspiração, esta aula proporcionará uma experiência enriquecedora para todos os amantes da arte. Não é apenas uma aula, é uma jornada artística!",
                ImagemUrl =  "/images/eventos/pintura.jpeg",
                Valor = 20.00,
                Disponivel = true,
                QuantidadeDisponivel = 150,
                IngressoEstudante = false,
                Localizacao = "Escola de Artes, Florianópolis",
                Categoria = "Educação"
            },
        };
    }

    public IList<Ingresso> ObterTodos()
    {
        return _ingressos;
    }

    public Ingresso ObterPorId(int ingressoId)
    {
        return _ingressos.First(i => i.IngressoId == ingressoId);
    }

    public void Incluir(Ingresso ingresso)
    {
        var proximoNumero = _ingressos.Max(item => item.IngressoId) + 1;
        ingresso.IngressoId = proximoNumero;
        _ingressos.Add(ingresso);
    }

    public void Remover(int id)
    {
        var ingressoEncontrado = ObterPorId(id);
        _ingressos.Remove(ingressoEncontrado);
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
        ingressoEncontrado.IngressoEstudante = ingresso.IngressoEstudante;
        ingressoEncontrado.Localizacao = ingresso.Localizacao;
        ingressoEncontrado.Categoria = ingresso.Categoria;
    }
}
