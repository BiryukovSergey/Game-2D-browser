using UnityEngine;

namespace Game.Code.Player.PlayerMovement.PlayerMove
{
    public class PlayerMovementWalk
    {
        private PlayerMovementData _playerMovementData;
        private PlayerView _playerView;
        private InputManager _inputManager;
        private Contacts.Contacts _contacts;

        public PlayerMovementWalk(PlayerMovementData playerMovementData, PlayerView playerView,
            InputManager inputManager,Rigidbody2D rigidbody2D,Contacts.Contacts contacts)
        {
            _playerView = playerView;
            _playerMovementData = playerMovementData;
            _inputManager = inputManager;
            _playerView.PlayerRigitBody = rigidbody2D;
            _contacts = contacts;
        }

        public void FixedExecute()
        {
            Debug.Log($"{_contacts._normalLeft}/{_contacts._normalRight}/{_contacts._contactsCollaidersArray[0]}");

            if (_inputManager.Horizontal != 0 && _contacts._normalLeft == false && _contacts._normalRight == false)
            {
                _playerView.PlayerRigitBody.velocity = new Vector2(
                    (_inputManager.Horizontal < 0 ? -1 : 1) * _playerMovementData.PlayerSpeed * Time.fixedDeltaTime,
                    _playerView.PlayerRigitBody.velocity.y);
            }
        }
    }
}