using System;

namespace Presenter
{
    public interface ICalculatorPresenter
    {
        void Calculate();
        string CalculatorLine { get; set; }
        event Action CalculatorLineUpdated;
    }
}
