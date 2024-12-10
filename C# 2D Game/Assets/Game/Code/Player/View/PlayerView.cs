using UnityEngine;
namespace Game
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField]private Animator _playerAnimation;
        public Animator PlayerAnimation => _playerAnimation;

    }
}