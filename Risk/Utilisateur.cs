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
    
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            this.Joueur = new HashSet<Joueur>();
        }
    
        public int id_utilisateur { get; set; }
        public string nom_utilisateur { get; set; }
        public string prenom_utilisateur { get; set; }
    
        public virtual ICollection<Joueur> Joueur { get; set; }
    }
}
