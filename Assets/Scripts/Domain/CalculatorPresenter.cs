using System;
using Data;
using Zenject;
using Presentation;

namespace Presenter
{
    public class CalculatorPresenter : IInitializable, IDisposable
    {
        private string _calculatorLine; 
        private string CalculatorLine 
        {
            get => _calculatorLine;
            set
            {
                _calculatorLine = value;
                _calculatorView?.UpdateLine(CalculatorLine);
            }
        }

        private ICalculator _calculator;

        private IDataManager _loadSaveUseCase;

        private CalculatorView _calculatorView;
        

        public CalculatorPresenter(ICalculator calculator, IDataManager loadSaveUseCase, CalculatorView calculatorView)
        {
            this._calculator = calculator;
            this._loadSaveUseCase = loadSaveUseCase;
            this._calculatorView = calculatorView;
        }

        public void Initialize()
        {
            string loadedValue = _loadSaveUseCase.Load();
            CalculatorLine = loadedValue;

            _calculatorView.OnButtonClicked += Calculate;
            _calculatorView.OnLineChanged += (line) => CalculatorLine = line;
        }

        public void Dispose()
        {
            _loadSaveUseCase.Save(CalculatorLine);
        }

        private void Calculate()
        {
            string calculatedValue = _calculator.Calculate(CalculatorLine);
            CalculatorLine = calculatedValue;
        }
    }
}