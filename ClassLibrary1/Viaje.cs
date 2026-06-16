using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Viaje
    {
        public string Destino { get; set; }
        public int Distancia { get; set; }
        public int CargaTransportada { get; set; }
        public int PasajerosTrasportados { get; set; }

        public DateTime Fecha { get; set; }

        public Viaje(string destino, int distancia, int cargaTransportada, DateTime fecha, int pasajerosTrasportados)
        {
            this.Destino = destino;
            this.Distancia = distancia;
            this.CargaTransportada = cargaTransportada;
            this.Fecha = fecha;
            this.PasajerosTrasportados = pasajerosTrasportados;
        }
    }
}

