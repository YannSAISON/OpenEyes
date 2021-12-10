using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSawBehavior : MonoBehaviour
{
    public bool isMoving = false;
    public Transform startPoint = null;
    public Transform endPoint = null;

    private GameObject SawBlade = null;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        SawBlade = transform.GetChild(0).gameObject;
        if (startPoint == null && endPoint == null)
        {
            Debug.Log("Not moving cause StartPoint and Endpoint are null");
            isMoving = false;
        }

        if (isMoving == true)
            while (true)
            {
                Debug.Log("Initializing move");
                yield return StartCoroutine(MoveObject(SawBlade.transform, startPoint.position, endPoint.position, 3.0f));
                yield return StartCoroutine(MoveObject(SawBlade.transform, endPoint.position, startPoint.position, 3.0f));
            }
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;

        SawBlade.transform.Rotate(Vector3.back, time * 2000);


    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            var y = thisTransform.position.y;
            var x = thisTransform.position.x;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            thisTransform.position = new Vector3(x, y, thisTransform.position.z);
            yield return null;
        }
    }


//////////          MOVE IN CHILD               /////////////////////////////
//////////          OR MOVE COLLIDER            /////////////////////////////
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("Player Entered");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("Player Exited");
    }
}
