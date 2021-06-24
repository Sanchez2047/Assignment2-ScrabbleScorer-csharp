using System;
using System.Collections.Generic;
using System.Linq;

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
            {0, " " },
            {1, "A, E, I, O, U, L, N, R, S, T"},
            {2, "D, G"},
            {3, "B, C, M, P" },
            {4, "F, H, V, W, Y" },
            {5, "K" },
            {8, "J, X" },
            {10, "Q, Z" }
        };
        public static int userInput;
        public static string userWord;

        public static Dictionary<char, int> newPointStructure = Transform();
        //Code your Transform method here
        public static Dictionary<char,int> Transform()
        {
            Dictionary<char, int> newDict = new Dictionary<char, int>();

            foreach (var line in oldPointStructure)
            {
                string lowerLetters = (line.Value).ToLower();
                string[] letters = lowerLetters.Split(", ");
                foreach (string letter in letters)
                {

                    newDict.Add(char.Parse(letter), line.Key);
                }
            }
            return newDict;
        }
        //Code your Scoring Option methods here

        //SimpleScorer-----
        public static void SimpleScorer(string word)
        {
            char[] letters = word.ToCharArray();
            Console.WriteLine($"Your word: {word} is worth {letters.Length} points");
        }
        //BonusVowels-----
        public static void BonusVowels(string word)
        {
            string lowerWord = word.ToLower();
            List<int> vowels = new List<int> { 'a', 'e', 'i', 'o', 'u' };
            char[] letters = lowerWord.ToCharArray();
            List<int> score = new List<int>();
            List<int> consonant = new List<int>();
            foreach (char letter in letters)
            {           
                if (vowels.Contains(letter))
                {
                    score.Add(3);
                }
                else
                {
                    consonant.Add(letter);
                }     
            }
            int finalScore = score.Sum() + consonant.Count;
            Console.WriteLine($"Your word: {word} is worth {finalScore} points");
        }
        //ScrabbleScorer-----
        public static void ScrabbleScorer(string word)
        {
            string lowerWord = word.ToLower();
            char[] letters = lowerWord.ToCharArray();
            List<int> score = new List<int>();
            foreach (char letter in letters)
            {
                score.Add(newPointStructure[letter]);
            }
            int finalScore = score.Sum();
            Console.WriteLine($"Your word: {word} is worth {finalScore} points");
        }
        //Code your ScoringAlgorithms method here
        public static void ScoringAlgorithms(int number)
        {
            if (userInput == 2)
            {
                SimpleScorer(userWord);
            }
            else if (userInput == 3)
            {
                BonusVowels(userWord);
            }
            else
            {
                ScrabbleScorer(userWord);
            }
        }
        //Code your InitialPrompt method here
        public static int InitialPrompt()
        {

            Console.WriteLine("Welcome to the Scrabble score calculator\n");
            foreach (var line in scoring)
            {
                Console.WriteLine($"{line.Key} - {line.Value}");
            }
            Console.WriteLine("\nEnter 1, 2, or 3");
            bool success =Int32.TryParse(Console.ReadLine(), out userInput);
            while (success == false || userInput > 3 || userInput <= 0)
            {
                Console.WriteLine("Please enter in only numbers 1, 2, or 3");
                success = Int32.TryParse(Console.ReadLine(), out userInput);
            }
            return userInput;

        }
        //Code your RunProgram method here
        public static int RunProgram()
        {
            userInput = InitialPrompt();
            Console.WriteLine("Enter a word to be scored, or \"STOP\" to quit: ");
            userWord = Console.ReadLine();
            while (userWord != "STOP")
            {
                ScoringAlgorithms(userInput);
                Console.WriteLine("Enter a word to be scored, or \"STOP\" to quit: ");
                userWord = Console.ReadLine();
            }
            return userInput;
        }
        static void Main(string[] args)
        {
            RunProgram();
        }
    }
}
