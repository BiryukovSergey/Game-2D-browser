using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Code.Quest
{
    public class QuestObjectView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private int _id;
        [SerializeField]public List<GameObject> _coins;
        public int Id => _id;

        private void Start()
        {
           // ProcessActivate();
        }

        public Action<PlayerView> OnLevelObjectEnter { get; set; }

        public void ProcessComplete()
        {
            _sprite.gameObject.SetActive(true);
        }
        public void ProcessActivate()
        {
            _sprite.gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var levelObject = other.gameObject.GetComponent<PlayerView>();
            if (levelObject != null)
            {
                OnLevelObjectEnter?.Invoke(levelObject);
            }
        }
    }
}