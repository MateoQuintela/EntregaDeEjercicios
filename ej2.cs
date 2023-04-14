using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlEmpresasEmpleados ce = new ControlEmpresasEmpleados();

            Console.WriteLine("Promedio por empresas \n************************");
            ce.promedioSalarios();
            Console.WriteLine("");

            Console.WriteLine("Quienes mandan \n*******************************");
            ce.getSeo("Jefe");

            Console.WriteLine("");
            Console.WriteLine("Plantilla \n************************************");
            ce.getEmpleadosOrdenados();
            Console.WriteLine("");
            Console.WriteLine("Plantilla ordenadoa por salarios \n*************");
            ce.getEmpleadoOrdeSegunSalario();
            Console.WriteLine("\nIngresa la empresa:(entero 1 a 3)\n 1 para ir Panchos S/A \n2 para BasketTeam\n3 para McTrucho");

            string Id = Console.ReadLine();
            try
            {
                int Empresa = int.Parse(Id);
               // ce.getEmpleadosEmpresa(Empresa);

            }
            catch
            {
                Console.WriteLine("Ha introducido in Id erroneo. Debe ingresar un numero entero.");


            }
        }

        internal class Persona
        {
            public int Edad { get; set; }

            public string Nombre { get; set; }

            public string Ciudad { get; set; }
        }

        internal class Empleado
        {
            public int Id { get; set; }

            public string Nombre { get; set; }

            public string Cargo { get; set; }

            public int Salario { get; set; }

            public int EmpresaId { get; set; }

            public void getDatosEmpleados()
            {
                Console.WriteLine("Empleados {0} con Id {1} , con cargo {2}, con salario {3} y pertenece a " + "la empresa {4}", Nombre, Id, Cargo, Salario, EmpresaId);
            }





        }
        internal class Empresa
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public void getDatosEmpresa()
            {
                Console.WriteLine("Empresa {0} con Id{1}", Nombre, Id);
            }
        }
        internal class ControlEmpresasEmpleados
        {
            public List<Empleado> listaEmpleados;
            public List<Empresa> listaEmpresas;

            public ControlEmpresasEmpleados()
            {
                listaEmpleados = new List<Empleado>();
                listaEmpresas = new List<Empresa>();

                listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Panchos S/A" });
                listaEmpresas.Add(new Empresa { Id = 2, Nombre = "BasketTeam" });
                listaEmpresas.Add(new Empresa { Id = 3, Nombre = "McTrucho" });

                listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Mateo ", Cargo = "Jefe", EmpresaId = 1, Salario = 30000 });
                listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Ana ", Cargo = "Analista", EmpresaId = 1, Salario = 20000 });
                listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Pepe ", Cargo = "Jefe", EmpresaId = 2, Salario = 29000 });
                listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Juan ", Cargo = "Analista", EmpresaId = 2, Salario = 30000 });
                listaEmpleados.Add(new Empleado { Id = 5, Nombre = "Ana ", Cargo = "Analista", EmpresaId = 3, Salario = 20000 });
                listaEmpleados.Add(new Empleado { Id = 6, Nombre = "Pepe ", Cargo = "Jefe", EmpresaId = 3, Salario = 29000 });




            }

            //getters
            public void getSeo(string Cargo)
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby  empleado.Cargo == Cargo descending select empleado;
                
               foreach (Empleado elemento in empleados)
                {
                    elemento.getDatosEmpleados();
                }

            }
            public void getEmpleadosOrdenados()
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby empleado.Nombre select empleado;

                foreach (Empleado elemento in empleados)
                {
                    elemento.getDatosEmpleados();
                }
            
            }
            
            public void getEmpleadoOrdeSegunSalario()
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby empleado.Salario select empleado;

                foreach (Empleado elemento in empleados)
                {
                    elemento.getDatosEmpleados();
                }

            }
            public void getEmpleadosEmpresa(int _Empresa)
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados join empresa in listaEmpresas on empleado.EmpresaId equals empresa.Id where empresa.Id == _Empresa select empleado;

                foreach (Empleado elemento in empleados)
                {
                    elemento.getDatosEmpleados();
                }

            }
            //___________________Metodos Particulares
            public void promedioSalarios()
            {
                var consulta = from e in listaEmpleados group e by e.EmpresaId into g select new { empresa = g.Key, PromedioSalario = g.Average(e => e.Salario) };

                foreach (var resultado in consulta)
                {
                    switch (resultado.empresa)
                    {
                        case 1:
                            Console.WriteLine($"Empresa Panchos S/A - Promedio de salario : {resultado.PromedioSalario}");
                            break;

                        case 2:
                            Console.WriteLine($"Empresa basketTeam - Promedio de salario : {resultado.PromedioSalario}");
                            break;

                        case 3:
                            Console.WriteLine($"Empresa McTrucho - Promedio de salario : {resultado.PromedioSalario}");
                            break;

                    }

                }
            }


        


        }

    }
}
