using System.Linq;
using UnityEngine;

public class NoticeBoard : Interactable
{
    private const string ActiveQuestIndicatorPrefabName = "QuestionMark";
    
    private GameObject ActiveQuestIndicator;
    
    private QuestController QuestController => Services.QuestController;
    private PrefabProvider PrefabProvider => Services.PrefabProvider;
    private WorldOverlayCanvas WorldOverlayCanvas => Services.WorldOverlayCanvas;

    private void Start()
    {
        var prefab = PrefabProvider.Get(ActiveQuestIndicatorPrefabName);
        ActiveQuestIndicator = Instantiate(prefab, WorldOverlayCanvas.transform);
        ActiveQuestIndicator.SetActive(false);
    }
    
    public override bool CanInteract()
    {
        return QuestController.AvailableQuests.Any();
    }

    public override void Interact()
    {
        QuestController.StartRandomQuest();
    }

    private void Update()
    {
        if (!QuestController.AvailableQuests.Any())
        {
            ActiveQuestIndicator.SetActive(false);
            
            return;
        }
        
        ActiveQuestIndicator.SetActive(true);
        var position = Camera.main.WorldToScreenPoint(Position + new Vector3(0.3f, 0.3f, 0f));
        ActiveQuestIndicator.transform.position = position;
    }
}
