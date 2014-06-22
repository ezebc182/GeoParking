using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Alert
        {
            get { return lblMessage.InnerText; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lblMessage.InnerText = value;
                    Show();
                }                
            }
        }
        private void Show()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "PopAlerta", "$(function() { Alerta_openModal(); });", true);
        }

    }
}