using UnityEngine;

namespace Game.Code.SpawnBullet
{
    public class BulletShoot
    {
        private float _forceShoot;
        private float ForceShoot => _forceShoot;

        public BulletShoot(float forceShoot)
        {
            _forceShoot = forceShoot;
        }
        public void Shoot(Rigidbody2D rigidbody2D)
        {
            rigidbody2D.AddForce(-rigidbody2D.transform.up * ForceShoot, ForceMode2D.Impulse);
        }
    }
}