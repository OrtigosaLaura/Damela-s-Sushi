namespace Damelas.Models;

    public class Produto
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Tipo { get; set;} = []; 
        public decimal Preco { get; set; }
        public string Imagem { get; set; }

    }
