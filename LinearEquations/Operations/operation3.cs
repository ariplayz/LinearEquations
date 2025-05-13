using System;

namespace LinearEquations.Operations;

public class operation3
{
    public static string calculate(string standardForm)
    {
        // Remove spaces and ensure consistent format
        standardForm = standardForm.Replace(" ", "");

        // Parse the standard form (Ax + By = C)
        try
        {
            // Split equation at equals sign
            string[] parts = standardForm.Split('=');
            if (parts.Length != 2)
                throw new ArgumentException("Invalid standard form. Must be in the form 'Ax + By = C'");

            string leftSide = parts[0];
            double C = double.Parse(parts[1]);

            // Find coefficients A and B
            int xIndex = leftSide.IndexOf('x');
            int yIndex = leftSide.IndexOf('y');
            
            if (xIndex == -1 || yIndex == -1)
                throw new ArgumentException("Equation must contain both 'x' and 'y' terms");

            // Extract A coefficient
            string aStr = leftSide.Substring(0, xIndex);
            if (string.IsNullOrEmpty(aStr) || aStr == "+")
                aStr = "1";
            else if (aStr == "-")
                aStr = "-1";
            double A = double.Parse(aStr);

            // Extract B coefficient
            string bStr = leftSide.Substring(xIndex + 1, yIndex - (xIndex + 1));
            if (string.IsNullOrEmpty(bStr) || bStr == "+")
                bStr = "1";
            else if (bStr == "-")
                bStr = "-1";
            double B = double.Parse(bStr);

            // Convert to slope-intercept form (y = mx + b)
            // From Ax + By = C to y = (-A/B)x + (C/B)
            if (B == 0)
                throw new ArgumentException("B coefficient cannot be zero (vertical line)");

            double slope = -A / B;
            double yIntercept = C / B;

            // Format the slope-intercept form
            return $"y = {slope:0.##}x + {yIntercept:0.##}";
        }
        catch (Exception ex) when (!(ex is ArgumentException))
        {
            throw new ArgumentException("Invalid standard form. Please use the format 'Ax + By = C'", ex);
        }
    }
}