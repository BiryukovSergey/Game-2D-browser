using System.Collections.Generic;
using System;
using UnityEngine;

namespace Game.Code.LevelObject.ConiManager
{
    public class CoinManager : IDisposable
    {
        private LevelObejctView _characterView;
        private List<LevelObejctView> _coinViews;

        public CoinManager(LevelObejctView levelObejctView, List<LevelObejctView> coinViews)
        {
            _characterView = levelObejctView;
            _coinViews = coinViews;
            var a = GameObject.FindObjectsOfType<LevelObejctView>();
            for (int i = 0; i < a.Length; i++)
            {
                _coinViews.Add(a[i]);
            }
            //_coinViews.Add(levelObejctView);
            _characterView.OnLevelObjectContact += OnLevelObjectContact;
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
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}