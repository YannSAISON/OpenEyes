using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;

        this.transform.Rotate(Vector3.down, time * 200);
    }
}
