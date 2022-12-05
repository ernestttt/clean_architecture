using System;
using UseCase;
using Zenject;
using UI;

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

        private ICalculatorUseCase _calculatorUseCase;

        private ISaveLoadUseCase _loadSaveUseCase;

        private CalculatorView _calculatorView;
        

        public CalculatorPresenter(ICalculatorUseCase calculatorUseCase, ISaveLoadUseCase loadSaveUseCase, CalculatorView calculatorView)
        {
            this._calculatorUseCase = calculatorUseCase;
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
            string calculatedValue = _calculatorUseCase.Calculate(CalculatorLine);
            CalculatorLine = calculatedValue;
        }
    }
}