using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        
        while (playAgain.ToLower() == "yes")
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101); 
            
            int guessCount = 0;
            int guess = 0;
            
            Console.WriteLine("I'm thinking of a number between 1 and 100!");
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    
                    Console.WriteLine($"It took you {guessCount} guesses!");
                }
            }
            
            Console.Write("Would you like to play again? (yes/no) ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }
        
        Console.WriteLine("Thanks for playing!");
    }
}
