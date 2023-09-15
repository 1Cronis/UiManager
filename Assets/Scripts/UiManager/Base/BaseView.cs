using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    private Canvas canvas;

    protected object Context { get; private set; }
    public bool IsVisible => canvas.enabled;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public abstract void UiEnable();

    public abstract void UiDisable();

    public void Show(object context = null)
    {
        Context = context;

        UiEnable();
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
        UiDisable();
    }
}
