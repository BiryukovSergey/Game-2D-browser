using System;
using UnityEngine;

namespace Game.Code.Dead
{
    public class PlayerDeadView : MonoBehaviour
    {
        [SerializeField] private Transform _deadZone;
        [SerializeField] private Collider2D _deadZoneCollider2D;
        
        public Transform PlayerStartPosition;
        public Transform DeadZone => _deadZone;
        public Collider2D DeadZoneCollider2D => _deadZoneCollider2D;

        public Action<PlayerDeadView> PlayerDeadViewDelegate { get; set; }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<PlayerView>())
            {
                var dead = other.gameObject.GetComponent<PlayerDeadView>();
                PlayerDeadViewDelegate?.Invoke(dead);
            }
            
        }
    }
}