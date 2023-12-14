using Microsoft.EntityFrameworkCore;
using sgarera.Controllers;
using sgarera.Models;
using System.Security.Cryptography.Xml;

namespace sgarera.Servicios
{
    public class ImplementacionCrud : InterfazCrud
    {
        Vajilla vaj = new Vajilla();
        private readonly exaDosContext contexto;

        public ImplementacionCrud(exaDosContext Contexto)
        {
            contexto = Contexto;
        }

        public void CrearElemento()
        {
            Console.WriteLine("Has seleccionado: Dar de alta Elemento");
            try
            { 
                Console.WriteLine("Ingresa los datos del nuevo elemento:");
                Console.Write("Nombre del Elemento: ");
                string nombre = Console.ReadLine();
                Console.Write("Descripción del Elemento: ");
                string descripcion = Console.ReadLine();
                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());
                string codigoElemento = "Elem-" + nombre;

                // Crear un elemento con los detalles ingresados
                vaj = new(0, codigoElemento, nombre, descripcion, cantidad);
                contexto.Vajillas.Add(vaj);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar crear un nuevo elemento." + e);
            }
        }

        public void MostrarStock()
        {
            Console.WriteLine("Has seleccionado: Mostrar Stocks");
            try
            {
                {
                    if (contexto.Vajillas.Any() == true)
                    {
                        // Obtener el stock desde la base de datos
                        List<Vajilla> stock = contexto.Vajillas.ToList();
                        Console.WriteLine("Stock actual:");
                        foreach (Vajilla vajilla in stock)
                        {
                            Console.WriteLine("Nombre :" + vajilla.Nombreelemento + "Cantidad :" + vajilla.Cantidadelemento);
                            Console.WriteLine("--------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay stock");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha producido un error al mostrar el stock");
            }
        }
    }
}
