using Actividad_CRUD_LINQ.Modelos;
using Actividad_CRUD_LINQ.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad_CRUD_LINQ.Controllers
{
    public class NominaController
    {
        private List<Nomina> listaNomina;

        private List<Nomina> LsListaNomina { get { return listaNomina; } }

        public NominaController()
        {
            listaNomina = new List<Nomina>();
        }

        //Llenar lista
        #region Llenar lista

        public void LlenarLista()
        {
            LsListaNomina.Clear();

            LsListaNomina.Add(new Nomina()
            {
                Id = 1,
                Fecha = Convert.ToDateTime("30/01/2022"),
                EmpleadoId = 1,
                Sueldo = 1100000,
                Dias = 27,
                TotalBasico = 990000,
                Otros = 100000,
                Devengado = 1090000,
            });
            LsListaNomina.Add(new Nomina()
            {
                Id = 2,
                Fecha = Convert.ToDateTime("30/08/2022"),
                EmpleadoId = 2,
                Sueldo = 1200000,
                Dias = 20,
                TotalBasico = 800000,
                Otros = 200000,
                Devengado = 1000000,
            });
            LsListaNomina.Add(new Nomina()
            {
                Id = 3,
                Fecha = Convert.ToDateTime("30/03/2022"),
                EmpleadoId = 3,
                Sueldo = 1300000,
                Dias = 22,
                TotalBasico = 953333,
                Otros = 300000,
                Devengado = 1253333,
            });
            LsListaNomina.Add(new Nomina()
            {
                Id = 4,
                Fecha = Convert.ToDateTime("30/04/2022"),
                EmpleadoId = 4,
                Sueldo = 1400000,
                Dias = 15,
                TotalBasico = 700000,
                Otros = 400000,
                Devengado = 1100000,
            });
            LsListaNomina.Add(new Nomina()
            {
                Id = 5,
                Fecha = Convert.ToDateTime("30/06/2022"),
                EmpleadoId = 5,
                Sueldo = 1500000,
                Dias = 20,
                TotalBasico = 1000000,
                Otros = 500000,
                Devengado = 1500000,
            });
        }

        #endregion

        //Listar todos
        #region ListarTodos

        public void ListarTodos()
        {
            List<Nomina> lista = new List<Nomina>();
            lista.AddRange(from a in LsListaNomina orderby a.Id select a);
            if (lista.Count > 0)
            {
                ServicioNomina.ImprimirNomina(lista);
            }
            else
            {
                Console.WriteLine("No hay nóminas registradas!");
            }
        }

        #endregion

        //Mostrar por Id
        #region MostrarxId
        public void MostrarxId(int id)
        {
            List<Nomina> lista = new List<Nomina>();
            lista.AddRange(from a in LsListaNomina where a.Id == id select a);
            if (lista.Count > 0)
            {
                ServicioNomina.ImprimirNomina(lista);
            }
            else
            {
                Console.WriteLine("El id de nómina ingresado no existe!");
            }
        }
        #endregion

        //Registrar
        #region Registrar
        public void Registrar(DateTime fecha, int empleadoId, decimal sueldo, int dias, decimal totalBasico, decimal otros, decimal devengado)
        {
            IEnumerable<Nomina> lista = LsListaNomina.OrderBy(ar => ar.Id);
            Nomina ultimo = lista.LastOrDefault();

            LsListaNomina.Add(new Nomina()
            {
                Id = ultimo.Id + 1,
                Fecha = fecha,
                EmpleadoId = empleadoId,
                Sueldo = sueldo,
                Dias = dias,
                TotalBasico = totalBasico,
                Otros = otros,
                Devengado = devengado
            });
            Console.WriteLine("Nómina registrada con éxito");
        }

        #endregion

        //Modificar
        #region Modificar
        public void Modificar(int id, DateTime fecha, int empleadoId, decimal sueldo, int dias, decimal totalBasico, decimal otros, decimal devengado)
        {
            var actualizarItem = new Nomina
            {
                Id = id,
                Fecha = fecha,
                EmpleadoId = empleadoId,
                Sueldo = sueldo,
                Dias = dias,
                TotalBasico = totalBasico,
                Otros = otros,
                Devengado = devengado
            };
            var item = LsListaNomina.FirstOrDefault(i => i.Id == actualizarItem.Id);
            if (item != null)
            {
                LsListaNomina.Remove(item);
                LsListaNomina.Add(actualizarItem);
                Console.WriteLine("Nómina actualizada con éxito");
            }
            else
            {
                Console.WriteLine("El id de nómina a modificar no existe!");
            }
        }
        #endregion

        //Eliminar
        #region Eliminar
        public void Eliminar(int id)
        {
            var item = LsListaNomina.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                LsListaNomina.Remove(item);
                Console.WriteLine("La nómina ha sido eliminada con éxito");
            }
            else
            {
                Console.WriteLine("El id del nómina no existe!");
            }
        }
        #endregion

        //Verificar Integridad referencial EmpeladoID
        #region Varificar Integridad referencial Empleado ID

        public bool VerificarIntegridadEmpleadoId(int idEmpleado)
        {
            List<Nomina> lista = new List<Nomina>();
            lista.AddRange(from a in LsListaNomina where a.EmpleadoId == idEmpleado select a);
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
    }
}
