using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseView : UIBaseView
{
    [SerializeField] Button prefabButton;
    //[SerializeField] Button closeButton;
    [SerializeField] float heightButton;

    private Button[] buttons;

    public override void UiEnable()
    {
        CreateButton();
        //closeButton.onClick.AddListener(() => UiEventsSystem.TriggerEvent(StateView.Hide, TypeView.LoadView));
    }

    public override void UiDisable()
    {
        Unsubscribe();
        //closeButton.onClick.RemoveAllListeners();
    }

    private void CreateButton()
    {
        
        int size = 0;
        int i = 0;
        foreach (var item in Enum.GetValues(typeof(TypeView)))
        {
            size = (int)item; 
        }

        buttons = new Button[size];
        var height = -heightButton * (buttons.Length / 2);

        foreach (TypeView item in Enum.GetValues(typeof(TypeView)))
        {
            if ((int)item != 0) 
            {
                var gameObj = Instantiate(prefabButton, transform);
                gameObj.GetComponentInChildren<TextMeshProUGUI>().text = $"{item}";
                var button = gameObj.GetComponent<Button>();
                var recTr = button.GetComponent<RectTransform>();
                recTr.anchoredPosition = new Vector3(0, height, 0);
                buttons[i] = button;
               
                height += heightButton;
                i++;
            }
        }
        Subscribe();
    }

    private void Subscribe()
    {
        int i = 0;
        foreach (TypeView item in Enum.GetValues(typeof(TypeView)))
        {
            if ((int)item != 0)
            {
                buttons[i].onClick.AddListener( () => UiEventsSystem.TriggerEvent(StateView.Show, item, this));
                i++;
            }
        }
        
    }

    private void Unsubscribe()
    {
        int i = 0;
        foreach (TypeView item in Enum.GetValues(typeof(TypeView)))
        {
            if ((int)item != 0)
            {
                buttons[i].onClick.RemoveAllListeners();
                i++;
            }
        }
    }
}
