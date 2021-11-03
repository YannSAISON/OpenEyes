using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class VolumePanel : MonoBehaviour {
    [SerializeField] protected RectTransform rectTransform;
    private const float Speed = 0.3f;
    private bool isFaded = true;

    #region Getter

    private static VolumePanel _instance;

    public static VolumePanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<VolumePanel>();
            if (_instance == null)
                Debug.LogError("UserControlPanel not found");
            return _instance;
        }
    }

    #endregion Getter

    private void Awake() {
        name = "VolumePanel";
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(rectTransform.rect.width * -1, 0f);
    }

    public void Show(float delay = 0f) {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }

    public void Hide(int numberOfRectTransform, float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * numberOfRectTransform, 0.3f).SetDelay(delay);
    }
}
