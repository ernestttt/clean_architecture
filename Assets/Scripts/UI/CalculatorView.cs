using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Presenter;

namespace UI
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private CalculatorButton _button;
        [SerializeField] private CalculatorTextField _textField;

        [Inject] private ICalculatorPresenter _presenter;


        private void Start()
        {
            _button.ButtonClicked += _presenter.Calculate;
            _textField.ValueChanged += line => _presenter.CalculatorLine = line;
            _presenter.CalculatorLineUpdated += () => _textField.UpdateText(_presenter.CalculatorLine);

            _textField.UpdateText(_presenter.CalculatorLine);
        }
    }
}

