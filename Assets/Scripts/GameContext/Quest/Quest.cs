public class Quest
{
    public QuestConfiguration QuestConfiguration { get; private set; }
    public bool IsCompleted { get; set; }
    public bool IsStarted { get; set; }

    public void Initialize(QuestConfiguration questConfiguration)
    {
        QuestConfiguration = questConfiguration;
    }
}
