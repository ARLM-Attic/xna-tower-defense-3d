using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    partial class Case 
    {
        //coordonnée de la case dans le terrain
        private int X;
        private int Y;
        private int Z;
        //public Terrain Carte;

        // propriete de la case
        private bool Constructible;
        private bool Construite;
        private bool Praticable;
        private List<Unite> Unites;
        
        public Case() 
        {
        
        }

        public Case(int x , int y , int z ,bool build, bool walk) 
        {
            //geographie 
            this.X = x;
            this.Y = y;
            this.Z = z;

            //propriete
            this.Praticable = walk;
            this.Constructible = build;
            Unites = new List<Unite>();
        }

        public void AjouterUnite(Unite u)
        {
            Unites.Add(u);
        }

        public void SupprimerUnite(Unite u) 
        {
            Unites.Remove(u);
        }
       
        public void Attaquer(int degat) 
        {
            foreach (Unite u in Unites) 
            {
                u.Attaquer(degat);
            }
        }
       
   }
}
