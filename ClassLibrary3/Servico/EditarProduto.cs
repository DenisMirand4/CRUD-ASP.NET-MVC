using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3.DTO;
using ClassLibrary3.Interface;
using ClassLibrary3.Utilitario;
using Dapper;

namespace ClassLibrary3.Servico
{
    public class EditarProduto : IEditarProduto
    {
        public void Edit(ProdutoDTO model)
        {
            using (var db = DbHelper.Conexao())
            {
                db.Open();
                var query = @"Update Produto Set Nome=@Nome, Preco=@Preco Where Id=@Id";
                db.Execute(query, model);
                return;
            }
            
        }
    }
}
