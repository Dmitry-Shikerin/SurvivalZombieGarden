using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.PlayerServises.InputSevice;
using MyProject.Scripts.PlayerServises.PlayerMovementCharacteristics;
using MyProject.Scripts.PlayerServises.PlayerMovementServices;
using UnityEngine;

public class PlayerMovementPresenterFactory : MonoBehaviour
{
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private PlayerMovementCharacteristic _characteristic;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private InputService _inputService;
    [SerializeField] private PlayerAnimationControllerView _playerAnimationControllerView;
    
    public PlayerMovementPresenter Create()
    {
        PlayerMovementModel playerMovementModel = new PlayerMovementModel(_characteristic, _cameraTransform);

        return new PlayerMovementPresenter
        (
            playerMovementModel,
            _playerMovementView,
            _playerTransform,
            _inputService,
            _playerAnimationControllerView
        );
    }
}
