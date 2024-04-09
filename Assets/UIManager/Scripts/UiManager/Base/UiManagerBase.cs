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
        SortView();
        InitPrefabView();
        AddEvent();
        Show(new ViewEvent<TViewEnum>(StateView.Show, defaultView, this));
    }

    private void OnDisable()
    {
        RemoveEvent();
    }

    private void Show(ViewEvent<TViewEnum> viewEvent)
    {
        var number = viewEvent.tEnum.GetHashCode() - 1;

        //if (View[viewEvent.tEnum.GetHashCode() - 1].prefab == null)
        if (number <= View.Count && number >= 0)
            View[number].prefab.Show();
        else
        {
            Debug.LogError($"({viewEvent.tEnum.ToString()}) this view is not present");
        }

    }

    private void Hide(ViewEvent<TViewEnum> viewEvent)
    {
        var number = viewEvent.tEnum.GetHashCode() - 1;

        if (number <= View.Count && number >= 0)
            View[number].prefab.Hide();
        else
        {
            Debug.LogError($"({viewEvent.tEnum.ToString()}) this view is not present");
        }


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
        CheckForNullList();

        var viewSort = new ViewData[View.Count];
        var index = 0;
        for (int x = 0; x < View.Count; x++)
        {
            index = View[x].type.GetHashCode() - 1;

            if (viewSort[index] != null)
            {
                Debug.LogError($"({View[x].type})" +
                        $" the object has already been added to the list");
                View.RemoveAt(x);
            }
            else
                viewSort[index] = View[x];
        }

        CheckForNullList();

        for (int y = 0, a = 1; y < View.Count; y++, a++)
        {
            View[y] = viewSort[y];
        }

    }

    private void CheckForNullList()
    {
        for (int s = 0; s < View.Count; s++)
        {
            if (View[s].prefab == null)
            {
                View.RemoveAt(s);
            }
        }
    }


    private void AddEvent()
    {
        allHideAction = action => AllHide();
        UiEventsSystem.Subscribe<TViewEnum>(StateView.Show, Show);
        UiEventsSystem.Subscribe<TViewEnum>(StateView.Hide, Hide);
        UiEventsSystem.Subscribe(StateView.AllHide, allHideAction);
    }

    private void RemoveEvent()
    {
        UiEventsSystem.Unsubscribe<TViewEnum>(StateView.Show, Show);
        UiEventsSystem.Unsubscribe<TViewEnum>(StateView.Hide, Hide);
        UiEventsSystem.Unsubscribe(StateView.AllHide, allHideAction);
    }


}


