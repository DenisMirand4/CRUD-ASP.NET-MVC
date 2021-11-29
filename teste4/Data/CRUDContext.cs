using teste4.Data.Mapping;
using teste4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace teste4.Data
{
    public class CRUDContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public CRUDContext()
            : base("MsSqlServer")
        { 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}