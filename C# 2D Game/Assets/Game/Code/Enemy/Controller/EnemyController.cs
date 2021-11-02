using UnityEngine;

namespace Game.Code.Enemy.Controller
{
    public class EnemyController
    {
        private PlayerView _playerView;
        private EnemyView _enemyView;

        public EnemyController(PlayerView playerView, EnemyView enemyView)
        {
            _playerView = playerView;
            _enemyView = enemyView;
        }

        public void Execute()
        {
            var dir = _playerView.transform.position - _enemyView.transform.position;
            var angle = Vector3.Angle(Vector3.down, dir);
            var axis = Vector3.Cross(Vector3.down, dir);
            _enemyView.transform.rotation = Quaternion.AngleAxis(angle,axis);
        }
    }
}