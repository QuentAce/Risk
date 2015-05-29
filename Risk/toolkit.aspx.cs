using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class toolkit : System.Web.UI.Page
    {

        public Joueur j1;

        public void charger_liste_monde()
        {
            ListBox_monde_dispo.Items.Clear();
            using (thomasEntities3 modele = new thomasEntities3())
                {
                    foreach (New_Monde m in modele.New_Monde.Where(m => m.nom_new_monde != null))
                    {
                        ListBox_monde_dispo.Items.Add(new ListItem(m.nom_new_monde, m.id_new_monde.ToString()));
                    }
                }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            j1 = (Joueur)Session["joueur"];

            if (j1 == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                if (!IsPostBack)
                    {
                        charger_liste_monde();
                    }
            }
        }

        protected void Button_generer_Click(object sender, EventArgs e)
        {
           
            int x_max = int.Parse(TextBox_x_max.Text);
            int y_max = int.Parse(TextBox_y_max.Text);

            initialiser_carte_vide(x_max, y_max);
        }

        public void initialiser_carte_vide(int x_max,int y_max)
        {
            List<LigneMonde> lignes = new List<LigneMonde>();
            for (int y=0;y<y_max;y++)
            {
                LigneMonde ligne = new LigneMonde();
                for (int x=0;x<x_max;x++)
                {
                    MaZone z = new MaZone();
                    z.x = x;
                    z.y = y;
                    z.nom="("+x.ToString()+","+y.ToString()+")";
                    ligne.Add(z);
                }
                lignes.Add(ligne);
            }

            Repeater1.DataSource=lignes;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // On passe dans cet évènement pour chaque element du repeater de premier niveau (celui qui est le plus en haut (Repeater1)
            Repeater repeater2 = (Repeater)e.Item.FindControl("Repeater2");

            // Item représente l'instance du ItemTemplate associé à cet évènement (élément graphique)
            // La donnée associée est dans Item.DataItem

            repeater2.DataSource = ((LigneMonde)e.Item.DataItem).items;
            repeater2.DataBind();
        }

        // Quand on clique sur une case
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.CssClass=="eau")
            {
                btn.CssClass = "terrain";
                btn.Text = "2";
            }
            else
            {
                btn.CssClass = "eau";
                btn.Text = "";
            }
        }

        protected void Button_enregistrer_Click(object sender, EventArgs e)
        {

            if (TextBox_nom_monde.Text == "")
            {
                Label_Message_Monde.Text = "Merci d'indiquer un nom de monde !";
            }
            else
            {
                using (thomasEntities3 modele = new thomasEntities3())
                {
                    New_Monde monde = new New_Monde();
                    monde.nom_new_monde = TextBox_nom_monde.Text;
                    modele.New_Monde.Add(monde);
                    modele.SaveChanges();


                    int y = 0;
                    foreach (RepeaterItem ligne in Repeater1.Items)
                    {
                        Repeater repeater2 = (Repeater)ligne.FindControl("Repeater2");
                        int x = 0;
                        foreach (RepeaterItem item in repeater2.Items)
                        {
                            Button bouton = (Button)item.FindControl("Button1");

                            if (bouton.CssClass == "terrain")
                            {
                                Zone z = new Zone();
                                z.coordonneesX_zone = x;
                                z.coordonneesY_zone = y;
                                z.zone_toMonde = monde.id_new_monde;
                                modele.Zone.Add(z);
                            }

                            x++;
                        }
                        y++;
                    }
                    modele.SaveChanges();
                }
            }            
        }

        protected void Button_ouvrir_monde_Click(object sender, EventArgs e)
        {

            New_Monde monde = new New_Monde();
            using (thomasEntities3 modele = new thomasEntities3())
            {
                int numero_monde = int.Parse(ListBox_monde_dispo.SelectedItem.Value);
                monde = modele.New_Monde.FirstOrDefault(m => m.id_new_monde == numero_monde);

                int xmax = monde.Zone.Max(m => m.coordonneesX_zone)+1;
                int ymax = monde.Zone.Max(m => m.coordonneesY_zone)+1;

                initialiser_carte_vide(xmax, ymax);

                int y = 0;
                foreach (RepeaterItem ligne in Repeater1.Items)
                {
                    Repeater repeater2 = (Repeater)ligne.FindControl("Repeater2");
                    int x = 0;
                    foreach (RepeaterItem item in repeater2.Items)
                    {
                        Button bouton = (Button)item.FindControl("Button1");

                        if (monde.Zone.FirstOrDefault(z => z.coordonneesX_zone==x && z.coordonneesY_zone==y)==null)
                        {
                            bouton.CssClass = "eau";
                        }
                        else
                        {
                            bouton.CssClass = "terrain";
                            bouton.Text = "2";
                        }

                        x++;
                    }
                    y++;
                }

            }
        }

        protected void Button_lancer_partie_Click(object sender, EventArgs e)
        {
            using (thomasEntities3 modele = new thomasEntities3())
            {

                Partie partie = new Partie();
                partie.etat_partie = "Créer";
                partie.partie_toJ1 = j1.id_joueur;
                partie.nom_partie = TextBox_nom_partie.Text;
                partie.partie_tonew_monde = int.Parse(ListBox_monde_dispo.SelectedItem.Value);
                partie.phase_partie = 0;
                modele.Partie.Add(partie);
                modele.SaveChanges();

                Session["partie"] = partie.id_partie;
                Response.Redirect("partie.aspx");
            }
        }

        //Button2 = Bouton rafraichir liste map.
        protected void Button2_Click(object sender, EventArgs e)
        {
            charger_liste_monde();
        }
    }
}