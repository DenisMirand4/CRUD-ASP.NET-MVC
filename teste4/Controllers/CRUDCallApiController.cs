using ClassLibrary3.DTO;
using ClassLibrary3.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teste4.Controllers.Api;

namespace teste4.Controllers
{
    public class CRUDCallApiController : Controller
    {
        public ActionResult ReturnBlank()
        {
            return View();
        }       
    }
}