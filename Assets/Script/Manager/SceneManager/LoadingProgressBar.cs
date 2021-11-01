using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour {
    private Image m_Image;

    private void Awake() {
        m_Image = transform.GetComponent<Image>();
    }

    private void Update() {
        m_Image.fillAmount = GameManager.Instance.SceneManager.GetLoadingProgress();
    }
}
