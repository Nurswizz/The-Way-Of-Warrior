using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    public Transform player;

   
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
