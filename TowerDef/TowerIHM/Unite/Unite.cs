using System;


namespace TowerDef
{
    partial class Unite
    {
        private String nom;
        private int point_vie;
        private int vitesse;
        private Position3D Position;
            
        /*
         * constructeur 
         */

        public Unite(String nom, int pv)
        {
            this.nom = nom;  
            this.vitesse = 100;
            this.point_vie = pv;
            Position = new Position3D();
        }

        /*
         * methode affectant le mouvement de l'unité
         */
        
        public void ReduireVitesse(int pourcentage) 
        {
            this.vitesse = this.vitesse - ((this.vitesse * pourcentage) / 100);
        }

        public void ReduireVitesseL(int v)
        {
            this.vitesse = this.vitesse - v;
        }

        public void AugmenterVitesse(int pourcentage)
        {
            this.vitesse = this.vitesse + ((this.vitesse * pourcentage) / 100);
        }

        public void AugmenterVitesseL(int v)
        {
            this.vitesse = this.vitesse + v;
        }

        public void Deplacer(Terrain t,Case c) 
        {
           
        }

        /*
         * Gestion des degats
         */

        public void Mourir() 
        {
            if (this.point_vie <= 0) 
            {
                Console.WriteLine(this.nom + " : je meurt !! quelqu'un voudrai me mettre un peu de terre j'aimerai dormir maintenant \n");
            }
            else
            {
                Console.WriteLine(this.nom + " : meme pas mal, encore ? \n");
            }
        }

        public void Attaquer(int degat) 
        {
            this.point_vie = this.point_vie - degat;
            Mourir();
        }

        public void Soigner(int soin)
        {
            this.point_vie = this.point_vie + soin;
        }

        /*
         * methode de l'Object
         */
        public override String ToString() 
        {
                String ret = "";
                ret += "nom : " + this.nom;
                ret += " vie : " + this.point_vie;
                ret += " deplacement : " + this.vitesse;
                return ret;
        }

    }
}
