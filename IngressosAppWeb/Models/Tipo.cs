namespace IngressosAppWeb.Models;

public class Tipo
{
    public int TipoId { get; set; }
    public string Nome { get; set; }
    
    public ICollection<Ingresso>? Ingressos { get; set; }
}
