using UnityEngine;

public class UITogglableOverlay : UICanvas
{
    [SerializeField] private bool _isVisibleByDefault;
    
    protected bool _isVisible;
    
    private CanvasGroup _canvasGroup;
    
    public override void Initialize() 
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        base.Initialize();

        ToggleVisibility(_isVisibleByDefault);
    }
    
    public virtual void ToggleVisibility(bool visible) 
    {
        _isVisible = visible;
        _canvasGroup.alpha = visible ? 1 : 0;
        
        if (visible) 
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        } 
        else 
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }
}
