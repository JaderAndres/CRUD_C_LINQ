using Actividad_CRUD_LINQ.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Actividad_CRUD_LINQ.Servicios
{
    public static class ServicioNomina
    {
        public static void ImprimirNomina(List<Nomina> Nomina1)
        {
            foreach (var item in Nomina1)
            {
                Console.WriteLine("Id: {0} - Fecha: {1} - Id del empleado: {2} - Sueldo: {3} - Días: {4} - Total básico: {5} - Otros: {6} - Devengado: {7}"
                    , item.Id, String.Format(item.Fecha.ToShortDateString(), "dd/mm/yyyy") ,item.EmpleadoId, item.Sueldo.ToString("c", new CultureInfo("es-CO")), item.Dias, Math.Round(item.TotalBasico).ToString("c", new CultureInfo("es-CO")), item.Otros.ToString("c", new CultureInfo("es-CO")), Math.Round(item.Devengado).ToString("c", new CultureInfo("es-CO")));
            }
        }
    }
}
