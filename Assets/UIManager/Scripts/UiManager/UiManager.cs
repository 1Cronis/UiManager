using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiManager : UiManagerBase<TypeView>
{
#if UNITY_EDITOR

    [MenuItem("GameObject/UI/UiManager", false, 10)] // Создаем элемент меню в контекстном меню GameObject -> UI с названием "Create UiManager"
    static void CreateUiManager(MenuCommand menuCommand)
    {
        GameObject uiManager = new GameObject("UiManager");
        uiManager.AddComponent<UiManager>();
        GameObjectUtility.SetParentAndAlign(uiManager, menuCommand.context as GameObject);
        Undo.RegisterCreatedObjectUndo(uiManager, "Create " + uiManager.name);
    }

    [MenuItem("/UI/UiManager", true)]
    static bool ValidateCreateUiManager(MenuCommand menuCommand)
    {
        return menuCommand.context != null;
    }

#endif


    private void OnValidate()
    {
        if (gameObject.GetComponentInChildren<Canvas>() == null && rootCanvas == null)
            rootCanvas = AddCanvas();
        else
            rootCanvas = gameObject.GetComponentInChildren<Canvas>();

        if (gameObject.GetComponentInChildren<EventSystem>() == null)
            AddEventSystem();
    }

    private Canvas AddCanvas()
    {
        gameObject.name = "UiManager";
        var canvas = new GameObject();
        canvas.name = "Canvas";
        canvas.transform.parent = gameObject.transform;
        canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();

        return canvas.GetComponent<Canvas>();
    }

    private void AddEventSystem()
    {
        var eventSystem = new GameObject();
        eventSystem.name = "EventSystem";
        eventSystem.transform.parent = gameObject.transform;
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
    }


}
