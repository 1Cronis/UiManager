using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationView : UIBaseView
{
    [SerializeField] Button closeButton;
    public override void UiEnable()
    {
        closeButton.onClick.AddListener(() => UiEventsSystem.TriggerEvent(StateView.Hide, TypeView.AnimationView));
    }
    public override void UiDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }

}
