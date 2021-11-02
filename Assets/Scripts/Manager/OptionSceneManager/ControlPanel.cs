using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ControlPanel : MonoBehaviour {
    [SerializeField] private RectTransform rectTransform;

    #region Getter

    private static ControlPanel _instance;

    public static ControlPanel Instance {
        get {
            if (_instance == null)
                _instance = FindObjectOfType<ControlPanel>();
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

    public void Hide(float delay = 0f) {
        rectTransform.DOAnchorPosX(rectTransform.rect.width, 0.3f).SetDelay(delay);
    }
}
