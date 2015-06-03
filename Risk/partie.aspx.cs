﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Risk
{
    public partial class Partie1 : System.Web.UI.Page
    {
        public int idPartie;
        public Partie partie;
        public Joueur_has_Partie jhp;
        public Joueur j1;
        public Joueur j2;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string[] nom_phase = { "Sélection de la zone de départ", "Renfort", "Déplacement / Attaque", "Fin de tour" };


            if (Session["partie"] == null)
            {
                Response.Redirect("risk_accueil.aspx");
            }
            else
            {
                
                idPartie = (int)Session["partie"];
                
                New_Monde monde = new New_Monde();
                using (thomasEntities3 modele = new thomasEntities3())
                {

                    partie = modele.Partie.FirstOrDefault(p => p.id_partie == idPartie);


                    int? idj1 = partie.partie_toJ1;

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
                partie.New_Monde = monde;
                Label_nom_monde.Text = partie.New_Monde.nom_new_monde;
                Label_phase.Text = nom_phase[(int)partie.phase_partie];


                if (partie.phase_partie == 0)
                {
                    //Random rand = new Random();
                    //int jet_j1 = rand.Next(1, 1000);
                    //int jet_j2 = rand.Next(1, 1000);

                    using (thomasEntities3 modele = new thomasEntities3())
                    {
                        jhp = modele.Joueur_has_Partie.FirstOrDefault(j => j.id_partie == partie.id_partie && j.id_joueur1 == partie.partie_toJ1);
                        //jhp.id_joueur1 = partie.partie_toJ1;
                        jhp.id_joueur2 = partie.partie_toJ2;
                        //if (jet_j1 < jet_j2)
                        //{
                        //    jhp.JhP_flag = partie.Joueur1.id_joueur;
                        //}
                        //else if (jet_j1 > jet_j2)
                        //{
                        //    jhp.JhP_flag = partie.Joueur.id_joueur;
                        //}
                        //modele.Joueur_has_Partie.Add(jhp);
                        modele.SaveChanges();
                    }

                }
                //else
                //{
                //    using (thomasEntities3 modele = new thomasEntities3())
                //    {
                //        jhp = modele.Joueur_has_Partie.FirstOrDefault(j => j.id_partie == partie.id_partie);
                //    }
                //}

                Label_joueur.Text = jhp.JhP_flag.ToString();
               
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
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // On passe dans cet évènement pour chaque element du repeater de premier niveau (celui qui est le plus en haut (Repeater1)
            Repeater repeater2 = (Repeater)e.Item.FindControl("Repeater2");

            // Item représente l'instance du ItemTemplate associé à cet évènement (élément graphique)
            // La donnée associée est dans Item.DataItem

            repeater2.DataSource = ((LigneMonde)e.Item.DataItem).items;
            repeater2.DataBind();
        }

        protected void But_fin_de_phase_Click(object sender, EventArgs e)
        {
            
        }

        protected void But_fin_de_tour_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

 
            if (partie.phase_partie == 0)
            {
                if (jhp.JhP_flag == partie.partie_toJ1)
                {
                    btn.CssClass = "j1";
                    btn.Text = "5";
                    
                }
                else
                {
                    btn.CssClass = "j2";
                    btn.Text = "5";
                    
                }
                
            }
            else if (partie.phase_partie == 1)
            {
                
            }
        }
    }
}