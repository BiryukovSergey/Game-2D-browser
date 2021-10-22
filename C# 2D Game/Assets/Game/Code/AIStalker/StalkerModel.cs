using Pathfinding;
using UnityEngine;

namespace Game.Code.AIStalker
{
    public class StalkerModel
    {
        private AIConfig _config;
        private Path _path;
        private int _currentPointIndex;

        public StalkerModel(AIConfig config)
        {
            _config = config;
        }

        public void UpdatePath(Path p)
        {
            _path = p;
            _currentPointIndex = 0;
        }
        public Vector2 CalculateVelocity(Vector2 position)
        {
            if (_path == null) return Vector2.zero;
            if (_currentPointIndex >= _path.vectorPath.Count) return Vector2.zero;

            var direction = ((Vector2)_path.vectorPath[_currentPointIndex] - position).normalized;
            var result = direction * _config.Speed;
            ChangeIndex(position);
            return result;
        }
        private void ChangeIndex(Vector2 position)
        {
            var sqrtDistance = Vector2.SqrMagnitude((Vector2)_path.vectorPath[_currentPointIndex] - position);
            if (sqrtDistance <= _config.MinDistanceToTarget) _currentPointIndex++;
        }
    }
}