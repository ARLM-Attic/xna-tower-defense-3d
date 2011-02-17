using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeu
{
    class Position3D
    {
        private int X;
        private int Y;
        private int Z;
        private int O; //orientation

        public Position3D(int x, int y, int z, int o)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.O = o % 360;
        }

        public Position3D()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
            this.O = 0;
        }

        public void Orienter(int o)
        {
            this.O = o % 360;
        }

        public void Changer(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void Reinitialiser()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }
    }
}