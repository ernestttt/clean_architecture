using System;

public interface ICalculatorView
{
    public event Action OnButtonClicked;
    public event Action<string> OnLineChanged;

    public void UpdateLine(string line);
}
