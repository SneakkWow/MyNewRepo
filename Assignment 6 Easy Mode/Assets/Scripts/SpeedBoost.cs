using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;

public class SpeedBoost : PowerUp
{
    public float speedMultiplier = 2f;
    private ThirdPersonController playerController;

    public override void ApplyPowerUp(GameObject player)
    {
        playerController = player.GetComponent<ThirdPersonController>();
        if (playerController != null)
        {
            playerController.MoveSpeed *= speedMultiplier;
            StartCoroutine(PowerUpDuration(player));
        }
    }

    protected override void RemovePowerUp(GameObject player)
    {
        if (playerController != null)
        {
            playerController.MoveSpeed /= speedMultiplier;
        }
    }
}
