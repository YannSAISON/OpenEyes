using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularSawBehavior : MonoBehaviour
{
    public bool isMoving = false;
    public Transform startPoint = null;
    public Transform endPoint = null;
    public float timeToBackAndForth = 10.0f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (startPoint == null && endPoint == null)
            isMoving = false;

        if (isMoving == true)
            while (true)
            {
                Debug.Log("Initializing move");
                yield return StartCoroutine(MoveObject(this.transform, startPoint.position, endPoint.position, timeToBackAndForth));
                yield return StartCoroutine(MoveObject(this.transform, endPoint.position, startPoint.position, timeToBackAndForth));
            }
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;

        this.transform.Rotate(Vector3.back, time * 2000);
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Debug.Log("Player Entered");
            // CALL PLAYER DEATH
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().
    }
}
