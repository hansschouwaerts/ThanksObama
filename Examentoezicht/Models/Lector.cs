using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Examentoezicht.Models
{
    public class Lector
    {
        public int LectorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Aangemaakt Op")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AangemaaktOp { get; set; }
        [Display(Name = "Gewijzigd Op")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AangepastOp { get; set; }
        public string  Wachtwoord { get; set; }
        public string Departement { get; set; }
        

    }
    
}