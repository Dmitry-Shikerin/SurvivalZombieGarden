using System;
using UnityEngine;

namespace MyProject.Scripts.PlayerServises.PlayerMovementServices
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationControllerView : MonoBehaviour, IPlayerAnimationControllerView
    {
        //TODO стринг ту хэш
        private const string Speed = "Speed";
        
        private Animator _animator;

        // public PlayerAnimationControllerView(Animator animator)
        // {
        //     _animator = animator;
        // }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMovementAnimation(float speed)
        {
            _animator.SetFloat(Speed, speed);
        }
    }
}