using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Entities
{
    public class CalculatorEntity : ICalculatorEntity
    {
        private string _matchPattern;

        public CalculatorEntity(string pattern)
        {
            _matchPattern = pattern;
        }

        private int Calculate(int num1, int num2)
        {
            return num1 + num2;
        }

        public bool CheckLine(string line)
        {
            return Regex.IsMatch(line, _matchPattern);
        }

        public int CalculateEquation(string line)
        {
            string[] numbers = line.Split("+");
            int num1 = int.Parse(numbers[0]);
            int num2 = int.Parse(numbers[1]);
            return Calculate(num1, num2);
        }
    }
}
