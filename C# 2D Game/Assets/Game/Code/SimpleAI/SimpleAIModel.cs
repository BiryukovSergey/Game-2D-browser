using Game.Code.AIStalker;
using UnityEngine;

namespace Game.Code.SimpleAI
{
    public class SimpleAIModel
    {
        private AIConfig _configSimpleAI;
        private Transform _transformTarget;
        private int _currentPointModel;

        public SimpleAIModel(AIConfig config)
        {
            _configSimpleAI = config;
            _transformTarget = GetNextPoint();
        }

        public Vector2 CalculculeteVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_transformTarget.position - fromPosition);
            _transformTarget = sqrDistance <= _configSimpleAI.MinDistanceToTarget ? GetNextPoint() : _transformTarget;
            var direction = ((Vector2)_transformTarget.position - fromPosition).normalized;
            return _configSimpleAI.Speed * direction;
        }

        private Transform GetNextPoint()
        {
            _currentPointModel = (_currentPointModel + 1) % _configSimpleAI.Waypoints.Length;
            return _configSimpleAI.Waypoints[_currentPointModel];
        }
    }
}