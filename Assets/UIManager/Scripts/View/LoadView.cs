using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadView : UIBaseView
{
    [SerializeField] Image image;
    //[SerializeField] Button closeButton;
    public override void UiEnable()
    {
        StartCoroutine(StartLoad());
        //closeButton.onClick.AddListener(() => UiEventsSystem.TriggerEvent(StateView.Hide, TypeView.LoadView));
    }

    public override void UiDisable()
    {
        //closeButton.onClick.RemoveAllListeners();
    }

    private IEnumerator StartLoad()
    {
        image.fillAmount = 0f;
        while (image.fillAmount != 1f)
        {
            image.fillAmount += 0.01f;
            yield return null;
        }

        UiEventsSystem.Invoke(new ViewEvent<TypeView>(StateView.Hide, TypeView.LoadView, this));
        UiEventsSystem.Invoke(new ViewEvent<TypeView>(StateView.Show, TypeView.BaseView, this));
    }

    public override void initialize()
    {

    }
}
