using RPG.Monsters;
using RPG.Heros;
using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Random random = new Random();

                int herosPointDeVie;
                Console.Write("Saisissez le nombre de point de vie de votre héros : ");
                while (!int.TryParse(Console.ReadLine(), out herosPointDeVie))
                {
                    Console.WriteLine("Veuillez rentrer un nombre");
                }
                int herosPointAttaque;
                Console.Write("Saisissez le nombre de point d'attaque de votre héros : ");
                while (!int.TryParse(Console.ReadLine(), out herosPointAttaque))
                {
                    Console.WriteLine("Veuillez rentrer un nombre");
                }

                Hero hero = new Hero(herosPointDeVie, herosPointAttaque);

                while (hero.PointDeVie > 0)
                {
                    // on instancie aleatoirement un monstre que le heros devra affonté
                    Monster monster = GestionnaireDePartie.randomMonster();

                    //tant que le heros ou le monstre on de la vie le combat continue
                    while (hero.PointDeVie > 0 && monster.PointDeVie > 0)
                    {
                        //Le heros attaque le monstre
                        monster.SubitAttaque(hero);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Le " + hero.Type() + " attaque ! il reste " + monster.PointDeVie + " points de vie à l'ennemi " + monster.Type(), Console.ForegroundColor);
                        Console.ResetColor();

                        // si le monstre survit a l'attaque alors il attaque a son tour
                        if (monster.PointDeVie > 0)
                        {
                            hero.SubitAttaque(monster);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Le " + monster.Type() + " attaque ! il reste " + hero.PointDeVie + " points de vie au " + hero.Type(), Console.ForegroundColor);
                            Console.ResetColor();
                        }

                    }

                    //actiosn effectuees a la suite du combat si le heros gagne
                    if (hero.PointDeVie > 0)
                    {
                        hero.Victoire();
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        if (hero.CombatGagne == 1)
                        {
                            Console.WriteLine("Le " + hero.Type() + " a gagné ! C'est sa " + hero.CombatGagne + "ere victoire !", Console.ForegroundColor);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Le " + hero.Type() + " a gagné ! C'est sa " + hero.CombatGagne + "eme victoire !", Console.ForegroundColor);
                            Console.ResetColor();
                        }

                        int PointDeVieMax = hero.PointDeVieMax;
                        int PointAttaque = hero.PointAttaque;
                        int CombatGagne = hero.CombatGagne;

                        if (hero.CombatGagne >= 5 && hero.Type() == "Hero")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            hero = GestionnaireDePartie.randomHero(PointDeVieMax, PointAttaque, CombatGagne);
                            Console.WriteLine("Incroyable ! Le heros evolue ! Il est desormais " + hero.Type() + " !", Console.ForegroundColor);
                            Console.ResetColor();
                        }

                        if (random.Next(0, 100) > 50)
                        {
                            Console.Write("Il semblerait que le " + hero.Type() + " est trouvé quelque chose.. ");
                            if (random.Next(0, 100) > 20)
                            {
                                hero.PotionSoin();
                                //on s'assure que les points de vie du heros ne depasse pas ses points de vie max.
                                if (hero.PointDeVie > hero.PointDeVieMax)
                                {
                                    hero.PointDeVieMaxi();
                                }
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Une fiole rapportant 30 points de vie ! Le " + hero.Type() + " à desormais " + hero.PointDeVie + " points de vie !", Console.ForegroundColor);
                                Console.ResetColor();
                            }
                            else
                            {
                                hero.Piege();
                                if (hero.PointDeVie <= 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Le " + hero.Type() + " n'a pas survécu à ce piége..", Console.ForegroundColor);
                                    Console.ResetColor();
                                    continue;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("C'est un piége ! Le " + hero.Type() + " perd 15 points de vie ! Le " + hero.Type() + " à desormais " + hero.PointDeVie + " points de vie !");
                                    Console.ResetColor();
                                }

                            }
                        }
                    }
                    // actions effectuees a la suite du combat si le heros perds
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Le " + hero.Type() + " est mort suite au combat contre le " + monster.Type(), Console.ForegroundColor);
                        Console.ResetColor();
                        continue;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Le " + hero.Type() + " a gagné " + hero.CombatGagne + " combat(s) avant d'être vaincu", Console.ForegroundColor);
                Console.ResetColor();

                Console.WriteLine("Voulez vous rejouer ? [Y]\nAppuyer sur n'importe quelle autre touche pour quitter le jeu..");
                var userWantsToContinue = Console.ReadLine();
                //true si l'input saisi n'est pas 'n' ou 'N'
                keepGoing = userWantsToContinue?.ToUpper() == "Y";
            }
        }
    }
}
