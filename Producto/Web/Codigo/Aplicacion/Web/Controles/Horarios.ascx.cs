using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Entidades;

namespace Web.Controles
{
    public partial class Horario : System.Web.UI.UserControl
    {
        GestorPlaya gestor;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPlaya();
            if (!Page.IsPostBack)
            {
            }
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
                               
                horario.Id = int.Parse(gvHorarios.DataKeys[row.RowIndex].Value.ToString());
                horario.DiaAtencionId = Convert.ToInt32(row.Cells[0].Text);
                horario.HoraDesde = row.Cells[2].Text;
                horario.HoraHasta = row.Cells[3].Text;
                
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
            horarios.Add(horario);
            Horarios = horarios;
        }

        private Entidades.Horario CargarEntidad()
        {
            var horario = new Entidades.Horario();
            horario.DiaAtencion = gestor.GetDiaAtencionById(IdDiaAtencionSeleccionado);
            horario.HoraDesde = HoraDesde;
            horario.HoraHasta = HoraHasta;
            return horario;
        }
        
        #region eventos
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarHorario(CargarEntidad());
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

    }
    
}