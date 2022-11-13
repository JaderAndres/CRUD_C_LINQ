using Actividad_CRUD_LINQ.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_CRUD_LINQ.Servicios
{
    public static class ServicioEmpleados
    {
        public static void ImprimirEmpleados(List<Empleados> Emple1)
        {
            foreach (var item in Emple1)
            {
                Console.WriteLine("Id: {0} - Nombre: {1} - Apellido: {2} - Dirección: {3} - Teléfono: {4} - Fecha de ingreso: {5} - Área Id: {6}", item.Id, item.Nombre, item.Apellidos, item.Direccion, item.Telefono, String.Format(item.FechaIngreso.ToShortDateString(), "dd/mm/yyyy"), item.AreaId);
            }
        }
    }
}
