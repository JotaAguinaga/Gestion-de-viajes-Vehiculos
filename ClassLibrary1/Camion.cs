using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Camion : Vehiculo
    {
         public int CapacidadCarga { get; set; } = 1000;

        //Clase Constructor de camion
        public Camion(int CapacidadCarga, string Patente, int Kilometraje)
        {
            this.CapacidadCarga = CapacidadCarga;
            this.Patente = Patente;
            this.Kilometraje = Kilometraje;
            this.viajes = new List<Viaje>();
        }


       public int CalcularCargaMaxima()
        {
            return CapacidadCarga;
        }
    }
}
