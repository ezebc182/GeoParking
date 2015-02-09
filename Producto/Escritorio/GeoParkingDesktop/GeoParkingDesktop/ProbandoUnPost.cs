using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoParkingDesktop
{
    public partial class ProbandoUnPost : Form
    {
        public ProbandoUnPost()
        {
            InitializeComponent();
        }

        private void btnHacerPost_Click(object sender, EventArgs e)
        {
            TipoPrecio precio1 = new TipoPrecio();
            precio1.IdTiempo = 1;
            precio1.Monto = 22;
            TipoPrecio precio2 = new TipoPrecio();
            precio2.IdTiempo = 2;
            precio2.Monto = 60;
            TipoPrecio[] precios = new TipoPrecio[2];
            precios[0] = precio1;
            precios[1] = precio2;

            ServicioAAgregar servicio = new ServicioAAgregar();
            servicio.Capacidad = 20;
            servicio.IdPlaya = 1057;
            servicio.IdTipoVehiculo = 4;
            servicio.Precios = precios;
            OtroPost(servicio);
        }

        public string OtroPost(ServicioAAgregar servicio)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:21305/api/Servicios/PostServicioARegistrar");

            var postData = "IdPlaya=" + servicio.IdPlaya;
            postData += ("&IdTipoVehiculo=" + servicio.IdTipoVehiculo);
            postData += ("&Capacidad=" + servicio.Capacidad);
            for (int i = 0; i < servicio.Precios.Length; i++)
            {
                postData += "&Precios%5B" + i + "%5D%5BIdTiempo%5D=" + servicio.Precios[i].IdTiempo;
                postData += "&Precios%5B" + i + "%5D%5BMonto%5D=" + servicio.Precios[i].Monto;
            }

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
    public class TipoPrecio
    {
        public int IdTiempo { get; set; }
        public double Monto { get; set; }
    }

    public class ServicioAAgregar
    {
        public int IdPlaya { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int Capacidad { get; set; }
        public TipoPrecio[] Precios { get; set; }
    }
}
