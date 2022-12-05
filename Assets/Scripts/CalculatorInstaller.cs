using UnityEngine;
using Zenject;
using Entities;
using UseCase;
using Presenter;

public class CalculatorInstaller : MonoInstaller<CalculatorInstaller>
{
    [SerializeField] private string _saveKey;
    [SerializeField] private string _pattern;

    public override void InstallBindings()
    {
        var saveLoadEntity = new SaveLoadEntity();
        var saveLoadUseCase = new SaveLoadUseCase(_saveKey, saveLoadEntity);
        var calculatorEntity = new CalculatorEntity(_pattern);
        var calculatorUseCase = new CalculatorUseCase(calculatorEntity);

        Container.BindInterfacesAndSelfTo<CalculatorPresenter>().AsSingle().WithArguments(calculatorUseCase, saveLoadUseCase);
        

        SignalBusInstaller.Install(Container);
    }
}
