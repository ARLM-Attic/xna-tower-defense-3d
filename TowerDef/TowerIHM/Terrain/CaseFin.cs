using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class CaseFin : Case
    {
        Case Fin;

        public CaseFin(int x , int y) 
        {
            Fin = new Case(x, y, 0, false, true); 
        }
    }
}
