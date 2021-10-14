using System.Collections.Generic;
using Game.Code.Contacts;
using Game.Code.Enemy.Controller;
using Game.Code.LevelObject;
using Game.Code.LevelObject.ConiManager;
using Game.Code.Player.PlayerMovement;
using Game.Code.Player.PlayerMovement.Phycics;
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
        [SerializeField] private Rigidbody2D _playerRigitBody;
        [SerializeField] private float _forceShoot;
        [SerializeField] private LevelObejctView _levelObejctView;


        private PlayerMovementWalk _playerMovementWalk;
        private InputManager _inputManager;

        private AnimationController _animationController;
        private EnemyController _enemyController;
        private SpawnBullet _spawnBullet;
        private BulletShoot _bulletShoot;
        private PlayerJump _playerJump;
        private Contacts _contacts;
        private CoinManager _coinManager;
        private List<LevelObejctView> _levelObejctViews;

        private void Start()
        {
            _inputManager = new InputManager();
            _contacts = new Contacts(_playerView.PlayerPolygonCollider);
            _bulletShoot = new BulletShoot(_forceShoot);
            _spawnBullet = new SpawnBullet(_bulletGameObject, _spawnBulletView, _bulletShoot);
            _animationController = new AnimationController(_inputManager, _playerView);
            _playerMovementWalk = new PlayerMovementWalk(_playerMovementData, _playerView, _inputManager, _playerRigitBody, _contacts);
            _playerJump = new PlayerJump(_playerView, _playerRigitBody, 4, _inputManager, _contacts);
            _enemyController = new EnemyController(_playerView, _enemyView);
            _levelObejctViews = new List<LevelObejctView>();
            _coinManager = new CoinManager(_levelObejctView, _levelObejctViews);
        }

        private void Update()
        {
            _inputManager.Execute();
            _animationController.Update();
            _enemyController.Execute();
            _spawnBullet.Execute();
            _playerJump.Execute();
            _contacts.Execute();
        }

        private void FixedUpdate()
        {
            _playerMovementWalk.FixedExecute();
        }
    }
}
