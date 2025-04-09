using UnityEngine;

public class UIMenu : UICanvas
{
    private CanvasGroup _canvasGroup;
    public CanvasGroup CanvasGroup
    {
        get
        {
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }
            return _canvasGroup;
        }
    }
    
    public virtual void Initialize(object payload)
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.interactable = false;

        base.Initialize();
    }
    
    public virtual void InvokeCompleted()
    {
    }
    
    public virtual bool CanClosedByOutsideClicking() 
    {
        return true;
    }
}
