using UnityEngine;
using Zenject;
using Entities;
using UseCase;
using Presenter;
using UI;

public class CalculatorInstaller : MonoInstaller<CalculatorInstaller>
{
    [SerializeField] private string _saveKey;
    [SerializeField] private string _pattern;
    [SerializeField] private CalculatorView _calculatorView;

    public override void InstallBindings()
    {
        var saveLoadEntity = new SaveLoadEntity();
        var saveLoadUseCase = new SaveLoadUseCase(_saveKey, saveLoadEntity);
        var calculatorEntity = new CalculatorEntity(_pattern);
        var calculatorUseCase = new CalculatorUseCase(calculatorEntity);

        Container.BindInterfacesAndSelfTo<CalculatorPresenter>().AsSingle().WithArguments(calculatorUseCase, saveLoadUseCase, _calculatorView);
        

        SignalBusInstaller.Install(Container);
    }
}
