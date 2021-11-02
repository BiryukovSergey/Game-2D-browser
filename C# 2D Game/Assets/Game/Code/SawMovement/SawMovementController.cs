using UnityEngine;

namespace Game.Code.SawMovement
{
    public class SawMovementController
    {
        private Transform _targetTransform;
        private int _countPoint;
        private SawConfig _sawConfig;
        

        public SawMovementController(SawConfig config)
        {
            _sawConfig = config;
            _targetTransform = GetNextPionts();
        }

        public Vector2 SawMovement(Vector2 from)
        {
            var dist = ((Vector2)_targetTransform.position - from).magnitude;
            if (dist <= _sawConfig._minTarget)
            {
                _targetTransform = GetNextPionts();
            }

            var dir = ((Vector2)_targetTransform.position - from).normalized;
            return _sawConfig._speed * dir;

        }

        private Transform GetNextPionts()
        {
            _countPoint = (_countPoint + 1) % _sawConfig._wayPoint.Length;
            return _sawConfig._wayPoint[_countPoint];
        }
    }
}