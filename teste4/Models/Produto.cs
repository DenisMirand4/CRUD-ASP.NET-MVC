using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teste4.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        public float Preco { get; set; }

        //public Produto()
        //{
        //    Id = Guid.NewGuid();
        //}
    }
}