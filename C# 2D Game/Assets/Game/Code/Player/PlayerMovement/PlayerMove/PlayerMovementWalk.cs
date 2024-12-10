using UnityEngine;

namespace Game.Code.Player.PlayerMovement.PlayerMove
{
    public class PlayerMovementWalk
    {
        private PlayerMovementData _playerMovementData;
        private PlayerView _playerView;
        private InputManager _inputManager;

        public PlayerMovementWalk(PlayerMovementData playerMovementData, PlayerView playerView,
            InputManager inputManager)
        {
            _playerView = playerView;
            _playerMovementData = playerMovementData;
            _inputManager = inputManager;
        }

        public void FixedExecute()
        {
            if (_inputManager.Horizontal != 0)
            {
                _playerView.transform.position += new Vector3((_inputManager.Horizontal < 0 ? -1 : 1)
                                                              * _playerMovementData.PlayerSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}