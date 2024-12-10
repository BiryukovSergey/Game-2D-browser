using System;
using UnityEngine;

namespace Game.Code.LevelObject
{
    public class LevelObejctView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        public Action<LevelObejctView> OnLevelObjectContact { get; set; }
    }
}