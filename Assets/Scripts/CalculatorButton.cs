using UnityEngine;
using UnityEngine.UI;
using System;

namespace Presentation
{
    [RequireComponent(typeof(Button))]
    public class CalculatorButton : MonoBehaviour
    {
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
