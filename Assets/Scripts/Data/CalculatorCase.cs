using System.Linq;
using System.Text.RegularExpressions;

public class CalculatorCase
{
    private Calculator _calculator;
    private string _linePattern;
    private string _errorMessage;

    public CalculatorCase(Calculator calculator, string pattern, string errorMessage)
    {
        this._calculator = calculator;
        this._linePattern = pattern;
        this._errorMessage = errorMessage;
    }

    public string Calculate(string line)
    {
        if (CheckLine(line))
        {
            string[] numbers = ExtractNumbers(line);

            int firstNumber = int.Parse(numbers[0]);
            int secondNumber = int.Parse(numbers[1]);

            return _calculator.Calculate(firstNumber, secondNumber).ToString();
        }
        else
        {
            return _errorMessage;
        }
    }

    private string[] ExtractNumbers(string line)
    {
        return Regex.Matches(line, "\\d+").Select(a => a.Value).ToArray();
    }

    private bool CheckLine(string line)
    {
        return Regex.IsMatch(line, _linePattern);
    }
}
