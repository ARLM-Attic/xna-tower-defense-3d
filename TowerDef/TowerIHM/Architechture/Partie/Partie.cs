using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Partie
    {
        public Partie()
        {
            Terrain t = new Terrain("gouffre",16,16,1);
            t.initTerrain();

            Vague v1 = new Vague(50);
            int i = 0;
            while (i < 50) 
            {
                v1.AjouterUnite(new Unite("Troll_"+i, 250));
                i++;
            }
            
            Senario s = new Senario(100);
            s.InitJoueur(2);
            s.Terrain = t;
           


            Moteur m = new Moteur(s.Terrain);
        }
        
    }
}
