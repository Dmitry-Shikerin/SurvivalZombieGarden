using MyProject.Sources.PresentationInterfaces.Views.Players.Animations;
using UnityEngine;

namespace MyProject.Sources.Presentation.Views.Players.Animations
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationView : MonoBehaviour, IPlayerAnimationView
    {
        private readonly int _speed = Animator.StringToHash("Speed");
        
        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMovementAnimation(float speed)
        {
            _animator.SetFloat(_speed, speed);
        }
    }
}