using UnityEngine;

[RequireComponent(typeof(Canvas))]
public abstract class UIBaseView : MonoBehaviour
{
    private Canvas canvas;

    protected object Data { get; private set; }

    public bool IsVisible => canvas.enabled;

    public int Order 
    {
        get{ return canvas.sortingOrder; }
        set { canvas.sortingOrder = value; }
    }

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.enabled = false;
        initialize();
    }

    public abstract void UiEnable();

    public abstract void UiDisable();

    public abstract void initialize();

    public void Show(object data = null)
    {
        Data = data;

        UiEnable();
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
        UiDisable();
    }
}

