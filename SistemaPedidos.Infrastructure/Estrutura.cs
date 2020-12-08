using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaPedidos.Infrastructure
{
    public class Estrutura
    {
        public bool Executar()
        {
            using var db = new ApplicationContext();
            var existe = db.Database.GetPendingMigrations().Any();
            if (existe)
            {
                db.Database.Migrate();
            }


            return true;
        }
    }
}
