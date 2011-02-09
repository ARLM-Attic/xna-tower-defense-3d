using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class CaseDebut : Case
    {
        private CaseFin Fin;

        public CaseDebut(int x, int y) 
        {
            Fin = null;
        }

        public void AjouterFin(CaseFin cf) 
        {
                Fin = cf;
        }

        public void SupprimerFin(int x, int y) 
        { 
            
        }
    }
}
