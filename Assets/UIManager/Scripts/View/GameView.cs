using UnityEngine;
using UnityEngine.UI;

public class GameView : UIBaseView
{
    [SerializeField] Button closeButton;
    public override void UiEnable()
    {
        closeButton.onClick.AddListener(() => UiEventsSystem.Invoke(new ViewEvent<TypeView>(StateView.Hide,TypeView.GameView)));
    }
    public override void UiDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }

    public override void initialize()
    {
    }
}
