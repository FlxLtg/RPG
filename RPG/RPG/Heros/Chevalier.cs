using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RPG.Heros
{
    class Chevalier : Hero
    {
        public Chevalier(int PointDeVieMax, int PointAttaque, int CombatGagne) : base(PointDeVieMax * Convert.ToInt32(1.2), PointAttaque * Convert.ToInt32(1.1))
        {
            this.CombatGagne = CombatGagne;
        }
    }
}
