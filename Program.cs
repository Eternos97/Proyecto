using MySql.Data.MySqlClient;
using System;

class Program
{
    static string connectionString = "Server=localhost; Database=tienda_; Uid=root; Pwd=;"; // Cambia según tu configuración

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Gestión de Productos y Categorías");
            Console.WriteLine("1. Insertar Categoría");
            Console.WriteLine("2. Insertar Producto");
            Console.WriteLine("3. Modificar Producto");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InsertarCategoria();
                    break;
                case "2":
                    InsertarProducto();
                    break;
                case "3":
                    ModificarProducto();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void InsertarCategoria()
    {
        Console.Write("Ingrese el nombre de la categoría: ");
        string nombreCategoria = Console.ReadLine();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO categorias (nombre) VALUES (@nombre)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", nombreCategoria);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Categoría insertada correctamente.");
    }

    static void InsertarProducto()
    {
        Console.Write("Ingrese el nombre del producto: ");
        string nombreProducto = Console.ReadLine();
        Console.Write("Ingrese el precio del producto: ");
        decimal precioProducto = Convert.ToDecimal(Console.ReadLine());
        Console.Write("Ingrese el ID de la categoría: ");
        int categoriaId = Convert.ToInt32(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO productos (nombre, precio, categoria_id) VALUES (@nombre, @precio, @categoria_id)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", nombreProducto);
            cmd.Parameters.AddWithValue("@precio", precioProducto);
            cmd.Parameters.AddWithValue("@categoria_id", categoriaId);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Producto insertado correctamente.");
    }

    static void ModificarProducto()
    {
        Console.Write("Ingrese el ID del producto a modificar: ");
        int productoId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese el nuevo nombre del producto: ");
        string nuevoNombre = Console.ReadLine();
        Console.Write("Ingrese el nuevo precio del producto: ");
        decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "UPDATE productos SET nombre = @nombre, precio = @precio WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
            cmd.Parameters.AddWithValue("@precio", nuevoPrecio);
            cmd.Parameters.AddWithValue("@id", productoId);
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Producto modificado correctamente.");
    }
}
