using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_B2B
{
    class Orden
    {
        public ComienzoDeAdenda comienzoDeAdenda { get; set; }
        public float total { get; set; }
        public Pdf pdf { get; set; }
        public string ordenDeCompra { get; set; }
        public Tiempos tiempos { get; set; }
        public Xml xml { get; set; }
        public Comprobante comprobante { get; set; }
        public Uploaded uploaded { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public Email email { get; set; }
        public Adenda adenda { get; set; }
        public List<string> collections { get; set; }
        public List<Partida> partidas { get; set; }
}


    public class Adenda
    {
        public int _seconds { get; set; }
        public int _nanoseconds { get; set; }
    }

    public class ComienzoDeAdenda
    {
        public int _seconds { get; set; }
        public int _nanoseconds { get; set; }
    }

    public class Comprobante
    {
        public TimeStamp timeStamp { get; set; }
        public string url { get; set; }
    }

    public class Email
    {
        public TimeStamp timeStamp { get; set; }
        public string recipientEmail { get; set; }
    }

    public class Factura
    {
        public string @string { get; set; }
        public string type { get; set; }
    }

    public class Partida
    {
        public string OrdenDeCompra { get; set; }
        public string ReceiverTicket { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public Uploaded uploaded { get; set; }
        public Factura Factura { get; set; }
        public string id { get; set; }
        public float Precio { get; set; }
    }

    public class Pdf
    {
        public string fileName { get; set; }
        public string url { get; set; }
    }

    public class TiempoDePartidas
    {
        public double tiempoDeProceso { get; set; }
        public int partidas { get; set; }
        public double tiempoDeRespuesta { get; set; }
    }

    public class Tiempos
    {
        public double tiempoDeProceso { get; set; }
        public TiempoDePartidas tiempoDePartidas { get; set; }
        public double tiempoDeRespuesta { get; set; }
    }

    public class TimeStamp
    {
        public int _seconds { get; set; }
        public int _nanoseconds { get; set; }
    }

    public class Uploaded
    {
        public int _seconds { get; set; }
        public int _nanoseconds { get; set; }
    }

    public class Xml
    {
        public string fileName { get; set; }
        public string url { get; set; }
    }


}
