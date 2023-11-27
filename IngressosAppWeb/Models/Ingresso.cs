using System.ComponentModel.DataAnnotations;

namespace IngressosAppWeb.Models;

public class Ingresso
{
    
    public int IngressoId { get; set; }

    [Display(Name = "Nome do evento")]
    [Required(AllowEmptyStrings = false)]
    public string NomeEvento { get; set; }

    public string NomeSlug => NomeEvento.ToLowerInvariant().Replace(" ", "-");
    
    [Display(Name = "Data do evento")]
    public DateTime DataEvento { get; set; }

    [Display(Name= "Local do evento")]
    public string Localizacao { get; set; }

    public string Categoria { get; set; }
    
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Display(Name = "URL da Imagem")]
    public string ImagemUrl { get; set; }

    [DisplayFormat(DataFormatString = "{0:C0}")]
    [DataType(DataType.Currency)]
    public double Valor { get; set; }

    [Display(Name = "Quantidade Disponível")]
    public int QuantidadeDisponivel { get; set; }
    
    public bool Disponivel { get; set; }

    [Display(Name = "Apenas estudante?")]
    public bool IngressoEstudante { get; set; }
}
