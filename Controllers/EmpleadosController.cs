using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Actividad_CRUD_LINQ.Modelos;
using Actividad_CRUD_LINQ.Servicios;

namespace Actividad_CRUD_LINQ.Controllers
{
    public class EmpleadosController
    {
        private List<Empleados> listaEmpleados;

        private List<Empleados> LsListaEmpleados { get { return listaEmpleados; } }

        public EmpleadosController()
        {
            listaEmpleados = new List<Empleados>();
        }

        //Llenar lista
        #region Llenar lista

        public void LlenarLista()
        {
            LsListaEmpleados.Clear();

            LsListaEmpleados.Add(new Empleados()
            {
                Id = 1,
                Nombre = "Karen",
                Apellidos = "Rios",
                Direccion = "Calle 43",
                Telefono = "314",
                FechaIngreso = Convert.ToDateTime("11/12/2000"),
                AreaId = 1,
            });
            LsListaEmpleados.Add(new Empleados()
            {
                Id = 2,
                Nombre = "Luis",
                Apellidos = "Vélez",
                Direccion = "Carrera 20",
                Telefono = "318",
                FechaIngreso = Convert.ToDateTime("09/01/2001"),
                AreaId = 2,
            });
            LsListaEmpleados.Add(new Empleados()
            {
                Id = 3,
                Nombre = "Augusto",
                Apellidos = "Gómez",
                Direccion = "Diagonal 34",
                Telefono = "300",
                FechaIngreso = Convert.ToDateTime("12/01/2012"),
                AreaId = 3,
            });
            LsListaEmpleados.Add(new Empleados()
            {
                Id = 4,
                Nombre = "Luisa",
                Apellidos = "Espinoza",
                Direccion = "Calle 89",
                Telefono = "301",
                FechaIngreso = Convert.ToDateTime("03/10/1999"),
                AreaId = 4,
            });
            LsListaEmpleados.Add(new Empleados()
            {
                Id = 5,
                Nombre = "Julio",
                Apellidos = "Díaz",
                Direccion = "Carrera 30",
                Telefono = "321",
                FechaIngreso = Convert.ToDateTime("06/11/2015"),
                AreaId = 5,
            });
        }

        #endregion

        //Listar todos
        #region ListarTodos

        public void ListarTodos()
        {
            List<Empleados> lista = new List<Empleados>();
            lista.AddRange(from a in LsListaEmpleados orderby a.Id select a);
            if (lista.Count > 0)
            {
                ServicioEmpleados.ImprimirEmpleados(lista);
            }
            else
            {
                Console.WriteLine("No hay empleados registrados!");
            }
        }

        #endregion

        //Mostrar por Id
        #region MostrarxId
        public void MostrarxId(int id)
        {
            List<Empleados> lista = new List<Empleados>();
            lista.AddRange(from a in LsListaEmpleados where a.Id == id select a);
            if (lista.Count > 0)
            {
                ServicioEmpleados.ImprimirEmpleados(lista);
            }
            else
            {
                Console.WriteLine("El empleado ingresado no existe!");
            }
        }
        #endregion

        //Registrar
        #region Registrar
        public void Registrar(string nombre, string apellidos, string direccion, string telefono, DateTime fechaIngreso, int areaId)
        {
            IEnumerable<Empleados> lista = LsListaEmpleados.OrderBy(ar => ar.Id);
            Empleados ultimo = lista.LastOrDefault();

            LsListaEmpleados.Add(new Empleados()
            {
                Id = ultimo.Id + 1,
                Nombre = nombre,
                Apellidos = apellidos,
                Direccion = direccion,
                Telefono = telefono,
                FechaIngreso = fechaIngreso,
                AreaId = areaId
            });
            Console.WriteLine("Empleado registrado con éxito");
        }

        #endregion

        //Modificar
        #region Modificar
        public void Modificar(int id, string nombre, string apellidos, string direccion, string telefono, DateTime fechaIngreso, int areaId)
        {
            var actualizarItem = new Empleados
            {
                Id = id,
                Nombre = nombre,
                Apellidos = apellidos,
                Direccion = direccion,
                Telefono = telefono,
                FechaIngreso = fechaIngreso,
                AreaId = areaId
            };
            var item = LsListaEmpleados.FirstOrDefault(i => i.Id == actualizarItem.Id);
            if (item != null)
            {
                LsListaEmpleados.Remove(item);
                LsListaEmpleados.Add(actualizarItem);
                Console.WriteLine("Empleado actualizado con éxito");
            }
            else
            {
                Console.WriteLine("El empleado a modificar no existe!");
            }
        }
        #endregion

        //Eliminar
        #region Eliminar
        public void Eliminar(int id)
        {
            var item = LsListaEmpleados.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                LsListaEmpleados.Remove(item);
                Console.WriteLine("El empleado ha sido eliminado con éxito");
            }
            else
            {
                Console.WriteLine("El id del empleado no existe!");
            }
        }
        #endregion

        //Verificar Integridad referencial AreaID
        #region Varificar Integridad referencial Area ID

        public bool VerificarIntegridadAreaId(int idArea)
        {
            List<Empleados> lista = new List<Empleados>();
            lista.AddRange(from a in LsListaEmpleados where a.AreaId == idArea select a);
            if (lista.Count > 0)
            {
                return true; //Hay registros
            }
            else
            {
                return false; //No hay registros
            }
        }

        #endregion

        //Verificar EmpleadoID
        #region Varificar Empleado ID

        public bool VerificarEmpleadoId(int idEmpleado)
        {
            List<Empleados> lista = new List<Empleados>();
            lista.AddRange(from a in LsListaEmpleados where a.Id == idEmpleado select a);
            if (lista.Count > 0)
            {
                return true; //Existe
            }
            else
            {
                return false; //No existe
            }
        }

        #endregion       
    }
}
