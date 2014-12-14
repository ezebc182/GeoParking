using System;
using System.Collections.Generic;
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
    public partial class Form1 : Form
    {
        PlayaDeEstacionamiento playa = new PlayaDeEstacionamiento();//playa de estacionamiento del sistema  

        int tipoVehiculo;//tipo de vehiculo a actualizar la disponibilidad

        public Form1()
        {
            //consulta a la API para recuperar los datos de la Playa de Estacionamiento

            //SIMULACION DE PLAYA
            playa.id = 1;

            //creo las disponibiliadaes de acuerdo a los tipos vehiculos y capacidades
            Disponibilidades dAuto = new Disponibilidades();
            dAuto.tipoVehiculo = 1;
            dAuto.disponibilidad = 2;

            Disponibilidades dMoto = new Disponibilidades();
            dMoto.tipoVehiculo = 2;
            dMoto.disponibilidad = 2;

            Disponibilidades dUti = new Disponibilidades();
            dUti.tipoVehiculo = 3;
            dUti.disponibilidad = 2;

            Disponibilidades dBici = new Disponibilidades();
            dBici.tipoVehiculo = 4;
            dBici.disponibilidad = 2;
           

            playa.disponibilidades.Add(dAuto);
            playa.disponibilidades.Add(dMoto);
            playa.disponibilidades.Add(dUti);
            playa.disponibilidades.Add(dBici);
            


            //creo los precios
            Precio pAuto= new Precio();
            pAuto.tipoVehiculo = 1;
            pAuto.precio = 12.00;

            Precio pMoto = new Precio();
            pMoto.tipoVehiculo = 2;
            pMoto.precio = 6.00;

            Precio pUti = new Precio();
            pUti.tipoVehiculo = 1;
            pUti.precio = 12.00;

            Precio pBici = new Precio();
            pBici.tipoVehiculo = 2;
            pBici.precio = 6.00;

            playa.preciosXhora.Add(pAuto);
            playa.preciosXhora.Add(pMoto);
            playa.preciosXhora.Add(pUti);
            playa.preciosXhora.Add(pBici);


            //iniciacion de todos los componentes
             InitializeComponent();

             txtDispAuto.Text = "2";
             txtDispMoto.Text = "2";
             txtDispUti.Text = "2";
             txtDispBici.Text = "2";

            //string sURL;
            //sURL = "http://ifrigerio-001-site1.smarterasp.net";

            //WebRequest wrGETURL;
            //wrGETURL = WebRequest.Create(sURL);

            ////WebProxy myProxy = new WebProxy("myproxy", 80);
            ////myProxy.BypassProxyOnLocal = true;

            ////wrGETURL.Proxy = WebProxy.GetDefaultProxy();

            //Stream objStream;
            //objStream = wrGETURL.GetResponse().GetResponseStream();

            //StreamReader objReader = new StreamReader(objStream);

            //string sLine = "";
            //int i = 0;

            //string respuesta = "";

            //while (sLine != null)
            //{
            //    i++;
            //    sLine = objReader.ReadLine();
            //    if (sLine != null)
            //        Console.WriteLine("{0}:{1}", i, sLine);
            //    respuesta += sLine + "\n";
            //}
            //MessageBox.Show(respuesta) ;
            //Console.ReadLine();

        }

        /// <summary>
        /// Registra el igreso de un vehiculo a la playa de estacionamiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            string matricula = txtMatriculaIngreso.Text;//matricula            
            int tipoVehiculo = (int)cmbTipoVehiculo.SelectedIndex+1;//tipo vehiculo
            int evento = 1;//ingreso
            DateTime fechaHora = DateTime.Now;//fecha y hora            
            int dia = DateTime.Today.Day;//dia

            //si hay lugares disponibles para ese tipo de vehiculo - registro
            if (playa.disponibilidades[tipoVehiculo-1].disponibilidad > 0)
            {
                //ingreso del vehiculo y actualizacion de disponibilidad
                registrarIngreso(playa.id, tipoVehiculo-1, matricula, evento, fechaHora, dia);
            }
            else
            {
                MessageBox.Show("No hay lugares disponibles para este tipo de vehiculo");
            }
        }

        /// <summary>
        /// Registra el ingreso del vehiculo a la playa de estacionamiento
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="tipoVehiculo"></param>
        /// <param name="matricula"></param>
        /// <param name="evento"></param>
        /// <param name="fechaHora"></param>
        /// <param name="dia"></param>
        public void registrarIngreso(int idPlaya, int tipoVehiculo, string matricula, int evento, DateTime fechaHora, int dia)
        {
            //registro en el sistema
            registrarIngresoEnSistema(matricula, tipoVehiculo, fechaHora);          
            
            //registrar en el API
            actualizarDisponibilidad(idPlaya, tipoVehiculo, evento, fechaHora, dia);
        }

        /// <summary>
        /// Registra el vehiculo en el sistema en la lista de vehiculos estacionados
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="tipoVehiculo"></param>
        /// <param name="fechaHoraIngreso"></param>
        public void registrarIngresoEnSistema(string matricula, int tipoVehiculo, DateTime fechaHoraIngreso)
        {
            //creo el vehiculo a estacionar
            VehiculoEstacionado v = new VehiculoEstacionado();
            v.matricula = matricula;
            v.tipoVehiculo = tipoVehiculo;
            v.horaIngreso = fechaHoraIngreso;

            //registro en la lista de vehiculos de la playa
            playa.vehiculos.Add(v);

            //limpio el formulario y emito mensaje de exito
            limpiarIngreso();
            MessageBox.Show("VEHICULO REGISTRADO EXITOSAMENTE");
        }

        /// <summary>
        /// Actualiza la disponibilidad de la playa
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="tipoVehiculo"></param>
        /// <param name="evento"></param>
        /// <param name="fechaHora"></param>
        /// <param name="dia"></param>
        public void actualizarDisponibilidad(int idPlaya, int tipoVehiculo, int evento, DateTime fechaHora, int dia)
        {
            //aca actualizo la disponibilidad en el sistema (ingreso=se resta un lugar disponible)
            if (evento == 1)
            {
                playa.disponibilidades[tipoVehiculo].disponibilidad = playa.disponibilidades[tipoVehiculo].disponibilidad - 1;
            }
            else
            {
                playa.disponibilidades[tipoVehiculo].disponibilidad = playa.disponibilidades[tipoVehiculo].disponibilidad + 1;
            }

            //actualizo los txt
            switch (tipoVehiculo)
            {
                case 0: txtDispAuto.Text = playa.disponibilidades[tipoVehiculo].disponibilidad.ToString();
                    break;
                case 1: txtDispMoto.Text = playa.disponibilidades[tipoVehiculo].disponibilidad.ToString(); 
                    break;
                case 2: txtDispUti.Text = playa.disponibilidades[tipoVehiculo].disponibilidad.ToString();
                    break;
                case 3: txtDispBici.Text = playa.disponibilidades[tipoVehiculo].disponibilidad.ToString();
                    break;
            }           

            //aca utilizo el acceso a la appi            
        }

        /// <summary>
        /// busca los datos del vehiculo por la matricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            //busco y obtengo los datos del vehiculo
            for (int i = 0; i < playa.vehiculos.Count; i++)
            {
                if (playa.vehiculos[i].matricula == txtMatriculaEgreso.Text)
                {
                    tipoVehiculo = playa.vehiculos[i].tipoVehiculo;

                    //muestro lso datos
                    switch(playa.vehiculos[i].tipoVehiculo)
                    {
                        case 0: txtTipoVehiculo.Text = "Automovil";
                            break;
                        case 1: txtTipoVehiculo.Text = "Motocicleta";
                            break;
                        case 2: txtTipoVehiculo.Text = "Utilitario";
                            break;
                        case 3: txtTipoVehiculo.Text = "Bicicleta";
                            break;
                    }                    

                    int tiempo = (int) (DateTime.Now - playa.vehiculos[i].horaIngreso).TotalHours;
                    txtTiempo.Text = tiempo.ToString();

                    double precioTipoVehiculoPorHora = playa.preciosXhora[playa.vehiculos[i].tipoVehiculo].precio;
                    txtImporte.Text = (precioTipoVehiculoPorHora * tiempo).ToString();

                    return;
                }
            }

            MessageBox.Show("No existe ningun vehiculo con esa matricula");
        }

        /// <summary>
        /// registra egreso del vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarEgreso_Click(object sender, EventArgs e)
        {
            registrarEgreso(playa.id, tipoVehiculo, txtMatriculaEgreso.Text, 2, DateTime.Now, DateTime.Now.Day);                 
        }

        /// <summary>
        /// registro egreso del vehiculo
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="tipoVehiculo"></param>
        /// <param name="matricula"></param>
        /// <param name="evento"></param>
        /// <param name="fechaHora"></param>
        /// <param name="dia"></param>
        public void registrarEgreso(int idPlaya, int tipoVehiculo, string matricula, int evento, DateTime fechaHora, int dia)
        {
            //registro el egreso en el sistema
            registrarEgresoEnSistema(txtMatriculaEgreso.Text);

            //actualizo la disponibilidad
            actualizarDisponibilidad(idPlaya, tipoVehiculo, evento, fechaHora, dia);
        }

        /// <summary>
        /// registrar egreso de vehiculo en el sistema y actulizar disponibilidad en sistema
        /// </summary>
        /// <param name="matricula"></param>
        public void registrarEgresoEnSistema(string matricula)
        {
             //busco y obtengo los datos del vehiculo
            for (int i = 0; i < playa.vehiculos.Count; i++)
            {
                if (playa.vehiculos[i].matricula == matricula)
                {
                    int tipoVehiculo = playa.vehiculos[i].tipoVehiculo;
                    playa.vehiculos.Remove(playa.vehiculos[i]);


                    //limpio el formulario y emito mensaje de exito
                    limpiarEgreso();
                    MessageBox.Show("SE REGISTRO EL EGRESO EXISTOSAMENTE");
                    paneles.SelectedTab=tabPage1;
                    
                    return;                    
                }
            }
            MessageBox.Show("Error al registrar el egreso del vehiculo");
        }



        /// <summary>
        /// limpiar formulario ingreso
        /// </summary>
        public void limpiarIngreso()
        {
            txtMatriculaIngreso.Text = "";
            cmbTipoVehiculo.SelectedIndex = 0;
        }

        /// <summary>
        /// limpiar formulario egreso
        /// </summary>
        public void limpiarEgreso()
        {
            txtMatriculaEgreso.Text = "";
            txtTipoVehiculo.Text = "";
            txtTiempo.Text = "";
            txtImporte.Text = "";
        }



       
    }
}
