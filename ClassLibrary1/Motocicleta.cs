using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Motocicleta : Vehiculo
    {
        public int PasajerosMoto { get; set; }


        public Motocicleta(int pasajerosMoto, string Patente, int Kilometraje)
        {
            this.PasajerosMoto = pasajerosMoto;
            this.Patente = Patente;
            this.Kilometraje = Kilometraje;
            this.viajes = new List<Viaje>();
        }
    }
}
