using ConsultaProdutos.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsultaProdutos.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        static HttpClient httpClient;
        static readonly String endPointHeader = "application/json";
        static readonly String endPoint = "http://localhost:51115/";
        
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto
        public async Task<JsonResult> Lista()
        {
            var rota = "Produto/ListarProdutosInicial";
            List<Produto> produtos = await ObterDadosProdutos(rota);
            
            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        private static async Task<List<Produto>> ObterDadosProdutos(string rota)
        {
            var produtosJson = string.Empty;
            List<Produto> produtos = null;
            ConfigurarHttpClient();

            HttpResponseMessage resposta = await httpClient.GetAsync(rota);

            if (resposta.IsSuccessStatusCode)
            {
                produtosJson = await resposta.Content.ReadAsStringAsync();
                produtos = JsonConvert.DeserializeObject<List<Produto>>(produtosJson);
            }

            FecharHttpClient();
            return produtos;
        }

        private static void ConfigurarHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(endPoint);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(endPointHeader));
        }

        private static void FecharHttpClient()
        {
            httpClient = new HttpClient();
        }
    }
}
