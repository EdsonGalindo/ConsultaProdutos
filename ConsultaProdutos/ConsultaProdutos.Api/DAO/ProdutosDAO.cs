using ConsultaProdutos.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ConsultaProdutos.Api.DAO
{
    public class ProdutosDAO
    {
        private List<Produto> Produtos { get; set; }
        readonly String LocalArquivo = @"App_Data\Produtos.json";

        public List<Produto> ListaPorNome(string nomeProduto)
        {
            return Produtos.Where(p => p.Nome.Contains(nomeProduto)).ToList();
        }

        public List<Produto> ListarTopDez()
        {
            var produtosMarcasBaratos = Produtos.OrderBy(p => p.Preco)
                                        .GroupBy(p => p.MarcaId)
                                        .Select(g => g.First()).Take(10).ToList();
            
            return produtosMarcasBaratos;
        }

        public ProdutosDAO()
        {
            var conteudoArquivoJson = File.ReadAllText(LocalArquivo);
            Produtos = JsonConvert.DeserializeObject<List<Produto>>(conteudoArquivoJson).ToList();
        }
    }
}