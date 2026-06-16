using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Furgoneta : Vehiculo
    {
       public int Pasajeros {  get; set; }

        public Furgoneta(int pasajeros, string Patente, int Kilometraje)
        {
            this.Pasajeros = pasajeros;
            this.Patente = Patente;
            this.Kilometraje = Kilometraje;
            this.viajes = new List<Viaje>();
        }
    }
}
