using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehiculo> Vehiculos = new List<Vehiculo>();

            Console.WriteLine("Bienvenido a tu gestor de viajes");

            bool Continuar = true;

            while (Continuar)
            {
                Console.WriteLine("---MENU DE GESTION DE VIAJES---");
                Console.WriteLine(" 1.Agregar Vehiculo \n 2.Registrar Viaje para un vehiculo \n 3.Mostrar Informacion de un Vehiculo \n 4.Mostrar Informacion de todos los vehiculos \n 5. X--- SALIR ---- X \n Seleccione una opcion: ");

                int Opcion = int.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        MenuAgregarVehiculo(Vehiculos);
                        break;

                    case 2:
                        MenuRegistrarViaje(Vehiculos); //tuve que poner el static en el metodo para poder llamarlo desde el main, sino me tiraba error de que no se puede acceder a un metodo no estatico desde un metodo estatico, y como el main es estatico, tuve que ponerlo tambien en los otros metodos para poder llamarlos desde el main
                        break;
                    case 3:
                        MenuMostrarVehiculos(Vehiculos); //tuve que poner el static en el metodo para poder llamarlo desde el main, sino me tiraba error de que no se puede acceder a un metodo no estatico desde un metodo estatico, y como el main es estatico, tuve que ponerlo tambien en los otros metodos para poder llamarlos desde el main.
                        break;
                    case 4:
                        MenuMostrarTodosRegistrados(Vehiculos); //tuve que poner el static en el metodo para poder llamarlo desde el main, sino me tiraba error de que no se puede acceder a un metodo no estatico desde un metodo estatico, y como el main es estatico, tuve que ponerlo tambien en los otros metodos para poder llamarlos desde el main
                        break;
                    case 5:
                        Continuar = false;
                        break;
                }
            }
        }
        static void MenuAgregarVehiculo(List<Vehiculo> Vehiculos)
        {
            Console.Clear();
            Console.WriteLine("--- AGREGAR VEHÍCULO ---");

            Console.Write("Ingrese la Patente: ");
            string Patente = Console.ReadLine();

            foreach (Vehiculo v in Vehiculos)
            {
                if (v.Patente == Patente)
                {
                    Console.WriteLine("Ya existe un vehiculo con esa patente.");
                    return;
                }
            }


            Console.Write("Ingrese Kilometraje: ");
            int Kilometraje = int.Parse(Console.ReadLine());


            Console.WriteLine("Seleccione el Tipo de Vehículo:");
            Console.WriteLine("1. Camión");
            Console.WriteLine("2. Furgoneta");
            Console.WriteLine("3. Motocicleta");
            Console.Write("Opción: ");
            string tipo = Console.ReadLine();

            switch (tipo)
            {
                case "1":
                    Console.WriteLine("Ingresa la capacidad de carga: ");
                    int CapacidadCarga = int.Parse(Console.ReadLine());

                    Camion camion = new Camion(CapacidadCarga, Patente, Kilometraje);
                    Vehiculos.Add(camion);
                    Console.WriteLine("Camion agregado correctamente.");

                    break;

                case "2":
                    Console.WriteLine("Ingresa la cantidad de pasajeros: ");
                    int Pasajeros = int.Parse(Console.ReadLine());

                    Furgoneta furgoneta = new Furgoneta(Pasajeros, Patente, Kilometraje);
                    Vehiculos.Add(furgoneta);

                    Console.WriteLine("Furgoneta agregada correctamente.");


                    break;

                case "3":
                    Console.Write("Ingrese capacidad de pasajeros: ");
                    int PasajerosMoto = int.Parse(Console.ReadLine());

                    if (PasajerosMoto != 1)
                    {
                        Console.WriteLine("La motocicleta debe llevar exactamente 1 pasajero.");
                        return;
                    }

                    Motocicleta motocicleta = new Motocicleta(PasajerosMoto, Patente, Kilometraje);
                    Vehiculos.Add(motocicleta);

                    Console.WriteLine("Motocicleta agregada correctamente.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    return;

                    //tuve que ponerlos en orden int string int porque sino no me dejaba crear el objeto, no se porque, si lo hago al reves me tira error de constructor, y si lo hago asi funciona.
            }
        }

        public static void MenuRegistrarViaje(List<Vehiculo> Vehiculos)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR VIAJE ---");
            Console.Write("Ingrese la Patente del vehículo: ");
            string Patente = Console.ReadLine();
            Vehiculo vehiculo = Vehiculos.FirstOrDefault(v => v.Patente == Patente);
            if (vehiculo == null)
            {
                Console.WriteLine("No se encontró un vehículo con esa patente.");
                return;
            }
            Console.Write("Ingrese el destino del viaje: ");
            string Destino = Console.ReadLine();
            Console.Write("Ingrese la distancia del viaje (km): ");
            int Distancia = int.Parse(Console.ReadLine());
            int CargaTransportada = 0;

            if (vehiculo is Camion)
            {
                Console.Write("Ingrese la carga transportada (kg): ");
                CargaTransportada = int.Parse(Console.ReadLine());
            }
            Console.Write("Ingrese la fecha del viaje (dd/mm/yyyy): ");
            DateTime Fecha = DateTime.Parse(Console.ReadLine());
            int PasajerosTrasportados = 0;

            if (vehiculo is Furgoneta)
            {
                Console.Write("Ingrese la cantidad de pasajeros: ");
                PasajerosTrasportados = int.Parse(Console.ReadLine());
            }

            if (vehiculo is Motocicleta)
            {
                Console.Write("Ingrese la cantidad de pasajeros: ");
                PasajerosTrasportados = int.Parse(Console.ReadLine());
                if (PasajerosTrasportados > 1)
                {
                    Console.WriteLine("La motocicleta solo puede llevar hasta 1 pasajero.");
                    return;
                }
            }
            Viaje viaje = new Viaje(Destino, Distancia, CargaTransportada, Fecha, PasajerosTrasportados);
            vehiculo.AgregarViaje(viaje);
            Console.WriteLine("Viaje registrado correctamente.");
        }
        public static void MenuMostrarVehiculos(List<Vehiculo> Vehiculos)
        {
            Console.Clear();
            Console.WriteLine("--- MOSTRAR VEHÍCULOS ---");
            Console.Write("Ingrese la Patente del vehículo: ");
            string Patente = Console.ReadLine();
            Vehiculo vehiculo = Vehiculos.FirstOrDefault(v => v.Patente == Patente);
            if (vehiculo == null)
            {
                Console.WriteLine("No se encontró un vehículo con esa patente.");
                return;
            }

            if (vehiculo is Camion camion)
            {
                Console.WriteLine("Tipo: Camion");
                Console.WriteLine("Capacidad de carga: " + camion.CapacidadCarga);

                int cargaTotal = 0;

                foreach (Viaje viaje in camion.viajes)
                {
                    cargaTotal += viaje.CargaTransportada;
                }

                Console.WriteLine("Carga total transportada: " + cargaTotal);
            }
            Console.WriteLine($"Patente: {vehiculo.Patente}");
            Console.WriteLine($"Kilometraje: {vehiculo.Kilometraje} km");
            Console.WriteLine($"Cantidad de viajes registrados: {vehiculo.viajes.Count}");
            Console.WriteLine("Distancia total recorrida: " + vehiculo.CalcularDistanciaTotal());
        }
        public static void MenuMostrarTodosRegistrados(List<Vehiculo> Vehiculos)
        {
            Console.Clear();
            Console.WriteLine("--- TODOS LOS VEHICULOS ---");

            if (Vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehiculos registrados.");
                return;
            }

            int distanciaTotalFlota = 0;
            int cargaTotalFlota = 0;

            foreach (Vehiculo vehiculo in Vehiculos)
            {
                Console.WriteLine("--------------------------");

                if (vehiculo is Camion camion)
                {
                    Console.WriteLine("Tipo: Camion");
                    Console.WriteLine("Patente: " + camion.Patente);
                    Console.WriteLine("Kilometraje: " + camion.Kilometraje);
                    Console.WriteLine("Cantidad de viajes: " + camion.viajes.Count);
                    Console.WriteLine("Distancia total recorrida: " + camion.CalcularDistanciaTotal());

                    int cargaTotalCamion = 0;

                    foreach (Viaje viaje in camion.viajes)
                    {
                        cargaTotalCamion += viaje.CargaTransportada;
                    }

                    Console.WriteLine("Carga total transportada: " + cargaTotalCamion);

                    cargaTotalFlota += cargaTotalCamion;
                    distanciaTotalFlota += camion.CalcularDistanciaTotal();
                }
                else if (vehiculo is Furgoneta furgoneta)
                {
                    Console.WriteLine("Tipo: Furgoneta");
                    Console.WriteLine("Patente: " + furgoneta.Patente);
                    Console.WriteLine("Kilometraje: " + furgoneta.Kilometraje);
                    Console.WriteLine("Cantidad de viajes: " + furgoneta.viajes.Count);
                    Console.WriteLine("Distancia total recorrida: " + furgoneta.CalcularDistanciaTotal());

                    distanciaTotalFlota += furgoneta.CalcularDistanciaTotal();
                }
                else if (vehiculo is Motocicleta motocicleta)
                {
                    Console.WriteLine("Tipo: Motocicleta");
                    Console.WriteLine("Patente: " + motocicleta.Patente);
                    Console.WriteLine("Kilometraje: " + motocicleta.Kilometraje);
                    Console.WriteLine("Cantidad de viajes: " + motocicleta.viajes.Count);
                    Console.WriteLine("Distancia total recorrida: " + motocicleta.CalcularDistanciaTotal());

                    distanciaTotalFlota += motocicleta.CalcularDistanciaTotal();
                }
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("--- ESTADISTICAS GENERALES ---");
            Console.WriteLine("Cantidad de vehiculos: " + Vehiculos.Count);
            Console.WriteLine("Distancia total recorrida por la flota: " + distanciaTotalFlota);
            Console.WriteLine("Carga total transportada por la flota: " + cargaTotalFlota);
        }

    }
}
