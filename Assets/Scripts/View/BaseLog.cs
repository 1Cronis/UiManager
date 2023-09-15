using UnityEngine;
using UnityEngine.UI;

public class BaseLog : BaseView
{
    [SerializeField] GameObject prefabButton;
    [SerializeField] float sizeYButton;

    public Button[] buttons;

    public override void UiEnable()
    {
        CreateButton();
    }

    public override void UiDisable()
    {
       
    }

    private void CreateButton()
    {
        
        var height = -sizeYButton * (buttons.Length / 2);

        for (int i = 0; i < buttons.Length; i++)
        {
            var gameObj = Instantiate(prefabButton, transform);
            var button = gameObj.GetComponent<Button>();
            var recTr = button.GetComponent<RectTransform>();
            recTr.anchoredPosition = new Vector3(0,height,0);
            buttons[i] = button;
            height += sizeYButton;
        }
    }

  
}
