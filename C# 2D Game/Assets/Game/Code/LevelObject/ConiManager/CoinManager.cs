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
        private float _speedCoinRotation = 4.0f;

        public CoinManager(LevelObejctView levelObejctView, List<LevelObejctView> coinViews)
        {
            _characterView = levelObejctView;
            _coinViews = coinViews;
            foreach (var item in _coinViews)
            {
                item.OnLevelObjectContact += OnLevelObjectContact;
            }
        }

        public void CoinRotation()
        {
            _characterView.transform.Rotate(Vector3.up* _speedCoinRotation);
        }

        public void OnLevelObjectContact(LevelObejctView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                contactView.gameObject.SetActive(false);
                //GameObject.Destroy(contactView.gameObject);
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