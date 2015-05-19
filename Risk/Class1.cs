using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Risk
{
    public class Class1
    {
        public List<Zone> list_zone = new List<Zone>();

        //Créer chaque zone et l'ajoute dans une liste/bdd
        public void creerZone()
        {
            for (int y = 1; y <= 5; y++)
            {
                for (int x = 1; x <= 5; x++)
                {
                    using (thomasEntities modele = new thomasEntities()) { 
                        Zone z = new Zone();
                        z.coordonneesX_zone = x;
                        z.coordonneesY_zone = y;
                        z.nom_zone = (x + " " + y).ToString();
                        //z.zone_toMonde = ;
                        list_zone.Add(z);
                        modele.Zone.Add(z);
                        modele.SaveChanges();
                        
                    }
                }
            }
        
        //Pour chaque zone dans la liste

            foreach (Zone z in list_zone)
            {
                //Calcul coordonnées zones proches
                int? xplus1 = z.coordonneesX_zone + 1;
                int? xmoins1 = z.coordonneesX_zone - 1;
                int? yplus1 = z.coordonneesY_zone + 1;
                int? ymoins1 = z.coordonneesY_zone - 1;

                using(thomasEntities modele = new thomasEntities()){
                    //Récupere les zones qui correspondent aux coordonnées
                    IQueryable<Zone> zone_contatct = from requete_zone in modele.Zone
                                                     where ((requete_zone.coordonneesX_zone == xplus1 && requete_zone.coordonneesY_zone == z.coordonneesY_zone)
                                                     || (requete_zone.coordonneesX_zone == xmoins1 && requete_zone.coordonneesY_zone == z.coordonneesY_zone)
                                                     || (requete_zone.coordonneesX_zone == z.coordonneesX_zone && requete_zone.coordonneesY_zone == ymoins1)
                                                     || (requete_zone.coordonneesX_zone == z.coordonneesX_zone && requete_zone.coordonneesY_zone == yplus1))
                                                     select requete_zone;
                    //TODO Rajouter monde

                    foreach (Zone zc in zone_contatct)
                    {
                        z.Zone1.Add(zc);
                        
                    }

                    Zone zoneUpdate = new Zone();
                    zoneUpdate = (Zone)(modele.Zone.Where(zu => zu.id_zone == z.id_zone));
                    zoneUpdate.Zone1 = z.Zone1;
                    modele.SaveChanges();
                    

                }              
            }
            //using (thomasEntities modele = new thomasEntities())
            //{
            //    foreach (Zone z in list_zone)
            //    {

            //        IQueryable<Zone> test = from x in modele.Zone
            //                                where x.id_zone == z.id_zone
            //                                select x;



            //        modele.Zone.Add(z);
                    
            //        modele.SaveChanges();
            //    }
            //}
        }       
    }    
}