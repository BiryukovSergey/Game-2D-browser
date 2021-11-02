using Game.Code.Quest;
using UnityEngine;

public class QuestConfigurator : MonoBehaviour
{
    [SerializeField] private QuestObjectView _singleObjectView;
    private Quest _singleQuest;

    private void Start()
    {
        _singleQuest = new Quest(_singleObjectView, new SwitchQuestmodel());
        _singleQuest.Reset();
    }

    private void OnDestroy()
    {
        _singleQuest.Dispose();
    }
}
