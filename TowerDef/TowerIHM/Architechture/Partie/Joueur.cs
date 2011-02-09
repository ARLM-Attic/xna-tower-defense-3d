using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Joueur
    {
        private String Nom;
        private List<Ressource> Ressources;
        private List<Tour> Tours;

        public Joueur() 
        {
            this.Nom = "Joueur";
            Ressources = new List<Ressource>();
            Tours = new List<Tour>();
        }

        public Joueur(String nom)
        {
            this.Nom = nom;
            Ressources = new List<Ressource>();
            Tours = new List<Tour>();
        }

        public void AjouterRessource(Ressource r) 
        {
            Ressources.Add(r);
        }
    }
}
