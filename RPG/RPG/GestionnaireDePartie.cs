using RPG.Heros;
using RPG.Monsters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    static class GestionnaireDePartie
    {
        public static Monster randomMonster()
        {
            Random random = new Random();

            Monster Monster;
            switch (random.Next(1, 4))
            {
                case 1: Monster = new Gobelin();
                        break;
                case 2: Monster = new Squelette();
                        break;
                case 3: Monster = new Sorciere();
                        break;
                default: Monster = new Gobelin();
                         break;
            }
            return Monster;
        }
        public static Hero randomHero(int pointDeVieMax, int PointAttaque, int CombatGagne)
        {
            Random random = new Random();

            Hero Hero;
            switch (random.Next(1, 4))
            {
                case 1:
                    Hero = new Chevalier(pointDeVieMax, PointAttaque, CombatGagne);
                    break;
                case 2:
                    Hero = new Archer(pointDeVieMax, PointAttaque, CombatGagne);
                    break;
                case 3:
                    Hero = new Magicien(pointDeVieMax, PointAttaque, CombatGagne);
                    break;
                default:
                    Hero = new Chevalier(pointDeVieMax, PointAttaque, CombatGagne);
                    break;
            }
            return Hero;
        }
    }

}
