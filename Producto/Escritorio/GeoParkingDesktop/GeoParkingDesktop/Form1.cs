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

        string urlServidor = "http://ifrigerio-001-site1.smarterasp.net";//url del servidor GeoParking

        int tipoVehiculo;//tipo de vehiculo a actualizar la disponibilidad         

        //datos de acceso
        string token = "rZgLGEYlkiTQAh35Kofj6w==";
        int id = 1012;

        public Form1()
        {            
             InitializeComponent();             
             configurarSistema(id);
        }

        /// <summary>
        /// configura el sistema de acuerdo a una playa de estacionamiento que se 
        /// busca por su ID
        /// </summary>
        /// <param name="id">identificador de la playa</param>
        public void configurarSistema(int id)
        {            
            string sURL = urlServidor+"/api/Playas/Get/" + id;

            //strinfg con los datos de la playa
            string JsonPlaya = consultaApi(sURL);                  

            try
            {
                //obtengo el objeto playa
                var deserializado = Newtonsoft.Json.JsonConvert.DeserializeObject(JsonPlaya).ToString();
                var objetoPlaya = Newtonsoft.Json.Linq.JObject.Parse(deserializado);

                //cargos datos generales
                playa.id = (int)objetoPlaya["Id"];
                playa.nombre = (string)objetoPlaya["Nombre"];
                playa.email = (string)objetoPlaya["Mail"];
                playa.tipoPlaya = int.Parse(objetoPlaya["IdTipoPlaya"].ToString());

                //horario
                var horario = objetoPlaya["Horario"];
                playa.horaDesde = (string)horario["HoraDesde"];
                playa.horaHasta = (string)horario["HoraHasta"]; 
                playa.dias = int.Parse(horario["IdDia"].ToString()); //falta cambiar las calases                

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
                }

                //muestro los datos de la playa
                cargarDatosPlaya();

                //mustro las disponibilidades
                cargarDisponibilidades();

                paneles.Visible = true;               
            }
            catch (Exception e)
            {                
                MessageBox.Show("Error al iniciar sistmea");                
            }       
        }

        /// <summary>
        /// Realiza la consulta a la API GeoParking
        /// </summary>
        /// <param name="idPlaya">url de la peticion</param>
        /// <returns>el resultado de la peticion</returns>
        public string consultaApi(string url)
        {
            try
            {
                WebRequest wrGETURL = WebRequest.Create(url);
                Stream objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);
                string sLine = objReader.ReadLine();               
                return sLine;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar api playa");
                return "error";
            }
        }

        /// <summary>
        /// Realiza una inserccion en la API GeoParking
        /// </summary>
        /// <param name="url">url de la peticion</param>
        /// <param name="postData">datos de la peticion</param>
        /// <returns></returns>
        public string inserccionApi(string url, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
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

        /// <summary>
        /// recupera la disponibilidad de un tipo de vehiculo de una playa
        /// </summary>
        /// <param name="idPlaya">identifaicador de la playa</param>
        /// <param name="idTipoVehiculo">identificador del tipo de vehicull</param>
        /// <returns></returns>
        private int recuperarDisponibilidad(int idPlaya, int idTipoVehiculo)
        {
            string sURL = urlServidor + "/api/Disponibilidad/GetDisponibilidadPlayaPorTipoVehiculo?idPlaya=" + idPlaya + "&idTipoVehiculo=" + idTipoVehiculo;

            try
            {
                return int.Parse(consultaApi(sURL));
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
            txtHoraHasta.Text = playa.horaHasta;

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

            if (matricula == "" & tipoVehiculo == 0)
            {
                MessageBox.Show("Datos incompletos para registrar el ingreso");
                return;
            }

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
            bool actualizoApi =  actualizarDisponibilidad(idPlaya, tipoVehiculo, evento, fechaHora);//registrar en el API

            if (actualizoApi)
            {
                //registro en el sistema
                registrarIngresoEnSistema(matricula, tipoVehiculo, fechaHora);                
            }
            
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
        public bool actualizarDisponibilidad(int idPlaya, int tipoVehiculo, int evento, DateTime fechaHora)
        {            

            //aca utilizo el acceso a la appi            
            string sURL,postData;
            sURL = urlServidor + "/api/Disponibilidad/PostActualizarDisponibilidad";
            postData = "IdPlaya=" + playa.id;
            postData += ("&IdTipoVehiculo=" + tipoVehiculo);
            postData += ("&IdEvento=" + evento);

            //string [] fecha = fechaHora.ToString().Split('/');
            //string fechaServidor = fecha[1] + "/" + fecha[0] + "/" + fecha[2].Substring(0,4);
            postData += ("&Fecha=" + fechaHora.ToString());
            postData += ("&Token=" + token);

            try
            {
                string sLine = inserccionApi(sURL, postData);

                if (sLine != "\"True\"")
                {
                    MessageBox.Show("no se pudo realizar la actualizacion");
                    return false;
                }

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

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar disponibilidad en API");
                return false;
            }
               
        }
       
        /// <summary>
        /// busca los datos del vehiculo por la matricula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            tipoVehiculo = 0;

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
            if (txtMatriculaEgreso.Text == "" || txtTipoVehiculo.Text == "" )
            {
                MessageBox.Show("Datos incompletos para registrar el ingreso");
                return;
            }
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
            bool actualizoApi = actualizarDisponibilidad(idPlaya, tipoVehiculo, evento, fechaHora);//actualizo la disponibilidad

            if (actualizoApi)
            {//registro el egreso en el sistema
                registrarEgresoEnSistema(txtMatriculaEgreso.Text);                
                limpiarEgreso();
                MessageBox.Show("SE REGISTRO EL EGRESO EXISTOSAMENTE");
                paneles.SelectedTab = tabPage1;
            }
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
            chekAuto.Enabled = true;
            chekUti.Enabled = true;
            chekMoto.Enabled = true;
            chekBici.Enabled = true;
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
            txtHoraHasta.Enabled = true;

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

            //chekAuto.Enabled = false;
            txt1hAuto.Enabled = false;
            txt12hAuto.Enabled = false;
            txt6hAuto.Enabled = false;
            txt24hAuto.Enabled = false;
            txtAbonoAuto.Enabled = false;

            //chekMoto.Enabled = false;
            txt1hMoto.Enabled = false;
            txt12hMoto.Enabled = false;
            txt6hMoto.Enabled = false;
            txt24hMoto.Enabled = false;
            txtAbonoMoto.Enabled = false;

            //chekUti.Enabled = false;
            txt1hUti.Enabled = false;
            txt12hUti.Enabled = false;
            txt6hUti.Enabled = false;
            txt24hUti.Enabled = false;
            txtAbonoUti.Enabled = false;

            //chekBici.Enabled = false;
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

            //actualizacion de horario
            if (playa.dias != cmbDiasHorario.SelectedIndex + 1 || playa.horaDesde != txtHoraDesde.Text || playa.horaHasta != txtHoraHasta.Text)
            {
                actualizarHorarioPlaya(cmbDiasHorario.SelectedIndex + 1, txtHoraDesde.Text, txtHoraHasta.Text);
            }

            //actualizacion de servicios y precios
            actualizarServiciosPrecios();

            inhabilitarFormularioAdminsitracion();
            btnCancelarCambios.Enabled = false;
            btnGuardarCambios.Enabled = false;
            chekAuto.Enabled = false;
            chekUti.Enabled = false;
            chekMoto.Enabled = false;
            chekBici.Enabled = false;

            MessageBox.Show("Actualizacion del sistema completada");
        }

        /// <summary>
        /// Actualiza el nombre y el email de la playa
        /// </summary>
        /// <param name="nombrePlaya">nuevo nombre</param>
        /// <param name="emaiPlaya">nuevo email</param>
        public void actualizarNombreEmailPLaya(string nombrePlaya, string emaiPlaya)
        {
            playa.nombre = nombrePlaya;
            playa.email = emaiPlaya;

            string sURL, postData;
            sURL = urlServidor + "/api/Playas/PostActualizarNombreEmailPlaya";
            postData = "IdPlaya=" + playa.id;
            postData += ("&Nombre=" + nombrePlaya);
            postData += ("&Mail=" + emaiPlaya);
            postData += ("&Token=" + token);            

            try
            {
                string sLine = inserccionApi(sURL, postData);

                if (sLine != "\"True\"")
                {
                    MessageBox.Show("no se pudo realizar la actualizacion de nombre y email");                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar nombre y email en API");                
            } 
        }

        /// <summary>
        /// Actualiza el horario de la playa
        /// </summary>
        /// <param name="diaAtencion">nuevo dia</param>
        /// <param name="horaDesde">nueva hora desde</param>
        /// <param name="horaHasta">nueva hora hasta</param>
        public void actualizarHorarioPlaya(int diaAtencion, string horaDesde, string horaHasta)
        {
            playa.dias = diaAtencion;
            playa.horaDesde = horaDesde;
            playa.horaHasta = horaHasta;            

            string sURL, postData;
            sURL = urlServidor+"/api/Playas/PostActualizarHorarioPlaya";
            postData = "IdPlaya=" + playa.id;
            postData += ("&DiaAtencionId=" + diaAtencion);
            postData += ("&HoraDesde=" + horaDesde);
            postData += ("&HoraHasta=" + horaHasta);
            postData += ("&Token=" + token);

            try
            {
                string sLine = inserccionApi(sURL,postData);

                if (sLine != "\"True\"")
                {
                    MessageBox.Show("no se pudo realizar la actualizacion del Horario");
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar horario en API");
            }
        }

        /// <summary>
        /// Actualiza el tipo de la playa
        /// </summary>
        /// <param name="tipoPlaya"></param>
        public void actualizarTipoPLaya(int tipoPlaya)
        {
            playa.tipoPlaya = tipoPlaya;

            string sURL, postData;
            sURL = urlServidor + "/api/Playas/PostActualizarTipoPlaya";
            postData = "IdPlaya=" + playa.id;
            postData += ("&TipoPlayaId=" + tipoPlaya);
            postData += ("&Token=" + token);           

            try
            {
                string sLine = inserccionApi(sURL,postData);

                if (sLine != "\"True\"")
                {
                    MessageBox.Show("no se pudo realizar la actualizacion de tipo playa");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar tipo playa en API");
            }
        }

        /// <summary>
        /// Actualza los precios de los servicios
        /// </summary>
        public void actualizarServiciosPrecios()
        {
            if (chekAuto.Checked == true)
            {
                if (verificarExistenciaDeServicio(1))
                {
                    //si existe verifico el cambio de precios
                    actualizarPrecios(1);
                }
                else
                {
                    //sino existe lock registramos AllowDrop servicio yield los precios
                    registracionDeServicio(1, txt1hAuto.Text, txt6hAuto.Text, txt12hAuto.Text, txt24hAuto.Text, txtAbonoAuto.Text);

                }
            }
            else
            {
                if (verificarExistenciaDeServicio(1))
                {
                    cancelacionDeServicio(1);
                }
            }

            if (chekUti.Checked == true)
            {
                if (verificarExistenciaDeServicio(2))
                {
                    //si existe verifico el cambio de precios
                    actualizarPrecios(2);
                }
                else
                {
                    //sino existe lock registramos AllowDrop servicio yield los precios
                    registracionDeServicio(2, txt1hUti.Text, txt6hUti.Text, txt12hUti.Text, txt24hUti.Text, txtAbonoUti.Text);

                }
            }
            else
            {
                if (verificarExistenciaDeServicio(2))
                {
                    cancelacionDeServicio(2);
                }
            }

            if (chekMoto.Checked == true)
            {
                if (verificarExistenciaDeServicio(3))
                {
                    //si existe verifico el cambio de precios
                    actualizarPrecios(3);
                }
                else
                {
                    //sino existe lock registramos AllowDrop servicio yield los precios
                    registracionDeServicio(3, txt1hMoto.Text, txt6hMoto.Text, txt12hMoto.Text, txt24hMoto.Text, txtAbonoMoto.Text);

                }
            }
            else
            {
                if (verificarExistenciaDeServicio(3))
                {
                    cancelacionDeServicio(3);
                }
            }

            if (chekBici.Checked == true)
            {
                if (verificarExistenciaDeServicio(4))
                {
                    //si existe verifico el cambio de precios
                    actualizarPrecios(4);
                }
                else
                {
                    //sino existe lock registramos AllowDrop servicio yield los precios
                    registracionDeServicio(4, txt1hBici.Text, txt6hBici.Text, txt12hBici.Text, txt24hBici.Text, txtAbonoBici.Text);

                }
            }
            else
            {
                if (verificarExistenciaDeServicio(4))
                {
                    cancelacionDeServicio(4);
                }
            }
            

        }

        /// <summary>
        /// REgistra un nuevo servicio con todos sus percios
        /// </summary>
        /// <param name="idTipoVehiculo">id del tipo vehiculo del servicio</param>
        /// <param name="x1">precio por hora</param>
        /// <param name="x6">por 6 hs</param>
        /// <param name="x12">por 12 hs</param>
        /// <param name="x24">por 24 hs</param>
        /// <param name="abono">abono mensual</param>
        public void registracionDeServicio(int idTipoVehiculo, string x1, string x6, string x12, string x24, string abono)
        {
            string sURL, postData;
            sURL = urlServidor+"/api/Servicios/PostRegistrarServicio";

            postData = "IdPlaya=" + playa.id;
            postData += ("&IdTipoVehiculo=" + idTipoVehiculo);
            postData += ("&Capacidad=0");

            postData += "&Precios%5B" + 0 + "%5D%5BIdTiempo%5D=1" ;
            postData += "&Precios%5B" + 0 + "%5D%5BMonto%5D=" + Double.Parse(x1);

            postData += "&Precios%5B" + 1 + "%5D%5BIdTiempo%5D=2";
            postData += "&Precios%5B" + 1 + "%5D%5BMonto%5D=" + Double.Parse(x6);

            postData += "&Precios%5B" + 2 + "%5D%5BIdTiempo%5D=3";
            postData += "&Precios%5B" + 2 + "%5D%5BMonto%5D=" + Double.Parse(x12);

            postData += "&Precios%5B" + 3 + "%5D%5BIdTiempo%5D=4";
            postData += "&Precios%5B" + 3 + "%5D%5BMonto%5D=" + Double.Parse(x24);

            postData += "&Precios%5B" + 4 + "%5D%5BIdTiempo%5D=5";
            postData += "&Precios%5B" + 4 + "%5D%5BMonto%5D=" + Double.Parse(abono);
            

            try
            {
                string sLine = inserccionApi(sURL,postData);

                if (sLine == "\"True\"")
                {
                    MessageBox.Show("Servicio Registrado");
                }
                else
                {
                    MessageBox.Show("no se pudo realizar la registracion del servicio");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al registrar un servicio en API");
            }
        }

        /// <summary>
        /// Cancela un servicio
        /// </summary>
        /// <param name="idTipoVehiculo">identificador del tipo de vehiculo del servicio</param>
        public void cancelacionDeServicio(int idTipoVehiculo)
        {
            string sURL, postData;
            sURL = urlServidor+"/api/Servicios/PostCancelarServicio";
            postData = "IdPlaya=" + playa.id;
            postData += ("&IdTipoVehiculo=" + idTipoVehiculo);

            try
            {
                string sLine = inserccionApi(sURL,postData); 

                if (sLine == "\"True\"")
                {
                    MessageBox.Show("Cancelacion de servicio correcta");
                }
                else
                {
                    MessageBox.Show("no se pudo realizar la cancelacion del servicio");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cancelar servicio en API");
            }
        }

        /// <summary>
        /// Verifica que exista el sevicio para ese tipo de vehiculo en la playa
        /// </summary>
        /// <param name="idTipoVehiculo">identificador del tipo de vehiculo</param>
        /// <returns></returns>
        public bool verificarExistenciaDeServicio(int idTipoVehiculo)
        {
            foreach (var item in playa.disponibilidades)
	        {
		        if(item.tipoVehiculo==idTipoVehiculo)
                    return true;
	        }
            
            return false;
        }

        /// <summary>
        /// Actualizacion de precios
        /// </summary>
        /// <param name="idTipoVehiculo"></param>
        public void actualizarPrecios(int idTipoVehiculo)
        {
            verificarModificacionPrecio(idTipoVehiculo);            
        }

        /// <summary>
        /// Verifica la modificacion de precios para un tipo de vehiculo
        /// </summary>
        /// <param name="idTipoVehiculo"></param>
        public void verificarModificacionPrecio(int idTipoVehiculo)
        {
            switch (idTipoVehiculo)
            {
                case 1: verificarModificacionPrecioAuto(); break;
                case 2: verificarModificacionPrecioUtilitario(); break;
                case 3: verificarModificacionPrecioMoto(); break;
                case 4: verificarModificacionPrecioBicicleta(); break;
                default: return;
                
            }
           
        }

        public void verificarModificacionPrecioAuto()
        {
           double precio = 0;

           if (txt1hAuto.Text != buscarPrecio(1,1).ToString())
           {        
               if(txt1hAuto.Text!="")
                   precio=Double.Parse(txt1hAuto.Text);

               if (buscarPrecio(1, 1) != 0)
                   actualizarPrecio(1, precio, 1);
               else
                   registrarPrecio(1, precio, 1);
           }

           if (txt6hAuto.Text != buscarPrecio(1, 2).ToString())
           {
               precio = 0;

               if (txt6hAuto.Text != "")
                   precio = Double.Parse(txt6hAuto.Text);

               if (buscarPrecio(1, 2)!=0)
                   actualizarPrecio(1, precio, 2);
               else
                   registrarPrecio(1, precio, 2);
           }

           if (txt12hAuto.Text != buscarPrecio(1, 3).ToString())
           {
               precio = 0;

               if (txt12hAuto.Text != "")
                   precio = Double.Parse(txt12hAuto.Text);

               if (buscarPrecio(1, 3) != 0)
                   actualizarPrecio(1, precio, 3);
               else
                   registrarPrecio(1, precio, 3);
           }

           if (txt24hAuto.Text != buscarPrecio(1, 4).ToString())
           {
               precio = 0;

               if (txt24hAuto.Text != "")
                   precio = Double.Parse(txt24hAuto.Text);

               if (buscarPrecio(1, 4) != 0)
                   actualizarPrecio(1, precio, 4);
               else
                   registrarPrecio(1, precio, 4);
           }

           if (txtAbonoAuto.Text != buscarPrecio(1, 5).ToString())
           {
               precio = 0;

               if (txtAbonoAuto.Text != "")
                   precio = Double.Parse(txtAbonoAuto.Text);

               if (buscarPrecio(1, 5) != 0)
                   actualizarPrecio(1, precio, 5);
               else
                   registrarPrecio(1, precio, 5);
           }
                

        }
        public void verificarModificacionPrecioUtilitario()
        {
            double precio = 0;

            string a = txt1hUti.Text;
            string b = buscarPrecio(2,1).ToString();

            if (txt1hUti.Text != buscarPrecio(2, 1).ToString())
            {
                if (txt1hUti.Text != "")
                    precio = Double.Parse(txt1hUti.Text);

                if (buscarPrecio(2, 1) != 0)
                    actualizarPrecio(2, precio, 1);
                else
                    registrarPrecio(2, precio, 1);
            }

            if (txt6hUti.Text != buscarPrecio(2, 2).ToString())
            {
                precio = 0;

                if (txt6hUti.Text != "")
                    precio = Double.Parse(txt6hUti.Text);

                if (buscarPrecio(2, 2) != 0)
                    actualizarPrecio(2, precio, 2);
                else
                    registrarPrecio(2, precio, 2);
            }

            if (txt12hUti.Text != buscarPrecio(2, 3).ToString())
            {
                precio = 0;

                if (txt12hUti.Text != "")
                    precio = Double.Parse(txt12hUti.Text);

                if (buscarPrecio(2, 3) != 0)
                    actualizarPrecio(2, precio, 3);
                else
                    registrarPrecio(2, precio, 3);
            }

            if (txt24hUti.Text != buscarPrecio(2, 4).ToString())
            {
                precio = 0;

                if (txt24hUti.Text != "")
                    precio = Double.Parse(txt24hUti.Text);

                if (buscarPrecio(2, 4) != 0)
                    actualizarPrecio(2, precio, 4);
                else
                    registrarPrecio(2, precio, 4);
            }

            if (txtAbonoUti.Text != buscarPrecio(2, 5).ToString())
            {
                precio = 0;

                if (txtAbonoUti.Text != "")
                    precio = Double.Parse(txtAbonoUti.Text);

                if (buscarPrecio(2, 5) != 0)
                    actualizarPrecio(2, precio, 5);
                else
                    registrarPrecio(2, precio, 5);
            }


        }
        public void verificarModificacionPrecioMoto()
        {
            double precio = 0;

            if (txt1hMoto.Text != buscarPrecio(3, 1).ToString())
            {
                if (txt1hMoto.Text != "")
                    precio = Double.Parse(txt1hMoto.Text);

                if (buscarPrecio(3, 1) != 0)
                    actualizarPrecio(3, precio, 1);
                else
                    registrarPrecio(3, precio, 1);
            }

            if (txt6hMoto.Text != buscarPrecio(3, 2).ToString())
            {
                precio = 0;

                if (txt6hMoto.Text != "")
                    precio = Double.Parse(txt6hMoto.Text);

                if (buscarPrecio(3, 2) != 0)
                    actualizarPrecio(3, precio, 2);
                else
                    registrarPrecio(3, precio, 2);
            }

            if (txt12hMoto.Text != buscarPrecio(3, 3).ToString())
            {
                precio = 0;

                if (txt12hMoto.Text != "")
                    precio = Double.Parse(txt12hMoto.Text);

                if (buscarPrecio(3, 3) != 0)
                    actualizarPrecio(3, precio, 3);
                else
                    registrarPrecio(3, precio, 3);
            }

            if (txt24hMoto.Text != buscarPrecio(3, 4).ToString())
            {
                precio = 0;

                if (txt24hMoto.Text != "")
                    precio = Double.Parse(txt24hMoto.Text);

                if (buscarPrecio(3, 4) != 0)
                    actualizarPrecio(3, precio, 4);
                else
                    registrarPrecio(3, precio, 4);
            }

            if (txtAbonoMoto.Text != buscarPrecio(3, 5).ToString())
            {
                precio = 0;

                if (txtAbonoMoto.Text != "")
                    precio = Double.Parse(txtAbonoMoto.Text);

                if (buscarPrecio(3, 5) != 0)
                    actualizarPrecio(3, precio, 5);
                else
                    registrarPrecio(3, precio, 5);
            }

        }
        public void verificarModificacionPrecioBicicleta()
        {
            double precio = 0;

            if (txt1hBici.Text != buscarPrecio(4, 1).ToString())
            {
                if (txt1hBici.Text != "")
                    precio = Double.Parse(txt1hBici.Text);

                if (buscarPrecio(4, 1) != 0)
                    actualizarPrecio(4, precio, 1);
                else
                    registrarPrecio(4, precio, 1);
            }

            if (txt6hBici.Text != buscarPrecio(4, 2).ToString())
            {
                precio = 0;

                if (txt6hBici.Text != "")
                    precio = Double.Parse(txt6hBici.Text);

                if (buscarPrecio(4, 2) != 0)
                    actualizarPrecio(4, precio, 2);
                else
                    registrarPrecio(4, precio, 2);
            }

            if (txt12hBici.Text != buscarPrecio(4, 3).ToString())
            {
                precio = 0;

                if (txt12hBici.Text != "")
                    precio = Double.Parse(txt12hBici.Text);

                if (buscarPrecio(4, 3) != 0)
                    actualizarPrecio(4, precio, 3);
                else
                    registrarPrecio(4, precio, 3);
            }

            if (txt24hBici.Text != buscarPrecio(4, 4).ToString())
            {
                precio = 0;

                if (txt24hBici.Text != "")
                    precio = Double.Parse(txt24hBici.Text);

                if (buscarPrecio(4, 4) != 0)
                    actualizarPrecio(4, precio, 4);
                else
                    registrarPrecio(4, precio, 4);
            }

            if (txtAbonoBici.Text != buscarPrecio(4, 5).ToString())
            {
                precio = 0;

                if (txtAbonoBici.Text != "")
                    precio = Double.Parse(txtAbonoBici.Text);

                if (buscarPrecio(4, 5) != 0)
                    actualizarPrecio(4, precio, 5);
                else
                    registrarPrecio(4, precio, 5);
            }

        }        

        /// <summary>
        /// Busca el precio para un tiempo de un tipo de vehiculo
        /// </summary>
        /// <param name="idTipoVechiculo"></param>
        /// <param name="idTiempo"></param>
        /// <returns></returns>
        public double buscarPrecio(int idTipoVechiculo, int idTiempo)
        {
            foreach (var item in playa.precios)
            {
                if (item.tiempo == idTiempo && item.tipoVehiculo == idTipoVechiculo)
                    return item.precio;
            }

            return 0;
        }        

        /// <summary>
        /// Actualiza un precio
        /// </summary>
        /// <param name="idTipoVehiculo">identificador del tipo de vehiculo</param>
        /// <param name="precio">precio</param>
        /// <param name="idTiempo">identificador de tiempo</param>
        public void actualizarPrecio(int idTipoVehiculo, double precio, int idTiempo)
        {            
            string sURL, postData;
            sURL = urlServidor+"/api/precios/PostActualizarPrecio";
            postData = "IdPlaya=" + playa.id;
            postData += ("&IdTiempo=" + idTiempo);
            postData += ("&IdTipoVehiculo=" + idTipoVehiculo);
            postData += ("&Precio=" + precio);
            postData += ("&Token=" + token);

            try
            {
               string sLine = inserccionApi(sURL,postData);

                if (sLine != "\"True\"")
                    MessageBox.Show("no se pudo realizar la actualizacion del precio");            

            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar precio en API");                
            }
        }

        /// <summary>
        /// Registra un nuevo precio
        /// </summary>
        /// <param name="idTipoVehiculo">identificador del vehiculo</param>
        /// <param name="precio">precio</param>
        /// <param name="idTiempo">identificador de tiempo</param>
        public void registrarPrecio(int idTipoVehiculo, double precio, int idTiempo)
        {
            string sURL, postData;
            sURL = urlServidor+"/api/precios/PostRegistrarPrecio";
            postData = "IdPlaya=" + playa.id;
            postData += ("&IdTiempo=" + idTiempo);
            postData += ("&IdTipoVehiculo=" + idTipoVehiculo);
            postData += ("&Precio=" + precio);

            try
            {
                string sLine = inserccionApi(sURL,postData);

                if (sLine != "\"True\"")
                    MessageBox.Show("no se pudo realizar la registracion del precio");   
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar precio en API");
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
        /// <param name="idPlaya">identificador de la playa</param>
        /// <param name="idTipoVehiculo">identificador del tipo de vehiculo</param>
        /// <param name="disponibilidad">disponibilidad</param>
        /// <param name="evento">evento</param>
        /// <param name="fecha">fecha</param>
        public bool actualizarDisponibilidadGeneral(int idPlaya, int idTipoVehiculo, int disponibilidad, int evento, DateTime fecha)
        {
            //aca actualizo la disponibilidad en el sistema (ingreso=se resta un lugar disponible)
            foreach (var item in playa.disponibilidades)
            {
                if (item.tipoVehiculo == idTipoVehiculo)
                {
                    item.disponibilidad = disponibilidad;                    

                    //actualizo los txt
                    switch (idTipoVehiculo)
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

            string sURL, postData;
            sURL = urlServidor+"/api/Disponibilidad/PostActualizarDisponibilidadGeneral";
            postData = "IdPlaya=" + playa.id;
            postData += ("&IdTipoVehiculo=" + idTipoVehiculo);
            postData += ("&Disponibilidad=" + disponibilidad);
            postData += ("&IdEvento=" + evento);

            //string[] fechas = fecha.ToString().Split('/');
            //string fechaServidor = fechas[1] + "/" + fechas[0] + "/" + fechas[2].Substring(0, 4);
            postData += ("&Fecha=" + fecha.ToString());
            postData += ("&Token=" + token);

            try
            {
                string sLine = inserccionApi(sURL,postData);

                if (sLine == "\"True\""){
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
        
    }
}
