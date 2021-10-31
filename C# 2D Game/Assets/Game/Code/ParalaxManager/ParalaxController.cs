using UnityEngine;

namespace Game.Code.ParalaxManager
{
    public class ParalaxController
    {
        private Transform _camera;
        private Transform _backPicture;

        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;
        private Vector3 _offset;
        private const float _coef = 0.3f;

        public ParalaxController(Transform camera, Transform backPicture)
        {
            _camera = camera;
            _backPicture = backPicture;
            _offset = new Vector3(0, 3, 0);
        }

        public void Update()
        {
            _backPicture.position = _offset + _backStartPosition + (_camera.position - _cameraStartPosition) * _coef;
        }
    }
}