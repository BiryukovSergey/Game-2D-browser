using UnityEngine;

namespace Game.Code.СollectingСoins
{
      
    public class СollectingСoinsView : MonoBehaviour
    {
        public delegate void CollisionCoin(); 
        public event CollisionCoin CoinCollision;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CoinCollision?.Invoke();
            }
        }
    }
}