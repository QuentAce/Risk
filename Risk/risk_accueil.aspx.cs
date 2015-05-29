using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{

    public partial class risk_accueil : System.Web.UI.Page
    {
        Joueur jo = new Joueur();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Utilisateur)Session["utilisateur"]) != null)
            {
                Utilisateur user = (Utilisateur)Session["utilisateur"];

                if (user != null)
                {
                    using (thomasEntities3 modele = new thomasEntities3())
                    {
                        jo = modele.Joueur.FirstOrDefault(j => j.joueur_toUtilisateur == user.id_utilisateur);
                    }
                    if (jo != null)
                    {
                        Label_accueil.Text = "Bienvenue " + jo.pseudo_joueur;
                        Panel_pseudo.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }

            using (thomasEntities3 modele = new thomasEntities3())
            {
                if (!IsPostBack)
                {
                    ListBox_Partie.Items.Clear();
                    IQueryable<Partie> req_partie_en_cours = from partie in modele.Partie
                                                             where partie.etat_partie == "Créer"
                                                             select partie;


                    foreach (Partie p in req_partie_en_cours)
                    {
                        ListBox_Partie.Items.Add(new ListItem(p.nom_partie, p.id_partie.ToString()));
                    }

                }
            }
        }
        protected void Button_creer_partie_Click(object sender, EventArgs e)
        {
            Session["joueur"] = jo;
            Response.Redirect("toolkit.aspx");
        }

        protected void Button_valider_pseudo_Click(object sender, EventArgs e)
        {
            if (TextBox_pseudo.Text.Length <= 25 && TextBox_pseudo.Text.Length >=5)
            {
                using (thomasEntities3 modele = new thomasEntities3())
                {
                    if (modele.Joueur.FirstOrDefault(u => u.pseudo_joueur == TextBox_pseudo.Text) != null)
                    {
                        Label_message.Text = "Pseudo deja utilisé";
                    }
                    else
                    {
                        Joueur joueur = new Joueur();
                        joueur.pseudo_joueur = TextBox_pseudo.Text;
                        joueur.joueur_toUtilisateur = ((Utilisateur)Session["utilisateur"]).id_utilisateur;
                        joueur.nbrpartiesgagnes_joueur = 0;
                        joueur.nbrpartiesjoues_joueur = 0;
                        joueur.nbrpartiesperdues_joueur = 0;
                        modele.Joueur.Add(joueur);
                        modele.SaveChanges();
                        //Panel_pseudo.Visible = false;
                        Response.Redirect("risk_accueil.aspx");
                    }
                }
            }
            else
            {
                Label_message.Text="Pseudo trop long";               
            }
            
        }

        protected void Button_rejoindre_partie_Click(object sender, EventArgs e)
        {
            using (thomasEntities3 modele = new thomasEntities3())
            {
                int numPartie = int.Parse(ListBox_Partie.SelectedItem.Value);
                Partie join_partie = modele.Partie.FirstOrDefault(p => p.id_partie == numPartie );
                join_partie.partie_toJ2 = jo.id_joueur;
                join_partie.phase_partie = 0;
                join_partie.etat_partie = "en cours";
                modele.SaveChanges();
                Session["partie"] = join_partie.id_partie;
                Response.Redirect("partie.aspx");

            }
        }
    }
}