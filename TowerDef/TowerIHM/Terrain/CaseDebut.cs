using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class CaseDebut : Case
    {
        public Case Debut;
        public CaseFin Fin;
        public Boolean Unique;
        public List<CaseFin> Fins;

        public CaseDebut(int x, int y) 
        {
            Debut = new Case(0, 0, 0, false, true);
            Unique = false;
            Fin = null;
            Fins = new List<CaseFin>();
        }

        public void AjouterFin(CaseFin cf) 
        {
            if (Fin == null)
            {
                Fin = cf;
                Unique = true;
            }
            else 
            {
                Fins.Add(cf);
            }
        }

        public void SupprimerFin(int x, int y) 
        { 
            
        }
    }
}
