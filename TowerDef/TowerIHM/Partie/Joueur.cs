using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Joueur
    {
        String Nom;
        List<Ressource> Ressources;
        List<Tour> Tours;

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
