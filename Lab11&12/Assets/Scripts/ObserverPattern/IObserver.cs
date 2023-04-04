public interface IObserver
{
    void OnNotify(ActionType action);
}

public enum ActionType
{
    Jump, Death, Health
}
