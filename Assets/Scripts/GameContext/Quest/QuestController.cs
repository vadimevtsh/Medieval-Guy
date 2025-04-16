using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public List<Quest> Quests = new List<Quest>();
    public IEnumerable<Quest> AvailableQuests => Quests.Where(q => !q.IsCompleted && !q.IsStarted);
    public IEnumerable<Quest> CurrentQuests => Quests.Where(q => !q.IsCompleted && q.IsStarted);
    
    private ConfigurationService Configuration => Services.Configuration;
    private InventoryController InventoryController => Services.InventoryController;

    public void Initialize()
    {
        var questConfigs = Configuration.QuestProviderService.GetAll();
        foreach (var quest in questConfigs)
        {
            var newQuest = new Quest();
            newQuest.Initialize(quest);
            Quests.Add(newQuest);
        }

        InventoryController.InventoryChanged += CheckQuestsCompletion;
    }
    
    public void StartQuest(string id)
    {
        var quest = AvailableQuests.FirstOrDefault(q => q.QuestConfiguration.Id == id);
        if (quest == null)
        {
            return;
        }

        quest.IsStarted = true;

        CheckQuestsCompletion();
    }

    private void CheckQuestsCompletion()
    {
        foreach (var quest in CurrentQuests)
        {
            var isCompleted = false;
            var requirements = quest.QuestConfiguration.Requirements;
            foreach (var requirement in requirements)
            {
                var itemsCount = InventoryController.CurrentItems.Count(i => i.Configuration.Id == requirement.Id);
                if (itemsCount < requirement.Quantity)
                {
                    continue;
                }

                isCompleted = true;
            }

            if (!isCompleted)
            {
                continue;
            }
            
            foreach (var requirement in requirements)
            {
                for (int i = 0; i < requirement.Quantity; i++)
                {
                    InventoryController.RemoveItem(requirement.Id);
                }
            }

            quest.IsCompleted = true;
            
            var rewards = quest.QuestConfiguration.Rewards;
            foreach (var reward in rewards)
            {
                for (int i = 0; i < reward.Quantity; i++)
                {
                    InventoryController.AddItem(reward.Id);
                }
            }
        }
    }

    public void StartRandomQuest()
    {
        var firstQuest = AvailableQuests.FirstOrDefault();
        if (firstQuest == null)
        {
            return;
        }
        StartQuest(firstQuest.QuestConfiguration.Id);
    }
}
