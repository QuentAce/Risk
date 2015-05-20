using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_inscription_Click(object sender, EventArgs e)
        {
            using (thomasEntities modele = new thomasEntities()) { 
                if (TextBox_Login.Text == "")
                {
                    Label_message.Text = "Login obligatoire";
                }
                else if (modele.Utilisateur.FirstOrDefault(u => u.nom_utilisateur == TextBox_Login.Text) != null)
                {
                    Label_message.Text = "Login deja utilisé";
                }

                else if (TextBox_mdp.Text == "")
                {
                    Label_message.Text = "Mot de passe obligatoire";
                }
                else if (TextBox_mdp.Text != TextBox_mdp_confirm.Text)
                {
                    Label_message.Text = "Mot de passe ne correspond pas";
                }
                else if (TextBox_nom.Text == "")
                {
                    Label_message.Text = "Nom obligatoire";
                }
                else if (TextBox_prenom.Text == "")
                {
                    Label_message.Text = "Prénom obligatoire";
                }

                else
                {                   
                    Utilisateur nouvel_utilisateur = new Utilisateur();
                    nouvel_utilisateur.login_utilisateur = TextBox_Login.Text;
                    nouvel_utilisateur.motdepasse_utilisateur = TextBox_mdp.Text;
                    nouvel_utilisateur.nom_utilisateur = TextBox_nom.Text;
                    nouvel_utilisateur.prenom_utilisateur = TextBox_prenom.Text;
                    modele.Utilisateur.Add(nouvel_utilisateur);
                    modele.SaveChanges();

                    Label_message.Text = "Inscription validée";
                    
                }
            }
        }
    }
}