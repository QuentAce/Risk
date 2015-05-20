using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class privee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["utilisateur"] != null)
            {
                Label_accueil.Text = "Bienvenue " + ((Utilisateur)Session["utilisateur"]).login_utilisateur;
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}