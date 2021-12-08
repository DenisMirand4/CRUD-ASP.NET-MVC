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

namespace teste4.Controllers
{
    public class CRUDController : Controller
    {
        private static string connectionString = @"Data Source=DESKTOP-ACGR40L;Initial Catalog=Produtos;Integrated Security=True;";
        
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var db = new SqlConnection(connectionString))
            {
                await db.OpenAsync();
                var query = "SELECT TOP (1000) [Id],[Nome],[Preco] FROM[Produtos].[dbo].[Produto]";
                var model = await db.QueryAsync<Produto>(query);
                if (Request.IsAjaxRequest())
                {
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                return View(model);
            }          
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(Produto model)
        {            
            using (var db = new SqlConnection(connectionString))
            {
                await db.OpenAsync();
                var query = @"Insert Into Produto(Nome,Preco) Values(@Nome,@Preco)";
                await db.ExecuteAsync(query, model);
            }
            return RedirectToRoute("CRUD.Index");
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            using (var db = new SqlConnection(connectionString))
            {                   
                db.Open();
                var query = "SELECT * FROM[dbo].[Produto] WHERE[Id] = "+ Id;
                var data = db.Query<Produto>(query);
                Produto model = data.FirstOrDefault(x => x.Id == Id);
                if (Request.IsAjaxRequest())
                {
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                return View(model);
            }            
        }

        [HttpPost]
        public ActionResult Editar(int Id, FormCollection form)  
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                var query = "SELECT * FROM[dbo].[Produto] WHERE[Id] = " + Id;
                var data = db.Query<Produto>(query);
                Produto model = data.FirstOrDefault(x => x.Id == Id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                TryUpdateModel(model);
                query = @"Update Produto Set Nome=@Nome, Preco=@Preco Where Id=@Id";
                db.Execute(query, model);
                return Json(true);                
            }
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                var query = "SELECT * FROM[dbo].[Produto] WHERE[Id] = " + Id;
                var data = db.Query<Produto>(query);
                Produto model = data.FirstOrDefault(x => x.Id == Id);                
                if (Request.IsAjaxRequest())
                {
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Excluir(int Id,FormCollection form)
        {
            if (Id == 0)
            {
                return RedirectToRoute("CRUD.Index");
            }
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                var query = "SELECT * FROM[dbo].[Produto] WHERE[Id] = " + Id;
                var data = db.Query<Produto>(query);
                Produto model = data.FirstOrDefault(x => x.Id == Id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                query = @"Delete from Produto Where Id=" + Id;
                db.Execute(query,Id);
                return Json(true);                
            }
        }
    }
}
