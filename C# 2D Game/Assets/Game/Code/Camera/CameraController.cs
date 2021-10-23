using UnityEngine;

namespace Game.Code.Camera
{
    public class CameraController
    {
        private CameraView _cameraView;
        public Transform _playerTransform;
        public CameraController(CameraView cameraView)
        {
            _cameraView = cameraView;
            _playerTransform = cameraView._playerTransform;
        }

        public void MoveCamera()
        {
            var player = GameObject.FindObjectOfType<PlayerView>().transform.position;
            _cameraView.transform.position = new Vector3(player.x, player.y, player.z - 10);
            Vector3 pos = Vector3.Lerp(_cameraView.transform.position, player,
                _cameraView._speedCamera * Time.deltaTime);
            _cameraView.transform.position = pos;
        }
    }
}