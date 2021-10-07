using UnityEngine;

namespace Game
{
    public class AnimationController
    {
        private InputManager _inputManager;
        private PlayerView _playerView;

        private AnimationConstanceName _constanceName = new AnimationConstanceName();

        public AnimationController(InputManager inputManager, PlayerView playerView)
        {
            _inputManager = inputManager;
            _playerView = playerView;
        }

        public void Update()
        {
            if (_inputManager.Horizontal != 0)
            {
                if (_inputManager.Horizontal > 0)
                {
                    _playerView.transform.localScale = new Vector3(1, 1, 1);
                    _playerView.PlayerAnimation.SetBool(_constanceName.Run, true);
                    _playerView.PlayerAnimation.SetBool(_constanceName.Idle, false);
                }
                else if (_inputManager.Horizontal < 0)
                {
                    _playerView.transform.localScale = new Vector3(-1, 1, 1);
                    _playerView.PlayerAnimation.SetBool(_constanceName.Run, true);
                    _playerView.PlayerAnimation.SetBool(_constanceName.Idle, false);
                }
            }
            else
            {
                _playerView.PlayerAnimation.SetBool(_constanceName.Idle, true);
                _playerView.PlayerAnimation.SetBool(_constanceName.Run, false);
            }

            if (_inputManager.Jump > 0)
            {
                _playerView.PlayerAnimation.SetBool(_constanceName.Jump, true);
                _playerView.PlayerAnimation.SetBool(_constanceName.Run, false);
                _playerView.PlayerAnimation.SetBool(_constanceName.Idle, false);
            }
            else if (_inputManager.Jump == 0)
            {
                _playerView.PlayerAnimation.SetBool(_constanceName.Jump, false);
                _playerView.PlayerAnimation.SetBool(_constanceName.Idle, true);
            }
        }
    }
}