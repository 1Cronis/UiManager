using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TestEventView<TEnum>
{
    public TEnum tEnum;
    public StateView stateView;
    public object data;

    public TestEventView(StateView stateView, TEnum tEnum) : this()
    {
        this.stateView = stateView;
        this.tEnum = tEnum;
    }
   
    public TestEventView(StateView stateView, TEnum tEnum, object data)
    {
        this.stateView = stateView;
        this.tEnum = tEnum;
        this.data = data;
    }
}
