using System;
using DefaultNamespace;
using Game.Code.Enemy.Controller;
using Game.Code.Player.PlayerMovement;
using Game.Code.Player.PlayerMovement.PlayerMove;
using Game.Code.SpawnBullet;
using UnityEngine;

namespace Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerMovementData _playerMovementData;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private SpawnBulletView _spawnBulletView;
        [SerializeField] private GameObject _bulletGameObject;
        
        
        private PlayerMovementWalk _playerMovementWalk;
        private PlayerMovementJump _playerMovementJump;
        private InputManager _inputManager;
        
        private AnimationController _animationController;
        private EnemyController _enemyController;
        private SpawnBullet _spawnBullet;
        private BulletShoot _bulletShoot;

        private void Start()
        {
            _inputManager = new InputManager();
            _animationController = new AnimationController(_inputManager, _playerView);
            _playerMovementWalk = new PlayerMovementWalk(_playerMovementData, _playerView,_inputManager);
            _playerMovementJump = new PlayerMovementJump(_playerView, _playerMovementData,_inputManager);
            _enemyController = new EnemyController(_playerView,_enemyView);
            _spawnBullet = new SpawnBullet(_bulletGameObject,_spawnBulletView);
            _bulletShoot = new BulletShoot(_spawnBullet);
        }

        private void Update()
        {
            _inputManager.Execute();
            _animationController.Update();
            _playerMovementJump.Execute();
            _enemyController.Execute();
            _spawnBullet.Execute();
            _bulletShoot.Execute();
        }

        private void FixedUpdate()
        {
            _playerMovementWalk.FixedExecute();
        }
    }
}
