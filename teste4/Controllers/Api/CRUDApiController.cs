using ClassLibrary3.DTO;
using ClassLibrary3.Interface;
using ClassLibrary3.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace teste4.Controllers.Api
{
    public class CRUDApiController : ApiController
    {
        private IObterProdutos _ObterRepo;
        private IAdicionarProduto _AdicionarRepo;
        private ILocalizarID _LocalizarIDRepo;
        private IEditarProduto _EditarRepo;
        private IExcluirProduto _ExcluirRepo;
        public CRUDApiController(IObterProdutos repo1, IAdicionarProduto repo2, ILocalizarID repo3, IEditarProduto repo4, IExcluirProduto repo5)
        {
            _ObterRepo = repo1;
            _AdicionarRepo = repo2;
            _LocalizarIDRepo = repo3;
            _EditarRepo = repo4;
            _ExcluirRepo = repo5;
        } 
        
        [HttpGet]
        public IEnumerable<ProdutoDTO> GetAll() 
        {
            return _ObterRepo.GetAll();
        }

        [HttpGet]
        public ProdutoDTO GetId(int Id)
        {
            return _LocalizarIDRepo.Locate(Id);
        }

        [HttpPost]
        public IHttpActionResult Adicionar(ProdutoDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            _AdicionarRepo.AddProduto(model);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPut]
        public IHttpActionResult Editar(ProdutoDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            _EditarRepo.Edit(model);
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpDelete]
        public IHttpActionResult Excluir(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            var model = _LocalizarIDRepo.Locate(Id);
            if (model == null)
            {
                return BadRequest();
            }
            _ExcluirRepo.Delete(Id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
