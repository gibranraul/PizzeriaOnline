using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PizzeriaOnline
{
    internal class Program
    {
        public static string logo = "";
        static StreamReader reader = null;
        static StreamWriter writer = null;
        public static class ProjectInfo
        {
            public static string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            public static string projectPath = appDirectory.Substring(0, appDirectory.IndexOf("\\bin"));
        }
        public static void MostrarLogo()
        {
            try
            {
                reader = new StreamReader($"{ProjectInfo.projectPath}\\logo.txt");
                Console.Write(reader.ReadToEnd() + "\n\n");
                reader.Close();
            }
            catch (Exception)
            {
                Console.Write("error");
                throw;
            }

        }

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        public static void MenuPrincipal()
        {
            string mensaje = "Bienvenido a Pizzeria Online!. ¿Que Quieres hacer?";
            string[] opciones = { "Ingresar", "Registrarse", "Salir" };
            Menu menuPrincipal = new Menu(mensaje, opciones);
            menuPrincipal.Correr();
            int selectedIndex = menuPrincipal.Correr();
            switch (selectedIndex)
            {
                case 0:
                    Ingresar();
                    break;
                case 1:
                    Registrarse();
                    break;
                case 2:
                    Salir();
                    break;
            }
        }
        private static void Ingresar()
        {
            string username, pass;
            Console.Clear();
            MostrarLogo();
            bool flag = false;
            while (flag != true)
            {
                Console.Write("Ingresa tu nombre de usuario : ");
                username = Console.ReadLine();
                Console.Write("Ingresa tu clave : ");
                pass = Console.ReadLine();
                //if (LeerUsuarios().Contains(username, StringComparison.CurrentCultureIgnoreCase))
                if (HayUsuario(username, pass))
                {
                    MenuUsuario(username);
                    flag = true;

                }
                else
                    Console.WriteLine("Usuario Incorrecto!");
            }

        }
        private static bool HayUsuario(string user, string pass)
        {
            int counter = 0;
            bool hayusuario=false;
            string line;
            reader = new StreamReader($"{ProjectInfo.projectPath}\\usuarios.txt");
            while ((line = reader.ReadLine()) != null)
            {
                counter++;
            }

            reader.Close();
            string[] lines = new string[counter];
            reader = new StreamReader($"{ProjectInfo.projectPath}\\usuarios.txt");
            for (int i = 0; i < counter; i++)
            {
                lines[i] = reader.ReadLine();
                if (lines[i].Contains(pass, StringComparison.Ordinal) && lines[i].Contains(user, StringComparison.Ordinal))
                {
                    hayusuario = true;
                }
            }
            reader.Close();
            return hayusuario;
        }

        private static string LeerUsuarios()
            {
                string usuarios;
                reader = new StreamReader($"{ProjectInfo.projectPath}\\usuarios.txt");
                usuarios = reader.ReadToEnd();
                reader.Close();
                return usuarios;
            }
            private static void Registrarse()
            {
            string nomusuario, datos, password, nombre, direccion, cp, tel, email, tarjeta, cvv, fecha;
                Console.Clear();
                MostrarLogo();
                Console.Write("Ingresa el nombre de usuario: ");
                nomusuario = Console.ReadLine();
                Console.Write("Ingresa el password: ");
            password = Console.ReadLine();
            Console.Write("Ingresa nombre completo: ");
            nombre = Console.ReadLine();
            Console.Write("Ingresa direccion: ");
            direccion = Console.ReadLine();
            Console.Write("Ingresa codigo postal: ");
            cp = Console.ReadLine();
            Console.Write("Ingresa telefono: ");
            tel = Console.ReadLine();
            Console.Write("Ingresa email: ");
            email = Console.ReadLine();
            Console.Write("Ingresa numero de tarjeta: ");
            tarjeta = Console.ReadLine();
            Console.Write("Ingresa numero de cvv: ");
            cvv = Console.ReadLine();
            Console.Write("Ingresa fecha vencimiento: ");
            fecha = Console.ReadLine();
                if (LeerUsuarios() != "")
                {
                    string txt;
                    reader = new StreamReader($"{ProjectInfo.projectPath}\\usuarios.txt");
                    txt = reader.ReadToEnd();
                    reader.Close();
                    writer = new StreamWriter($"{ProjectInfo.projectPath}\\usuarios.txt");
                    if (txt == "")
                        writer.WriteLine($"{nomusuario}:{password} datos:{nombre}, {direccion}, {email}, {cp}, {tel}, {tarjeta}, {cvv}, {fecha}");
                else
                        writer.Write(txt + $"\n{nomusuario}:{password} datos:{nombre}, {direccion}, {email}, {cp}, {tel}, {tarjeta}, {cvv}, {fecha}");
                    writer.Close();
                }
                Console.WriteLine("\nRegistro exitoso!");
                Console.ReadKey();
                MenuPrincipal();

            }
            private static void MenuProductos(string user)
            {
                string mensaje = $"Bienvenido {user}!. ¿Que vas a ordenar hoy?";
                string[] opciones = { "Pizza peperoni ($100MXN c/u)", "Pizza con hawaiana ($200MXN c/u)", "Pizza italiana ($300MXN c/u)", "Pizza con carne ($500MXN c/u)", "Pizza vegetariana ($1000MXN c/u)" };
                Menu menuProductos = new Menu(mensaje, opciones);
                menuProductos.Correr();
                int selectedIndex = menuProductos.Correr();
                string cant;
                switch (selectedIndex)
                {
                    case 0:
                        Console.Write($"\n{opciones[selectedIndex]}. Buena eleccion! ¿Cuantas vas a querer? ");
                        cant = Console.ReadLine();
                        RegistrarOrden(user, opciones[selectedIndex], cant);
                        break;
                    case 1:
                        Console.Write($"\n{opciones[selectedIndex]}. Buena eleccion! ¿Cuantas vas a querer? ");
                        cant = Console.ReadLine();
                        RegistrarOrden(user, opciones[selectedIndex], cant);
                        break;
                    case 2:
                        Console.Write($"\n{opciones[selectedIndex]}. Buena eleccion! ¿Cuantas vas a querer? ");
                        cant = Console.ReadLine();
                        RegistrarOrden(user, opciones[selectedIndex], cant);
                    break;
                    case 3:
                        Console.Write($"\n{opciones[selectedIndex]}. Buena eleccion! ¿Cuantas vas a querer? ");
                        cant = Console.ReadLine();
                        RegistrarOrden(user, opciones[selectedIndex], cant);
                    break;
                    case 4:
                        Console.Write($"\n{opciones[selectedIndex]}. Buena eleccion! ¿Cuantas vas a querer? ");
                        cant = Console.ReadLine();
                        RegistrarOrden(user, opciones[selectedIndex], cant);
                    break;
            }
            Algomas(user);

            }
            private static void RegistrarOrden(string user, string producto, string cant)
            {
                string txt;
                reader = new StreamReader($"{ProjectInfo.projectPath}\\ordenes.txt");
                txt = reader.ReadToEnd();
                reader.Close();
                writer = new StreamWriter($"{ProjectInfo.projectPath}\\ordenes.txt");
                if (txt == "")
                    writer.WriteLine($"{user}: {producto} x {cant}");
                else
                    writer.Write(txt + $"\n{user}: {producto} x {cant}");
            writer.Close();
        }
        private static void Algomas(string username)
        {
            string mensaje = "Orden exitosa! ¿Quieres ordenar algo mas?";
            string[] opciones = { "Si", "No" };
            Menu menuUsuario = new Menu(mensaje, opciones);
            menuUsuario.Correr();
            int selectedIndex = menuUsuario.Correr();
            switch (selectedIndex)
            {
                case 0:
                    MenuProductos(username);
                    break;
                case 1:
                    MenuUsuario(username);
                    break;
            }
        }
        private static void ListaOrdenes(string username)
        {
            Console.Clear();
            int counter = 0;
            bool hayusuario = false;
            string line;
            reader = new StreamReader($"{ProjectInfo.projectPath}\\ordenes.txt");
            while ((line = reader.ReadLine()) != null)
            {
                counter++;
            }

            reader.Close();
            string[] lines = new string[counter];
            reader = new StreamReader($"{ProjectInfo.projectPath}\\ordenes.txt");
            for (int i = 0; i < counter; i++)
            {
                lines[i] = reader.ReadLine();
                if (lines[i].Contains(username, StringComparison.Ordinal))
                {
                    Console.WriteLine(lines[i]);
                }
            }
            reader.Close();
            Console.ReadKey();
            MenuUsuario(username);
        }

        private static void MenuUsuario(string username)
        {
            string mensaje = $"Bienvenido {username}!. ¿Que quieres hacer?";
            string[] opciones = { "Comprar", "Ver historial de ordenes", "Cerrar Sesion" };
            Menu menuAlgomas = new Menu(mensaje, opciones);
            menuAlgomas.Correr();
            int selectedIndex = menuAlgomas.Correr();
            switch (selectedIndex)
            {
                case 0:
                    MenuProductos(username);
                    break;
                case 1:
                    ListaOrdenes(username);
                    break;
                case 2:
                    MenuPrincipal(); ;
                    break;
            }
        }
        private static void Salir()
            {
                Environment.Exit(0);
            }
        }


    }
