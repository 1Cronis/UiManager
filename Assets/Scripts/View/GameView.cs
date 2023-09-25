using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : UIBaseView
{
    [SerializeField] Button closeButton;
    public override void UiEnable()
    {
        closeButton.onClick.AddListener(() => Test2UiEventsSystem.Invoke(new TestEventView<TypeView>(StateView.Hide,TypeView.GameView)));
    }
    public override void UiDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }

}
