using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{
    private bool touched = false;
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player" && !touched) {
            touched = true;
            FindObjectOfType<LevelManager>().NextLevel();
        }
    }
}
