using UnityEngine;
using UnityEngine.InputSystem;
public class CursorTrackerService : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private LayerMask _hoverLayerMask = ~0;

    private IHoverHandler _currentHoverTarget;

    private void Awake()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        TrackHover();
        CheckClick();
    }

    private void TrackHover()
    {
        var mousePosition = Mouse.current.position.ReadValue();
        var worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        
        var hit = Physics2D.Raycast(worldPosition, Vector2.zero, 0f);
        if (hit.collider != null)
        {
            var hoverTarget = hit.collider.GetComponent<IHoverHandler>();
            if (hoverTarget != null)
            {
                if (hoverTarget != _currentHoverTarget)
                {
                    if (_currentHoverTarget != null)
                    {
                        _currentHoverTarget.OnPointerExit();
                    }
                    
                    _currentHoverTarget = hoverTarget;
                    _currentHoverTarget.OnPointerEnter();
                }
            }
            else
            {
                ClearHover();
            }
        }
        else
        {
            ClearHover();
        }
    }
    
    private void CheckClick()
    {
        if (Mouse.current == null)
        {
            return;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && _currentHoverTarget != null)
        {
            // If the same object also implements IClickHandler, invoke OnClick
            var clickTarget = (_currentHoverTarget as Component)?.GetComponent<IClickHandler>();
            clickTarget?.OnClick();
        }
    }

    private void ClearHover()
    {
        if (_currentHoverTarget != null)
        {
            _currentHoverTarget.OnPointerExit();
            _currentHoverTarget = null;
        }
    }
}
