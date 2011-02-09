using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    partial class Vague
    {

        public int Nb_unites { get; private set; }
        public List<Unite> Unites {get; private set;}

        public Vague(int nb_unite) 
        {
            Nb_unites = nb_unite;
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
            Unites.Remove(u);
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
