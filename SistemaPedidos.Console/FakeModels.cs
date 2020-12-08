using SistemaPedidos.Domain.Entities;
using SistemaPedidos.Domain.ValueObjects;
using SistemaPedidos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedidos.Console
{
    public class FakeModels
    {
        public void Executar()
        {
            using var db = new ApplicationContext();
            InserirProduto(db);
            InserirListaProdutos(db);
            InserirMassa(db);
            ConsultarProdutos(db);
            AtualizarCliente(db);
            RemoverCliente(db);
        }

        private void InserirProduto(ApplicationContext db)
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891231",
                Ativo = true,
                Valor = 10,
                TipoProduto = TipoProduto.MercadoriaParaRevenda
            };

            db.Produto.Add(produto);

            var registros = db.SaveChanges();

        }

        private void InserirListaProdutos(ApplicationContext db)
        {
            var produto2 = new Produto
            {
                Descricao = "Produto Teste2",
                CodigoBarras = "1234567891232",
                Ativo = true,
                Valor = 15,
                TipoProduto = TipoProduto.Embalagem
            };

            var produto3 = new Produto
            {
                Descricao = "Produto Teste3",
                CodigoBarras = "1234567891233",
                Ativo = true,
                Valor = 5,
                TipoProduto = TipoProduto.Embalagem
            };

            List<Produto> listaProdutos = new List<Produto>();
            listaProdutos.Add(produto2);
            listaProdutos.Add(produto3);

            db.Produto.AddRange(listaProdutos);

            var registros = db.SaveChanges();
        }

        private void InserirMassa(ApplicationContext db)
        {
            var produto4 = new Produto
            {
                Descricao = "Produto Teste 4",
                CodigoBarras = "1234567891236",
                Ativo = true,
                Valor = 10,
                TipoProduto = TipoProduto.MercadoriaParaRevenda
            };

            var cliente = new Cliente
            {
                Nome = "Cliente Teste",
                Telefone = "3134769999",
                CEP = "31330100",
                Cidade = "Belo Horizonte",
                Estado = "MG",
                Email = "teste@hotmail.com"
            };

            db.AddRange(produto4, cliente);

            var registros = db.SaveChanges();

        }

        private void ConsultarProdutos(ApplicationContext db)
        {
            //Opção 01 - LINQ SINTAXE
            var consultaPorSintaxe = (from c in db.Produto where c.Valor == 15 select c).ToList();
            var registros = consultaPorSintaxe.Count;

            //Opção 02 - LINQ METODO EXTENSAO
            var consultaPorMetodo = db.Produto
                .Where(p => p.Valor == 15)
                .OrderBy(p => p.Id)
                .ToList();

            registros = consultaPorMetodo.Count;
        }

        private void AtualizarCliente(ApplicationContext db)
        {
            var cliente = db.Cliente.Find(4);

            if (cliente != null)
            {
                cliente.Nome = "Teste Alterado";
                db.SaveChanges();
            }

        }

        private void RemoverCliente(ApplicationContext db)
        {
            var cliente = db.Cliente.Find(3);

            if (cliente != null)
            {
                db.Cliente.Remove(cliente);
                db.SaveChanges();
            }

        }
    }
}
