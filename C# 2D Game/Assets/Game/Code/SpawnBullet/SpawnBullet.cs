using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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


        public GameObject[] Bullets => _bulletPull;


        public SpawnBullet(GameObject gameObject, SpawnBulletView spawnBulletView)
        {
            _bulletPull = new GameObject[10];
            _prefab = gameObject;
            _spawnBulletView = spawnBulletView;
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

            _bulletPull[_index].transform.position = _spawnBulletView.transform.position;
            _bulletPull[_index].transform.rotation = _spawnBulletView.transform.rotation;
            _bulletPull[_index].SetActive(true);
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