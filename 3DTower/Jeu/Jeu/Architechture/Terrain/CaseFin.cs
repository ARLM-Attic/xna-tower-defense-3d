using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    class CaseFin : Case
    {
        public CaseFin(int x, int y)
        {
            new Case(x, y, 0, false, true);
        }
    }
}