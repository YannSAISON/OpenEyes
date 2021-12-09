using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    public int appearingLevel = 1;

    void Start()
    {
        if (FindObjectOfType<LevelManager>().Level < appearingLevel) {
            Destroy(this.gameObject);
        }
    }
}
