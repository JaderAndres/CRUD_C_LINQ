using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Actividad_CRUD_LINQ.Modelos
{
    public class Empleados
    {
        [Key]        
        [Required]
        public int Id  { get; set;}

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        public int AreaId { get; set; }

        [Display(Name = "Nombre completo")]
        public string NombreCompleto 
        {
            get
            {
                return Nombre + " " + Apellidos;
            }
        }


    }
}
