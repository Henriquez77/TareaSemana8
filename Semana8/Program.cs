using System;
using System.Linq;
using System.Threading;
using Semana8.Models;

namespace Semana8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create database Almacen;
            //use Almacen;

            //create table Producto(
            //    Id int primary key identity,
            //    Nombre varchar(50),
            //    Descripcion varchar(255),
            //    Precio decimal(16, 2),
            //    Stock int
            //);
            //insert into Producto(Nombre, Descripcion, Precio, Stock)
            //values('Intel core i9-12900', 'Procesador', 600.00, 15);

            Producto producto = new Producto();
            
            do
            {
                int op = 0;
                
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n     Menu\n");
                    Console.WriteLine("1- Insertar producto");
                    Console.WriteLine("2- Listar productos");
                    Console.WriteLine("3- Salir\n");
                    Console.Write("Selecciona una opcion valida ");
                    op = int.Parse(Console.ReadLine());
                    if(!(op >= 1 && op <= 3)) { 
                        Console.WriteLine("\nOpcion invalida, intentalo de nuevo!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                switch(op)
                {
                    case 1:
                        //Insert
                        using (AlmacenContext context = new AlmacenContext())
                        {
                            Console.Write("Ingrese el nombre del producto: ");
                            producto.Nombre = Console.ReadLine();
                            Console.Write("Ingrese la descripcion del producto: ");
                            producto.Descripcion = Console.ReadLine();
                            Console.Write("Ingrese el precio del producto: ");
                            producto.Precio = decimal.Parse(Console.ReadLine());
                            Console.Write("Ingrese el stock del producto: ");
                            producto.Stock = int.Parse(Console.ReadLine());
                            context.Add(producto);
                            if (context.SaveChanges() > 0)
                            {
                                Console.WriteLine("\nProducto almacenado correctamente!");
                            }
                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 2:
                        //Read
                        using (AlmacenContext context = new AlmacenContext())
                        {

                            foreach (var read in context.Productos.ToList())
                            {
                                Console.WriteLine("\n---------------------------------------");
                                Console.WriteLine($"Registro #{read.Id}");
                                Console.WriteLine($"Id: {read.Id}");
                                Console.WriteLine($"Nombre: {read.Nombre}");
                                Console.WriteLine($"Descripcion: {read.Descripcion}");
                                Console.WriteLine($"Precio: ${read.Precio}");
                                Console.WriteLine($"Stock: {read.Stock}");
                                Console.WriteLine("---------------------------------------\n");
                            }

                        }
                        Console.Write("\nPresiona una tecla para regresar");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("\nFinalizando ejecucion!");
                        break;
                    default:
                        Console.WriteLine("\nFinalizando ejecucion!");
                        break;
                }
                if((op != 1 && op != 2) || op == 3) { break; }
            } while (true);

            
            
        }
    }
}
