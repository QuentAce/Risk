using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_ok_Click(object sender, EventArgs e)
        {
            using (thomasEntities2 modele = new thomasEntities2())
            {
                Utilisateur utilisateur = modele.Utilisateur.ToList().FirstOrDefault(u => u.login_utilisateur == TextBox_login.Text && u.motdepasse_utilisateur == TextBox_mdp.Text);

                if (utilisateur == null)
                {
                    Label_message.Text = "login ou mot de passe incorect";
                }
                else
                {
                    Session["utilisateur"] = utilisateur;
                    Response.Redirect("privee.aspx");
                }
            }
        }
    }
}