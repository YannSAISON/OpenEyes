using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerCanvasDontDestroy : MonoBehaviour
{
    private AngerCanvasDontDestroy instance = null;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != null)
            Destroy(gameObject);
    }
}
