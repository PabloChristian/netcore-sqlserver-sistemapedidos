using SistemaPedidos.Infrastructure;
using System;

namespace SistemaPedidos.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Estrutura estrutura = new Estrutura();
            FakeModels fakeModels = new FakeModels();

            estrutura.Executar();
            fakeModels.Executar();
        }
    }
}
