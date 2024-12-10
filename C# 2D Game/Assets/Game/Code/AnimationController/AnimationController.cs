using UnityEngine;

namespace Game
{
    public class AnimationController
    {
        private InputManager _inputManager;
        private PlayerView _playerView;

        public AnimationController(InputManager inputManager, PlayerView playerView)
        {
            _inputManager = inputManager;
            _playerView = playerView;
        }

        public void Update()
        {
            if (_inputManager.Horizontal != 0)
            {
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Run, true);
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Idle, false);
                _playerView.transform.localScale = new Vector3(_inputManager.Horizontal < 0 ? -1 : 1,1,1);
            }
            else
            {
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Idle, true);
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Run, false);
            }

            if (_inputManager.Jump > 0)
            {
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Jump, true);
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Run, false);
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Idle, false);
            }
            else if (_inputManager.Jump == 0)
            {
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Jump, false);
                _playerView.PlayerAnimation.SetBool(AnimationConstanceName.Idle, true);
            }
        }
    }
}