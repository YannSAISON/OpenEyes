using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageOutline : MonoBehaviour
{
    public AngerBar angerBar;
    // Start is called before the first frame update
    void Start()
    {
        angerBar.AddCalmEvent(Disappear);
        angerBar.AddAngryEvent(Appear);
        Disappear();
    }

    void Disappear() {
        this.gameObject.SetActive(false);
    }
    void Appear() {
        this.gameObject.SetActive(true);
    }
}
