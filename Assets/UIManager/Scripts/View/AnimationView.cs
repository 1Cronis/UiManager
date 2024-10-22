using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationView : UIBaseView
{
    [SerializeField] Button closeButton;
    public override void UiEnable()
    {
        closeButton.onClick.AddListener(() => UiEventsSystem.Invoke(new ViewEvent<TypeView>(StateView.Hide, TypeView.AnimationView)));
    }
    public override void UiDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }

    public override void initialize()
    {
    }
}
