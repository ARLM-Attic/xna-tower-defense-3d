using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    partial class Terrain
    {
        private const int TAILLE_CASE = 32;
        private String NomCarte;

        /* X, Y , Z niveau abstraction case */
        public int Horizontal;
        public int Vertical;
        public int Profondeur;

        /* X, Y, Z niveau moteur 3D */
        public int x;
        public int y;
        public int z;  // z varie de 2 hauteur de terrain pour les tour et les unite (0,1) dans un premier temp
       
        public Case[,] Carte; //plateau de jeu 

        public CaseDebut Debut; //case de depart (definit au passage les case de fin cf classe)

        public Terrain(String mapName, int longeur, int largeur, int profondeur) 
        {
            if (largeur > 0 & longeur > 0 & profondeur > 0)
            {
                this.Horizontal = longeur;
                this.Vertical = largeur;
                this.Profondeur = profondeur;

                this.x = this.Horizontal * TAILLE_CASE;
                this.y = this.Vertical * TAILLE_CASE;
                this.z = this.Profondeur; // a discuter

                Carte = new Case[Horizontal, Vertical];
                this.NomCarte = mapName;
            }
            else
            {
                Console.WriteLine("Dimmension de votre cartes sont incorrect");
            }
        }

        public void initTerrain() 
        {
            int i = 0;
            int j = 0;
            while (i < this.Vertical)
            {
                while (j < this.Horizontal)
                {
                    Carte[j, i] = new Case(j, i, 0, false, false);
                    j++;
                }
                i++;
                j = 0;
            }

            // -1 du a l'indexage 0..n
            CaseFin fin = new CaseFin(this.Horizontal - 1, this.Vertical - 1);
            CaseDebut Debut = new CaseDebut(0,0);
            Debut.AjouterFin(fin);
        }

        public override String ToString() 
        {
            String ret = "";
            int i = 0;
            int j = 0;
            while (i < this.Vertical) 
            {
                while (j < this.Horizontal) 
                {
                    if (Carte[j,i].Praticable)
                    {
                        if (Carte[j, i].Unites.Count > 0)
                        {
                            ret += "X";
                        }
                        else 
                        {
                            ret += " ";
                        }
                    }
                    else
                    {
                        if (Carte[j, i].Constructible)
                        {
                            ret += "O";
                        }
                        else
                        {
                            ret += "#";
                        }
                    }
                    j++;
                }
                i++;
                ret += "\n";
                j = 0;
            }
            return ret;
        }
    }
}
