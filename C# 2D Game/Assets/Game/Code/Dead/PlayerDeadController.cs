using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Dead
{
    public class PlayerDeadController : IDisposable
    {
        private PlayerDeadView _playerDeadView;
        private Transform _dead;

        private Vector3 _start;
        private Collider2D _deadCollaider;
        private List<PlayerDeadView> _deadListView;

        public PlayerDeadController(PlayerDeadView playerDeadView)
        {
            _dead = playerDeadView.DeadZone;
            _start = new Vector3(playerDeadView.PlayerStartPosition.position.x,
                playerDeadView.PlayerStartPosition.position.y, 0);
            _deadCollaider = playerDeadView.DeadZoneCollider2D;
            _deadListView = new List<PlayerDeadView>();
            _deadListView.Add(playerDeadView);
            foreach (var item in _deadListView)
            {
                item.PlayerDeadViewDelegate += OnContactDead;
            }
        }

        public void OnContactDead(PlayerDeadView playerDeadView)
        {
            playerDeadView = GameObject.FindObjectOfType<PlayerDeadView>();

            if (_deadListView.Contains(playerDeadView))
            {
                var player = GameObject.FindObjectOfType<PlayerView>();
                player.transform.position = _start;
            }
        }

        public void Dispose()
        {
            foreach (var item in _deadListView)
            {
                item.PlayerDeadViewDelegate -= OnContactDead;
            }
        }
    }
}