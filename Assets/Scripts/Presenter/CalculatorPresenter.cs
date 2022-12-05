using System;
using UseCase;
using Zenject;

namespace Presenter
{
    public class CalculatorPresenter : ICalculatorPresenter, IInitializable, IDisposable
    {
        public string CalculatorLine { get; set; }

        public event Action CalculatorLineUpdated;

        private ICalculatorUseCase _calculatorUseCase;

        private ISaveLoadUseCase _loadSaveUseCase;
        

        public CalculatorPresenter(ICalculatorUseCase calculatorUseCase, ISaveLoadUseCase loadSaveUseCase)
        {
            this._calculatorUseCase = calculatorUseCase;
            this._loadSaveUseCase = loadSaveUseCase;
        }


        public void Initialize()
        {
            string loadedValue = _loadSaveUseCase.Load();
            UpdateCalculatorLine(loadedValue);
        }

        public void Dispose()
        {
            _loadSaveUseCase.Save(CalculatorLine);
        }

        public void Calculate()
        {
            string calculatedValue = _calculatorUseCase.Calculate(CalculatorLine);
            UpdateCalculatorLine(calculatedValue);
        }

        private void UpdateCalculatorLine(string value)
        {
            CalculatorLine = value;
            CalculatorLineUpdated?.Invoke();
        }
    }
}