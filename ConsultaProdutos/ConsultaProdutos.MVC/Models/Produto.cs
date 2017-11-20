using System;
using System.ComponentModel.DataAnnotations;

namespace ConsultaProdutos.MVC.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public String Nome { get; set; }
        
        public string Preco { get; set; }

        public String NomeMarca { get; set; }

        public int MarcaId { get; set; }
    }
}