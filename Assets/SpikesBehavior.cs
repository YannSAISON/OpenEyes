using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("Player Entered");
            // CALL PLAYER DEATH
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().
    }
}
