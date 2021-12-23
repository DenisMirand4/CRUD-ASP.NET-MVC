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
    public class AdicionarProduto : IAdicionarProduto
    {
        public void AddProduto(ProdutoDTO model)
        {
            using (var db = DbHelper.Conexao())
            {
                db.Open();
                var query = @"Insert Into Produto(Nome,Preco) Values(@Nome,@Preco)";
                db.Execute(query, model);
            }
            return;
        }

    }
}
