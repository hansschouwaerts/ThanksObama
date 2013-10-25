using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Examentoezicht.Models
{
    public class ExamenToezichtDbContext : DbContext
    {
        public DbSet<Lector> Lectoren { get; set; }
        public DbSet<Toezichtbeurt> ExamenLijst { get; set; }
        public DbSet<Reservatie> Reservaties { get; set; }
    }
}