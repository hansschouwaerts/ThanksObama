using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Examentoezicht.Models
{
    public class Toezichtbeurt
    {
        public int ToezichtbeurtId { get; set; }
        public string Datum { get; set; }
        public string Start { get; set; }
        public string Einde { get; set; }
        public string Duurtijd { get; set; }
        public int Capaciteit { get; set; }
        public int Gereserveerd { get; set; }
        [Display(Name = "Aangemaakt Op")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AangemaaktOp { get; set; }
        [Display(Name = "Gewijzigd Op")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GewijzigdOp { get; set; }
        public bool Digitaal { get; set; }
        public string Campus { get; set; }
        public string Departement { get; set; }
        
    }
    
    }
