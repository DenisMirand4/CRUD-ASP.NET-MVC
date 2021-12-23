using teste4.Data;
using teste4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ClassLibrary3.Servico;
using ClassLibrary3.DTO;

namespace teste4.Controllers
{
    public class CRUDController : Controller
    {     
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ObterProdutos().GetAll();
            if (Request.IsAjaxRequest())
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return View(model);                      
        }

        [HttpPost]
        public ActionResult Adicionar(ProdutoDTO model)
        {
            new AdicionarProduto().AddProduto(model);
            return RedirectToRoute("CRUD.Index");
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var model = new LocalizarID().Locate(Id);
            if (Request.IsAjaxRequest())
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return View(model);
                        
        }

        [HttpPost]
        public ActionResult Editar(int Id, FormCollection form)  
        {
            var model = new LocalizarID().Locate(Id);
            if (model == null)
            {
                return HttpNotFound();
            }
            TryUpdateModel(model);         
            new EditarProduto().Edit(model);
            return Json(true);                
            
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            var model = new LocalizarID().Locate(Id);
            if (Request.IsAjaxRequest())
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            return View(model);
            
        }

        [HttpPost]
        public ActionResult Excluir(int Id,FormCollection form)
        {
            if (Id == 0)
            {
                return RedirectToRoute("CRUD.Index");
            }
             var model = new LocalizarID().Locate(Id);
                if (model == null)
                {
                    return HttpNotFound();
                }
            new ExcluirProduto().Delete(Id);
                return Json(true);                
            }
        }
    }