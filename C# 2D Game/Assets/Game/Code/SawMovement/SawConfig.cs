using System;
using UnityEngine;

namespace Game.Code.SawMovement
{
    [Serializable]
    public struct SawConfig
    {
        public float _speed;
        public float _minTarget;
        public Transform[] _wayPoint;
    }
}