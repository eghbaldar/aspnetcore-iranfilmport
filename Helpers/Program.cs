using Helpers.helperclasses.GeneralDetails;
using Helpers.helperclasses.TodoList;

static void Main()
{
    // Instantiate the classes
    GeneralDetailsHelper generalDetailsHelper = new GeneralDetailsHelper();
    TodoListHelper todoListHelper = new TodoListHelper();

    while (true)
    {
        Console.Clear(); // Clear the screen

        // Ask the user to choose a helper class or exit
        Console.WriteLine("Select a helper class:");
        Console.WriteLine("0: General Details (Strucutres,...)");
        Console.WriteLine("1: TodoList");

        // Read user input
        string input = Console.ReadLine();

        // Check if the user wants to exit
        if (input.ToLower() == "exit")
            break;

        // Parse the user input as an integer
        if (int.TryParse(input, out int choice))
        {
            // Perform actions based on user choice
            switch (choice)
            {
                case 0:
                    Console.Clear(); // Clear the screen
                    Console.WriteLine("General Details (Strucutres,...) Notes:");
                    DisplayNotes(generalDetailsHelper.Notes);
                    break;
                case 1:
                    Console.Clear(); // Clear the screen
                    Console.WriteLine("Todo List:");
                    DisplayNotes(todoListHelper.Notes);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            // Wait for user to go back to parent list
            Console.WriteLine("Press any key to go back to the parent list...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid input. Please try again.");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
    // Helper method to display notes
    void DisplayNotes(List<string> notes)
    {
        foreach (var note in notes)
        {
            Console.WriteLine(note);
        }
    }
}