using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private bool _isInteractableOnce;

    public bool IsInteractableOnce => _isInteractableOnce;
    
    public Vector3 Position => transform.position;
    
    public virtual bool CanInteract()
    {
        return true;
    }

    public virtual void Interact()
    {
        
    }
}
