using System;
using System.Collections.Generic;
using System.Linq;

namespace Serhun_EM_13_1_HM4
{
    internal class Program
    {
        //Functions for most tasks
        static void ErrorMessage(string message)
        {
            throw new Exception($"Error! {message}");
        }
        static void vivodRazdeliteley(string razdelitel)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat(razdelitel, 23)));
        }
        //Functions for task 1
        static void Result(double num1, double num2, string operation)
        {
            double result = Calculate(num1, num2, operation);
            if (operation == "√")
            {
                Console.WriteLine(num1+"√" + num2 + " = " + result);
                return;
            }
             Console.WriteLine(num1 + " " + operation + " " + num2 + " = " + result);
        }
        static double Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case ("+"):
                    return num1 + num2;
                case ("-"):
                    return num1 - num2;
                case ("*"):
                    return num1 * num2;
                case ("/"):
                    return num1 / num2;
                case ("^"):
                    return Math.Pow(num1, num2);
                case ("√"):
                    if (num2 < 0 && num1 % 2 != 0)
                        return -Math.Pow(-num2, 1 / num1);
                    return Math.Pow(num2, 1/num1);
                default:
                    return (num1 * num2) / 100;
            }
        }
        
        //Functions for task 2
        static string PlayerName(string number)
        {
            Console.Write("Enter the " +number + " player name: ");
            string playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName))
            {
                ErrorMessage("Player name cannot be empty.");
            }
            return playerName;
        }
        static int H_OR_T(Random random) {
            int num = random.Next(1, 1001);
            if (num < 498)
            {
                Console.WriteLine("heads");
                return 3;
            }
            else if (num > 502)
            {
                Console.WriteLine("tails");
                return 1;
            }
            else
            {
                Console.WriteLine("edge");
                return 10;
            }
        }
        static int Throw(string pl1, Random random)
        {
            Console.Write(pl1 + " trow ");
            int trow = H_OR_T(random);
            return trow;
        }
        static void PlayerScore(string player, int score)
        {
            Console.WriteLine(player + " score: " + score);
        }

        static void FinishGame(string player1, string player2, int score1, int score2)
        {
            Console.WriteLine("\nFinal scores:");
            Console.WriteLine(player1 + ": " + score1);
            Console.WriteLine(player2 + ": " + score2);
            if (score1 > score2)
            {
                Console.WriteLine(player1 + " wins!");
            }
            else if (score2 > score1)
            {
                Console.WriteLine(player2 + " wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }


        //Functions for Task 3
        static void GuessNumber(int computerNumber, int UserNumber)
        {             
            if (UserNumber < 1 || UserNumber > 10)
            {
                ErrorMessage("Number must be between 1 and 10.");
            }
            if (UserNumber > computerNumber)
            {
                Console.WriteLine("The guessed number is less than yours.");
            }
            else if (UserNumber < computerNumber)
            {
                Console.WriteLine("The guessed number is greater than yours.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the number: " + computerNumber);
            }
        }
        //Functions for Task 4

        enum NPC1{
            HP = 200,
            ATTACK = 20,
            CRITCHANCE = 5
        }
        enum NPC2
        {
            HP = 200,
            ATTACK = 15,
            CRITCHANCE = 30
        }

        static int Attack(string NPCName, int NPCAtack, int NPCCrit, string NPC2Name, int NPC2HP, Random random)
        {
            Console.WriteLine(NPCName + " attack!");
            int crit = CritChance(NPCCrit, random);
            int damage = NPCAtack * crit;
            NPC2HP -= damage;
            Console.WriteLine(NPCName + " dealt " + damage + " HP damage");
            if (NPC2HP < 0)
                NPC2HP = 0;
            Console.WriteLine(NPC2Name + " HP: " + NPC2HP);
            return NPC2HP;
        }

        static int CritChance(int NPCCritChance, Random random)
        {
            int num = random.Next(1, 101);
            if (num <= NPCCritChance)
            {
                Console.WriteLine("Critical hit!");
                return 2;
            }
            else
            {
                Console.WriteLine("Normal hit.");
                return 1;
            }
        }
        
        static void Finish(int NPC1Hp, int NPC2Hp)
        {
            if (NPC1Hp <= 0)
            {
                Console.WriteLine("NPC2 win! HP left " + NPC2Hp);
                return;
            }
            else
            {
                Console.WriteLine("NPC1 win! HP left " + NPC1Hp);
            }
        }

        static void Main(string[] args)
        {
            // Task 1
            
            try
            {
                List<string> opr = new List<string> { "+", "-", "*", "/", "^", "√", "%" };
                Console.Write("Enter the first number(or root degree): ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the available operations(");
                for (int i = 0; i < opr.Count; i++)
                {
                    Console.Write(i + 1 + " - \"" + opr[i]);
                    if (i < opr.Count - 1)
                    {
                        Console.Write("\", ");
                    }
                    else
                    {
                        Console.Write("\"): ");
                    }
                }
                int operation = Convert.ToInt32(Console.ReadLine()) - 1;
                if (operation < 0 || operation > 7)
                {
                    ErrorMessage("Invalid operation selected. Please choose a valid operation.");
                }
                Console.Write("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());
                if (operation == 3 && num2 == 0)
                {
                    ErrorMessage("Division by zero is not allowed.");
                }
                if ((operation == 5) && (num2 < 0) && (num1 % 2 == 0))
                {
                    ErrorMessage("Cannot extract the root of an even degree from a negative number.");
                }
                Result(num1, num2, opr[operation]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


            // Task 2
            /*
            {
                Random random = new Random();
                string player1 = PlayerName("first");
                string player2 = PlayerName("second");
                int score1 = 0, score2 = 0;
                for (int i = 0; i < 5; i++)
                {
                    vivodRazdeliteley("=");
                    Console.WriteLine("Round " + (i + 1));
                    int trow1 = Throw(player1, random);
                    int trow2 = Throw(player2, random);
                    score1 += trow1;
                    score2 += trow2;
                    Console.WriteLine("Scores: ");
                    PlayerScore(player1, score1);
                    PlayerScore(player2, score2);
                }
                FinishGame(player1, player2, score1, score2);
            }
            */

            // Task 3
            /*
            try
            {
                Random random = new Random();
                int ComputerNumber = random.Next(1, 11);
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Enter your number (1-10): ");
                    int UserNumber = Convert.ToInt32(Console.ReadLine());
                    GuessNumber(ComputerNumber, UserNumber);
                    if (UserNumber == ComputerNumber)
                    {
                        break;
                    }
                }
                Console.WriteLine("Sorry, you lost! The computer's number was: " + ComputerNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */

            // Task 4
            /*
            {
                Random random = new Random();
                int NPC1HP = (int)NPC1.HP;
                int NPC2HP = (int)NPC2.HP;
                int i = 1;
                while (NPC1HP > 0 && NPC2HP > 0)
                {
                    Console.WriteLine("Round " + i);
                    i++;
                    NPC2HP = Attack("NPC1", (int)NPC1.ATTACK, (int)NPC1.CRITCHANCE, "NPC2", NPC2HP, random);
                    if (NPC2HP <= 0)
                    {
                        vivodRazdeliteley("=");
                        break;
                    }
                    vivodRazdeliteley("-");
                    NPC1HP = Attack("NPC2", (int)NPC2.ATTACK, (int)NPC2.CRITCHANCE, "NPC1", NPC1HP, random);
                    vivodRazdeliteley("=");
                }
                Finish(NPC1HP, NPC2HP);
            }
            */
        }
    }
}
