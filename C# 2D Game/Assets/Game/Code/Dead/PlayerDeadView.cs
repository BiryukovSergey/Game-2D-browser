using System;
using UnityEngine;

namespace Game.Code.Dead
{
    public class PlayerDeadView : MonoBehaviour
    {
        [SerializeField] private Transform _deadZone;
        //[SerializeField] private Rigidbody2D _deadZoneDeadRigidbody2D;
        [SerializeField] private Collider2D _deadZoneCollider2D;
        
        public Transform PlayerStartPosition;
        public Transform DeadZone => _deadZone;
        //public Rigidbody2D DeadRigidbody2D => _deadZoneDeadRigidbody2D;
        public Collider2D DeadZoneCollider2D => _deadZoneCollider2D;

        public Action<PlayerDeadView> PlayerDeadViewDelegate { get; set; }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var dead = other.gameObject.GetComponent<PlayerDeadView>();
            PlayerDeadViewDelegate?.Invoke(dead);
        }
    }
}