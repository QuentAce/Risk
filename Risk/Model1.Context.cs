﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class thomasEntities : DbContext
    {
        public thomasEntities()
            : base("name=thomasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Joueur> Joueur { get; set; }
        public virtual DbSet<Joueur_has_Partie> Joueur_has_Partie { get; set; }
        public virtual DbSet<Monde> Monde { get; set; }
        public virtual DbSet<Partie> Partie { get; set; }
        public virtual DbSet<Territoire> Territoire { get; set; }
        public virtual DbSet<Type_zone> Type_zone { get; set; }
        public virtual DbSet<Unite> Unite { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
    }
}