//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Risk
{
    using System;
    using System.Collections.Generic;
    
    public partial class Joueur
    {
        public Joueur()
        {
            this.Joueur_has_Partie = new HashSet<Joueur_has_Partie>();
            this.Joueur_has_Partie1 = new HashSet<Joueur_has_Partie>();
            this.Partie = new HashSet<Partie>();
            this.Partie1 = new HashSet<Partie>();
            this.Unite = new HashSet<Unite>();
        }
    
        public int id_joueur { get; set; }
        public string pseudo_joueur { get; set; }
        public Nullable<int> nbrpartiesjoues_joueur { get; set; }
        public Nullable<int> nbrpartiesgagnes_joueur { get; set; }
        public Nullable<int> nbrpartiesperdues_joueur { get; set; }
        public Nullable<int> joueur_toUtilisateur { get; set; }
    
        public virtual ICollection<Joueur_has_Partie> Joueur_has_Partie { get; set; }
        public virtual ICollection<Joueur_has_Partie> Joueur_has_Partie1 { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual ICollection<Partie> Partie { get; set; }
        public virtual ICollection<Partie> Partie1 { get; set; }
        public virtual ICollection<Unite> Unite { get; set; }
    }
}