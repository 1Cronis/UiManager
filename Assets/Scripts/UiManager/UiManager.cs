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
        Show(new TestEventView<TypeView>(StateView.Show,TypeView.LoadView,this));
        AddEvent();

    }

    private void OnDisable()
    {
        RemoveEvent();
    }

    //private void Show(TypeView typeView, object data = null)
    //{
    //    if (typeView != TypeView.None)
    //        View[(int)typeView - 1].prefab.Show();
    //}

    private void Show(TestEventView<TypeView> testEventView)
    {
        if (testEventView.tEnum != TypeView.None)
            View[(int)testEventView.tEnum - 1].prefab.Show();
    }

    private void Hide(TestEventView<TypeView> testEventView)
    {
        if (testEventView.tEnum != TypeView.None)
            View[(int)testEventView.tEnum - 1].prefab.Hide();
    }

    public void AllHide(TestEventView<TypeView> testEventView)
    {
        
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

        Test2UiEventsSystem.Subscribe(StateView.Show,Show);
        Test2UiEventsSystem.Subscribe(StateView.Hide,Hide);
        Test2UiEventsSystem.Subscribe(StateView.AllHide, AllHide);
        //Test2UiEventsSystem.Subscribe(StateView.AllHide,new Action(AllHide));

        //TestUiEventsSystem.Subscribe<TypeView>(StateView.Show, Show);
        //TestUiEventsSystem.Subscribe<TypeView>(StateView.Hide, Hide);
        //TestUiEventsSystem.Subscribe(StateView.AllHide, AllHide);

    }

    private void RemoveEvent()
    {
        Test2UiEventsSystem.Unsubscribe(StateView.Show, Show);
        Test2UiEventsSystem.Unsubscribe(StateView.Hide, Hide);
        Test2UiEventsSystem.Unsubscribe(StateView.AllHide, AllHide);

        //TestUiEventsSystem.Unsubscribe<TypeView>(StateView.Show, Show);
        //TestUiEventsSystem.Unsubscribe<TypeView>(StateView.Hide,Hide);
        //TestUiEventsSystem.Unsubscribe(StateView.AllHide, AllHide);

    }

   
}
