using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public int warpId;
    public SceneEnum m_scene;

    public KeyCode key;

    private Collider2D player;
    private bool isPlayerInside = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(key) && isPlayerInside)
        {
            ChangeScenePlanManager.instance.LoadScene(m_scene, warpId, player);
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
    }


}
