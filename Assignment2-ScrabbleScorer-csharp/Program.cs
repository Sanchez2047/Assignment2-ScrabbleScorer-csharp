using System;
using System.Collections.Generic;

namespace Assignment2_ScrabbleScorer_csharp
{
    class Program
    {
        public static Dictionary<int, string> scoring = new Dictionary<int, string>()
        {
            {1, "Scrabble: The traditional scoring algorithm." },
            {2, "Simple Score: Each letter is worth 1 point." },
            {3, "Bonus Vowels: Vowels are worth 3 pts, and consonants are 1 pt." },
        };
        //Here is the original OldPointStructure dictionay
        public static Dictionary<int, string> oldPointStructure = new Dictionary<int, string>()
        {
            {1, "A, E, I, O, U, L, N, R, S, T"},
            {2, "D, G"},
            {3, "B, C, M, P" },
            {4, "F, H, V, W, Y" },
            {5, "K" },
            {8, "J, X" },
            {10, "Q, Z" }
        };




        //Code your Transform method here






        //Code your Scoring Option methods here

        //SimpleScorer-----
        public static void SimpleScorer()
        {

        }


        //BonusVowels-----




        //ScrabbleScorer-----





        //Code your ScoringAlgorithms method here





        //Code your InitialPrompt method here
        public static int InitialPrompt()
        {

            Console.WriteLine("Welcome to the Scrabble score calculator\n");
            foreach (var line in scoring)
            {
                Console.WriteLine($"{line.Key} - {line.Value}");
            }
            Console.WriteLine("\nEnter 1, 2, or 3");
            int userInput = Int32.Parse(Console.ReadLine());
            return userInput;

        }



        //Code your RunProgram method here






        static void Main(string[] args)
        {
            InitialPrompt();
            //Call your RunProgram method here





            Console.ReadLine();
        }
    }
}
