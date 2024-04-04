namespace Damelas.Models;

public class DetailsVM
{
    public Produto Anterior { get; set; }
    public Produto Atual { get; set; }
    public Produto Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}