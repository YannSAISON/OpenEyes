using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingPlatform : MonoBehaviour
{
    public float radius;
    public float speed;
    public float startingAngle = 0f;
    public Transform basePoint = null;

    private float alpha;
    // Start is called before the first frame update
    void Start()
    {
        alpha = startingAngle;
        if (basePoint == null)
            basePoint = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime * speed;
        alpha %= 360;
        if (basePoint == null)
            Destroy(this.gameObject);
        this.transform.position = basePoint.position + new Vector3(Mathf.Cos(alpha * Mathf.Deg2Rad) * radius, Mathf.Sin(alpha * Mathf.Deg2Rad) * radius, this.transform.position.z);
    }
}
