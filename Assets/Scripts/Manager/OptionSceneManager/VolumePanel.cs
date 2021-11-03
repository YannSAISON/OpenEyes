using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class VolumePanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;

    #region Getter

    static VolumePanel _instance;

    public static VolumePanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<VolumePanel>();
            if (_instance == null)
                Debug.LogError("HomeUIManager not found");
            return _instance;
        }
    }

    #endregion Getter

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0f);
    }

    public void Show(float delay = 0f) {
        rectTransform.DOAnchorPosX(0, 0.3f).SetDelay(delay);
    }
    
    public void Hide(int numberOfRectTransform, float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width * numberOfRectTransform, 0.3f).SetDelay(delay);
    }
}
