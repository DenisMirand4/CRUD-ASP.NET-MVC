using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    class Adicionar
    {
        public Adicionar (Produto model)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                var query = @"Insert Into Produto(Nome,Preco) Values(@Nome,@Preco)";
                db.Execute(query, model);
            }
            return;
        }
    }
}
