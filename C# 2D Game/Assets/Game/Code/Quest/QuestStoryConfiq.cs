using UnityEngine;

namespace Game.Code.Quest
{
    [CreateAssetMenu(menuName = "Confiq/QuestStoryConfiq", fileName = "QuestStoryConfiq", order = 0)]
    public class QuestStoryConfiq : ScriptableObject
    {
        public QuestConfiq[] quests;
        public QuestStoryType questStoryType;
        
        public enum QuestStoryType
        {
            Common,
            Resettable
        }
    }
}