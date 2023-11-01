using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.PlayerServises.InputSevice;
using MyProject.Scripts.PlayerServises.PlayerCameraServices;
using UnityEngine;

public class PlayerCameraPresenterFactory : MonoBehaviour
{
    [SerializeField] private PlayerCameraView _playerCameraView;
    [SerializeField] private InputService _inputService;
    [SerializeField] private Transform _cameraTransform;
    
    public PlayerCameraPresenter Create()
    {
        PlayerCameraModel playerCameraModel = new PlayerCameraModel(_cameraTransform);

        return new PlayerCameraPresenter
        (
            playerCameraModel,
            _playerCameraView,
            _inputService
        );
    }
}