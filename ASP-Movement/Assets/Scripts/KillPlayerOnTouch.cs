using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //HUD, sound and particle effects
            collision.gameObject.GetComponent<Respawn>().RespawnPlayer();
        }
    }
}
