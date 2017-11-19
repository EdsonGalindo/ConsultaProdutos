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
        static HttpClient httpClient = new HttpClient();
        static readonly String endPointHeader = "application/json";
        static readonly String endPoint = "http://localhost:51115/";


        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto
        public async Task<ActionResult> Lista()
        {
            var rota = "Produtos/Inicio";
            List<Produto> produtos = await ObterDadosProdutos(rota);

            ViewBag.Produtos = produtos;

            return View();
        }

        private static async Task<List<Produto>> ObterDadosProdutos(string rota)
        {
            httpClient.BaseAddress = new Uri(endPoint);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(endPointHeader));

            var produtosJson = string.Empty;
            List<Produto> produtos = null;

            HttpResponseMessage resposta = await httpClient.GetAsync(rota);

            if (resposta.IsSuccessStatusCode)
            {
                produtosJson = await resposta.Content.ReadAsStringAsync();
                produtos = JsonConvert.DeserializeObject<List<Produto>>(produtosJson);
            }

            return produtos;
        }
    }
}
