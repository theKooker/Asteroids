using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject player;

    public void shoot() {
        if(player != null)
        player.GetComponent<PlayerMovement>().Shoot();
    }

}
