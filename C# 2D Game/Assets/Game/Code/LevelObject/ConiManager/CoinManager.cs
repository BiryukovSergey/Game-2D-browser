using System.Collections.Generic;
using System;
using UnityEngine;

namespace Game.Code.LevelObject.ConiManager
{
    public class CoinManager : IDisposable
    {
        private LevelObejctView _characterView;
        private List<LevelObejctView> _coinViews;
        private PlayerView _playerView;
        public CoinManager(LevelObejctView levelObejctView, List<LevelObejctView> coinViews)
        {
            _characterView = levelObejctView;
            _coinViews = coinViews;
            foreach (var item in _coinViews)
            {
                item.OnLevelObjectContact += OnLevelObjectContact; 
            }
        }

        public void OnLevelObjectContact(LevelObejctView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            foreach (var item in _coinViews)
            {
                item.OnLevelObjectContact -= OnLevelObjectContact;
            }
        }
    }
}