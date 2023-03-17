using Domain;

namespace Presentation
{
    public class CalculatorPresenter : IUpdatedLine
    {
        private LoadSaveUseCase _loadSaveUseCase;
        private ICalculatorView _calculatorView;
        private CalculatorCase _calculator;
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

        public CalculatorPresenter(CalculatorCase calculator, LoadSaveUseCase loadSaveUseCase,
            ICalculatorView calculatorView)
        {
            this._calculator = calculator;
            this._loadSaveUseCase = loadSaveUseCase;
            _loadSaveUseCase.SetUpdatedLine(this);
            this._calculatorView = calculatorView;

            _loadSaveUseCase.StartOfApp();

            _calculatorView.OnButtonClicked += Calculate;
            _calculatorView.OnLineChanged += (line) =>
            {
                loadSaveUseCase.UpdateLine(line);
                UpdatedLine = line;
            };
        }

        private void Calculate()
        {
            string calculatedValue = _calculator.Calculate(UpdatedLine);
            UpdatedLine = calculatedValue;
        }
    }
}