using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary3.Utilitario
{
    public static class DbHelper
    {
        private static string connectionString = @"Data Source=DESKTOP-ACGR40L;Initial Catalog=Produtos;Integrated Security=True;";
        
        public static IDbConnection Conexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}
