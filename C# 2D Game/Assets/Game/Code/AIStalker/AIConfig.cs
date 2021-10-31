using System;
using UnityEngine;

namespace Game.Code.AIStalker
{
    [Serializable]
    public struct AIConfig
    {
        public float Speed;
        public float MinDistanceToTarget;
        public Transform[] Waypoints;

    }
}