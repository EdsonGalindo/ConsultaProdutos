using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsultaProdutos.Api.Controllers;
using System.Web.Mvc;
using ConsultaProdutos.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaProdutos.Api.Testes.Controllers
{
    [TestClass]
    public class ProdutoControllerTest
    {
        [TestMethod]
        public void ListarProdutosPorNome()
        {
            ProdutoController controller = new ProdutoController();

            JsonResult result = controller.ListarProdutosPorNome("ips") as JsonResult;

            Assert.IsNotNull(result.Data, "Não foram retornados dados.");
            List<Produto> Produtos = (List<Produto>)result.Data;
            Assert.IsTrue(Produtos.Count() > 0, "Nenhum produto encontrado com as três letras informadas.");
        }

        [TestMethod]
        public void ListarProdutosInicial()
        {
            ProdutoController controller = new ProdutoController();

            JsonResult result = controller.ListarProdutosInicial() as JsonResult;

            Assert.IsNotNull(result.Data, "Não foram retornados dados.");
            List<Produto> Produtos = (List<Produto>)result.Data;
            Assert.IsTrue(Produtos.Count() == 10, "Quantidade de registros diferente de 10.");
        }
    }
}
