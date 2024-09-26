using System;
using Game.Code.SimpleAI;
using Pathfinding;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Code.AIStalker
{
    public class StalkerMain : MonoBehaviour
    {
        /// <summary>
        /// Включение логики врагу(simple или Stalker)
        /// </summary>
        [SerializeField] private bool _choiseEnemy;

        [Header("SimpleAI")] [SerializeField] private AIConfig _configSimple;
        [SerializeField] private EnemyView _enemyViewSimple;

        [Header("AIStalker")] [SerializeField] private AIConfig _aiConfig;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private Seeker _seeker;
        [SerializeField] private Transform _targetPlayer;

        private StalkerController _stalkerController;
        private SimpleAIController _simpleAIController;

        private void Start()
        {
            _simpleAIController = new SimpleAIController(new SimpleAIModel(_configSimple), _enemyViewSimple);
            _stalkerController = new StalkerController(_enemyView, new StalkerModel(_aiConfig), _seeker, _targetPlayer);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 0.1f);
        }

        private void FixedUpdate()
        {
            if (_choiseEnemy) _stalkerController.FixedUpdate();
            else
            {
                _simpleAIController.FixedUpdate();
            }
        }

        public void RecalculateAIPath()
        {
            _stalkerController.RecalculatePath();
        }
    }
}