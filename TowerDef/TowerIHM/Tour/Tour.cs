using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    partial class Tour
    {
        private int porte;
        private int degat;
        private int nbCible;

        private int nb_tic_timer;
        private List<Projectile> projectiles;

        private bool volant;
        private List<Case> cibles;
        private List<Case> implentation;

        public Tour(int porte, int degat, bool volant) 
        {
            this.porte = porte;
            this.degat = degat;
            this.volant = volant;
        }

        public void attaquerCible(Unite u, int degat) 
        {
            u.Attaquer(degat);
        }

        public void attaquerZone(int etendu, int degat) 
        {
            foreach (Case cible in cibles) 
            {
                cible.Attaquer(degat);
            }
            //puis pour celle autour en foinction du range en connexité 8 
            // donc sur plateau + ou - range en X et Y par rapport au X et Y de la case courrante
        }

        public void construire() 
        {
            // remplir toute cibles de tout les case comprios dans la porté qui sont (bool) pratiquable
        }

    }
}
