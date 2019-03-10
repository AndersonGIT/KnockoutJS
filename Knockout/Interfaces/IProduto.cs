using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knockout.Models;

namespace Knockout.Interfaces
{
    interface IProduto
    {
        IEnumerable<Produto> RetornaTodos();
        Produto RetornaProduto(int pId);
        Produto IncluirProduto(Produto pProduto);
        bool AtualizarProduto(Produto pProduto);
        bool ExcluirProduto(int pId);
    }
}
