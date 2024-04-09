public struct ViewEvent<TEnum>
    where TEnum : System.Enum
{
    public TEnum tEnum;
    public StateView stateView;
    public object data;

    public ViewEvent(StateView stateView, TEnum tEnum, object data = null)
    {
        this.stateView = stateView;
        this.tEnum = tEnum;
        this.data = data;
    }
}
