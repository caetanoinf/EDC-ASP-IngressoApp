namespace IngressosAppWeb.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Descricao { get; set; }
    
    public ICollection<Ingresso>? Ingressos { get; set; }
}
