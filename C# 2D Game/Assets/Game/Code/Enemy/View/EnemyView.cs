﻿using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
