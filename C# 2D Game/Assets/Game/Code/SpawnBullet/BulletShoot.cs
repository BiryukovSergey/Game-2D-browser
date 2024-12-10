using UnityEngine;

namespace Game.Code.SpawnBullet
{
    public class BulletShoot
    {
        private SpawnBullet _spawnBulletView;
        public float SpeedBullet = 2.0f;
        
        public BulletShoot(SpawnBullet spawnBulletView)
        {
            _spawnBulletView = spawnBulletView;
        }
        public void Execute()
        {
            for (int i = 0; i < _spawnBulletView.Bullets.Length; i++)
            {
                _spawnBulletView.Bullets[i].transform.position +=
                   -_spawnBulletView.Bullets[i].transform.up * SpeedBullet * Time.deltaTime;
            }
        }
    }
}