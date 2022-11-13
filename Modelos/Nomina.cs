using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Actividad_CRUD_LINQ.Modelos
{
    public class Nomina
    {
        [Key]        
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Sueldo { get; set; }

        [Required]
        [StringLength(3)]
        public int Dias { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Total básico")]
        public decimal TotalBasico { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Otros { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Devengado { get; set; }

        //TOTALBASICO DECIMAL(QUE SEA CALCUALDO) SUELDO* DIAS /30 
        //DEVENGADO(QUE SEA CALCUALDO) TOTALBASICO + OTROS
    }
}
