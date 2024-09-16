using Pathfinding;
using UnityEngine;

namespace Game.Code.AIStalker
{
    public class StalkerController
    {
        private Transform _player;
        private EnemyView _enemyView;
        private StalkerModel _stalkerModel;
        private Seeker _seeker;
        private Vector2 _velocity;


        public StalkerController(EnemyView enemyView, StalkerModel stalkerModel, Seeker seeker, Transform transform)
        {
            _enemyView = enemyView;
            _stalkerModel = stalkerModel;
            _seeker = seeker;
            _player = transform;
        }

        public void FixedUpdate()
        {
            _velocity = _stalkerModel.CalculateVelocity(_enemyView.transform.position) * Time.deltaTime;
            _enemyView._rigidbody2D.velocity = _velocity;
        }

        public void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_enemyView._rigidbody2D.position, _player.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _stalkerModel.UpdatePath(p);
        }
    }
}