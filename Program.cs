using Actividad_CRUD_LINQ.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Actividad_CRUD_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Util Util = new Util(); //Metodos

            AreasController AreasControll = new AreasController();
            EmpleadosController EmpleadosControll = new EmpleadosController();
            NominaController NominaControll = new NominaController();

            //Console.WriteLine("******* Actividad CRUD POO LINQ *******");
            //Console.WriteLine("Presione otra tecla para continuar...");
            //Console.ReadKey();

            int opc = 0;
            int opcCRUD = 0;
            string leer = "";
            string leerA = "";
            int id = 0;
            string nombre = "";
            string apellidos = "";
            string direccion = "";
            string telefono = "";
            string fechaIngreso = "";
            int areaId = 0;
            int empleadoId = 0;
            DateTime fechaNomina;
            decimal sueldo = 0;
            int dias = 0;
            decimal totalBasico = 0;
            decimal otrosNomina = 0;
            decimal devengado = 0;

            //Se llena una vez para que se puedan ver el registrar, Actualizar, Eliminar.
            AreasControll.LlenarLista();
            EmpleadosControll.LlenarLista();
            NominaControll.LlenarLista();

            do
            {
                Console.Clear();

                Console.WriteLine("******* Actividad CRUD POO LINQ *******");
                Console.WriteLine(" ");
                Console.WriteLine("Escoja modelo para realizar el CRUD:");
                Console.WriteLine("1 - Áreas");
                Console.WriteLine("2 - Empleados");
                Console.WriteLine("3 - Nómina");
                Console.WriteLine("4 - Salir");

                opc = Convert.ToInt32(Console.ReadLine());

                switch (opc)
                {
                    case 1:

                        //Areas
                        #region Areas
                                                
                        opcCRUD = 0;

                        do
                        {
                            Console.Clear();

                            Console.WriteLine("**************** ÁREAS ****************");
                            Console.WriteLine("Escoja la operación que desea realizar:");
                            Console.WriteLine("1 - Listar todas");
                            Console.WriteLine("2 - Mostrar por Id");
                            Console.WriteLine("3 - Registrar");
                            Console.WriteLine("4 - Modificar");
                            Console.WriteLine("5 - Eliminar");
                            Console.WriteLine("6 - Atrás");

                            //Lee la opción
                            leer = Console.ReadLine();
                            //Valida la tecla Enter
                            if (Util.ValidarIngresado(leer))
                            {
                                opcCRUD = Convert.ToInt32(leer.Trim());                                
                            }
                            else
                            {
                                opcCRUD = 0;
                            }

                            switch (opcCRUD)
                            {
                                case 1:
                                    
                                    Console.WriteLine("---- Listado de áreas ----");
                                    AreasControll.ListarTodas();                                    
                                    Console.WriteLine("--------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 2:

                                    Console.WriteLine("---- Mostrar área por Id ----");
                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }
                                                                  
                                    AreasControll.MostrarxId(id);
                                    Console.WriteLine("------------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 3:

                                    Console.WriteLine("---- Registrar área ----");

                                    Console.Write("Ingrese el nombre: ");
                                    nombre = Console.ReadLine();
                                    AreasControll.Registrar(nombre);

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 4:

                                    Console.WriteLine("---- Modificar área ----");

                                    Console.Write("Ingrese el Id: ");                                    

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());                                       
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    Console.Write("Ingrese el nombre: ");
                                    nombre = Console.ReadLine();

                                    AreasControll.Modificar(id, nombre);

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 5:

                                    Console.WriteLine("---- Eliminar área ----");

                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    //Confirmación eliminar
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    string opcElm = "";
                                    Console.WriteLine("¿Esta seguro que desea eliminar este registro?: s / n");
                                    opcElm = Console.ReadLine();
                                    if (opcElm.Trim() == "s")
                                    {
                                        //Valida Integridad en Empleados
                                        if(EmpleadosControll.VerificarIntegridadAreaId(id) == false)
                                        {
                                            AreasControll.Eliminar(id);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Esta área no se puede eliminar debido a que esta registrada en Empleados!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Eliminación cancelada!");
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 6:
                                    Console.WriteLine("Atrás");
                                    opcCRUD = 6;                                    
                                    break;
                                default:
                                    Util.MensajeOpcionNoValida();
                                    Util.PieOperacion();
                                    break;
                            }
                        } while (opcCRUD != 6);
                        #endregion
                        //Fin áreas                                                                       
                        break;

                    case 2:

                        //Empleados
                        #region Empleados

                        opcCRUD = 0;

                        do
                        {
                            Console.Clear();

                            Console.WriteLine("**************** EMPLEADOS ****************");
                            Console.WriteLine("Escoja la operación que desea realizar:");
                            Console.WriteLine("1 - Listar todos");
                            Console.WriteLine("2 - Mostrar por Id");
                            Console.WriteLine("3 - Registrar");
                            Console.WriteLine("4 - Modificar");
                            Console.WriteLine("5 - Eliminar");
                            Console.WriteLine("6 - Atrás");

                            //Lee la opción
                            leer = Console.ReadLine();
                            //Valida la tecla Enter
                            if (Util.ValidarIngresado(leer))
                            {
                                opcCRUD = Convert.ToInt32(leer.Trim());
                            }
                            else
                            {
                                opcCRUD = 0;
                            }

                            switch (opcCRUD)
                            {
                                case 1:

                                    Console.WriteLine("---- Listado de empleados ----");
                                    EmpleadosControll.ListarTodos();
                                    Console.WriteLine("--------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 2:

                                    Console.WriteLine("---- Mostrar empleado por Id ----");
                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    EmpleadosControll.MostrarxId(id);
                                    Console.WriteLine("------------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 3:

                                    Console.WriteLine("---- Registrar empleado ----");

                                    Console.Write("Ingrese el nombre: ");
                                    nombre = Console.ReadLine();
                                    Console.Write("Ingrese el apellido: ");
                                    apellidos = Console.ReadLine();
                                    Console.Write("Ingrese la dirección: ");
                                    direccion = Console.ReadLine();
                                    Console.Write("Ingrese el teléfono: ");
                                    telefono = Console.ReadLine();
                                    Console.Write("Ingrese el fecha de ingreso: ");
                                    fechaIngreso = Console.ReadLine();
                                    Console.Write("Ingrese el Id del área: ");
                                    leer = Console.ReadLine();

                                    if (Util.ValidarIngresado(leer))
                                    {
                                        areaId = Convert.ToInt32(leer);

                                        //Verifica AreaID
                                        if (AreasControll.VerificarAreaId(areaId) == true)
                                        {
                                            EmpleadosControll.Registrar(nombre, apellidos, direccion, telefono, Convert.ToDateTime(fechaIngreso), areaId);
                                        }
                                        else
                                        {
                                            Console.WriteLine("El área ingresada no está registrada!");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese un valor válido en área id!");
                                    }

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 4:

                                    Console.WriteLine("---- Modificar empleado ----");

                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    Console.Write("Ingrese el nombre: ");
                                    nombre = Console.ReadLine();
                                    Console.Write("Ingrese el apellido: ");
                                    apellidos = Console.ReadLine();
                                    Console.Write("Ingrese la dirección: ");
                                    direccion = Console.ReadLine();
                                    Console.Write("Ingrese el teléfono: ");
                                    telefono = Console.ReadLine();
                                    Console.Write("Ingrese el fecha de ingreso: ");
                                    fechaIngreso = Console.ReadLine();
                                    Console.Write("Ingrese el Id del área: ");
                                    leerA = Console.ReadLine();

                                    if (Util.ValidarIngresado(leerA))
                                    {
                                        areaId = Convert.ToInt32(leerA);

                                        //Verifica AreaID
                                        if (AreasControll.VerificarAreaId(areaId) == true)
                                        {
                                            EmpleadosControll.Modificar(id, nombre, apellidos, direccion, telefono, Convert.ToDateTime(fechaIngreso), areaId);
                                        }
                                        else
                                        {
                                            Console.WriteLine("El área ingresada no está registrada!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese un valor válido en área id!");
                                    }
                                   
                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 5:

                                    Console.WriteLine("---- Eliminar empleado ----");

                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    //Confirmación eliminar
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    string opcElm = "";
                                    Console.WriteLine("¿Esta seguro que desea eliminar este registro?: s / n");
                                    opcElm = Console.ReadLine();
                                    if (opcElm.Trim() == "s")
                                    {

                                        //Valida Integridad en Nómina
                                        if (NominaControll.VerificarIntegridadEmpleadoId(id) == false)
                                        {
                                            EmpleadosControll.Eliminar(id);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Esta área no se puede eliminar debido a que esta registrada en Nómina!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Eliminación cancelada!");
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 6:
                                    Console.WriteLine("Atrás");
                                    opcCRUD = 6;
                                    break;
                                default:
                                    Util.MensajeOpcionNoValida();
                                    Util.PieOperacion();
                                    break;
                            }
                        } while (opcCRUD != 6);
                        #endregion
                        //Fin empleados
                        break;

                    case 3:

                        //Nómina
                        #region Nómina

                        opcCRUD = 0;

                        do
                        {
                            Console.Clear();

                            Console.WriteLine("**************** NÓMINA ****************");
                            Console.WriteLine("Escoja la operación que desea realizar:");
                            Console.WriteLine("1 - Listar todas");
                            Console.WriteLine("2 - Mostrar por Id");
                            Console.WriteLine("3 - Registrar");
                            Console.WriteLine("4 - Modificar");
                            Console.WriteLine("5 - Eliminar");
                            Console.WriteLine("6 - Atrás");

                            //Lee la opción
                            leer = Console.ReadLine();
                            //Valida la tecla Enter
                            if (Util.ValidarIngresado(leer))
                            {
                                opcCRUD = Convert.ToInt32(leer.Trim());
                            }
                            else
                            {
                                opcCRUD = 0;
                            }

                            switch (opcCRUD)
                            {
                                case 1:

                                    Console.WriteLine("---- Listado de las nóminas ----");
                                    NominaControll.ListarTodos();
                                    Console.WriteLine("--------------------------");
                                    
                                    Util.PieOperacion();                                    

                                    break;
                                case 2:

                                    Console.WriteLine("---- Mostrar nómina por Id ----");
                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    NominaControll.MostrarxId(id);
                                    Console.WriteLine("------------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 3:

                                    Console.WriteLine("---- Registrar nómina ----");

                                    Console.Write("Ingrese la fecha: ");
                                    fechaNomina = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Ingrese el id del empleado: ");
                                    leer = Console.ReadLine();
                                    Console.Write("Ingrese el sueldo: ");
                                    sueldo = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Ingrese los días: ");
                                    dias = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Ingrese otros: ");
                                    otrosNomina = Convert.ToDecimal(Console.ReadLine());

                                    //Cálculos
                                    totalBasico = (sueldo * dias) / 30;
                                    devengado = totalBasico + otrosNomina;

                                    if (Util.ValidarIngresado(leer))
                                    {
                                        empleadoId = Convert.ToInt32(leer);

                                        //Verifica EmpleadoID
                                        if (EmpleadosControll.VerificarEmpleadoId(empleadoId) == true)
                                        {
                                            NominaControll.Registrar(fechaNomina, empleadoId, sueldo, dias, totalBasico, otrosNomina, devengado);
                                        }
                                        else
                                        {
                                            Console.WriteLine("El empleado ingresado no está registrado!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese un valor válido en empleado id!");
                                    }

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 4:

                                    Console.WriteLine("---- Modificar empleado ----");

                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    Console.Write("Ingrese la fecha: ");
                                    fechaNomina = Convert.ToDateTime(Console.ReadLine());
                                    Console.Write("Ingrese el id del empleado: ");
                                    leer = Console.ReadLine();
                                    Console.Write("Ingrese el sueldo: ");
                                    sueldo = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Ingrese los días: ");
                                    dias = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Ingrese otros: ");
                                    otrosNomina = Convert.ToDecimal(Console.ReadLine());

                                    //Cálculos
                                    totalBasico = (sueldo * dias) / 30;
                                    devengado = totalBasico + otrosNomina;

                                    if (Util.ValidarIngresado(leer))
                                    {
                                        empleadoId = Convert.ToInt32(leer);

                                        //Verifica AreaID
                                        if (EmpleadosControll.VerificarEmpleadoId(empleadoId) == true)
                                        {
                                            NominaControll.Modificar(id, fechaNomina, empleadoId, sueldo, dias, totalBasico, otrosNomina, devengado);
                                        }
                                        else
                                        {
                                            Console.WriteLine("El empleado ingresado no está registrado!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ingrese un valor válido en empleado id!");
                                    }

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 5:

                                    Console.WriteLine("---- Eliminar nómina ----");

                                    Console.Write("Ingrese el Id: ");

                                    //Lee el Id
                                    leer = Console.ReadLine();
                                    //Valida la tecla Enter
                                    if (Util.ValidarIngresado(leer))
                                    {
                                        id = Convert.ToInt32(leer.Trim());
                                    }
                                    else
                                    {
                                        id = -1;
                                    }

                                    //Confirmación eliminar
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    string opcElm = "";
                                    Console.WriteLine("¿Esta seguro que desea eliminar este registro?: s / n");
                                    opcElm = Console.ReadLine();
                                    if (opcElm.Trim() == "s")
                                    {
                                        NominaControll.Eliminar(id);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Eliminación cancelada!");
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.WriteLine("-------------------------");

                                    Util.PieOperacion();

                                    break;
                                case 6:
                                    Console.WriteLine("Atrás");
                                    opcCRUD = 6;
                                    break;
                                default:
                                    Util.MensajeOpcionNoValida();
                                    Util.PieOperacion();
                                    break;
                            }
                        } while (opcCRUD != 6);
                        #endregion
                        //Fin nómina
                        break;

                    case 4:
                        string confirmacion = "";
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Está seguro que quiere salir?: s / n");
                        confirmacion = Console.ReadLine();
                        if (confirmacion == "s")
                        {
                            opc = 4;
                        }
                        else
                        {
                            opc = 1;
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    default:
                        Console.WriteLine("Opción no válida, escoja otra");
                        break;
                }
            } while (opc != 4) ;


            


        }      
    }

    //Funciones:

    public class Util
    {
        public void MensajeOpcionNoValida()
        {
            Console.WriteLine("Opción no válida, escoja otra opción válida!");
        }

        public void PieOperacion()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        public bool ValidarIngresado(string leido)
        {
            //Valida la conversión de string a INTEGER.
            bool valor = false;
            int num = 0;
            valor = Int32.TryParse(leido, out num);
            return valor;
        }      

    }
}
