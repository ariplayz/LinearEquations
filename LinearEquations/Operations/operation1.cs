using System.Globalization;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace LinearEquations.Operations;

public class operation1
{
    public double Slope { get; private set; }
    public double YIntercept { get; private set; }
    public string SlopeInterceptForm { get; private set; }
    public string StandardForm { get; private set; }
    public double A { get; private set; } // For standard form (Ax + By = C)
    public double B { get; private set; } // For standard form
    public double C { get; private set; } // For standard form

    public static operation1 calculate(double x1, double y1, double x2, double y2)
    {
        operation1 result = new operation1();

        // Check if it's a vertical line
        if (x1 == x2)
        {
            throw new ArgumentException("Vertical line detected. Slope is undefined (infinite).");
        }

        // Calculate slope
        result.Slope = (y2 - y1) / (x2 - x1);

        // Calculate y-intercept
        result.YIntercept = y1 - (result.Slope * x1);

        // Create slope-intercept form (y = mx + b)
        result.SlopeInterceptForm = $"y = {result.Slope:0.##}x + {result.YIntercept:0.##}";

        // Convert to standard form (Ax + By = C)
        // From y = mx + b to -mx + y = b
        // Multiply everything by the denominator of slope to eliminate fractions
        double lcm = 1;
        string slopeStr = result.Slope.ToString(CultureInfo.InvariantCulture);
        if (slopeStr.Contains('.'))
        {
            string[] parts = slopeStr.Split('.');
            if (parts.Length > 1)
            {
                lcm = Math.Pow(10, parts[1].Length);
            }
        }

        result.A = -result.Slope * lcm;
        result.B = 1 * lcm;
        result.C = result.YIntercept * lcm;

        // Create standard form string (Ax + By = C)
        result.StandardForm = $"{result.A:0.##}x + {result.B:0.##}y = {result.C:0.##}";

        return result;
    }
}