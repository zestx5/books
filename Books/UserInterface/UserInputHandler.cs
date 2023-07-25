
namespace Books.UserInterface;

public static class UserInputHandler
{
    public static string GetStringInput(string prompt)
    {
        Console.WriteLine(prompt);

        string? output;
        do
        {
            output = Console.ReadLine();
        } while (string.IsNullOrEmpty(output));
        return output;
    }

    public static int GetIntegerInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    public static bool GetYesNoInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt + " (Yes/No): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Please enter either 'Yes' or 'No'.");
                continue;
            }

            if (input.Equals("Yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (input.Equals("No", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            Console.WriteLine("Invalid input. Please enter either 'Yes' or 'No'.");
        }
    }

}
