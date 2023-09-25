using System.Collections.Generic;

public static class TestDictionary<T1>
{
    

    public static readonly Dictionary<StateView, System.Action> eventNoParam = new();
    public static readonly Dictionary<StateView, System.Action<T1>> eventOneParam = new();
    public static readonly Dictionary<StateView, System.Action<T1, object>> eventTwoParam = new();

}
