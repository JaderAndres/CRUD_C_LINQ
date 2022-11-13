using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Actividad_CRUD_LINQ.Modelos;
using Actividad_CRUD_LINQ.Servicios;

namespace Actividad_CRUD_LINQ.Controllers
{
    public class AreasController: EmpleadosController
    {
        private List<Areas> listaAreas;

        private List<Areas> LsListaAreas { get { return listaAreas; } }

        public AreasController()
        {
            listaAreas = new List<Areas>();
        }
       
        //Llenar lista
        #region Llenar lista

        public void LlenarLista()
            {
                LsListaAreas.Clear();

                LsListaAreas.Add(new Areas()
                {
                    Id = 1,
                    Nombre = "Ventas",
                });
                LsListaAreas.Add(new Areas()
                {
                    Id = 2,
                    Nombre = "Contablilidad",
                });
                LsListaAreas.Add(new Areas()
                {
                    Id = 3,
                    Nombre = "Recursos humanos",
                });
                LsListaAreas.Add(new Areas()
                {
                    Id = 4,
                    Nombre = "Compras",
                });
                LsListaAreas.Add(new Areas()
                {
                    Id = 5,
                    Nombre = "Operaciones",
                });
            }

        #endregion

        //Listar todos
        #region ListarTodos

        public void ListarTodas()
        {
            List<Areas> lista = new List<Areas>();
            lista.AddRange(from a in LsListaAreas orderby a.Id select a);
            //lista = lista.OrderBy(p => p.Id).ToList();
            if (lista.Count > 0)
            {
                ServicioAreas.ImprimirAreas(lista);
            }
            else
            {
                Console.WriteLine("No hay áreas registradas!");
            }            
        }

        #endregion

        //Mostrar por Id
        #region MostrarxId
        public void MostrarxId(int id)
        {
            List<Areas> lista = new List<Areas>();
            lista.AddRange(from a in LsListaAreas where a.Id == id select a);
            if (lista.Count > 0)
            {
                ServicioAreas.ImprimirAreas(lista);
            }
            else
            {
                Console.WriteLine("El área ingresada no existe!");
            }
        }
        #endregion

        //Registrar
        #region Registrar
        public void Registrar(string nombre)
        {
            //LlenarLista();

            IEnumerable<Areas> lista = LsListaAreas.OrderBy(ar => ar.Id);
            Areas ultimo = lista.LastOrDefault();

            LsListaAreas.Add(new Areas()
            {
                Id = ultimo.Id + 1,
                Nombre = nombre                    
            });
            Console.WriteLine("Área registrada con éxito");
        }

        #endregion

        //Modificar
        #region Modificar
        public void Modificar(int id, string nombre)
        {
            var actualizarItem = new Areas
            {
                Id = id,
                Nombre = nombre                
            };
            var item = LsListaAreas.FirstOrDefault(i => i.Id == actualizarItem.Id);
            if (item != null)
            {
                LsListaAreas.Remove(item);
                LsListaAreas.Add(actualizarItem);
                Console.WriteLine("Área actualizada con éxito");
            }
            else
            {
                Console.WriteLine("El área a modificar no existe!");
            }
        }
        #endregion

        //Eliminar
        #region Eliminar
        public void Eliminar(int id)
        {
            var item = LsListaAreas.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                LsListaAreas.Remove(item);
                Console.WriteLine("El área ha sido eliminada con éxito");
            }
            else
            {
                Console.WriteLine("El id del área no existe!");
            }
        }
        #endregion

        //Verificar AreaID
        #region Varificar Area ID

        public bool VerificarAreaId(int id)
        {
            List<Areas> lista = new List<Areas>();
            lista.AddRange(from a in LsListaAreas where a.Id == id select a);
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
