using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Heros
{
    class Magicien : Hero
    {
        public Magicien(int PointDeVieMax, int PointAttaque, int CombatGagne) : base(PointDeVieMax * Convert.ToInt32(1.1), PointAttaque * Convert.ToInt32(1.2))
        {
            this.CombatGagne = CombatGagne;
        }
    }
}
