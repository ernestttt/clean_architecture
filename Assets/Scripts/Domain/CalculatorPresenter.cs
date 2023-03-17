using System;
using Data;
using Zenject;
using Presentation;

namespace Presenter
{
    public class CalculatorPresenter : IInitializable, IDisposable, IUpdatedLine
    {
        private string _updatedLine; 
        public string UpdatedLine 
        {
            get => _updatedLine;
            set
            {
                _updatedLine = value;
                _calculatorView?.UpdateLine(UpdatedLine);
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
            UpdatedLine = loadedValue;

            _calculatorView.OnButtonClicked += Calculate;
            _calculatorView.OnLineChanged += (line) => UpdatedLine = line;
        }

        public void Dispose()
        {
            _loadSaveUseCase.Save(UpdatedLine);
        }

        private void Calculate()
        {
            string calculatedValue = _calculator.Calculate(UpdatedLine);
            UpdatedLine = calculatedValue;
        }
    }
}