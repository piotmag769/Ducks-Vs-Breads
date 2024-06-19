using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpeedUp : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerControl playerControlObject = collision.GetComponent<PlayerControl>();
        if(playerControlObject)
        {
            playerControlObject.movementSpeed =  playerControlObject.baseMovementSpeed * 1.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerControl playerControlObject = collision.GetComponent<PlayerControl>();
        if(playerControlObject)
        {
            playerControlObject.movementSpeed =  playerControlObject.baseMovementSpeed;
        }
    }
}
