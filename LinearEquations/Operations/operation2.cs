using System;
using System.Globalization;
using System.Text;

namespace LinearEquations.Operations
{
    public class operation2
    {
        public static string calculate(string slopeInterceptForm)
        {
            // Remove spaces and convert to lowercase for easier parsing
            slopeInterceptForm = slopeInterceptForm.Replace(" ", "").ToLower();

            // Parse the slope-intercept form (y = mx + b)
            try
            {
                // Extract m (slope) and b (y-intercept)
                int equalIndex = slopeInterceptForm.IndexOf('=');
                if (equalIndex == -1)
                    throw new ArgumentException("Invalid equation format. Must be in the form 'y = mx + b'");

                string rightSide = slopeInterceptForm.Substring(equalIndex + 1);
                
                // Find the x term and the constant term
                int xIndex = rightSide.IndexOf('x');
                if (xIndex == -1)
                    throw new ArgumentException("Equation must contain an 'x' term");

                // Extract slope (m)
                string slopeStr = rightSide.Substring(0, xIndex);
                if (string.IsNullOrEmpty(slopeStr) || slopeStr == "+")
                    slopeStr = "1";
                else if (slopeStr == "-")
                    slopeStr = "-1";
                double slope = double.Parse(slopeStr, CultureInfo.InvariantCulture);

                // Extract y-intercept (b)
                string interceptStr = rightSide.Substring(xIndex + 1);
                if (string.IsNullOrEmpty(interceptStr))
                    interceptStr = "0";
                double intercept = string.IsNullOrEmpty(interceptStr) ? 0 : double.Parse(interceptStr, CultureInfo.InvariantCulture);

                // Convert to standard form (Ax + By + C = 0)
                double A = -slope;
                double B = 1;
                double C = -intercept;

                // Format the standard form equation
                var standardForm = new StringBuilder();
                
                if (A != 0)
                {
                    if (A == 1)
                        standardForm.Append("x");
                    else if (A == -1)
                        standardForm.Append("-x");
                    else
                        standardForm.Append($"{A.ToString(CultureInfo.InvariantCulture)}x");
                }

                if (B != 0)
                {
                    if (B > 0 && standardForm.Length > 0)
                        standardForm.Append("+");
                    if (B == 1)
                        standardForm.Append("y");
                    else if (B == -1)
                        standardForm.Append("-y");
                    else
                        standardForm.Append($"{B.ToString(CultureInfo.InvariantCulture)}y");
                }

                if (C != 0)
                {
                    if (C > 0)
                        standardForm.Append("+");
                    standardForm.Append(C.ToString(CultureInfo.InvariantCulture));
                }

                standardForm.Append("=0");

                return standardForm.ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid slope-intercept form. Please use the format 'y = mx + b'", ex);
            }
        }
    }
}