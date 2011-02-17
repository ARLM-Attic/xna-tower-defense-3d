using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    class Moteur
    {
        private Terrain Carte;

        public Moteur(Terrain map)
        {
            this.Carte = map;
        }

        // test si la case est bien dans la carte
        public bool CaseValide(Case c)
        {
            if (Carte.Horizontal >= c.X & Carte.Vertical >= c.Y & Carte.Profondeur >= c.Z &
                c.X <= 0 & c.Y <= 0 & c.Z <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // calcul si la case et adjacente deplacement
        public bool CaseAdjacente(Case c, Case ca)
        {
            if (((c.X == ca.X + 1) | (c.X == ca.X - 1)) & ((c.Y == ca.Y + 1) | (c.Y == ca.Y - 1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // calcul des cases a porter a faire a la creation d'une tour et a l'update
        public List<Case> Porte(Case c, int porte)
        {
            List<Case> ret = new List<Case>();
            int Cx = c.X;
            int Cy = c.Y;
            int x, y, d, i;

            i = 0;
            x = 0;
            y = porte;
            d = 1 - porte;
            i = y;
            List<Case> tmp = new List<Case>();
            while (i > x)
            {
                tmp.Add(Carte.Carte[Cx + x, Cy + i]);
                tmp.Add(Carte.Carte[Cx - x, Cy + i]);
                tmp.Add(Carte.Carte[Cx + x, Cy - i]);
                tmp.Add(Carte.Carte[Cx - x, Cy - i]);
                tmp.Add(Carte.Carte[Cx + i, Cy + x]);
                tmp.Add(Carte.Carte[Cx - i, Cy + x]);
                tmp.Add(Carte.Carte[Cx + i, Cy - x]);
                tmp.Add(Carte.Carte[Cx - i, Cy - x]);

                i--;
            }
            while (y > x)
            {
                if (d < 0)
                    d += 2 * x + 3;
                else
                {
                    d += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                i = y;
                while (i > x)
                {
                    tmp.Add(Carte.Carte[Cx + x, Cy + i]);
                    tmp.Add(Carte.Carte[Cx - x, Cy + i]);
                    tmp.Add(Carte.Carte[Cx + x, Cy - i]);
                    tmp.Add(Carte.Carte[Cx - x, Cy - i]);
                    tmp.Add(Carte.Carte[Cx + i, Cy + x]);
                    tmp.Add(Carte.Carte[Cx - i, Cy + x]);
                    tmp.Add(Carte.Carte[Cx + i, Cy - x]);
                    tmp.Add(Carte.Carte[Cx - i, Cy - x]);
                    i--;
                }

                i = 1;
                while (i < porte - 1)
                {
                    tmp.Add(Carte.Carte[Cx - i, Cy - i]);
                    tmp.Add(Carte.Carte[Cx + i, Cy + i]);
                    tmp.Add(Carte.Carte[Cx + i, Cy - i]);
                    tmp.Add(Carte.Carte[Cx - i, Cy + i]);
                    i++;
                }
            }

            foreach (Case test in tmp)
            {
                if (test.Praticable)
                {
                    ret.Add(test);
                }
            }
            return ret;
        }
    }
}