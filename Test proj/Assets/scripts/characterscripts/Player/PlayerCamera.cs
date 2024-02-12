using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;
        public PlayerManager player;
        public Camera cameraObject;
        [SerializeField] Transform cameraPivotTransform;
        [Header("Camera Settings")]
        
        private float cameraSmoothSpeed = 1;
        [SerializeField] float leftrightrotationspeed = 220;
        [SerializeField] float updownrotationspeed = 220;
        [SerializeField] float minimumpivot = -30;
        [SerializeField] float maximumpivot = 60;

        [Header("Camera values")]
        private Vector3 cameraVelocity;
        [SerializeField] float leftrightlookangle;
        [SerializeField] float updownlookangle;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        public void HandleAllCameraActions()
        {
            HandleFollowTarget();
            HandleRotation();
            //collide
        }
        private void HandleFollowTarget()
        {
            Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position, ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }

        private void HandleRotation()
        {
            leftrightlookangle += (Playerinputmanager.instance.camerahorizontalInput * leftrightrotationspeed * Time.deltaTime);
            updownlookangle -= (Playerinputmanager.instance.cameraverticalInput * updownrotationspeed * Time.deltaTime);
            updownlookangle = Mathf.Clamp(updownlookangle, minimumpivot, maximumpivot);

            Vector3 cameraRotation = Vector3.zero;
            Quaternion targetRotation;
            //rotate LR
            
            cameraRotation.y = leftrightlookangle;
            targetRotation = Quaternion.Euler(cameraRotation);
            transform.rotation = targetRotation;
            //rotate UD
            cameraRotation = Vector3.zero;
            cameraRotation.x = updownlookangle;
            targetRotation = Quaternion.Euler(cameraRotation);
            cameraPivotTransform.localRotation = targetRotation;

        }

    }
}
