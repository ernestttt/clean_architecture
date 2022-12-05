using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public interface ICalculatorEntity
    {
        public int CalculateEquation(string line);
        public bool CheckLine(string line);
    }
}
