using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Joueur
    {
        public String Nom { get; private set; }
        public List<Ressource> Ressources { get; private set; }
        public List<Tour> Tours { get; private set; }

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
