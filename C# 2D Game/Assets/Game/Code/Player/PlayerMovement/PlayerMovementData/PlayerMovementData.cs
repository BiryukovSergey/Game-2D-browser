using UnityEngine;

namespace Game.Code.Player.PlayerMovement
{
    [CreateAssetMenu(menuName = "Player Movement Data/Data ",fileName = "Movement data Player", order = 1)]
    public class PlayerMovementData : ScriptableObject
    {
        [Header("Player Characteristics")]
        [SerializeField] private float _PlayerSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _g;

        public float PlayerSpeed => _PlayerSpeed;
        public float JumpForce => _jumpForce;
        public float G => _g;
    }
}