using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Case 
    {
        //coordonnée de la case dans le terrain
        public int X;
        public int Y;
        public int Z;
        //public Terrain Carte;

        // propriete de la case
        public bool Constructible;
        public bool Construite;
        public bool Praticable;
        public List<Unite> Unites;
        
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
