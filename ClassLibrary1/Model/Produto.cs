﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary1.Model
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