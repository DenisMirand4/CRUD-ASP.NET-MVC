using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3.Utilitario;
using ClassLibrary3.DTO;
using Dapper;
using ClassLibrary3.Interface;

namespace ClassLibrary3.Servico
{
    public class ObterProdutos : IObterProdutos
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
