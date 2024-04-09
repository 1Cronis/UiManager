using UnityEngine;
using UnityEngine.UI;

public class InventoryView : UIBaseView
{
    [SerializeField] Button closeButton;
    public override void UiEnable()
    {
        closeButton.onClick.AddListener(() => UiEventsSystem.Invoke(new ViewEvent<TypeView>(StateView.Hide, TypeView.InventoryView)));

    }
    public override void UiDisable()
    {
        closeButton.onClick.RemoveAllListeners();
    }

    public override void initialize()
    {

    }
}
