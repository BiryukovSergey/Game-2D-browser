using UnityEngine;

namespace Game.Code.Quest
{
    public class SwitchQuestmodel : IQuestModel
    {
        public bool TryCompleted(GameObject activator)
        {
            return activator.GetComponent<PlayerView>() != null;
        }
    }
}