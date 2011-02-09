using System;


namespace TowerDef
{
    partial class Unite
    {
        public String Nom { get; private set; }
        public int PointVie { get; private set; }
        public int Vitesse { get; private set; }
        public Position3D Position { get; private set; }
            
        /*
         * constructeur 
         */

        public Unite(String nom, int pv)
        {
            this.Nom = nom;  
            this.Vitesse = 100;
            this.PointVie = pv;
            Position = new Position3D();
        }

        /*
         * methode affectant le mouvement de l'unité
         */
        
        public void ReduireVitesse(int pourcentage) 
        {
            this.Vitesse = this.Vitesse - ((this.Vitesse * pourcentage) / 100);
        }

        public void ReduireVitesseL(int v)
        {
            this.Vitesse = this.Vitesse - v;
        }

        public void AugmenterVitesse(int pourcentage)
        {
            this.Vitesse = this.Vitesse + ((this.Vitesse * pourcentage) / 100);
        }

        public void AugmenterVitesseL(int v)
        {
            this.Vitesse = this.Vitesse + v;
        }

        public void Deplacer(Terrain t,Case c) 
        {
           
        }

        /*
         * Gestion des degats
         */

        public void Mourir() 
        {
            if (this.PointVie <= 0) 
            {
                Console.WriteLine(this.Nom + " : je meurt !! quelqu'un voudrai me mettre un peu de terre j'aimerai dormir maintenant \n");
            }
            else
            {
                Console.WriteLine(this.Nom + " : meme pas mal, encore ? \n");
            }
        }

        public void Attaquer(int degat) 
        {
            this.PointVie = this.PointVie - degat;
            Mourir();
        }

        public void Soigner(int soin)
        {
            this.PointVie = this.PointVie + soin;
        }

        /*
         * methode de l'Object
         */
        public override String ToString() 
        {
                String ret = "";
                ret += "nom : " + this.Nom;
                ret += " vie : " + this.PointVie;
                ret += " deplacement : " + this.Vitesse;
                return ret;
        }

    }
}
