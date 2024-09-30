namespace WordGuessingGameGroup
{
    using System;

    class WordGuessingGame
    {
        static string[] words = { "apple", "banana", "cherry", "date", "elderberry", "grapes", "orange", "horse", "pig", "dog", "cat", "elephant", "giraffe", "lion", "tiger", "zebra", "monkey", "bear", "wolf", "fox", "rabbit", "deer", "squirrel", "mouse", "rat", "snake", "lizard", "frog", "toad", "turtle", "crocodile", "alligator", "dolphin", "whale", "shark", "fish", "octopus", "squid", "jellyfish", "starfish", "seahorse", "crab", "lobster", "shrimp", "clam", "oyster", "scallop", "snail", "slug", "butterfly", "moth", "bee", "wasp", "ant", "dragonfly"};
        static Random random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nWord Guessing Game");
                Console.WriteLine("1. Play Game (easy mode)");
                Console.WriteLine("2. Play Game (medium mode)");
                Console.WriteLine("3. Play Game (hard mode)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    PlayGame(12);
                }
                else if (choice == "2")
                {
                    PlayGame(6);
                }
                else if (choice == "3")
                {
                    PlayGame(3);
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

        static void PlayGame(int attemptsLeft)
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

                char guess = Console.ReadLine().ToLower()[0];
                bool correctGuess = false;

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
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
                    return;
                }
            }

            Console.WriteLine($"Game over! The word was: {wordToGuess}");
        }
    }
}
