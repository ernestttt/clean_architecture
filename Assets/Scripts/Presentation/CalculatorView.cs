using UnityEngine;
using System;

namespace Presentation
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private CalculatorButton _button;
        [SerializeField] private CalculatorTextField _textField;

        public event Action OnButtonClicked;
        public event Action<string> OnLineChanged;

        private void Start()
        {
            _button.ButtonClicked += () => OnButtonClicked?.Invoke(); // _presenter.Calculate;
            _textField.ValueChanged += line => OnLineChanged?.Invoke(line); //_presenter.CalculatorLine = line;
        }

        public void UpdateLine(string line) => _textField.UpdateText(line);
    }
}

