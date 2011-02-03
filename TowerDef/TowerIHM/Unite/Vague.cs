using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Vague
    {
        public int Nb_unites;
        List<Unite> Unites;

        public Vague(int nb_unite) 
        {
            this.Nb_unites = nb_unite;
            Unites = new List<Unite>();
        }

        public void AjouterUnite(Unite u) 
        {
            if (Unites.Count() < Nb_unites - 1)
            {
                Unites.Add(u);
            }
        }

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
