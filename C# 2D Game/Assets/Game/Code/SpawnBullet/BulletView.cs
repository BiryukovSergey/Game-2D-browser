using UnityEngine;

namespace Game.Code.SpawnBullet
{
    public class BulletView : MonoBehaviour
    {
        
        [SerializeField] private Rigidbody2D _bulletRigidBody;
        
        public Rigidbody2D Rigidbody
        {
            get => _bulletRigidBody;
            set => _bulletRigidBody = value;
            
        }

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

    }
}