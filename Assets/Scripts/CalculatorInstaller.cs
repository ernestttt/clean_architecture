using System.Collections;
using UnityEngine;
using Data;
using Presentation;
using Domain;

public class CalculatorInstaller : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    [SerializeField] private string _pattern;
    [SerializeField] private CalculatorView _calculatorView;
    [SerializeField] private string _errorMessage = "Error";

    private IEnumerator Start()
    {
        yield return null;
        Calculator calculator = new Calculator();
        CalculatorCase calculatorCase = new CalculatorCase(calculator, _pattern, _errorMessage);
        PlayerPrefsManager playerPrefsManager = new PlayerPrefsManager();
        DataCommunicator communicator = new DataCommunicator(_saveKey, playerPrefsManager);
        LoadSaveUseCase loadSaveUseCase = new LoadSaveUseCase(communicator);
        CalculatorPresenter presenter = new CalculatorPresenter(calculatorCase, loadSaveUseCase, _calculatorView);
        
    }
}
