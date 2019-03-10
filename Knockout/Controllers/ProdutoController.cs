using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Knockout.Interfaces;
using Knockout.Repositorios;
using Knockout.Models;

namespace Knockout.Controllers
{
    public class ProdutoController : Controller
    {
        private static readonly IProduto ProdRep = new ProdutoRepositorio();
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BuscarProduto(int pId)
        {
            return Json(ProdRep.RetornaProduto(pId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarTodosProdutos()
        {
            return Json(ProdRep.RetornaTodos(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InserirProduto(Produto pProduto)
        {
            return Json(ProdRep.IncluirProduto(pProduto), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditarProduto(Produto pProduto)
        {
            if (ProdRep.AtualizarProduto(pProduto))
            {
                return Json(ProdRep.RetornaTodos(), JsonRequestBehavior.AllowGet);
            }
            return Json(null);

        }
        

        public JsonResult RemoverProduto(int pId)
        {
            return Json(ProdRep.ExcluirProduto(pId) ? new { Status = "OK" } : new { Status = "NOK" }, JsonRequestBehavior.AllowGet);
        }


    }
}