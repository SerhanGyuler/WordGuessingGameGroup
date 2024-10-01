namespace WordGuessingGameGroup
{
    using System;

    class WordGuessingGame
    {
        static string[] words = { "apple", "banana", "cherry", "date", "elderberry", "grapes", "orange", "horse", "pig", "dog", "cat", "elephant", "giraffe", "lion", "tiger", "zebra", "monkey", "bear", "wolf", "fox", "rabbit", "deer", "squirrel", "mouse", "rat", "snake", "lizard", "frog", "toad", "turtle", "crocodile", "alligator", "dolphin", "whale", "shark", "fish", "octopus", "squid", "jellyfish", "starfish", "seahorse", "crab", "lobster", "shrimp", "clam", "oyster", "scallop", "snail", "slug", "butterfly", "moth", "bee", "wasp", "ant", "dragonfly" };
        static Random random = new Random();

        static void Main(string[] args)
        {
            int[] totalScore = [0];
            while (true)
            {
                Console.WriteLine("\nWord Guessing Game");
                Console.WriteLine($"current score is {totalScore.Max()} and you got {totalScore.Last()} points");
                Console.WriteLine("1. Play Game (easy mode)");
                Console.WriteLine("2. Play Game (medium mode)");
                Console.WriteLine("3. Play Game (hard mode)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Array.Resize(ref totalScore, totalScore.Length + 1);
                    totalScore[totalScore.GetUpperBound(0)] = PlayGame(12);
                }
                else if (choice == "2")
                {
                    Array.Resize(ref totalScore, totalScore.Length + 1);
                    totalScore[totalScore.GetUpperBound(0)] = PlayGame(6);
                }
                else if (choice == "3")
                {
                    Array.Resize(ref totalScore, totalScore.Length + 1);
                    totalScore[totalScore.GetUpperBound(0)] = PlayGame(3);
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static int PlayGame(int attemptsLeft)
        {
            string wordToGuess = words[random.Next(words.Length)];
            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            while (attemptsLeft > 0)
            {
                Console.WriteLine($"\nWord: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");

                char? guess = Console.ReadLine()?.ToLower()[0];
                bool correctGuess = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess && guess != null)
                    {
                        guessedWord[i] = (char)guess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    attemptsLeft--;
                    Console.WriteLine("Incorrect guess!");
                }

                if (new string(guessedWord) == wordToGuess)
                {
                    Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}");
                    return attemptsLeft;
                }
            }

            Console.WriteLine($"Game over! The word was: {wordToGuess}");
            return 0;
        }
    }
}
