using UnityEngine;

public class HoverCircle : MonoBehaviour, IHoverHandler
{
    [SerializeField] private GameObject _circleSprite;

    public void OnPointerEnter()
    {
        _circleSprite.SetActive(true);
    }
    
    public void OnPointerExit()
    {
        _circleSprite.SetActive(false);
    }
}
