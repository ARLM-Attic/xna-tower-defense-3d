using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    partial class Vague
    {
        private int Nb_unites;
        private List<Unite> Unites;

        public Vague(int nb_unite) 
        {
            this.Nb_unites = nb_unite;
            Unites = new List<Unite>();
        }


        //edition vague
        public void AjouterUnite(Unite u) 
        {
            if (Unites.Count() < Nb_unites - 1)
            {
                Unites.Add(u);
            }
        }

        public void SupprimerUnite(Unite u) 
        {
            
        }


        //affichage 
        public String Composition() 
        {
            String ret = "";
            foreach (Unite u in Unites)
            {
                ret += u + "\n";
            }
            return ret;
        }


    }
}
