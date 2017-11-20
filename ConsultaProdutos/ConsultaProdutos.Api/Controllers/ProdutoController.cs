using ConsultaProdutos.Api.DAO;
using ConsultaProdutos.Api.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ConsultaProdutos.Api.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public JsonResult ListarProdutosPorNome(String nomeProduto)
        {
            ProdutosDAO dao = new ProdutosDAO();
            List<Produto> produto = dao.ListaPorNome(nomeProduto);

            return Json(produto, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult ListarProdutosInicial()
        {
            ProdutosDAO dao = new ProdutosDAO();
            List<Produto> produto = dao.ListarTopDez();
            
            return Json(produto, JsonRequestBehavior.AllowGet);
        }
    }
}