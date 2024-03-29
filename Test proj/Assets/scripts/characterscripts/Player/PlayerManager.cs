using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerManager : CharacterManager
    {
        PlayerLocomotionManager playerLocomotionManager;
        protected override void Awake()
        {
            base.Awake();
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()

        {
            base.Update();
            if (!IsOwner) return;
            playerLocomotionManager.HandleAllMovement();
        }
        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            if (IsOwner)
            {
                PlayerCamera.instance.player = this;
            }
        }
        protected override void LateUpdate()
        {
            if(!IsOwner) return;
            base.LateUpdate();
            PlayerCamera.instance.HandleAllCameraActions();
        }
    }
}
