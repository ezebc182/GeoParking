using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Entidades;
using Web.Util;

namespace Web.Controles
{
    public partial class HorarioControl : System.Web.UI.UserControl
    {
        GestorPlaya gestor;
        public event EventHandler ErrorHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPlaya();
            if (!Page.IsPostBack)
            {
                CargarCombos();
            }
        }
        public void CargarCombos()
        {
            FormHelper.CargarCombo(ddlDias, gestor.BuscarDiasDeAtencion(), "Nombre", "Id", "Seleccione");
        }
        public IList<Entidades.Horario> Horarios
        {
            get { return GetHorariosDesdeGrilla(); }
            set { SetHorarioAGrilla(value); }
        }

        private void SetHorarioAGrilla(IList<Entidades.Horario> value)
        {
            gvHorarios.DataSource = value;
            gvHorarios.DataBind();
        }
        private void AddHorario(Entidades.Horario horario)
        {
            var horarios = Horarios;
            horarios.Add(horario);
            Horarios = horarios;
        }
        private IList<Entidades.Horario> GetHorariosDesdeGrilla()
        {
            IList<Entidades.Horario> horarios = new List<Entidades.Horario>();

            foreach (GridViewRow row in gvHorarios.Rows)
            {
                var horario = new Entidades.Horario();
                               
                horario.Id = int.Parse(gvHorarios.DataKeys[row.RowIndex].Values[0].ToString());
                horario.DiaAtencionId = int.Parse(gvHorarios.DataKeys[row.RowIndex].Values[1].ToString());
                horario.DiaAtencion = gestor.GetDiaAtencionById(horario.DiaAtencionId);
                horario.HoraDesde = row.Cells[1].Text;
                horario.HoraHasta = row.Cells[2].Text;
                
                horarios.Add(horario);
            }
            return horarios;
        }
        protected void OnRowCommandGvHorarios(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var lista = Horarios;

            switch (e.CommandName)
            {                
                case "Quitar":
                    lista.RemoveAt(index);
                    Horarios = lista;
                    break;
            }
        }
        private void AgregarHorario(Entidades.Horario horario)
        {
            var horarios = Horarios;
            if (!ValidarHorario(horario)) return;
            
                horarios.Add(horario);
                Horarios = horarios;
            
        }

        private bool ValidarHorario(Entidades.Horario horario)
        {
            
            foreach (var item in Horarios)
            {
                if (item.DiaAtencionId == horario.DiaAtencionId)
                {
                    OnError("Ya se ha cargado el horario de atencion para los dias seleccionados.");
                    return false;
                }
            }

            return true;
        }

        private bool ValidarDatosIngresados()
        {
            if (IdDiaAtencionSeleccionado == 0 || string.IsNullOrEmpty(HoraDesde) || string.IsNullOrEmpty(HoraHasta))
            {
                OnError("Debe ingresar todos los datos requeridos.");
                return false;
            }
            return true;
        }
        private Entidades.Horario CargarEntidad()
        {
            var horario = new Entidades.Horario();
            horario.DiaAtencionId = IdDiaAtencionSeleccionado;
            horario.DiaAtencion = gestor.GetDiaAtencionById(IdDiaAtencionSeleccionado);
            horario.HoraDesde = HoraDesde;
            horario.HoraHasta = HoraHasta;

            return horario;
        }

        public void LimpiarCampos()
        {
            IdDiaAtencionSeleccionado = 0;
            HoraDesde = "";
            HoraHasta = "";
        }

        private void SetVisibleFormulario(bool habilitar)
        {
            divSeccionFormulario.Visible = habilitar;
            divSeccionHorarios.Visible = !habilitar;
            btnAgregarHorario.Visible = !habilitar;
        }

        public void ConfigurarVer()
        {
            divSeccionFormulario.Visible = false;
            divSeccionHorarios.Visible = true;
            gvHorarios.Columns[3].Visible = false;
            btnAgregarHorario.Visible = false;
        }

        public void ConfigurarEditar()
        {
            divSeccionFormulario.Visible = false;
            divSeccionHorarios.Visible = true;
            gvHorarios.Columns[3].Visible = true;
            btnAgregarHorario.Visible = true;
        }

        public void ConfigurarRegistrar()
        {
            divSeccionFormulario.Visible = false;
            divSeccionHorarios.Visible = true;
            gvHorarios.Columns[3].Visible = true;
            btnAgregarHorario.Visible = true;
        }
        #region eventos
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados()) return;
            AgregarHorario(CargarEntidad());
            SetVisibleFormulario(false);
        }

        protected void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(true);
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(false);
        }

        #endregion
        #region properties


        public int IdDiaAtencionSeleccionado
        {
            get { return Convert.ToInt32(ddlDias.SelectedValue); }
            set { ddlDias.SelectedValue = value.ToString(); }
        }

        public string HoraDesde
        {
            get { return chk24Horas.Checked ? "00:00" : txtDesde.Text; }
            set { txtDesde.Text = value; }
        }

        public string HoraHasta
        {
            get { return chk24Horas.Checked ? "23:59" : txtHasta.Text;}
            set { txtHasta.Text = value; }
        }

        #endregion


        public void OnError(String mensaje)
        {
            if (ErrorHandler != null)
                ErrorHandler.Invoke(this, new HorarioArgs(mensaje));
        }


        public class HorarioArgs : EventArgs
        {
            public HorarioArgs(String error)
            {
                this.Mensaje = error;
            }

            public String Mensaje { get; set; }
        }

        

    }
    
}