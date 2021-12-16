using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private FovTest fieldOfView;
    public Transform startPoint;
    public Transform endPoint;

    private bool m_FacingRight = true; // For determining which way the player is currently facing.

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
            {
                if (!m_FacingRight)
                    Flip();
                fieldOfView.baseAngle = 45f;
            }
            else
            {
                if (m_FacingRight)
                    Flip();
                fieldOfView.baseAngle = 225f;
            }
            yield return null;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        transform.localScale =  new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public bool IsPlayerSeen()
    {
        return fieldOfView.IsPlayerSeen();
    }
}