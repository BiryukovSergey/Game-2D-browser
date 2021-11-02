using UnityEngine;

namespace Game.Code.Quest
{
    [CreateAssetMenu(menuName = "Confiq/Create QuestConfiq", fileName = "QuestConfiq", order = 1)]
    public class QuestConfiq : ScriptableObject
    {
        public int id;
        public QuestType questType;
        
    }
    public enum QuestType
    {
        Switch,
    }
}