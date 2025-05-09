using LinearEquations.Operations;

namespace LinearEquations;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "1";
        int operation;

        
        Console.WriteLine("This is a calculator for Linear Equations in Algebra 1.");
        Console.WriteLine("Select one of the following operations:");
        Console.WriteLine("1. Take points and give equations, slope, and intercept.");
        Console.WriteLine("2. Take slope intercept form and give standard form.");
        Console.WriteLine("3. Take standard form and give slope intercept form.");
        Console.WriteLine("4. Take point and slope and give equations and intercept.");
        Console.WriteLine("5. Take point and Y intercept and give equations and slope.");
        
        Console.WriteLine("Input Operation: ");
        userInput = Console.ReadLine();
        
        operation = ConvertToNumber(userInput);

        switch (operation)
        {
            case 1:
                try
                {
                    Console.WriteLine("Enter x1: ");
                    double x1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter y1: ");
                    double y1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter x2: ");
                    double x2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter y2: ");
                    double y2 = Convert.ToDouble(Console.ReadLine());
        
                    var result = operation1.calculate(x1, y1, x2, y2);
                    Console.WriteLine($"Slope: {result.Slope}");
                    Console.WriteLine($"Y-Intercept: {result.YIntercept}");
                    Console.WriteLine($"Slope-Intercept Form: {result.SlopeInterceptForm}");
                    Console.WriteLine($"Standard Form: {result.StandardForm}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers.");
                } 
                break;
                
        }
        
    }

    public static int ConvertToNumber(string input)
    {
        // Filter out any non-digit characters
        string numbersOnly = new string(input.Where(char.IsDigit).ToArray());
    
        // Try to parse the filtered string to an integer
        if (int.TryParse(numbersOnly, out int result))
        {
            return result;
        }
    
        // Return 0 if parsing fails
        return 0;
    }
    
}