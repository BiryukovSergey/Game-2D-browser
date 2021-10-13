using UnityEngine;

namespace Game.Code.Player.PlayerMovement.Phycics
{
    public class PlayerJump
    {
        private PlayerView _playerView;
        private float _forceToJump;
        private bool _isJump;
        private InputManager _inputManager;
        private Contacts.Contacts _contacts;

        public PlayerJump(PlayerView playerView, Rigidbody2D rigidbody2D, float jumpForce, InputManager inputManager, Contacts.Contacts contacts)
        {
            _playerView = playerView;
            _playerView.PlayerRigitBody = rigidbody2D;
            _forceToJump = jumpForce;
            _inputManager = inputManager;
            _contacts = contacts;
            _isJump = false;
            
        }

        public void Jump()
        {
            if (!_isJump && _inputManager.Jump > 0 && _playerView.PlayerRigitBody.velocity.y == 0 && _contacts._normalDown == false)
            {
                _playerView.PlayerRigitBody.AddForce(Vector2.up * _forceToJump, ForceMode2D.Impulse);
                _isJump = true;
            }
            _isJump = false;
        }
        
        public void Execute()
        {
            Jump();
        }
    }
}