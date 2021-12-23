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
    public class LocalizarID : ILocalizarID
    {
        public ProdutoDTO Locate(int Id)
        {
            using (var db = DbHelper.Conexao())
            {
                db.Open();
                var query = "SELECT * FROM[dbo].[Produto] WHERE[Id] = " + Id;
                var data = db.Query<ProdutoDTO>(query);
                return data.FirstOrDefault(x => x.Id == Id);
            }
        }
    }
}
