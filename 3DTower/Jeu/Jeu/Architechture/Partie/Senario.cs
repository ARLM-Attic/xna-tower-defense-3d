using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    class Senario
    {
        private const int NB_VAGUE = 10;
        private const int NB_MAX_JOUEUR = 2;

        public int Nb_vie { get; private set; }

        public Joueur[] Joueurs { get; private set; }

        public Terrain Terrain { get; set; }

        public Vague[] Vagues { get; private set; }

        public List<Tour> Tours { get; private set; }

        public Senario(int nb_vie)
        {
            this.Nb_vie = nb_vie;

            Joueurs = new Joueur[NB_MAX_JOUEUR];

            Vagues = new Vague[NB_VAGUE];

            Tours = new List<Tour>();
        }

        public void InitJoueur(int nb_joueur)
        {
            int i = 0;

            if (nb_joueur <= NB_MAX_JOUEUR)
            {
                while (i < nb_joueur)
                {
                    Joueurs[i] = new Joueur("Joueur" + i);
                    i++;
                }
            }
        }

        public void ChargerVague(Vague v)
        {
            if (Vagues.Count() < NB_VAGUE - 1)
            {
                //Vagues[Vagues.Count()+1](v);
            }
        }

        public void Charger()
        {
            // chargement d'une partie
        }

        public void Sauvegarder()
        {
            // sauvegarde d'une partie
        }

        public void Creer()
        {
            //editeur de map
        }
    }
}