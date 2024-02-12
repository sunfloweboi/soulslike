using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace SG{
    public class Playerinputmanager : MonoBehaviour
    {
        public static Playerinputmanager instance;
        Playercontrols playercontrols;
        [Header("player Movement Input")]
        [SerializeField] Vector2 movementinput;
        public float verticalInput;
        public float horizontalInput;
        public float moveAmount;

        [Header("Camera Input")]
        [SerializeField] Vector2 cameraInput;
        public float cameraverticalInput;
        public float camerahorizontalInput;

        

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            SceneManager.activeSceneChanged += OnSceneChange;
        }

        private void OnSceneChange(Scene oldscene, Scene newscene)
        {
            if (newscene.buildIndex == 1) // World scene
            {
                instance.enabled = true;
            }
            else if (newscene.buildIndex == 0) // Main menu
            {
                instance.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (playercontrols == null)
            {
                playercontrols = new Playercontrols();
                playercontrols.Playermovement.Movement.performed += i => movementinput = i.ReadValue<Vector2>();
                playercontrols.PlayerCam.CameraMovement.performed += i => cameraInput = i.ReadValue<Vector2>();
            }
            playercontrols.Enable();
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChange;
        }

        private void OnApplicationFocus(bool focus)
        {
            if (enabled)
            {
                if (focus)
                {
                    playercontrols.Enable();
                }
                else
                {
                    playercontrols.Disable();
                }
                
            }
        }
        private void Update()
        {
            HandleMovementInput();
            HandleCameraMovementInput();
        }
        private void HandleMovementInput()
        {
            verticalInput = movementinput.y;
            horizontalInput = movementinput.x;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            if (moveAmount<= 0.5 && moveAmount >= 0)
            {
                moveAmount = 0.5f;
            }
            else if (moveAmount > 0.5 && moveAmount < 1)
            {
                moveAmount = 1;
            }
            
            
        }
        private void HandleCameraMovementInput()
        {
            cameraverticalInput = cameraInput.y;
            camerahorizontalInput = cameraInput.x;
        }    
    }
}