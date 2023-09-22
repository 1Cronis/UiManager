using Sirenix.OdinInspector;
using System;
using UnityEngine;
using System.Collections.Generic;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;

public class UiManager : MonoBehaviour
{
    [Header("Root Canvas"), HideLabel]
    [SerializeField] Canvas rootCanvas;
    //[Space(5)]
    [Header("Default View"), HideLabel]
    [SerializeField] TypeView defaultView;
    //[Space(5)]
    [Header("Prefab View"), HideLabel, TableList]
    [SerializeField] List<ViewData> View = new List<ViewData>();

    [Serializable]
    public class ViewData
    {
        [TableColumnWidth(60, Resizable = true)]
        public TypeView type = TypeView.None;

        [TableColumnWidth(200, Resizable = true)]
        public UIBaseView prefab = null;

        [TableColumnWidth(40, Resizable = true)]
        public int order = 0;
    }

    private void Awake()
    {
        InstantiateView();
        SortView();
        Show(defaultView);
        AddEvent();

    }

    private void OnDisable()
    {
        RemoveEvent();
    }

    private void Show(TypeView typeView, object data = null)
    {
        if (typeView != TypeView.None)
            View[(int)typeView - 1].prefab.Show();
    }

    private void Hide(TypeView typeView)
    {
        if (typeView != TypeView.None)
            View[(int)typeView - 1].prefab.Hide();
    }

    private void AllHide()
    {
        foreach (TypeView item in Enum.GetValues(typeof(TypeView)))
        {
            if (item != TypeView.None)
                Hide(item);
        }
    }

    private void InstantiateView()
    {
       
        for (int x = 0; x <  View.Count; x++)
        {
            var view = Instantiate( View[x].prefab, rootCanvas.transform);
            view.Order =  View[x].order;
            View[x].prefab = view;
        }
       
    }

    private void SortView()
    {
        var viewSort = new ViewData[View.Count + 1];
        for (int x = 0; x < View.Count; x++)
        {
            viewSort[(int)View[x].type] = View[x];
        }
        for (int y = 0, a = 1; y < View.Count; y++, a++)
        {
            View[y] = viewSort[a];
        }
    }

    private void AddEvent()
    {
        UiEventsSystem.Subscribe<TypeView, object>(StateView.Show, Show);
        UiEventsSystem.Subscribe<TypeView>(StateView.Hide, Hide);
        UiEventsSystem.Subscribe(StateView.AllHide, AllHide);

    }
    private void RemoveEvent()
    {
        UiEventsSystem.Unsubscribe<TypeView, object>(StateView.Show, Show);
        UiEventsSystem.Unsubscribe<TypeView>(StateView.Hide, Hide);
        UiEventsSystem.Unsubscribe(StateView.AllHide, AllHide);
    }

   
}
