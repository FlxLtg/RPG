using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Hero
    {
        public int PointDeVie { get; private set; }
        public int PointDeVieMax { get; private set; }
        public int PointAttaque { get; private set; }
        public int CombatGagne { get; protected set; }

        public Hero(int PointDeVie, int PointAttaque)
        {
            this.PointDeVie = PointDeVie;
            this.PointAttaque = PointAttaque;
            this.PointDeVieMax = PointDeVie;
            this.CombatGagne = 0;
        }

        public void SubitAttaque(Monster monster)
        {
            this.PointDeVie -= new Random().Next(1, monster.PointAttaque);
            if(this.PointDeVie <= 0)
            {
                this.PointDeVie = 0;
            }
        }
        public string Type()
        {
            return GetType().Name;
        }

        public void Victoire()
        {
            this.CombatGagne++;
        }

        public void PotionSoin()
        {
            this.PointDeVie += 30;
        }

        public void PointDeVieMaxi()
        {
            this.PointDeVie = this.PointDeVieMax;
        }

        public void Piege()
        {
            this.PointDeVie -= 15;
            if (this.PointDeVie <= 0)
            {
                this.PointDeVie = 0;
            }
        }
    }
}
