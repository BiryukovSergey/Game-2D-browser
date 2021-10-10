using Game;
using Game.Code.Player.PlayerMovement;
using UnityEngine;
using UnityEngine.Timeline;

namespace DefaultNamespace
{
    public class PlayerMovementJump
    {
        private PlayerView _playerView;
        private PlayerMovementData _playerMovementData;
        private InputManager _inputManager;
        private float velocity_Y;
        private bool _isCanJump;

        public PlayerMovementJump(PlayerView playerView, PlayerMovementData playerMovementData,
            InputManager inputManager)
        {
            _playerView = playerView;
            _playerMovementData = playerMovementData;
            _inputManager = inputManager;
            _isCanJump = true;
        }

        public void Execute()
        {
            if (_inputManager.Jump != 0 && _isCanJump)
            {
                velocity_Y = _playerMovementData.JumpForce;
                _playerView.transform.position += new Vector3(0, 1, 0) * velocity_Y * Time.deltaTime;
                _isCanJump = false;
            }

            if (!IsGround())
            {
                IsFly();
            }
            else
            {
                _playerView.transform.position =
                    new Vector3(_playerView.transform.position.x, 0, _playerView.transform.position.z);
                velocity_Y = 0;
                _isCanJump = true;
            }
        }
        

        private bool IsGround()
        {
            if (_playerView.transform.position.y <= 0)
            {
                return true;
            }

            return false;
        }

        private void IsFly()
        {
            _playerView.transform.position += new Vector3(0, 1, 0) * velocity_Y * Time.deltaTime;
            velocity_Y += _playerMovementData.G * Time.deltaTime;
        }
    }
}