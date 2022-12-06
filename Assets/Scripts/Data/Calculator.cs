using System.Text.RegularExpressions;

namespace Data
{
    public class Calculator : ICalculator
    {
        private string _matchPattern;

        public Calculator(string matchPattern)
        {
            _matchPattern = matchPattern;
        }

        public string Calculate(string value)
        {
            if (!CheckLine(value))
            {
                return "Error";
            }

            int result = CalculateEquation(value);
            return result.ToString();
        }

        private int CalculateEquation(string line)
        {
            string[] numbers = line.Split("+");
            int num1 = int.Parse(numbers[0]);
            int num2 = int.Parse(numbers[1]);
            return Calculate(num1, num2);
        }

        private int Calculate(int num1, int num2)
        {
            return num1 + num2;
        }

        private bool CheckLine(string line)
        {
            return Regex.IsMatch(line, _matchPattern);
        }
    }
}