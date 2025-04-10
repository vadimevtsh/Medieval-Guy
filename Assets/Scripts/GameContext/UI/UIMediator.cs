using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMediator : MonoBehaviour
{
    private readonly List<RaycastResult> _raycastResultCache = new();

    [SerializeField] private MenuMediator _menuMediator;
    [SerializeField] private OverlayMediator _overlayMediator;

    public static UIMediator Instance;

    private float _lastFrameCheck = -1;
    private bool _isInputConsumedCache;

    // Check if current mouse position is above any UI element.
    // Note: update only once per frame to avoid raycast overload.
    public bool IsInputConsumedByUI
    {
        get
        {
            if (Time.time != _lastFrameCheck)
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    pointerId = -1,
                }; 

                pointerData.position = Input.mousePosition;

                _raycastResultCache.Clear();
                EventSystem.current.RaycastAll(pointerData, _raycastResultCache);

                var firstRaycast = _raycastResultCache.FirstOrDefault();

                _isInputConsumedCache = firstRaycast.gameObject != null && firstRaycast.gameObject.GetComponent<RectTransform>() != null;

                _lastFrameCheck = Time.time;
            }

            return _isInputConsumedCache;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }
}
