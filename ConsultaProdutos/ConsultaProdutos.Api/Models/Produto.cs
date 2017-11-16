using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaProdutos.Api.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public String Nome { get; set; }

        public Double Preco { get; set; }

        public String NomeMarca { get; set; }

        public int MarcaId { get; set; }
    }
}