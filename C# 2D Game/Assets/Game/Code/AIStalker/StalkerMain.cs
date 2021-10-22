using System;
using Pathfinding;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Code.AIStalker
{
    public class StalkerMain : MonoBehaviour
    {
        [SerializeField] private AIConfig _aiConfig;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private Seeker _seeker;
        [SerializeField] private Transform _targetPlayer;

        private StalkerController _stalkerController;

        private void Start()
        {
            _stalkerController = new StalkerController(_enemyView, new StalkerModel(_aiConfig), _seeker, _targetPlayer);
            InvokeRepeating(nameof(RecalculateAIPath),0.0f,0.1f);
        }

        private void FixedUpdate()
        {
            _stalkerController.FixedUpdate();
        }

        public void RecalculateAIPath()
        {
            _stalkerController.RecalculatePath();
        }
    }
}