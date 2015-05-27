using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class Partie1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idPartie ;
            Partie partie;

            if (Session["partie"] == null)
            {
                Response.Redirect("risk_accueil.aspx");
            }
            else
            {
                idPartie = (int)Session["partie"];
                New_Monde monde = new New_Monde();
                using (thomasEntities1 modele = new thomasEntities1())
                {

                    partie = modele.Partie.FirstOrDefault(p => p.id_partie == idPartie);





                    int numero_monde = partie.partie_tonew_monde;
                    monde = modele.New_Monde.FirstOrDefault(m => m.id_new_monde == numero_monde);

                    int xmax = monde.Zone.Max(m => m.coordonneesX_zone) + 1;
                    int ymax = monde.Zone.Max(m => m.coordonneesY_zone) + 1;

                    initialiser_carte_vide(xmax, ymax);

                    int y = 0;
                    foreach (RepeaterItem ligne in Repeater1.Items)
                    {
                        Repeater repeater2 = (Repeater)ligne.FindControl("Repeater2");
                        int x = 0;
                        foreach (RepeaterItem item in repeater2.Items)
                        {
                            Button bouton = (Button)item.FindControl("Button1");

                            if (monde.Zone.FirstOrDefault(z => z.coordonneesX_zone == x && z.coordonneesY_zone == y) == null)
                            {
                                bouton.CssClass = "eau";
                            }
                            else
                            {
                                bouton.CssClass = "terrain";
                            }

                            x++;
                        }
                        y++;
                    }

                }
            } 
            
        }
        public void initialiser_carte_vide(int x_max, int y_max)
        {
            List<LigneMonde> lignes = new List<LigneMonde>();
            for (int y = 0; y < y_max; y++)
            {
                LigneMonde ligne = new LigneMonde();
                for (int x = 0; x < x_max; x++)
                {
                    MaZone z = new MaZone();
                    z.x = x;
                    z.y = y;
                    z.nom = "(" + x.ToString() + "," + y.ToString() + ")";
                    ligne.Add(z);
                }
                lignes.Add(ligne);
            }

            Repeater1.DataSource = lignes;
            Repeater1.DataBind();
        }

       
    }
}