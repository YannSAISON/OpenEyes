using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecessBehaviour : MonoBehaviour
{
    public KeyCode key;

    private Collider2D player;
    private bool isPlayerInside = false;
    private bool isKeyDown = false;

    private void Update()
    {
        if (Input.GetKeyDown(key) && isPlayerInside)
        {
            var playerPosition = player.attachedRigidbody.transform.position;
            var playerGO = player.gameObject;
            if (player.tag == "Player")
            {
                player.tag = "HiddenPlayer";
                playerGO.layer = LayerMask.NameToLayer("HiddenPlayer");
                playerGO.GetComponent<SpriteRenderer>().sortingOrder = -1;
                playerPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + 1);
            } else
            {
                playerGO.layer = LayerMask.NameToLayer("Player");
                playerGO.GetComponent<SpriteRenderer>().sortingOrder = 1;
                player.tag = "Player";
                playerPosition = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 1);
            }
            player.attachedRigidbody.transform.position = playerPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            player = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            player = null;
        }
        else if (other.CompareTag("HiddenPlayer"))
        {
            isPlayerInside = false;
            player.tag = "Player";
            player = null;
        }
    }
}
