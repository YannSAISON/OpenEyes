using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingPlatformGroup : MonoBehaviour
{
    public int nbPlatforms = 1;
    public float radius = 2f;
    public float speed = 50f;
    public GameObject platformPrefab;
    private List<GameObject> platforms = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nbPlatforms; i++)
        {
            Debug.Log("Adding a platform");
            GameObject platform = Instantiate(platformPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            platform.GetComponent<CirclingPlatform>().radius = radius;
            platform.GetComponent<CirclingPlatform>().startingAngle = 360/nbPlatforms * (i - 1);
            platform.GetComponent<CirclingPlatform>().speed = speed;
            platform.GetComponent<CirclingPlatform>().basePoint = this.transform;
            platforms.Add(platform);
        }

    }
}
