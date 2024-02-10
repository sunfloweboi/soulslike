using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerLocomotionManager : CharacterLocomotionManager
    {   
        PlayerManager player;
        public float verticalMovement;
        public float horizontalMovement;
        public float moveAmount;
        private Vector3 moveDirection;
        private Vector3 targetrotationDirection;
        [SerializeField] float walkingSpeed = 2;
        [SerializeField] float runningSpeed = 5;
        [SerializeField] float rotationspeed = 10;
        protected override void Awake()
        {
            base.Awake();
            player = GetComponent<PlayerManager>();
        }
        public void HandleAllMovement()
        {
            HandleGroundedMovement();
            HandleRotation();
        }

        private void GetVerticalandHorizontalInput()
        {
            verticalMovement = Playerinputmanager.instance.verticalInput;
            horizontalMovement = Playerinputmanager.instance.horizontalInput;
           
        }
        private void HandleGroundedMovement()
        {
            GetVerticalandHorizontalInput();
            moveDirection = PlayerCamera.instance.transform.forward * verticalMovement;
            moveDirection += PlayerCamera.instance.transform.right * horizontalMovement;
            moveDirection.Normalize();
            moveDirection.y = 0;

            if (Playerinputmanager.instance.moveAmount > 0.5f)
            {
                player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
            }
            else if (Playerinputmanager.instance.moveAmount <= 0.5f)
            {
                player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
            }
           
        }

        private void HandleRotation()
        {
            Vector3 targetrotationDirection = Vector3.zero;
            targetrotationDirection = PlayerCamera.instance.cameraObject.transform.forward * verticalMovement;
            targetrotationDirection += PlayerCamera.instance.cameraObject.transform.right * horizontalMovement;
            targetrotationDirection.Normalize();
            targetrotationDirection.y = 0;

            if (targetrotationDirection == Vector3.zero)
            {
                targetrotationDirection = transform.forward;
            }

            Quaternion newRotation = Quaternion.LookRotation(targetrotationDirection);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationspeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
    }
}

