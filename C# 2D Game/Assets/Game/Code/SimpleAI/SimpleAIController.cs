using UnityEngine;

namespace Game.Code.SimpleAI
{
    public class SimpleAIController
    {
        private SimpleAIModel _simpleAIModel;
        private EnemyView _enemyView;

        public SimpleAIController(SimpleAIModel simpleAIModel, EnemyView enemyView)
        {
            _simpleAIModel = simpleAIModel;
            _enemyView = enemyView;
        }

        public void FixedUpdate()
        {
            var newVelocity = _simpleAIModel.CalculculeteVelocity(_enemyView._rigidbody2D.position) *
                              Time.fixedDeltaTime;
            _enemyView._rigidbody2D.velocity = newVelocity;
        }
    }
}