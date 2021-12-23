using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Utilitario;
using ClassLibrary2.DTO;
using Dapper;

namespace ClassLibrary2.Serviço
{
    public class ObterProdutos
    {
        public IEnumerable<ProdutoDTO> GetAll()
        {
            using (var db = DbHelper.Conexao())
            {
                db.Open();
                var query = "SELECT TOP (1000) [Id],[Nome],[Preco] FROM[Produtos].[dbo].[Produto]";
                return db.Query<ProdutoDTO>(query);
            }
        }

    }
}
