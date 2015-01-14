﻿using System;
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
             InitializeComponent();
        }

        /// <summary>
        /// configura el sistema de acuerdo a una playa de estacionamiento que se 
        /// busca por su ID
        /// </summary>
        /// <param name="id"></param>
        public void configurarSistema(int id)
        {
            //configuracion de progres bar
            progressBar1.Visible = true;
            lblConectar.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar1.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            progressBar1.Maximum = 10;
            // Set the initial value of the ProgressBar.
            progressBar1.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar1.Step = 1;
            progressBar1.PerformStep();
            progressBar1.PerformStep();
            
            //consulta a la API para recuperar los datos de la Playa de Estacionamiento
            string sURL;
            sURL = "http://localhost:21305/api/Playas/Get/" + id;           

            try
            {
                WebRequest wrGETURL;
                progressBar1.PerformStep();
                wrGETURL = WebRequest.Create(sURL);
                progressBar1.PerformStep();

                //WebProxy myProxy = new WebProxy("myproxy", 80);
                //myProxy.BypassProxyOnLocal = true;

                //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                progressBar1.PerformStep();

                StreamReader objReader = new StreamReader(objStream);
                progressBar1.PerformStep();

                string sLine = objReader.ReadLine();
                progressBar1.PerformStep();

                //obtengo el objeto playa
                var deserializado = Newtonsoft.Json.JsonConvert.DeserializeObject(sLine).ToString();
                var objetoPlaya = Newtonsoft.Json.Linq.JObject.Parse(deserializado);
                progressBar1.PerformStep();

                //cargos datos generales
                playa.id = (int)objetoPlaya["Id"];
                playa.nombre = (string)objetoPlaya["Nombre"];
                playa.email = (string)objetoPlaya["Mail"];
                playa.tipoPlaya = int.Parse(objetoPlaya["IdTipoPlaya"].ToString());
                playa.dias = 3;//falta cambiar las calases
                playa.horaDesde = "00:00";
                playa.horaHata = "24:00";

                progressBar1.PerformStep();

                //cargos los servicios
                var servicios = objetoPlaya["Servicios"];

                foreach (var item in servicios)
                {
                    Disponibilidades vehiculo = new Disponibilidades();
                    vehiculo.tipoVehiculo = int.Parse(item["IdTipoVehiculo"].ToString());

                    //recupero la disponibilidad de cada tipo de vehiculo
                    vehiculo.disponibilidad = recuperarDisponibilidad(playa.id,vehiculo.tipoVehiculo);
                    
                    playa.disponibilidades.Add(vehiculo);

                    //cargo los precios
                    var precios = item["Precios"];

                    foreach (var item2 in precios)
                    {
                        Precio precio = new Precio();
                        precio.tipoVehiculo = vehiculo.tipoVehiculo;
                        precio.tiempo = int.Parse(item2["IdTiempo"].ToString());
                        precio.precio = double.Parse(item2["Monto"].ToString());
                        playa.precios.Add(precio);
                    }
                    progressBar1.PerformStep();

                }

                progressBar1.PerformStep();
              

                //muestro los datos de la playa
                cargarDatosPlaya();
                progressBar1.PerformStep();

                //mustro las disponibilidades
                cargarDisponibilidades();
                progressBar1.PerformStep();

                MessageBox.Show("Sistema configurado correctamente");
                
                paneles.Visible = true;
                progressBar1.Visible = false;
                lblConectar.Visible = false;
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Error al iniciar sistmea");
                progressBar1.Visible = false;
                lblConectar.Visible = false;
               
            }       
        }

        /// <summary>
        /// recupera la disponibilidad de un tipo de vehiculo de una playa
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        private int recuperarDisponibilidad(int idPlaya, int idTipoVehiculo)
        {
            string sURL;
            sURL = "http://localhost:21305/api/Disponibilidad/GetDisponibilidadPlayaPorTipoVehiculo?idPlaya=" + idPlaya + "&idTipoVehiculo=" + idTipoVehiculo;

            try
            {
                WebRequest wrGETURL;
                progressBar1.PerformStep();
                wrGETURL = WebRequest.Create(sURL);

                //WebProxy myProxy = new WebProxy("myproxy", 80);
                //myProxy.BypassProxyOnLocal = true;

                //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                int sLine = int.Parse(objReader.ReadLine());


                return sLine;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al recuperar disponibilidad en API");
                return 0;
            }
        }               
        
        /// <summary>
        /// carga los datos de la playa de estacionamiento para
        /// el funcionamiento del sistema
        /// </summary>
        public void cargarDatosPlaya()
        {
            txtNombrePlaya.Text = playa.nombre;
            txtEmailPlaya.Text = playa.email;
            cmbTipoPlaya.SelectedIndex = playa.tipoPlaya -1;
            cmbDiasHorario.SelectedIndex = playa.dias - 1;
            txtHoraDesde.Text = playa.horaDesde;
            txtHoraHasta.Text = playa.horaHata;

            cargarDisponibilidades();//carga las disponibilidades

            foreach (var item in playa.precios)
            {
                switch (item.tipoVehiculo)//de acuerdo al tipo de vehiculo cargo los precios
                {
                    case 1: cargaPreciosAutos(item);//auto
                        chekAuto.Checked = true;
                        break;
                    case 2: cargaPreciosUtilitarios(item);//utilitario
                        chekUti.Checked = true;
                        break;
                    case 3: cargaPreciosMotos(item);//moto
                        chekMoto.Checked = true;
                        break; 
                    case 4: cargaPreciosBicicletas(item);//bicicleta
                        chekBici.Checked = true;
                        break;
                }

            }

            inhabilitarFormularioAdminsitracion();

        }

        /// <summary>
        /// carga las disponibilidades al inicio de la aplicacion
        /// </summary>
        public void cargarDisponibilidades()
        {
            foreach (var item in playa.disponibilidades)
            {
                switch (item.tipoVehiculo)
                {
                    case 1: txtDispAuto.Text = item.disponibilidad.ToString();
                        break;
                    case 2: txtDispUti.Text = item.disponibilidad.ToString();
                        break;
                    case 3: txtDispMoto.Text = item.disponibilidad.ToString();
                        break; 
                    case 4: txtDispBici.Text = item.disponibilidad.ToString();
                        break;
                }

            }

        }

        /// <summary>
        /// carga los precios para los autos
        /// </summary>
        /// <param name="item"></param>
        public void cargaPreciosAutos(Precio item)
        {
            switch (item.tiempo)
	       {
               case 1: txt1hAuto.Text = item.precio.ToString();
                       break;
               case 2: txt6hAuto.Text = item.precio.ToString();
                       break;
               case 3: txt12hAuto.Text = item.precio.ToString();
                       break;
               case 4: txt24hAuto.Text = item.precio.ToString();
                       break;
               case 5: txtAbonoAuto.Text = item.precio.ToString();
                       break;
	        }
        }

        /// <summary>
        /// carga los percios para las motos
        /// </summary>
        /// <param name="item"></param>
        public void cargaPreciosMotos(Precio item)
        {
            switch (item.tiempo)
            {
                case 1: txt1hMoto.Text = item.precio.ToString();
                    break;
                case 2: txt6hMoto.Text = item.precio.ToString();
                    break;
                case 3: txt12hMoto.Text = item.precio.ToString();
                    break;
                case 4: txt24hMoto.Text = item.precio.ToString();
                    break;
                case 5: txtAbonoMoto.Text = item.precio.ToString();
                    break;
            }
        }

        /// <summary>
        /// carga los precios para los utilitarios
        /// </summary>
        /// <param name="item"></param>
        public void cargaPreciosUtilitarios(Precio item)
        {
            switch (item.tiempo)
            {
                case 1: txt1hUti.Text = item.precio.ToString();
                    break;
                case 2: txt6hUti.Text = item.precio.ToString();
                    break;
                case 3: txt12hUti.Text = item.precio.ToString();
                    break;
                case 4: txt24hUti.Text = item.precio.ToString();
                    break;
                case 5: txtAbonoUti.Text = item.precio.ToString();
                    break;
            }
        }

        /// <summary>
        /// carga los precios para las bicicletas
        /// </summary>
        /// <param name="item"></param>
        public void cargaPreciosBicicletas(Precio item)
        {
            switch (item.tiempo)
            {
                case 1: txt1hBici.Text = item.precio.ToString();
                    break;
                case 2: txt6hBici.Text = item.precio.ToString();
                    break;
                case 3: txt12hBici.Text = item.precio.ToString();
                    break;
                case 4: txt24hBici.Text = item.precio.ToString();
                    break;
                case 5: txtAbonoBici.Text = item.precio.ToString();
                    break;
            }
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
            
            bool resultado = false;

            foreach (var item in playa.disponibilidades)
            {
                if (item.tipoVehiculo == tipoVehiculo) 
                {
                    resultado = true;

                    if(item.disponibilidad>0)
                    {
                        registrarIngreso(playa.id, tipoVehiculo, matricula, evento, fechaHora);                    
                    }
                    else
                    {
                        MessageBox.Show("No hay lugares disponibles para este tipo de vehiculo");
                    }
                }
            }

            if (resultado == false)
            {
                MessageBox.Show("Esta playa de estacionamiento no alberga este tipo de vehiculo");
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
        public void registrarIngreso(int idPlaya, int tipoVehiculo, string matricula, int evento, DateTime fechaHora)
        {
            //registro en el sistema
            registrarIngresoEnSistema(matricula, tipoVehiculo, fechaHora);          
            
            //registrar en el API
            actualizarDisponibilidad(idPlaya, tipoVehiculo, evento, fechaHora);
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
        public void actualizarDisponibilidad(int idPlaya, int tipoVehiculo, int evento, DateTime fechaHora)
        {
            //aca actualizo la disponibilidad en el sistema (ingreso=se resta un lugar disponible)
            foreach (var item in playa.disponibilidades)
            {
                if (item.tipoVehiculo == tipoVehiculo)
                {
                    if (evento == 1)
                    {
                        item.disponibilidad = item.disponibilidad - 1;
                    }
                    else
                    {
                        item.disponibilidad = item.disponibilidad + 1;
                    }

                    //actualizo los txt
                    switch (tipoVehiculo)
                    {
                        case 1: txtDispAuto.Text = item.disponibilidad.ToString();
                            break;
                        case 2: txtDispUti.Text = item.disponibilidad.ToString();
                            break;
                        case 3: txtDispMoto.Text = item.disponibilidad.ToString();
                            break;
                        case 4: txtDispBici.Text = item.disponibilidad.ToString();
                            break;
                    }  
                    
                }
            }

            //aca utilizo el acceso a la appi
            
            string sURL;
            sURL = "http://localhost:21305/api/Disponibilidad/GetActualizarDisponibilidad?idPlaya="+playa.id+"&idTipoVehiculo="+tipoVehiculo+"&idEvento="+evento+"&fecha="+fechaHora.ToString();

            try
            {
                WebRequest wrGETURL;
                progressBar1.PerformStep();
                wrGETURL = WebRequest.Create(sURL);

                //WebProxy myProxy = new WebProxy("myproxy", 80);
                //myProxy.BypassProxyOnLocal = true;

                //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = objReader.ReadLine();
                

                if (sLine == "\"True\"")
                    MessageBox.Show("Actualizacion Existosa");
                else
                    MessageBox.Show("no se pudo realizar la actualizacion");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar disponibilidad en API");
            }
               
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
                        case 1: txtTipoVehiculo.Text = "Automovil";
                            break;
                        case 2: txtTipoVehiculo.Text = "Utilitario";
                            break;
                        case 3: txtTipoVehiculo.Text = "Motocicleta";
                            break;
                        case 4: txtTipoVehiculo.Text = "Bicicleta";
                            break;
                    }                    

                    int tiempo = (int) (DateTime.Now - playa.vehiculos[i].horaIngreso).TotalHours;
                    txtTiempo.Text = tiempo.ToString();

                    //falta logica para buscar cual es el precio que corresponde poner 1h , 6h, 12 ..etc
                    txtImporte.Text = calcularImporte(tipoVehiculo, tiempo).ToString(); 

                    return;
                }
            }

            MessageBox.Show("No existe ningun vehiculo con esa matricula");
        }
        
        /// <summary>
        /// calcular el importe de acuerdo al tipo de vehiculo y al tiempo de permanencia
        /// </summary>
        /// <param name="tipoVehiculo"></param>
        /// <param name="tiempo"></param>
        /// <returns></returns>
        public double calcularImporte(int tipoVehiculo, int tiempo)
        {
            double importe = 0;

            if (tiempo < 6)//calculo por hora
            {                
                foreach (var item in playa.precios)
                {
                    if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 1)
                    {
                        importe = tiempo * item.precio;
                        return importe;
                    }
                    
                }
            }
            else if (tiempo > 6 && tiempo < 12)//calculo por las 6 horas y por hora de diferencia
            {
                //calculo primero la direferncia de horas, pasadas las 6
                int tiempoExedente = tiempo - 6;

                //recupero el precio de las 6 horas
                foreach (var item in playa.precios)
                {
                    if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 2)
                    {
                        importe = 6 * item.precio;                        
                    }
                }

                //sumo el precio de las horas excedentes
                if (tiempoExedente > 0)
                {
                    foreach (var item in playa.precios)
                    {
                        if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 1)
                        {
                            importe += tiempoExedente * item.precio;
                        }
                    }
                }

                return importe;

            }
            else if (tiempo > 12 && tiempo < 24)//calculo por 12 horas y por hora de diferencia
            {
                //calculo primero la direferncia de horas, pasadas las 6
                int tiempoExedente = tiempo - 12;

                //recupero el precio de las 6 horas
                foreach (var item in playa.precios)
                {
                    if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 3)
                    {
                        importe = 6 * item.precio;
                    }
                }

                //sumo el precio de las horas excedentes
                if (tiempoExedente > 0)
                {
                    foreach (var item in playa.precios)
                    {
                        if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 1)
                        {
                            importe += tiempoExedente * item.precio;
                        }
                    }
                }

                return importe;
            }
            else //calculo por 24 hs y por hora de diferencia
            {
                //calculo primero la direferncia de horas, pasadas las 6
                int tiempoExedente = tiempo - 24;

                //recupero el precio de las 6 horas
                foreach (var item in playa.precios)
                {
                    if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 4)
                    {
                        importe = 6 * item.precio;
                    }
                }

                //sumo el precio de las horas excedentes
                if (tiempoExedente > 0)
                {
                    foreach (var item in playa.precios)
                    {
                        if (item.tipoVehiculo == tipoVehiculo && item.tiempo == 1)
                        {
                            importe += tiempoExedente * item.precio;
                        }
                    }
                }
                return importe;
            }

            return importe;
            
        }

        /// <summary>
        /// registra egreso del vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarEgreso_Click(object sender, EventArgs e)
        {
            registrarEgreso(playa.id, tipoVehiculo, txtMatriculaEgreso.Text, 2, DateTime.Now);                 
        }
        
        /// <summary>
        /// registro egreso del vehiculo
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="tipoVehiculo"></param>
        /// <param name="matricula"></param>
        /// <param name="evento"></param>
        /// <param name="fechaHora"></param>
        public void registrarEgreso(int idPlaya, int tipoVehiculo, string matricula, int evento, DateTime fechaHora)
        {
            //registro el egreso en el sistema
            registrarEgresoEnSistema(txtMatriculaEgreso.Text);

            //actualizo la disponibilidad
            actualizarDisponibilidad(idPlaya, tipoVehiculo, evento, fechaHora);

            //limpio el formulario y emito mensaje de exito
            limpiarEgreso();
            MessageBox.Show("SE REGISTRO EL EGRESO EXISTOSAMENTE");
            paneles.SelectedTab = tabPage1;
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

        /// <summary>
        /// habilita los controles y la opcion de guardar la nueva configuracion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarFormularioAdministracion();
            btnCancelarCambios.Enabled = true;
            btnGuardarCambios.Enabled = true;
        }

        /// <summary>
        /// habilita los controles del formulario
        /// </summary>
        public void habilitarFormularioAdministracion()
        {
            txtNombrePlaya.Enabled = true;
            txtEmailPlaya.Enabled = true;
            cmbTipoPlaya.Enabled = true;

            cmbDiasHorario.Enabled = true;
            txtHoraDesde.Enabled = true;
            txtHoraHasta.Enabled = false;

            if (chekAuto.Checked == true)
            {
                chekAuto.Enabled = true;
                txt1hAuto.Enabled = true;
                txt12hAuto.Enabled = true;
                txt6hAuto.Enabled = true;
                txt24hAuto.Enabled = true;
                txtAbonoAuto.Enabled = true;
            }

            if (chekMoto.Checked == true)
            {
                chekMoto.Enabled = true;
                txt1hMoto.Enabled = true;
                txt12hMoto.Enabled = true;
                txt6hMoto.Enabled = true;
                txt24hMoto.Enabled = true;
                txtAbonoMoto.Enabled = true;
            }

            if (chekUti.Checked == true)
            {
                chekUti.Enabled = true;
                txt1hUti.Enabled = true;
                txt12hUti.Enabled = true;
                txt6hUti.Enabled = true;
                txt24hUti.Enabled = true;
                txtAbonoUti.Enabled = true;
            }

            if (chekBici.Checked == true)
            {
                chekBici.Enabled = true;
                txt1hBici.Enabled = true;
                txt12hBici.Enabled = true;
                txt6hBici.Enabled = true;
                txt24hBici.Enabled = true;
                txtAbonoBici.Enabled = true;
            }
        }

        /// <summary>
        /// desabilita los controles del formulario
        /// </summary>
        public void inhabilitarFormularioAdminsitracion()
        {
            txtNombrePlaya.Enabled = false;
            txtEmailPlaya.Enabled = false;
            cmbTipoPlaya.Enabled = false;

            cmbDiasHorario.Enabled = false;
            txtHoraDesde.Enabled = false;
            txtHoraHasta.Enabled = false;

            chekAuto.Enabled = false;
            txt1hAuto.Enabled = false;
            txt12hAuto.Enabled = false;
            txt6hAuto.Enabled = false;
            txt24hAuto.Enabled = false;
            txtAbonoAuto.Enabled = false;

            chekMoto.Enabled = false;
            txt1hMoto.Enabled = false;
            txt12hMoto.Enabled = false;
            txt6hMoto.Enabled = false;
            txt24hMoto.Enabled = false;
            txtAbonoMoto.Enabled = false;

            chekUti.Enabled = false;
            txt1hUti.Enabled = false;
            txt12hUti.Enabled = false;
            txt6hUti.Enabled = false;
            txt24hUti.Enabled = false;
            txtAbonoUti.Enabled = false;

            chekBici.Enabled = false;
            txt1hBici.Enabled = false;
            txt12hBici.Enabled = false;
            txt6hBici.Enabled = false;
            txt24hBici.Enabled = false;
            txtAbonoBici.Enabled = false;
        }

        /// <summary>
        /// deja en blanco todos los controles de adminsitracion
        /// </summary>
        public void limpiarFormularioAdministracion()
        {
            txtNombrePlaya.Text = "";
            txtEmailPlaya.Text = "";
            cmbTipoPlaya.SelectedIndex = 0;

            cmbDiasHorario.SelectedIndex = 0;
            txtHoraDesde.Text = "";
            txtHoraHasta.Text = "";

            chekAuto.Checked = false;
            txt1hAuto.Text = "";
            txt12hAuto.Text = "";
            txt6hAuto.Text = "";
            txt24hAuto.Text = "";
            txtAbonoAuto.Text = "";

            chekMoto.Checked = false;
            txt1hMoto.Text = "";
            txt12hMoto.Text = "";
            txt6hMoto.Text = "";
            txt24hMoto.Text = "";
            txtAbonoMoto.Text = "";

            chekUti.Checked = false;
            txt1hUti.Text = "";
            txt12hUti.Text = "";
            txt6hUti.Text = "";
            txt24hUti.Text = "";
            txtAbonoUti.Text = "";

            chekBici.Checked = false;
            txt1hBici.Text = "";
            txt12hBici.Text = "";
            txt6hBici.Text = "";
            txt24hBici.Text = "";
            txtAbonoBici.Text = "";
        }

        /// <summary>
        /// guarda los cambios con al nueva configuracion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //actualizacion de nombre y email de playa
            if (playa.nombre != txtNombrePlaya.Text || playa.email != txtEmailPlaya.Text)
            {
                actualizarNombreEmailPLaya(txtNombrePlaya.Text, txtEmailPlaya.Text);
            }

            //actualizacion de tipo playa
            if (playa.tipoPlaya != cmbTipoPlaya.SelectedIndex+1)
            {
                actualizarTipoPLaya(cmbTipoPlaya.SelectedIndex + 1);
            }

            inhabilitarFormularioAdminsitracion();
            btnCancelarCambios.Enabled = false;
            btnGuardarCambios.Enabled = false;
        }

        public void actualizarNombreEmailPLaya(string nombrePlaya, string emaiPlaya)
        {
            playa.nombre = nombrePlaya;
            playa.email = emaiPlaya;

            string sURL;
            sURL = "http://localhost:21305/api/Playas/GetActualizarNombreEmailPlaya?idPlaya=" + playa.id + "&nombrePlaya=" + nombrePlaya + "&emailPlaya=" + emaiPlaya;

            try
            {
                WebRequest wrGETURL;
                progressBar1.PerformStep();
                wrGETURL = WebRequest.Create(sURL);

                //WebProxy myProxy = new WebProxy("myproxy", 80);
                //myProxy.BypassProxyOnLocal = true;

                //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = objReader.ReadLine();


                if (sLine == "\"True\"")
                {
                    MessageBox.Show("Nombre y email actualizados");                    
                }
                else
                {
                    MessageBox.Show("no se pudo realizar la actualizacion de nombre y email");                    
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar disponibilidad en API");                
            } 
        }

        public void actualizarTipoPLaya(int tipoPlaya)
        {
            playa.tipoPlaya = tipoPlaya;

            string sURL;
            sURL = "http://localhost:21305/api/Playas/GetActualizarTipoPlaya?idPlaya=" + playa.id + "&idTipoPlaya=" + tipoPlaya;

            try
            {
                WebRequest wrGETURL;
                progressBar1.PerformStep();
                wrGETURL = WebRequest.Create(sURL);

                //WebProxy myProxy = new WebProxy("myproxy", 80);
                //myProxy.BypassProxyOnLocal = true;

                //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = objReader.ReadLine();


                if (sLine == "\"True\"")
                {
                    MessageBox.Show("Tipo Playa actualizado");
                }
                else
                {
                    MessageBox.Show("no se pudo realizar la actualizacion de tipo playa");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar disponibilidad en API");
            }
        }

        /// <summary>
        /// cancelo lso cambios realizados y restaura los campos
        /// con la configuracion anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarCambios_Click(object sender, EventArgs e)
        {
            inhabilitarFormularioAdminsitracion();
            btnCancelarCambios.Enabled = false;
            btnGuardarCambios.Enabled = false;

            //restablecerConfiguracion();
            limpiarFormularioAdministracion();
            MessageBox.Show("RESTAURANDO A CONFIGURACION ANTERIOR");
            cargarDatosPlaya();            
        }

        /// <summary>
        /// cambio de activacion de precios para autos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chekAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chekAuto.Checked == true)//habilito la edicion
            {
                txt1hAuto.Enabled = true;
                txt12hAuto.Enabled = true;
                txt6hAuto.Enabled = true;
                txt24hAuto.Enabled = true;
                txtAbonoAuto.Enabled = true;
            }
            else // borro y deshabilito
            {
                txt1hAuto.Text = "";
                txt12hAuto.Text = "";
                txt6hAuto.Text = "";
                txt24hAuto.Text = "";
                txtAbonoAuto.Text = "";
                txt1hAuto.Enabled = false;
                txt12hAuto.Enabled = false;
                txt6hAuto.Enabled = false;
                txt24hAuto.Enabled = false;
                txtAbonoAuto.Enabled = false;
            }
        }
        /// <summary>
        /// cambio de activacion de precios para motos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chekMoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chekMoto.Checked == true)//habilito la edicion
            {
                txt1hMoto.Enabled = true;
                txt12hMoto.Enabled = true;
                txt6hMoto.Enabled = true;
                txt24hMoto.Enabled = true;
                txtAbonoMoto.Enabled = true;
            }
            else // borro y deshabilito
            {
                txt1hMoto.Text = "";
                txt12hMoto.Text = "";
                txt6hMoto.Text = "";
                txt24hMoto.Text = "";
                txtAbonoMoto.Text = "";
                txt1hMoto.Enabled = false;
                txt12hMoto.Enabled = false;
                txt6hMoto.Enabled = false;
                txt24hMoto.Enabled = false;
                txtAbonoMoto.Enabled = false;
            }

        }
        /// <summary>
        /// cambio de activacion de precios para utilitarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chekUti_CheckedChanged(object sender, EventArgs e)
        {
            if (chekUti.Checked == true)//habilito la edicion
            {
                txt1hUti.Enabled = true;
                txt12hUti.Enabled = true;
                txt6hUti.Enabled = true;
                txt24hUti.Enabled = true;
                txtAbonoUti.Enabled = true;
            }
            else // borro y deshabilito
            {
                txt1hUti.Text = "";
                txt12hUti.Text = "";
                txt6hUti.Text = "";
                txt24hUti.Text = "";
                txtAbonoUti.Text = "";
                txt1hUti.Enabled = false;
                txt12hUti.Enabled = false;
                txt6hUti.Enabled = false;
                txt24hUti.Enabled = false;
                txtAbonoUti.Enabled = false;
            }
        }
        /// <summary>
        /// cambio de activacion de precios para bicicletas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chekBici_CheckedChanged(object sender, EventArgs e)
        {
            if (chekBici.Checked == true)//habilito la edicion
            {
                txt1hBici.Enabled = true;
                txt12hBici.Enabled = true;
                txt6hBici.Enabled = true;
                txt24hBici.Enabled = true;
                txtAbonoBici.Enabled = true;
            }
            else // borro y deshabilito
            {
                txt1hBici.Text = "";
                txt12hBici.Text = "";
                txt6hBici.Text = "";
                txt24hBici.Text = "";
                txtAbonoBici.Text = "";
                txt1hBici.Enabled = false;
                txt12hBici.Enabled = false;
                txt6hBici.Enabled = false;
                txt24hBici.Enabled = false;
                txtAbonoBici.Enabled = false;
            }
        }

        /// <summary>
        /// abre una ventana para ingresar el noombre de la playa y conectarse al sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coonectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 testDialog = new Form2();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                configurarSistema(int.Parse(testDialog.txtIdPlaya.Text));
            }
            else
            {
                //MessageBox.Show("Error");
            }
            testDialog.Dispose();
        }

        /// <summary>
        /// habilita editar o actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (btnDisponibilidades.Text == "EDITAR")
            {
                //habilito la edicion de disponibilidades
                txtDispAuto.Enabled = true;
                txtDispUti.Enabled = true;
                txtDispMoto.Enabled = true;
                txtDispBici.Enabled = true;
                btnDisponibilidades.Text = "ACTUALIZAR";
                btnDisponibilidadesCancelar.Visible = true;
            }
            else
            {
                //actualizo las disponibilidades
                txtDispAuto.Enabled = false;
                txtDispUti.Enabled = false;
                txtDispMoto.Enabled = false;
                txtDispBici.Enabled = false;
                btnDisponibilidades.Text = "EDITAR";
                btnDisponibilidadesCancelar.Visible = false;
                bool resultado = actualizarDisponibilidades();
                if (resultado)
                    MessageBox.Show("Disponibilidades actualizadas");
                else
                {
                    txtDispAuto.Text = "";
                    txtDispUti.Text = "";
                    txtDispMoto.Text = "";
                    txtDispBici.Text = "";
                    cargarDisponibilidades();
                }
            }         
        }

        /// <summary>
        /// actualizacion de disponibilidad general, separado de los ingreso y egreso de vehiculos
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <param name="disponibilidad"></param>
        /// <param name="evento"></param>
        /// <param name="fecha"></param>
        public bool actualizarDisponibilidadGeneral(int idPlaya, int idTipoVehiculo, int disponibilidad, int evento, DateTime fecha)
        {
            string sURL;
            sURL = "http://localhost:21305/api/Disponibilidad/GetActualizarDisponibilidadGeneral?idPlaya=" + playa.id + "&idTipoVehiculo=" + idTipoVehiculo + "&disponibilidad=" + disponibilidad + "&idEvento=" + evento + "&fecha=" + fecha.ToString();

            try
            {
                WebRequest wrGETURL;
                progressBar1.PerformStep();
                wrGETURL = WebRequest.Create(sURL);

                //WebProxy myProxy = new WebProxy("myproxy", 80);
                //myProxy.BypassProxyOnLocal = true;

                //wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                StreamReader objReader = new StreamReader(objStream);

                string sLine = objReader.ReadLine();


                if (sLine == "\"True\""){
                    MessageBox.Show("Actualizacion Existosa");
                    return true;
                }
                else{
                    MessageBox.Show("no se pudo realizar la actualizacion");
                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar disponibilidad en API");
                return false;
            }
            
        }

        /// <summary>
        /// Actualiza las dispoibilidades de la playa
        /// </summary>
        /// <returns>true si la actualizacion fue</returns>
        public bool actualizarDisponibilidades()
        {
            //actualiza disponibilidades por acad tipo de vehiculo(auto, utilitario, moto, bici)

            //actualizacion auto
            if (existeVehiculo(1))//verifica la existencia de este tipo de vehiculo en la playa
            {
                //actualiza la disponibilidad y espera una respuesta por true o false (idPlaya, idTipoVehiculo, disponibiliad, evento, fecha)
                if (!actualizarDisponibilidadGeneral(playa.id, 1, int.Parse(txtDispAuto.Text), 3, DateTime.Now))
                {
                    MessageBox.Show("error en la actualizacion de disponibilidad tipo vehiculo Auto");
                    return false;
                }
              
            }
            else//setea el campo a vacio por si el usuario lo lleno y no formaba parte de los servicios
            {
                txtDispAuto.Text = "";
            }

            //actualizacion utilitario
            if (existeVehiculo(2))
            {
                if(!actualizarDisponibilidadGeneral(playa.id, 2, int.Parse(txtDispUti.Text), 3, DateTime.Now))
                {
                    MessageBox.Show("error en la actualizacion de disponibilidad tipo vehiculo Utilitario");
                    return false;
                }
            }
            else
            {
                txtDispUti.Text = "";
            }

            //actualizacion moto
            if (existeVehiculo(3))
            {
                if(!actualizarDisponibilidadGeneral(playa.id, 3, int.Parse(txtDispMoto.Text), 3, DateTime.Now))
                {
                    MessageBox.Show("error en la actualizacion de disponibilidad tipo vehiculo Motocicleta");
                    return false;
                }
            }
            else
            {
                txtDispMoto.Text = "";
            }

            //actualizacion bici
            if (existeVehiculo(4))
            {
                if(!actualizarDisponibilidadGeneral(playa.id, 4, int.Parse(txtDispBici.Text), 3, DateTime.Now))
                {
                    MessageBox.Show("error en la actualizacion de disponibilidad tipo vehiculo Bicicleta");
                    return false;
                }
            }
            else
            {
                txtDispBici.Text = "";
            }

            return true;
        }

        /// <summary>
        /// verifica la existencia del tipo de vehiculo en los servicios
        /// </summary>
        /// <param name="idTipoVehiculo">tipo de vehiculo</param>
        /// <returns>true si existe un servicio para ese tipo de vehiculo</returns>
        public bool existeVehiculo(int idTipoVehiculo)
        {
            foreach (var item in playa.disponibilidades)
            {
                if (item.tipoVehiculo == idTipoVehiculo)
                    return true;                
            }
            return false;
        }

        /// <summary>
        /// cancela la actualizacion de disponibilidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisponibilidadesCancelar_Click(object sender, EventArgs e)
        {
            //inhabilita la edicion
            txtDispAuto.Enabled = false;
            txtDispUti.Enabled = false;
            txtDispMoto.Enabled = false;
            txtDispBici.Enabled = false;
            btnDisponibilidades.Text = "EDITAR";
            btnDisponibilidadesCancelar.Visible = false;

            //recuperar las disponibilidades
            txtDispAuto.Text = "";
            txtDispUti.Text = "";
            txtDispMoto.Text = "";
            txtDispBici.Text = "";

            cargarDisponibilidades();           

            MessageBox.Show("Edicion cancelada");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
               
    }
}
