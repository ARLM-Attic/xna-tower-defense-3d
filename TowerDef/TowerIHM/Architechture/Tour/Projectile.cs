using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDef.Tower
{
    partial class Projectile
    {
        public Position3D position { get; private set; }
        public int vitesse { get; private set; }
        public int ZoneEffet { get; private set; }
    }
}