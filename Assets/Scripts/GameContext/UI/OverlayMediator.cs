using System;
using System.Collections.Generic;
using UnityEngine;

public class OverlayMediator : MonoBehaviour
{
    public readonly List<UICanvas> _canvases = new();

    [SerializeField] private UICanvas[] _requiredCanvases;
    
    public static OverlayMediator Instance { get; private set; }
    
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        InitializeUI();
    }

    public T GetCanvas<T>() where T : UICanvas
    {
        foreach (var canvas in _canvases)
        {
            if (canvas is T specificCanvas)
            {
                return specificCanvas;
            }
        }

        return null;
    }

    private void InitializeUI()
    {
        foreach (var canvasPrefab in _requiredCanvases)
        {
            var canvasGameObject = Instantiate(canvasPrefab, transform);
            canvasGameObject.name = canvasPrefab.name;
            
            canvasGameObject.Initialize();
            
            _canvases.Add(canvasGameObject);
        }
    }

    private void ToggleOverlay<T>(bool visible) where T : UITogglableOverlay
    {
        var canvas = GetCanvas<T>();
        if (canvas != null)
        {
            canvas.ToggleVisibility(visible);
        }
    }

    public void ToggleAllOverlays(bool visible)
    {
        foreach (var canvas in _canvases)
        {
            if (canvas is UITogglableOverlay togglableOverlay)
            {
                togglableOverlay.ToggleVisibility(visible);
            }
        }
    }
    
    
}
