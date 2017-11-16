using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsultaProdutos.Api;
using ConsultaProdutos.Api.Controllers;
using System.Collections.Generic;
using ConsultaProdutos.Api.Models;
using ConsultaProdutos.Api.DAO;

namespace ConsultaProdutos.Api.Testes.DAO
{
    [TestClass]
    public class ProdutosDAOTest
    {
        [TestMethod]
        public void ListaPorNome()
        {
            ProdutosDAO dao = new ProdutosDAO();

            List<Produto> result = dao.ListaPorNome("ips");

            Assert.IsTrue((result.Count > 0), "Nenhum produto encontrado com as três letras informadas.");
        }

        [TestMethod]
        public void ListarTopDez()
        {
            ProdutosDAO dao = new ProdutosDAO();

            List<Produto> result = dao.ListarTopDez();

            Assert.IsTrue((result.Count == 10), "Quantidade de registros diferente de 10.");
        }
    }
}
