using MyProject.Scripts.PlayerServises.InputSevice;
using MyProject.Scripts.PlayerServises.PlayerCameraServices;
using MyProject.Scripts.PlayerServises.PlayerMovementCharacteristics;
using MyProject.Scripts.PlayerServises.PlayerMovementServices;
using UnityEngine;

namespace MyProject.Scripts.PlayerServises
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        //TODO это не Player, а PlayerMovementService?
        //TODO по итогу когда мы разбиваем все на маленькие части у нас получается как будто бы фасад? но это не фасад.
        //TODO говоря про друвовидную систему имелось ввиду чтото типо компановщика?
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private PlayerMovementCharacteristic _characteristics;
        [SerializeField] private InputService _inputService;
        [SerializeField] private PlayerMovementView _movementView;
        [SerializeField] private PlayerCameraPresenterFactory _playerCameraPresenterFactory;
        [SerializeField] private PlayerMovementPresenterFactory _playerMovementPresenterFactory;

        
        private CharacterController _characterController;
        private Animator _animator;

        private PlayerMovementModel _playerMovementModel;
        private IPlayerMovementView _playerMovementView;
        private IPlayerAnimationControllerView _animationControllerView;
        private PlayerMovementPresenter _playerMovementPresenter;

        private PlayerCameraPresenter _playerCameraPresenter;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        
            _playerMovementPresenter = _playerMovementPresenterFactory.Create();
            
            _playerCameraPresenter = _playerCameraPresenterFactory.Create();
        }


        void Update()
        {
            _playerMovementPresenter.Move();
            _playerCameraPresenter.RotateCamera();
        }

        // private PlayerMovementPresenter CreatePlayerMovementPresenter()
        // {
        //     _playerMovementModel = new PlayerMovementModel(_characteristics, _cameraTransform);
        //     // _playerMovementView = new PlayerMovementView();
        //     // _animationControllerView = new PlayerAnimationControllerView(_animator);
        //
        //     return new PlayerMovementPresenter
        //     (
        //         _playerMovementModel,
        //         _movementView,
        //         transform,
        //         _inputService,
        //         _animationControllerView
        //     );
        // }
    }
}