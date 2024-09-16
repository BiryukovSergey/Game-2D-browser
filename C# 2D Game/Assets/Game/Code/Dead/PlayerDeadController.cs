using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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
            var position = playerDeadView.PlayerStartPosition.position;
            _start = new Vector3(position.x, position.y, 0);
            _deadCollaider = playerDeadView.DeadZoneCollider2D;
            _deadListView = new List<PlayerDeadView>();
            var objectDeadPlayer = Object.FindObjectsOfType<PlayerDeadView>();
            for (int i = 0; i < objectDeadPlayer.Length; i++)
            {
                _deadListView.Add(objectDeadPlayer[i]);
                objectDeadPlayer[i].PlayerDeadViewDelegate += OnContactDead;
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