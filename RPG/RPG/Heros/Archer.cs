using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Heros
{
    class Archer : Hero
    {
        public Archer(int PointDeVieMax, int PointAttaque, int CombatGagne) : base(PointDeVieMax * Convert.ToInt32(1.15), PointAttaque * Convert.ToInt32(1.15))
        {
            this.CombatGagne = CombatGagne;
        }
    }
}
