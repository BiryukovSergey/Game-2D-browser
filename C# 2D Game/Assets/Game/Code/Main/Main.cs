using UnityEngine;
using Game;

public class Main : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    private InputManager _inputManager;
    private AnimationController _animationController;

    private void Start()
    {
        _inputManager = new InputManager();
        _animationController = new AnimationController(_inputManager, _playerView);
    }

    private void Update()
    {
        _inputManager.Execute();
        _animationController.Update();
    }
}
