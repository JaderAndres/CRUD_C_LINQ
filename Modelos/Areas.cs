using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Actividad_CRUD_LINQ.Modelos
{
    public class Areas
    {
        [Key]        
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; }
    }   
}
