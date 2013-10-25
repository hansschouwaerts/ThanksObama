namespace Examentoezicht.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Examentoezicht.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Examentoezicht.Models.ExamenToezichtDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Examentoezicht.Models.ExamenToezichtDbContext context)
        {
            context.ExamenLijst.AddOrUpdate(i => i.ToezichtbeurtId,
                new Toezichtbeurt
                {                    
                    Datum = "2013/08/26",
                    Start = "8:30",
                    Einde = "10:30",
                    Duurtijd = "2:30",
                    Capaciteit = 2,
                    Gereserveerd = 0,
                    AangemaaktOp = DateTime.Parse("2013/10/18"),
                    GewijzigdOp = DateTime.Parse("2013/10/18"),
                    Digitaal = true,
                    Campus = "BouwmeesterStraat",
                    Departement = "ONDERWIJS EN TRAINING"

                },
                new Toezichtbeurt
                {                    
                    Datum = "2013/08/26",
                    Start = "10:30",
                    Einde = "13:00",
                    Duurtijd = "2:30",
                    Capaciteit = 4,
                    Gereserveerd = 0,
                    AangemaaktOp = DateTime.Parse("2013/10/18"),
                    GewijzigdOp = DateTime.Parse("2013/10/18"),
                    Digitaal = true,
                    Campus = "Meistraat",
                    Departement = "MANAGEMENT EN COMMUNICATIE"

                }
                );
            context.Lectoren.AddOrUpdate(i => i.Email,
                new Lector
                {
                    Name = "lector1",
                    Email = "lector@ap.be",
                    AangemaaktOp = DateTime.Parse("2013/10/18"),
                    AangepastOp = DateTime.Parse("2013/10/18"),
                    Departement = "MANAGEMENT EN COMMUNICATIE",
                    Wachtwoord = "password"
                });
        }
    }
}
