using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private const float InteractionRange = 1f;
    private const string InteractionPromptPrefabName = "InteractionPrompt";

    private GameObject InteractionPrompt;
    
    private List<Interactable> _interactables = new List<Interactable>();

    private PlayerController PlayerController => Services.PlayerController;
    private PrefabProvider PrefabProvider => Services.PrefabProvider;
    private WorldOverlayCanvas WorldOverlayCanvas => Services.WorldOverlayCanvas;
    private InputController InputController => Services.InputController;
    
    public void Initialize()
    {
        _interactables = FindObjectsOfType<Interactable>().ToList();

        var prefab = PrefabProvider.Get(InteractionPromptPrefabName);
        InteractionPrompt = Instantiate(prefab, WorldOverlayCanvas.transform);
        InteractionPrompt.SetActive(false);
    }

    public void AddInteractable(Interactable interactable)
    {
        _interactables.Add(interactable);
    }

    private void Update()
    {
        var playerPosition = PlayerController.PlayerPosition;

        Interactable nearestInteractable = null;
        var closestDistance = Mathf.Infinity;
        foreach (var interactable in _interactables)
        {
            var distance = Vector3.Distance(interactable.Position, playerPosition);
            if (distance > InteractionRange)
            {
                continue;
            }

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestInteractable = interactable;
            }
        }

        if (nearestInteractable != null)
        {
            InteractionPrompt.SetActive(true);
            var mainCamera = Camera.main;
            var position = mainCamera.WorldToScreenPoint(nearestInteractable.Position);
            InteractionPrompt.transform.position = position + new Vector3(0, 40f, 0f);
            
            if (InputController.GetInteractClicked())
            {
                if (nearestInteractable.IsInteractableOnce)
                {
                    _interactables.Remove(nearestInteractable);
                }
                
                nearestInteractable.Interact();
            }
        }
        else
        {
            InteractionPrompt.SetActive(false);
        }
    }
}

