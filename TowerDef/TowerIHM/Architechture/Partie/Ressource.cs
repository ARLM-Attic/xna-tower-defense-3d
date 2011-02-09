using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Ressource
    {
        public String nomRessources { get; private set; }
        public int Ressources { get; private set; }

        public Ressource(String nom, int montant)
        {
            this.nomRessources = nom;
            this.Ressources = montant;
        }

        public void AjouterRessource(int montant)
        {
            this.Ressources = this.Ressources + montant;
        }

        public void SupprimerRessource(int montant) 
        {
            this.Ressources = this.Ressources - montant;
        }
    
    }
}
