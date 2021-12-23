using ClassLibrary3.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3.Interface
{
    public interface ILocalizarID
    {
        ProdutoDTO Locate(int Id);
    }
}
