using teste4.Data;
using teste4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teste4.Controllers
{
    public class CRUDController : Controller
    {
        public IList<Produto> ListaProdutos
        {
            get { return _ListaProdutos ?? (_ListaProdutos = new List<Produto>()); }
        }
        static IList<Produto> _ListaProdutos;
        

        [HttpGet]
        public ActionResult Index()
        {

            var context = new CRUDContext();
            var model = context.Produtos.ToList();
            
            if (Request.IsAjaxRequest())
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }   

            return View(model);
        }

        [HttpPost]
        public ActionResult Adicionar(Produto model)
        {
            using (var context = new CRUDContext())
            {
                context.Produtos.Add(model);
                context.SaveChanges();
            }
            return RedirectToRoute("CRUD.Index");
        }


        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var context = new CRUDContext();
            var model = context.Produtos.FirstOrDefault(x => x.Id == Id);

            if (Request.IsAjaxRequest())
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int Id, FormCollection form)  
        {
            //var model = new Produto();
            var context = new CRUDContext();
            
           var data = context.Produtos.FirstOrDefault(x => x.Id == Id);
                if (data == null)
                {
                    return HttpNotFound();
                }
            TryUpdateModel(data);
            context.SaveChanges();
            return Json(true);

        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            var context = new CRUDContext();
            var model = context.Produtos.FirstOrDefault(x => x.Id == Id);

            if (Request.IsAjaxRequest())
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Excluir(int Id,FormCollection form)
        {
            var context = new CRUDContext();
            Produto edit = null;
            if (Id == 0)
            {
                return RedirectToRoute("CRUD.Index");
            }
            else
            {
                edit = context.Produtos.FirstOrDefault(x => x.Id == Id);
                context.Produtos.Remove(edit);
                context.SaveChanges();
                return Json(true);
            }
        }
    }
}
