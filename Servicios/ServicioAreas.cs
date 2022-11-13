using Actividad_CRUD_LINQ.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_CRUD_LINQ.Servicios
{
    public static class ServicioAreas
    {
        public static void ImprimirAreas(List<Areas> Area1)
        {            
            foreach (var item in Area1)
            {
                Console.WriteLine("Id: {0} - Nombre: {1} ", item.Id, item.Nombre);
            }
        }
    }
}

