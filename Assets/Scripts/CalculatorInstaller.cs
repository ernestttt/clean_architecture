using UnityEngine;
using Zenject;
using Data;
using Presenter;
using Presentation;


public class CalculatorInstaller : MonoInstaller<CalculatorInstaller>
{
    [SerializeField] private string _saveKey;
    [SerializeField] private string _pattern;
    [SerializeField] private CalculatorView _calculatorView;

    public override void InstallBindings()
    {
        var dataManager = new DataManager(_saveKey);
        var calculator = new Data.Calculator(_pattern);
        Container.BindInterfacesAndSelfTo<CalculatorPresenter>().AsSingle().WithArguments(calculator, dataManager, _calculatorView);
        SignalBusInstaller.Install(Container);
    }
}
