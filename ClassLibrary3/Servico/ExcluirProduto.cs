using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3.DTO;
using ClassLibrary3.Utilitario;
using Dapper;
using ClassLibrary3.Interface;

namespace ClassLibrary3.Servico
{
    public class ExcluirProduto : IExcluirProduto
    {
        public void Delete(int Id)
        {
            using (var db = DbHelper.Conexao())
            {
                db.Open();
                var query = @"Delete from Produto Where Id=" + Id;
                db.Execute(query, Id);
                return;
            }

        }
    }
}
