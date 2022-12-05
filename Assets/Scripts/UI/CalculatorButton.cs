using UnityEngine;
using UnityEngine.UI;
using System;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class CalculatorButton : MonoBehaviour
    {
        ///[Inject]
        //private ICalculatorPresenter _presenter;
        private Button _button;

        public event Action ButtonClicked;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(() => ButtonClicked?.Invoke());
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}
