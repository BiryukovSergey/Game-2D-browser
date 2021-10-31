using System.Collections.Generic;
using Game.Code.Camera;
using Game.Code.Contacts;
using Game.Code.Dead;
using Game.Code.Enemy.Controller;
using Game.Code.LevelObject;
using Game.Code.LevelObject.ConiManager;
using Game.Code.ParalaxManager;
using Game.Code.Player.PlayerMovement;
using Game.Code.Player.PlayerMovement.Phycics;
using Game.Code.Player.PlayerMovement.PlayerMove;
using Game.Code.SpawnBullet;
using Game.Code.СollectingСoins;
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
        [SerializeField] private LevelObejctView[] _levelObejctView;
        [SerializeField] private PlayerDeadView _playerDeadView;
        [SerializeField] private CameraView _cameraView;
        [SerializeField] private float _jumpForce;
        [SerializeField] private СollectingСoinsView _сollectingСoinsView;
        
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _backPicture;


        private CameraController _cameraController;
        private PlayerMovementWalk _playerMovementWalk;
        private InputManager _inputManager;

        private AnimationController _animationController;
        private EnemyController _enemyController;
        private SpawnBullet _spawnBullet;
        private BulletShoot _bulletShoot;
        private PlayerJump _playerJump;
        private Contacts _contacts;
        private CoinManager[] _coinManager;
        private PlayerDeadController _playerDeadController;
        private СollectingСoinsController _сollectingСoinsController;
        private ParalaxController _paralaxController;


        private List<LevelObejctView> _levelObejctViewsList;
        //public List<LevelObejctView> _deadZone;
        //public List<LevelObejctView> _winZone;

        private void Start()
        {
            
            _cameraController = new CameraController(_cameraView);
            _paralaxController = new ParalaxController(_camera, _backPicture);
            _inputManager = new InputManager();
            _contacts = new Contacts(_playerView.PlayerPolygonCollider);
            _bulletShoot = new BulletShoot(_forceShoot);
            _spawnBullet = new SpawnBullet(_bulletGameObject, _spawnBulletView, _bulletShoot);
            _animationController = new AnimationController(_inputManager, _playerView);
            _playerMovementWalk = new PlayerMovementWalk(_playerMovementData, _playerView, _inputManager,
                _playerRigitBody, _contacts);
            _playerJump = new PlayerJump(_playerView, _playerRigitBody, _jumpForce, _inputManager, _contacts);
            _enemyController = new EnemyController(_playerView, _enemyView);
            _levelObejctViewsList = new List<LevelObejctView>();
            var a = FindObjectsOfType<LevelObejctView>();
            for (int i = 0; i < a.Length; i++)
            {
                _levelObejctViewsList.Add(a[i]);
            }

            _coinManager = new CoinManager[2];
            
            for (int i = 0; i < _coinManager.Length; i++)
            {
                _coinManager[i] = new CoinManager(_levelObejctView[i], _levelObejctViewsList);
            }
           
            
            
            _playerDeadController = new PlayerDeadController(_playerDeadView);
            _сollectingСoinsController = new СollectingСoinsController(_сollectingСoinsView);
        }

        private void Update()
        {
            _paralaxController.Update();
            _cameraController.MoveCamera();
            _inputManager.Execute();
            _animationController.Update();
            _enemyController.Execute();
            //_spawnBullet.Execute();
            _playerJump.Execute();
            _contacts.Execute();
        }

        private void FixedUpdate()
        {
            _playerMovementWalk.FixedExecute();
            
            for (int i = 0; i < _coinManager.Length; i++)
            {
                _coinManager[i].CoinRotation();
            }
            
        }
    }
}
