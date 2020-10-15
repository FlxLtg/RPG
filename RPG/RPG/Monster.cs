using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public abstract class Monster
    {
        public int PointDeVie { get; protected set; }
        private int PointDeVieMax { get; set; }
        public int PointAttaque { get; protected set; }

        public Monster(int PointDeVie, int PointAttaque)
        {
            this.PointDeVie = PointDeVie;
            this.PointAttaque = PointAttaque;
            this.PointDeVieMax = PointDeVie;
        }

        public void SubitAttaque(Hero hero)
        {
            this.PointDeVie -= new Random().Next(1, hero.PointAttaque);
            if(this.PointDeVie <= 0)
            {
                this.PointDeVie = 0;
            }
        }

        public string Type()
        {
            return GetType().Name;
        }

    }
}
