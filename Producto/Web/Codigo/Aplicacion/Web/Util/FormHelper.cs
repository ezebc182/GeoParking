using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Web.Util
{
    public class FormHelper
    {
        #region Recuperar valores

        public static DateTime? ObtenerFecha(TextBox campo)
        {
            try
            {
                if (string.IsNullOrEmpty(campo.Text))
                    return null;

                return DateTime.Parse(campo.Text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DateTime? ObtenerFecha(HtmlGenericControl campo)
        {
            try
            {
                if (string.IsNullOrEmpty(campo.InnerText))
                    return null;

                return DateTime.Parse(campo.InnerText);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DateTime? ObtenerFecha(string valor)
        {
            try
            {
                if (string.IsNullOrEmpty(valor))
                    return null;
                DateTime fecha;
                if (!DateTime.TryParse(valor, out fecha))
                    return null;
                return fecha;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int? ObtenerNullableEntero(object control)
        {
            try
            {
                string valor = null;

                if (control.GetType() == typeof(DropDownList))
                    valor = ((DropDownList)control).SelectedValue;

                if (control.GetType() == typeof(TextBox))
                    valor = ((TextBox)control).Text;

                if (control.GetType() == typeof(HiddenField))
                    valor = ((HiddenField)control).Value;

                if (string.IsNullOrEmpty(valor))
                    return null;

                return int.Parse(valor);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int ObtenerEntero(object control)
        {
            try
            {
                string valor = null;

                if (control.GetType() == typeof(DropDownList))
                    valor = ((DropDownList)control).SelectedValue;

                if (control.GetType() == typeof(TextBox))
                    valor = ((TextBox)control).Text;

                if (control.GetType() == typeof(HiddenField))
                    valor = ((HiddenField)control).Value;

                if (string.IsNullOrEmpty(valor))
                    return 0;

                return int.Parse(valor);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static decimal? ObtenerNullableDecimal(object control)
        {
            try
            {
                string valor = null;

                if (control.GetType() == typeof(DropDownList))
                    valor = ((DropDownList)control).SelectedValue;

                if (control.GetType() == typeof(TextBox))
                    valor = ((TextBox)control).Text;

                if (control.GetType() == typeof(HiddenField))
                    valor = ((HiddenField)control).Value;

                if (string.IsNullOrEmpty(valor))
                    return null;

                return decimal.Parse(valor);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static decimal ObtenerDecimal(object control)
        {
            try
            {
                string valor = null;

                if (control.GetType() == typeof(DropDownList))
                    valor = ((DropDownList)control).SelectedValue;

                if (control.GetType() == typeof(TextBox))
                    valor = ((TextBox)control).Text;

                if (control.GetType() == typeof(HiddenField))
                    valor = ((HiddenField)control).Value;

                if (string.IsNullOrEmpty(valor))
                    return 0;

                return decimal.Parse(valor);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static float? ObtenerNullableFlotante(object control)
        {
            try
            {
                string valor = null;

                if (control.GetType() == typeof(DropDownList))
                    valor = ((DropDownList)control).SelectedValue;

                if (control.GetType() == typeof(TextBox))
                    valor = ((TextBox)control).Text;

                if (control.GetType() == typeof(HiddenField))
                    valor = ((HiddenField)control).Value;

                if (string.IsNullOrEmpty(valor))
                    return null;

                return float.Parse(valor);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static float ObtenerFlotante(object control)
        {
            try
            {
                string valor = null;

                if (control.GetType() == typeof(DropDownList))
                    valor = ((DropDownList)control).SelectedValue;

                if (control.GetType() == typeof(TextBox))
                    valor = ((TextBox)control).Text;

                if (control.GetType() == typeof(HiddenField))
                    valor = ((HiddenField)control).Value;

                return float.Parse(valor);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static TEnumeracion ObtenerEnumeracion<TEnumeracion>(DropDownList ddl)
        {
            var valor = ddl.SelectedValue.Replace(' ', '_');
            return (TEnumeracion)Enum.Parse(typeof(TEnumeracion), valor);
        }

        #endregion

        #region Grillas

        public static void CargarGrilla(GridView grilla, IEnumerable source)
        {
            grilla.DataSource = source;
            grilla.DataKeyNames = new[] { "Id" };
            grilla.DataBind();
        }

        public static void LimpiarGrilla(GridView grilla)
        {
            grilla.DataSource = null;
            grilla.DataBind();
        }


        /// <summary>
        /// Recupera los IDs de los objetos seleccionados en un GridView con una columna de checkbox
        /// </summary>
        /// <param name="grilla">GridView</param>
        /// <param name="idControl">Nombre del control chk dentro de la grilla</param>
        /// <param name="posicionColumna">Número de columna (contada de 0 a N) donde está la columna de ID. Esta columna DEBE estar VISIBLE=TRUE</param>
        /// <returns></returns>
        public static IList<int> RecuperarSeleccionEnGrillaCheckbox(GridView grilla, string idControl, int posicionColumna)
        {
            var ids = new List<int>();

            foreach (GridViewRow gvr in grilla.Rows)
            {
                var control = (CheckBox)gvr.FindControl(idControl);
                if (control.Checked)
                {
                    int value = int.Parse(gvr.Cells[posicionColumna].Text);
                    ids.Add(value);
                }
            }

            return ids;
        }

        /// <summary>
        /// Selecciona los checkbox de una grilla con una columna de checkbox
        /// </summary>
        /// <param name="grilla"></param>
        /// <param name="nombreControlCheckbox"></param>
        /// <param name="posicionColumnaId"></param>
        /// <param name="ids"></param>
        public static void SeleccionarEnGrillaCheckbox(GridView grilla, string nombreControlCheckbox, int posicionColumnaId, IList<int> ids)
        {
            foreach (GridViewRow gvr in grilla.Rows)
            {
                var control = ((CheckBox)gvr.FindControl(nombreControlCheckbox));
                var uPrimaryid = int.Parse(gvr.Cells[posicionColumnaId].Text);
                if (ids.Any(id => id == uPrimaryid))
                    control.Checked = true;
            }
        }

        /// <summary>
        /// Limpiar la selección en los checkbox de una grilla con una columna de checkbox
        /// </summary>
        /// <param name="grilla"></param>
        /// <param name="nombreControlCheckbox"></param>
        /// <param name="posicionColumnaId"></param>
        /// <param name="ids"></param>
        public static void LimpiarSeleccionEnGrillaCheckbox(GridView grilla, string nombreControlCheckbox, int posicionColumnaId)
        {
            foreach (GridViewRow gvr in grilla.Rows)
            {
                var control = ((CheckBox)gvr.FindControl(nombreControlCheckbox));
                control.Checked = false;
            }
        }

        #endregion

        #region Manejo enumeraciones


        public static string GetEnumNombre(Enum e)
        {
            return e.ToString().Replace('_', ' ');
        }

        public static string GetEnumNombreFromValor(string valor)
        {
            return valor.Replace(' ', '_');
        }

        public static List<string> ListFromEnumeration(Type enumeracion)
        {
            Array enumSource = Enum.GetValues(enumeracion);
            var source = new List<string>();

            foreach (var item in enumSource)
            {
                source.Add(item.ToString().Replace('_', ' '));
            }

            return source;
        }

        public static List<string> ListFromListEnum(List<Enum> list)
        {

            var listResult = new List<string>();
            foreach (var e in list)
                listResult.Add(e.ToString().Replace('_', ' '));

            return listResult;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        #endregion

        #region Combos

        public static void LimpiarCombo(DropDownList combo)
        {
            combo.DataSource = null;
            combo.DataBind();
        }

        /// <summary>
        /// Metodo usado para llenar un combo con una lista de entidades.
        /// </summary>
        /// <param name="combo">El combo a cargar</param>
        /// <param name="source">La lista de entidades con la que se va a cargar el combo</param>
        /// <param name="dataTextField">Propiedad de la entidad que se mostrara</param>
        /// <param name="dataValueField">Propiedad de la entidad que se toma como valor al seleccionar algun item</param>
        public static void CargarCombo(DropDownList combo, Object source, string dataTextField, string dataValueField)
        {

            // seteo la propiedad de la Entidad que quiero mostrarle al usuario
            combo.DataTextField = dataTextField;
            // seteo la propiedad de la Entidad que quiero tomar como valor
            combo.DataValueField = dataValueField;
            combo.DataSource = source;
            combo.DataBind();
        }

        /// <summary>
        /// Metodo usado para llenar un combo con una lista de entidades.
        /// </summary>
        /// <param name="combo">El combo a cargar</param>
        /// <param name="source">La lista de entidades con la que se va a cargar el combo</param>
        /// <param name="dataTextField">Propiedad de la entidad que se mostrara</param>
        /// <param name="dataValueField">Propiedad de la entidad que se toma como valor al seleccionar algun item</param>
        /// <param name="primerItemVacio">Valor del primer item a mostrar cuando se cargue el combo</param>
        public static void CargarCombo(DropDownList combo, Object source, string dataTextField, string dataValueField, string primerItemVacio)
        {
            CargarCombo(combo, source, dataTextField, dataValueField);
            combo.Items.Insert(0, new ListItem(primerItemVacio, "0"));
        }

        public static void CargarComboDesdeEnumeracion(DropDownList combo, Type enumeracion)
        {
            var source = ListFromEnumeration(enumeracion);
            CargarCombo(combo, source, String.Empty, String.Empty);
        }

        public static void CargarComboDesdeEnumeracion(DropDownList combo, Type enumeracion, string primerItemVacio)
        {
            var source = ListFromEnumeration(enumeracion);
            CargarCombo(combo, source, String.Empty, String.Empty, primerItemVacio);
        }

        /// <summary>
        /// Metodo usado para llenar un combo con una lista de entidades.
        /// </summary>
        /// <param name="combo">El combo a cargar</param>
        /// <param name="source">La lista de entidades con la que se va a cargar el combo</param>
        /// <param name="dataTextField">Propiedad de la entidad que se mostrara</param>
        /// <param name="dataValueField">Propiedad de la entidad que se toma como valor al seleccionar algun item</param>
        public static void CargarComboMultiple(ListBox combo, Object source, string dataTextField, string dataValueField)
        {
            // seteo la propiedad de la Entidad que quiero mostrarle al usuario
            combo.DataTextField = dataTextField;
            // seteo la propiedad de la Entidad que quiero tomar como valor
            combo.DataValueField = dataValueField;
            combo.DataSource = source;
            combo.DataBind();
        }

        public static IList<int> RecuperarComboMultiple(ListBox combo)
        {
            var lista = new List<int>();
            foreach (var selectedIndex in combo.GetSelectedIndices())
            {
                lista.Add(int.Parse(combo.Items[selectedIndex].Value));
            }
            return lista;
        }

        public static void SeleccionarComboMultiple(ListBox combo, IList<int> lista)
        {
            foreach (var valor in lista)
            {
                foreach (ListItem item in combo.Items)
                {
                    if (item.Value == valor.ToString())
                        item.Selected = true;
                }
            }
        }

        #endregion

        #region Controles
        /// <summary>
        /// Agrega o elimina la clase 'hidden' a un control
        /// </summary>
        /// <param name="control">control</param>
        public static void CambiarVisibilidadControl(HtmlControl control)
        {
            if (control.Attributes["class"].Contains("hidden"))
            {
                MostrarControl(control);
            }
            else OcultarControl(control);
        }

        /// <summary>
        /// Agrega o elimina la clase 'hidden' a un control
        /// </summary>
        /// <param name="control">control</param>
        public static void CambiarVisibilidadControl(WebControl control)
        {
            if (control.Attributes["class"].Contains("hidden"))
            {
                MostrarControl(control);
            }
            else OcultarControl(control);
        }

        /// <summary>
        /// muestra u oculta un control
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="habilitar">true=mostrar, false=ocultar</param>
        public static void CambiarVisibilidadControl(HtmlControl control, bool habilitar)
        {
            if (habilitar)
            {
                MostrarControl(control);
            }
            else OcultarControl(control);
        }

        /// <summary>
        /// muestra u oculta un control
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="habilitar">true=mostrar, false=ocultar</param>
        public static void CambiarVisibilidadControl(WebControl control, bool habilitar)
        {
            if (habilitar)
            {
                MostrarControl(control);
            }
            else OcultarControl(control);
        }
        /// <summary>
        /// Muestra un control
        /// </summary>
        /// <param name="control"></param>
        private static void MostrarControl(HtmlControl control)
        {
            control.Attributes.Add("class", String.Join(" ", control
               .Attributes["class"]
               .Split(' ')
               .Except(new string[] { "", "hidden" })
               .ToArray()
               ));
        }
        /// <summary>
        /// Muestra un control
        /// </summary>
        /// <param name="control"></param>
        private static void MostrarControl(WebControl control)
        {
            control.Attributes.Add("class", String.Join(" ", control
               .Attributes["class"]
               .Split(' ')
               .Except(new string[] { "", "hidden" })
               .ToArray()
               ));
        }
        /// <summary>
        /// Oculta un control
        /// </summary>
        /// <param name="control"></param>
        private static void OcultarControl(HtmlControl control)
        {
            control.Attributes.Add("class", String.Join(" ", control
               .Attributes["class"]
               .Split(' ')
               .Except(new string[] { "", "hidden" })
               .Concat(new string[] { "hidden" })
               .ToArray()
               ));
        }
        /// <summary>
        /// Oculta un control
        /// </summary>
        /// <param name="control"></param>
        private static void OcultarControl(WebControl control)
        {
            control.Attributes.Add("class", String.Join(" ", control
                   .Attributes["class"]
                   .Split(' ')
                   .Except(new string[] { "", "hidden" })
                   .Concat(new string[] { "hidden" })
                   .ToArray()
                   ));
        }
        #endregion

    }
}