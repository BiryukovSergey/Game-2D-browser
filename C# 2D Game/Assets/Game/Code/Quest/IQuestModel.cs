using UnityEngine;

namespace Game.Code.Quest
{
    public interface IQuestModel
    {
        bool TryCompleted(GameObject activator);
    }
}