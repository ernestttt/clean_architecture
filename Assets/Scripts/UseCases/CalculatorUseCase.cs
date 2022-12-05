using Entities;

namespace UseCase
{
    public class CalculatorUseCase : ICalculatorUseCase
    {
        private ICalculatorEntity _calculatorEntity;

        public CalculatorUseCase(ICalculatorEntity calculatorEntity)
        {
            _calculatorEntity = calculatorEntity;
        }

        public string Calculate(string value)
        {
            if (!_calculatorEntity.CheckLine(value))
            {
                return "Error";
            }

            int result = _calculatorEntity.CalculateEquation(value);
            return result.ToString();
        }
    }
}