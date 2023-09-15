using Sirenix.OdinInspector;
using System;
using UnityEngine;
using System.Collections.Generic;

public class UiManager : MonoBehaviour
{
    [SerializeField] Canvas rootCanvas;
    [Space(20)]
    [TableList]
    [SerializeField] List<ViewData> View = new List<ViewData>();


    [Serializable]
    public class ViewData
    {
        [TableColumnWidth(60, Resizable = true)]
        public TypeView type = TypeView.None;

        [TableColumnWidth(200, Resizable = true)]
        public BaseView prefab;

        [TableColumnWidth(40, Resizable = true)]
        public int order;
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
