using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageOutline : MonoBehaviour
{
    public AngerBar angerBar;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        angerBar.AddCalmEvent(FullDisappear);
        angerBar.AddChangeEvent(ChangeAppear);
        angerBar.AddAngryEvent(FullAppear);
        FullDisappear();
    }

    void FullDisappear() {
        image.material.SetFloat("CurrentAlpha", 0);
    }
    void ChangeAppear(float alpha) {
        image.material.SetFloat("CurrentAlpha", alpha);
    }
    void FullAppear() {
        image.material.SetFloat("CurrentAlpha", 1);
    }
}
