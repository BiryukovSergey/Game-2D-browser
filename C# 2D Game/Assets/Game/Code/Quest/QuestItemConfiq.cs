using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Quest
{
    [CreateAssetMenu(menuName = "Confiq/QuestItemConfiq", fileName = "QuestItemConfiq", order = 0)]
    public class QuestItemConfiq : ScriptableObject
    {
        public int questId;
        public List<int> questItemCollection;
    }
}