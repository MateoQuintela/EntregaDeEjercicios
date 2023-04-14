using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LQejPaEntregar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona { Nombre = "Mateo", Edad = 23, Ciudad = "Maldonado" },
                new Persona { Nombre = "Mateo", Edad = 29, Ciudad = "San Carlos" },
                new Persona { Nombre = "Mateo", Edad = 26, Ciudad = "Maldonado" },
                new Persona { Nombre = "Mateo", Edad = 33, Ciudad = "Piriapolis" },
                new Persona { Nombre = "Mateo", Edad = 43, Ciudad = "Pan de Azucar" },
                new Persona { Nombre = "Matet", Edad = 35, Ciudad = "Maldonado" }


            };
            var consulta = from p in personas where p.Edad < 25 && p.Ciudad == "Maldonado" orderby p.Nombre descending select new { p.Nombre, p.Edad };
            foreach (var persona in consulta)
            {
                Console.WriteLine($"{persona.Nombre} ({persona.Edad} años)");

            }
            var consulta2 = from p in personas where p.Edad > 30 && p.Ciudad == "Maldonado" orderby p.Nombre descending select new { p.Nombre, p.Edad ,p.Ciudad};
            foreach (var persona in consulta2)
            {
                Console.WriteLine($"{persona.Nombre} ({persona.Edad} años) ciudad {persona.Ciudad}");

            }
            var consulta3 = from p in personas where p.Edad <30 && p.Edad >25  orderby p.Edad ascending select new { p.Nombre, p.Edad };
            foreach (var persona in consulta3)
            {
                Console.WriteLine($"{persona.Nombre} ({persona.Edad} años)");

            }

        }

        internal class Persona
        {
            public int Edad { get; set; }

            public string Nombre { get; set; }

            public string Ciudad { get; set; }
        }

       




        
    }
}