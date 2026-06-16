using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Vehiculo
    {
       public string Patente { get; set; }
       public int Kilometraje { get; set; }
       public List<Viaje> viajes {  get; set; }
        
        public void AgregarViaje(Viaje viaje)
        {
            viajes.Add(viaje);
            Kilometraje += viaje.Distancia;
        }

        public int CalcularDistanciaTotal()
        {
            int total = 0;

            foreach (Viaje viaje in viajes)
            {
                total += viaje.Distancia;
            }

            return total;
        }

    }
}

