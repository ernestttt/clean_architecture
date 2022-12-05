using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField _field;
    [SerializeField] private Button _button;

    private string _pattern = "\\d+\\+\\d+";
    private string _saveKey = "save";

    private void Start()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            _field.text = PlayerPrefs.GetString(_saveKey);
        }

        _button.onClick.AddListener(() =>
        {
            if (Regex.IsMatch(_field.text, _pattern))
            {
                string[] numbers = _field.text.Split("+");
                int firstNumber = int.Parse(numbers[0]);
                int secondNumber = int.Parse(numbers[1]);
                _field.text = (firstNumber + secondNumber).ToString();
            }
            else
            {
                _field.text = "Error";
            }
        });
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(_saveKey, _field.text);
    }
}
