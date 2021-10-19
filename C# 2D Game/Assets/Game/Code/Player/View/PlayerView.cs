using System;
using Game.Code.LevelObject;
using UnityEngine;
namespace Game
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]private Animator _playerAnimation;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Collider2D _plauerCollider2D;
        [SerializeField]private LevelObejctView _levelObejctView;
        public Rigidbody2D PlayerRigitBody
        {
            get => _playerRigidbody;
            set => _playerRigidbody = value;
        }
        public Animator PlayerAnimation => _playerAnimation;
        public Collider2D PlayerPolygonCollider => _plauerCollider2D;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            var levelObject = other.gameObject.GetComponent<LevelObejctView>();
            _levelObejctView.OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}