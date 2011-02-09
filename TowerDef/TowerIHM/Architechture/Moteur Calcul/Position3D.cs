using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef
{
    class Position3D
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public int O { get; private set; } //orientation

        public Position3D(int x, int y, int z, int o) 
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.O = o %360;
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
