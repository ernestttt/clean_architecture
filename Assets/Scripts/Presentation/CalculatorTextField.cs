using UnityEngine;
using TMPro;
using System;

namespace Presentation
{
    [RequireComponent(typeof(TMP_InputField))]
    public class CalculatorTextField : MonoBehaviour
    {
        //[Inject]
        //private ICalculatorPresenter _presenter;
        private TMP_InputField _inputField;

        public event Action<string> ValueChanged;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Start()
        {
            _inputField.onValueChanged.AddListener(calcLine =>
            {
                ValueChanged?.Invoke(calcLine);
            });
        }

        public void UpdateText(string text)
        {
            _inputField.text = text;
        }

        private void OnDestroy()
        {
            _inputField.onValueChanged.RemoveAllListeners();
        }
    }
}

