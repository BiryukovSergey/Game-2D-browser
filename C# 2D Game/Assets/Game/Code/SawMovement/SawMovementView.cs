using System;
using UnityEngine;

namespace Game.Code.SawMovement
{
    public class SawMovementView : MonoBehaviour
    {
        private SawMovementController _sawMovementController;
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private SawConfig sawConfig;

        private void Start()
        {
            _sawMovementController = new SawMovementController(sawConfig);
        }

        private void FixedUpdate()
        {
            var newVelocity = _sawMovementController.SawMovement(rigidbody2D.transform.position) * Time.deltaTime;
            rigidbody2D.velocity = newVelocity;
            this.gameObject.transform.RotateAround(Vector3.forward,25);
        }
    }
}