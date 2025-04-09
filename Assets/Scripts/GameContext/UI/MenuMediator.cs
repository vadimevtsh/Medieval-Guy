using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuMediator : MonoBehaviour {
    public static MenuMediator Instance { get; private set; }

    public static bool HasActiveMenu => ActiveMenu != null;
    public static Type ActiveMenuType => HasActiveMenu ? ActiveMenu.GetType() : typeof(object);
    public static bool CanClosedByOutsideClicking => ActiveMenu.CanClosedByOutsideClicking();

    private static UIMenu ActiveMenu { get; set; }

    public static event Action MenuOpened;
    public static event Action MenuClosed;
    
    private struct MenuOpenRequest 
    {
        public Type MenuType;
        public object Payload;
    }
    
    private static Queue<MenuOpenRequest> _selectionMenuQueue = new Queue<MenuOpenRequest>();

    private void Start() 
    {
        if (Instance != null) 
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }
    
    
    public static void OpenMenu<T>(object payload = null) where T : UIMenu 
    {
        if (ActiveMenu != null) 
        {
            ForceCloseMenu();
        }

        if (ActiveMenu is ISelectionRequiredMenu dynamicMenu && !dynamicMenu.IsSelectionMade()) 
        {
            if (typeof(ISelectionRequiredMenu).IsAssignableFrom(typeof(T))) 
            {
                _selectionMenuQueue.Enqueue(new MenuOpenRequest { MenuType = typeof(T), Payload = payload });
                return; 
            }
        }

        ActiveMenu = CanvasFactory.Build<T>(Instance.gameObject);
        ActiveMenu.Initialize(payload);

        MenuOpened?.Invoke();
    }
    
    public static void OpenMenuOfType(Type menuType, object payload = null) 
    {
        if (menuType == null) 
        {
            return;
        }

        var genericMethod = typeof(MenuMediator).GetMethod("OpenMenu").MakeGenericMethod(menuType);
        genericMethod.Invoke(Instance, new object[] { payload });
    }
    
    public static void ForceCloseMenu() 
    {
        if (ActiveMenu == null) 
        {
            return;
        }

        if (ActiveMenu is ISelectionRequiredMenu dynamicMenu) 
        {
            if (!dynamicMenu.IsSelectionMade()) 
            {
                Debug.Log("Selection not made yet, cannot close menu.");
                return;
            }
            ActiveMenu.InvokeCompleted();
            ActiveMenu = null;
            MenuClosed?.Invoke();
            ProcessSelectionMenuQueue();
            return;
        }
        ActiveMenu.InvokeCompleted();
        ActiveMenu = null;
        MenuClosed?.Invoke();
    }
    
    private static void ProcessSelectionMenuQueue() 
    {
        if (_selectionMenuQueue.Count > 0) 
        {
            var request = _selectionMenuQueue.Dequeue();
            var type = request.MenuType;
            var payload = request.Payload;
            OpenMenuOfType(type, payload);;
        }    
    }
}