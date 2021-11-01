using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private FovTest fieldOfView;
    public Transform startPoint;
    public Transform endPoint;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, startPoint.position, endPoint.position, 3.0f));
            yield return StartCoroutine(MoveObject(transform, endPoint.position, startPoint.position, 3.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        fieldOfView.SetOrigin(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z));
    
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
            thisTransform.position = new Vector3(thisTransform.position.x, y, thisTransform.position.z);
            if (x < thisTransform.position.x)
                fieldOfView.baseAngle = 45f;
            else
                fieldOfView.baseAngle = 225f;
            yield return null;
        }
    }
}