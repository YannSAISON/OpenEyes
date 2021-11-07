using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;

    private List<GameObject> objects = new List<GameObject>();

    void Update()
    {
        foreach (GameObject obj in objects)
        {
            obj.transform.position = new Vector3(obj.transform.position.x - speed, obj.transform.position.y, obj.transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        objects.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        objects.Remove(other.gameObject);
    }
}
