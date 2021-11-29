using teste4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace teste4.Data.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");
            HasKey(x => x.Id);
            Property(x => x.Nome)
                .HasMaxLength(100)
                .IsVariableLength()
                .IsRequired();
            Property(x => x.Preco)
                .IsRequired();
        }
    }
}