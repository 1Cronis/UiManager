using Sirenix.OdinInspector;
using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class UiManagerBase<TViewEnum> : MonoBehaviour
    where TViewEnum : System.Enum
{
    [Header("Root Canvas"), HideLabel]
    [SerializeField] protected Canvas rootCanvas;
    [Header("Default View"), HideLabel]
    [SerializeField] TViewEnum defaultView;
    [Header("Give the ScriptsView names the same as the TypeView")]
    [Header("Prefab View"), HideLabel, TableList]
    [SerializeField] List<ViewData> View = new List<ViewData>();

    [Serializable]
    private class ViewData
    {
        [TableColumnWidth(60, Resizable = true), GUIColor("color")]
        public TViewEnum type;

        [TableColumnWidth(200, Resizable = true)]
        public UIBaseView prefab = null;

        [TableColumnWidth(40, Resizable = true)]
        public int order = 0;

        private Color color
        {
            get
            {
                if (prefab != null)
                {
                    if (type.ToString() == prefab.GetType().Name)
                        return Color.green;
                    else
                        return Color.red;
                }
                return Color.white;
            }
        }

    }
    private System.Action<ViewEvent<TViewEnum>> allHideAction;

    private void Awake()
    {
        InitPrefabView();
        SortView();
        AddEvent();
        Show(new ViewEvent<TViewEnum>(StateView.Show, defaultView, this));
    }

    private void OnDisable()
    {
        RemoveEvent();
    }

    private void Show(ViewEvent<TViewEnum> viewEvent)
    {
        if (View[viewEvent.tEnum.GetHashCode() - 1] == null)
            return;

        View[viewEvent.tEnum.GetHashCode() - 1].prefab.Show();
    }

    private void Hide(ViewEvent<TViewEnum> viewEvent)
    {
        if (View[viewEvent.tEnum.GetHashCode() - 1] == null)
            return;

        View[viewEvent.tEnum.GetHashCode() - 1].prefab.Hide();
    }

    private void AllHide()
    {
        foreach (var item in System.Enum.GetValues(typeof(TViewEnum)))
        {
            View[item.GetHashCode()].prefab.Hide();
        }
    }

    private void InitPrefabView()
    {
        for (int x = 0; x < View.Count; x++)
        {
            var view = Instantiate(View[x].prefab, rootCanvas.transform);
            view.Order = View[x].order;
            View[x].prefab = view;
        }
    }

    private void SortView()
    {
        var viewSort = new ViewData[View.Count + 1];
        for (int x = 0; x < View.Count; x++)
        {
            if (viewSort[View[x].type.GetHashCode()] != null)
            {
                Debug.LogError($"({View[x].type})" +
                    $" the object has already been added to the list");
            }
            else
            {
                viewSort[View[x].type.GetHashCode()] = View[x];
            }
                
        }

        for (int y = 0, a = 1; y < View.Count; y++, a++)
        {
            View[y] = viewSort[a];
            
        }

    }

    private void AddEvent()
    {
        allHideAction = e => AllHide();
        UiEventsSystem.Subscribe<TViewEnum>(StateView.Show,Show);
        UiEventsSystem.Subscribe<TViewEnum>(StateView.Hide,Hide);
        UiEventsSystem.Subscribe(StateView.AllHide, allHideAction);
    }

    private void RemoveEvent()
    {
        UiEventsSystem.Unsubscribe<TViewEnum>(StateView.Show, Show);
        UiEventsSystem.Unsubscribe<TViewEnum>(StateView.Hide, Hide);
        UiEventsSystem.Unsubscribe(StateView.AllHide, allHideAction);
    }


}


