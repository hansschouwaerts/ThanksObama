using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Examentoezicht.Models
{
    public class Reservatie
    {
        private DateTime _date = DateTime.Now;
    [Key]public int ReservatieId { get; set; }
        public int ToezichtbeurtId { get; set; }        
        public int LectorId { get; set; }
        [Display(Name = "Aangemaakt Op")]
        [DataType(DataType.Date)]       
        
        public DateTime AangemaaktOp {
            get { return _date; }
            set { _date = value; }
        }
        [Display(Name = "Gewijzigd Op")]
        [DataType(DataType.Date)]        
       
        public DateTime AangepastOp {
            get { return _date; }
            set { _date = value; }
        }
        [ForeignKey("ToezichtbeurtId")]
        public virtual Toezichtbeurt Toezichtbeurt { get; set; }
        [ForeignKey("LectorId")]
        public virtual Lector Lector { get; set; }
    }
}