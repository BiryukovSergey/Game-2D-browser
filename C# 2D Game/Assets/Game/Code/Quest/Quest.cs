using System;

namespace Game.Code.Quest
{
    public class Quest : IQuest, IDisposable
    {
        private readonly QuestObjectView _view;
        private IQuestModel _questModel;
        private bool _active;
        public event Action<IQuest> Completed;
        public bool IsComplete { get; private set; }

        public Quest(QuestObjectView questObjectView, IQuestModel questModel)
        {
            _view = questObjectView;
            _questModel = questModel;
        }

        private void OnContact(PlayerView obj)
        {
            var completed = _questModel.TryCompleted(obj.gameObject);
            if (completed)
                Complete();
        }

        private void Complete()
        {
            if (!_active) return;
            _active = false;
            IsComplete = true;
            _view.OnLevelObjectEnter -= OnContact;
            _view.ProcessComplete();
            Completed?.Invoke(this);
        }

        public void Reset()
        {
            if (_active) return;
            _active = true;
            IsComplete = false;
            _view.OnLevelObjectEnter += OnContact;
            _view.ProcessActivate();
            //_view.ProcessComplete();
        }

        public void Dispose()
        {
            _view.OnLevelObjectEnter -= OnContact;
        }
    }
}