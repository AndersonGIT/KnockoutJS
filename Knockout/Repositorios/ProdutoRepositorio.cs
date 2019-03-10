using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Knockout.Interfaces;
using Knockout.Models;

namespace Knockout.Repositorios
{
    public class ProdutoRepositorio : IProduto
    {
        List<Produto> Produtos = new List<Produto>();
        private int _nextId = 1;

        public ProdutoRepositorio()
        {
            IncluirProduto(new Produto { Nome = "Televisão", Categoria = "Eletronicos", Preco = 150.00M });
            IncluirProduto(new Produto { Nome = "Geladeira", Categoria = "Linha Branca", Preco = 150.00M });
            IncluirProduto(new Produto { Nome = "Maquina", Categoria = "Linha Branca", Preco = 150.00M });
        }

        public bool AtualizarProduto(Produto pProduto)
        {
            if (pProduto == null)
            {
                throw new ArgumentNullException("pProduto");
            }
            int ProdutoIndex = Produtos.FindIndex(Prod => Prod.Id == pProduto.Id);
            if (ProdutoIndex == -1) return false;

            Produtos.RemoveAt(ProdutoIndex);
            IncluirProduto(pProduto);
            return true;

        }

        public bool ExcluirProduto(int pId)
        {
            Produtos.RemoveAll(Prod => Prod.Id == pId);
            return true;
        }

        public Produto IncluirProduto(Produto pProduto)
        {
            if(pProduto == null)
            {
                throw new ArgumentNullException("pProduto");
            }
            pProduto.Id = _nextId++;
            Produtos.Add(pProduto);
            return pProduto;
        }

        public Produto RetornaProduto(int pId)
        {
            return Produtos.Find(Prod => Prod.Id == pId);
        }

        public IEnumerable<Produto> RetornaTodos()
        {
            return Produtos;
        }
    }
}