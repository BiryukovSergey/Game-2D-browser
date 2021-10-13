using UnityEngine;
namespace Game
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]private Animator _playerAnimation;
        public Animator PlayerAnimation => _playerAnimation;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private Collider2D _plauerCollider2D;
        public Rigidbody2D PlayerRigitBody
        {
            get => _playerRigidbody;
            set => _playerRigidbody = value;
        }

        public Collider2D PlayerPolygonCollider => _plauerCollider2D;
    }
}