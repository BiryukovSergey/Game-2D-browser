using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.LevelObject
{
    public class LevelCompleteManager : IDisposable
    {
        private Vector3 _start;
        private LevelObejctView _levelObejctView;
        private PlayerView _playerView;
        private List<LevelObejctView> _deadZone;
        private List<LevelObejctView> _winZone;

        public LevelCompleteManager(LevelObejctView levelObejctView, List<LevelObejctView> levelObejctViews_dead,
            List<LevelObejctView> levelObejctViews_wins)
        {
            _start = levelObejctView.transform.position;
            _levelObejctView = levelObejctView;
            _deadZone = levelObejctViews_dead;
            _winZone = levelObejctViews_wins;
        }


        private void OnLevelObjectContact(LevelObejctView obejctView)
        {
            if (_deadZone.Contains(obejctView))
            {
                _levelObejctView.transform.position = _start;
            }
        }

        public void Dispose()
        {
            _levelObejctView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}