using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDef.Unit;

namespace TowerDef.Map
{
    partial class Case
    {
        //coordonnée de la case dans le terrain
        public int X { get; private set; }

        public int Y { get; private set; }

        public int Z { get; private set; }

        //public Terrain Carte;

        // propriete de la case
        public bool Constructible { get; private set; }

        public bool Construite { get; private set; }

        public bool Praticable { get; private set; }

        public List<Unite> Unites { get; private set; }

        public Case()
        {
        }

        public Case(int x, int y, int z, bool build, bool walk)
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