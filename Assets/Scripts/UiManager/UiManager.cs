
public class UiManager : UiManagerBase<TypeView>
{
   /* [Header("Root Canvas"), HideLabel]
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
        Show(new TestEventView<TScrinEnum>(StateView.Show, defaultView, this));
        AddEvent();

    }

    private void Show(TestEventView<TScrinEnum> testEventView)
    {
        View[testEventView.tEnum.GetHashCode() - 1].prefab.Show();
    }
    private void Hide(TestEventView<TScrinEnum> testEventView)
    {
        View[testEventView.tEnum.GetHashCode() - 1].prefab.Hide();
    }
    public void AllHide()
    {

    }
    private void InstantiateView()
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
            viewSort[(int)View[x].type] = View[x];
        }
        for (int y = 0, a = 1; y < View.Count; y++, a++)
        {
            View[y] = viewSort[a];
        }
    }

    private void AddEvent()
    {
        allHideAction = e => AllHide();
        UiEventsSystem.Subscribe<TScrinEnum>(StateView.Show, Show);
        UiEventsSystem.Subscribe<TScrinEnum>(StateView.Hide, Hide);
        UiEventsSystem.Subscribe(StateView.AllHide, allHideAction);

        //Test2UiEventsSystem.Subscribe(StateView.AllHide,new Action(AllHide));

        //TestUiEventsSystem.Subscribe<TypeView>(StateView.Show, Show);
        //TestUiEventsSystem.Subscribe<TypeView>(StateView.Hide, Hide);
        //TestUiEventsSystem.Subscribe(StateView.AllHide, AllHide);

    }

    private void RemoveEvent()
    {
        UiEventsSystem.Unsubscribe<TScrinEnum>(StateView.Show, Show);
        UiEventsSystem.Unsubscribe<TScrinEnum>(StateView.Hide, Hide);
        UiEventsSystem.Unsubscribe(StateView.AllHide, allHideAction);

        //TestUiEventsSystem.Unsubscribe<TypeView>(StateView.Show, Show);
        //TestUiEventsSystem.Unsubscribe<TypeView>(StateView.Hide,Hide);
        //TestUiEventsSystem.Unsubscribe(StateView.AllHide, AllHide);

    }*/
}
