/*
* EXCEEDING REQUIREMENTS REPORT:
* 1. No Repeat Prompts/Questions: I have enhanced the Reflection and Listing activities
* to ensure that a random prompt or question is not repeated until all options in the
* list have been used at least once in the current session. This is achieved by
* creating a temporary copy of the prompt/question list and removing items as they
*e   are used. When the temporary list is empty, it is refilled from the master list.
* 2. Enhanced Listing Activity Input: The listing activity now gives a clear "> "
* prompt for each item the user enters, making the user interface cleaner and more
* intuitive.
* 3. Code Structure and Readability: The code is organized into separate, well-documented
* classes following OOP principles, making it easy to understand, maintain, and extend
* with new activities in the future.
*/

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

}
