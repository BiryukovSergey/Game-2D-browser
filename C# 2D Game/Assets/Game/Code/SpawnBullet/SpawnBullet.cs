using UnityEngine;

namespace Game.Code.SpawnBullet
{
    public class SpawnBullet
    {
        private GameObject[] _bulletPull;
        private GameObject _prefab;
        private SpawnBulletView _spawnBulletView;
        private float _time = 0.0f;
        private float _timeLife = 2.0f;
        private int _index = 0;
        private Rigidbody2D _rigidbody2D;
        private BulletShoot _shoot;
        


        public GameObject[] Bullets => _bulletPull;


        public SpawnBullet(GameObject gameObject, SpawnBulletView spawnBulletView, BulletShoot bulletShoot)
        {
            
            _bulletPull = new GameObject[10];
            _prefab = gameObject;
            _spawnBulletView = spawnBulletView;
            _shoot = bulletShoot;
            CreateBullet();
        }

        private void CreateBullet()
        {
            for (int i = 0; i < _bulletPull.Length; i++)
            {
                _bulletPull[i] = GameObject.Instantiate(_prefab, _spawnBulletView.transform.position, _spawnBulletView.transform.rotation);
                _bulletPull[i].SetActive(false);
            }
        }

        private void SpawnBullets()
        {
            if(_index == _bulletPull.Length) _index = 0;

            var transform = _spawnBulletView.transform;
            Bullets[_index].transform.position = transform.position;
            Bullets[_index].transform.rotation = transform.rotation;
            Bullets[_index].SetActive(true);
            _shoot.Shoot(Bullets[_index].GetComponent<Rigidbody2D>());
            _index++;
        }
        public void Execute()
        {
            _time += Time.deltaTime;
            
            if (_time >= _timeLife)
            {
                SpawnBullets();
                _time = 0;
            }
        }
    }
}